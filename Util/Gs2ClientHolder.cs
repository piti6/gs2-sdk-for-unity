using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Gs2.Core.Exception;
using Gs2.Core.Model;
#if GS2_ENABLE_UNITASK
using Cysharp.Threading.Tasks;
#endif
using Gs2.Unity.Core;
using Gs2.Unity.Core.Exception;
using Gs2.Unity.Core.ScriptableObject;
using Gs2.Unity.Gs2Version.Model;
using Gs2.Unity.Util;
using Gs2.Util.LitJson;
using UnityEngine;
using UnityEngine.Events;

namespace Gs2.Unity.Util
{
    [AddComponentMenu("GS2/Core/Gs2ClientHolder")]
    public class Gs2ClientHolder : MonoBehaviour
    {
        private Profile _profile;
        public Profile Profile => _profile;
        
        public Gs2Domain Gs2 { get; private set; }
        public bool Initialized => Gs2 != null;
        
        public string activeEnvironmentName;
        public List<Gs2Environment> environments;
        public Gs2.Unity.Gs2Distributor.ScriptableObject.Namespace distributorNamespace;

        [Serializable]
        private class InitializedEvent : UnityEvent
        {
            
        }
        
        [SerializeField]
        private InitializedEvent onInitialized = new InitializedEvent();
        
        public event UnityAction OnInitialized
        {
            add => onInitialized.AddListener(value);
            remove => onInitialized.RemoveListener(value);
        }
        
        [SerializeField]
        internal ErrorEvent onError = new ErrorEvent();
        
        public event UnityAction<Gs2Exception, Func<IEnumerator>> OnError
        {
            add => onError.AddListener(value);
            remove => onError.RemoveListener(value);
        }

        protected internal static Gs2ClientHolder _instance;
        
        public static Gs2ClientHolder Instance
        {
            get
            {
                if (_instance == null)
                {
                    var clientHolders = GameObject.FindObjectsOfType<Gs2ClientHolder>();
                    if (clientHolders.Length > 0)
                    {
                        return clientHolders[0];
                    }

                    _instance = new GameObject("Gs2ClientHolder").AddComponent<Gs2ClientHolder>();
                }
                return _instance;
            }
        }

        public void Awake()
        {
            var items = FindObjectsOfType<Gs2ClientHolder>();
            foreach (var item in items)
            {
                if (item != this)
                {
                    DestroyImmediate(this.gameObject);
                }
            }
        }

        public IEnumerator Start() {
            var environment = environments.FirstOrDefault(
                v => v.name == this.activeEnvironmentName
            );
            if (environment == null) {
                onError.Invoke(new CanIgnoreException(
                    new UnknownException(new [] {
                        new RequestError(
                            "environment",
                            "prefab.GS2ClientHolder.activeEnvironmentName.error.notFound"
                        )
                    })
                ), null);
                yield break;
            }
            _profile = new Profile(
                environment.clientId,
                environment.clientSecret,
                new Gs2BasicReopener(),
                environment.region,
                distributorNamespace == null ? null : distributorNamespace.NamespaceName
            );
            var initializeFuture = _profile.InitializeFuture();
            yield return initializeFuture;
            if (initializeFuture.Error != null)
            {
                onError.Invoke(initializeFuture.Error, null);
                yield break;
            }
            
            Gs2 = initializeFuture.Result;

            onInitialized.Invoke();
        }
        
#if GS2_ENABLE_UNITASK
        public async UniTask StartAsync()
        {
            var environment = environments.FirstOrDefault(
                v => v.name == this.activeEnvironmentName
            );
            if (environment == null) {
                onError.Invoke(new CanIgnoreException(
                    new UnknownException(new [] {
                        new RequestError(
                            "environment",
                            "prefab.GS2ClientHolder.activeEnvironmentName.error.notFound"
                        )
                    })
                ), null);
                return;
            }
            _profile = new Profile(
                environment.clientId,
                environment.clientSecret,
                new Gs2BasicReopener(),
                environment.region
            );
            await _profile.InitializeAsync();
            
            Gs2 = new Gs2Domain(
                _profile,
                distributorNamespace.namespaceName
            );
            
            onInitialized.Invoke();
        }
#endif

        public void DebugErrorHandler(Gs2Exception e, Func<IEnumerator> retry) {
            if (e is CanIgnoreException) {
                return;
            }
            Debug.LogError($"{e.GetType()} {string.Join(",", e.Errors.Select(v => v.Message))} : Retryable={retry != null}");
        }
    }
}