/*
 * Copyright 2016 Game Server Services, Inc. or its affiliates. All Rights
 * Reserved.
 *
 * Licensed under the Apache License, Version 2.0(the "License").
 * You may not use this file except in compliance with the License.
 * A copy of the License is located at
 *
 *  http://www.apache.org/licenses/LICENSE-2.0
 *
 * or in the "license" file accompanying this file. This file is distributed
 * on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either
 * express or implied. See the License for the specific language governing
 * permissions and limitations under the License.
 */


using System;
using System.Collections;
using Gs2.Core;
using Gs2.Core.Domain;
using Gs2.Core.Exception;
using Gs2.Core.Model;
using Gs2.Core.Net;
using Gs2.Core.Result;
using Gs2.Gs2Auth.Model;
using UnityEngine.Events;
#if GS2_ENABLE_UNITASK
using Cysharp.Threading.Tasks;
#endif

namespace Gs2.Unity.Util
{
    public class Profile
    {
        private readonly IReopener _reopener;
        private IAuthenticator _authenticator;

        public Profile(
            string clientId,
            string clientSecret,
            IReopener reopener,
            Region region = Region.ApNortheast1,
            bool checkCertificateRevocation = true
        )
        {
            BasicGs2Credential credential = new BasicGs2Credential(
                clientId,
                clientSecret
            );
            Gs2Session = new Gs2WebSocketSession(
                credential,
                region,
                checkCertificateRevocation
            );
            Gs2RestSession = new Gs2RestSession(
                credential,
                region,
                checkCertificateRevocation
            );
            _reopener = reopener;
            _authenticator = null;
            this.checkRevokeCertificate = checkCertificateRevocation;
        }

#if GS2_ENABLE_UNITASK

        public async UniTask InitializeAsync()
        {
            await _reopener.ReOpenAsync(
                Gs2Session,
                Gs2RestSession
            );
        }

#endif

        public Gs2Future Initialize()
        {
            IEnumerator Impl(Gs2Future self)
            {
                yield return _reopener.ReOpen(
                    Gs2Session,
                    Gs2RestSession,
                    r => {
                        if (r.Error != null)
                        {
                            self.OnError(r.Error);
                        }
                        else
                        {
                            self.OnComplete(null);
                        }
                    }
                );
            }

            return new Gs2InlineFuture(Impl);
        }
        
        public IEnumerator Initialize(
            UnityAction<AsyncResult<object>> callback
        )
        {
            var future = Initialize();
            yield return future;
            callback.Invoke(new AsyncResult<object>(future.Result, future.Error));
        }

#if GS2_ENABLE_UNITASK
        public async UniTask FinalizeAsync()
        {
            await Gs2Session.CloseAsync();
            await Gs2RestSession.CloseAsync();
        }
#endif

        public void UpdateProjectToken(string projectToken)
        {
            Gs2Session.Credential.ProjectToken = projectToken;
            Gs2RestSession.Credential.ProjectToken = projectToken;
        }

        public IEnumerator Finalize()
        {
            yield return Gs2Session.Close(() => {});
            yield return Gs2RestSession.Close(() => {});
        }

#if GS2_ENABLE_UNITASK
        public async UniTask<GameSession> LoginAsync(
            IAuthenticator authenticator
        )
        {
            _authenticator = authenticator;
            var accessToken = await authenticator.AuthenticationAsync();
            return new GameSession(
                accessToken
            );
        }
#endif

        public Gs2Future<GameSession> LoginFuture(
            IAuthenticator authenticator
        )
        {
            _authenticator = authenticator;
            
            IEnumerator Impl(Gs2Future<GameSession> self)
            {
                yield return authenticator.Authentication(
                    r =>
                    {
                        if (r.Error != null)
                        {
                            self.OnError(r.Error);
                        }
                        else
                        {
                            self.OnComplete(new GameSession(r.Result));
                        }
                    }
                );
            }
            return new Gs2InlineFuture<GameSession>(Impl);
        }

        public IEnumerator Login(
            IAuthenticator authenticator,
            UnityAction<AsyncResult<GameSession>> callback
        )
        {
            _authenticator = authenticator;

            yield return authenticator.Authentication(
                r =>
                {
                    if (r.Error != null)
                    {
                        callback.Invoke(
                            new AsyncResult<GameSession>(
                                null,
                                r.Error
                            )
                        );
                    }
                    else
                    {
                        callback.Invoke(
                            new AsyncResult<GameSession>(
                                new GameSession(
                                    r.Result
                                ),
                                r.Error
                            )
                        );
                    }
                }
            );
        }

#if GS2_ENABLE_UNITASK

        public async UniTask<T> RunAsync<T>(
            AccessToken accessToken,
            Func<UniTask<T>> requestActionAsync)
        {
            bool isReopenTried = false;
            bool isAuthenticationTried = false;

            while (true)
            {
                try
                {
                    return await requestActionAsync.Invoke();
                }
                catch (UnauthorizedException)
                {
                    var authenticator = _authenticator;
                    if (accessToken != null && authenticator != null && !isAuthenticationTried)
                    {
                        isAuthenticationTried = true;

                        var asyncAuthenticationResult = await authenticator.AuthenticationAsync();

                        if (asyncAuthenticationResult != null)
                        {
                            accessToken.Token = asyncAuthenticationResult.Token;
                            accessToken.UserId = asyncAuthenticationResult.UserId;
                            accessToken.Expire = asyncAuthenticationResult.Expire;
                            continue;
                        }
                    }
                    else
                    {
                        throw;
                    }
                }
                catch (SessionNotOpenException)
                {
                    if (_reopener != null && !isReopenTried)
                    {
                        isReopenTried = true;

                        var asyncOpenResult = await _reopener.ReOpenAsync(Gs2Session, Gs2RestSession);

                        if (asyncOpenResult != null)
                        {
                            continue;
                        }
                    }
                    else
                    {
                        throw;
                    }
                }

                break;
            }

            return default(T);
        }

        public async UniTask<bool> RunIteratorAsync(
            AccessToken accessToken,
            Func<UniTask<bool>> requestActionAsync,
            RetryIterator retryIterator)
        {
            bool isReopenTried = false;
            bool isAuthenticationTried = false;

            while (true)
            {
                try
                {
                    return await requestActionAsync.Invoke();
                }
                catch (UnauthorizedException)
                {
                    var authenticator = _authenticator;
                    if (accessToken != null && authenticator != null && !isAuthenticationTried)
                    {
                        isAuthenticationTried = true;

                        var asyncAuthenticationResult = await authenticator.AuthenticationAsync();

                        if (asyncAuthenticationResult != null)
                        {
                            accessToken.Token = asyncAuthenticationResult.Token;
                            accessToken.UserId = asyncAuthenticationResult.UserId;
                            accessToken.Expire = asyncAuthenticationResult.Expire;
                            
                            retryIterator?.Invoke();
                            
                            continue;
                        }
                    }
                    else
                    {
                        throw;
                    }
                }
                catch (SessionNotOpenException)
                {
                    if (_reopener != null && !isReopenTried)
                    {
                        isReopenTried = true;

                        var asyncOpenResult = await _reopener.ReOpenAsync(Gs2Session, Gs2RestSession);

                        if (asyncOpenResult != null)
                        {
                            retryIterator?.Invoke();
                            
                            continue;
                        }
                    }
                    else
                    {
                        throw;
                    }
                }

                break;
            }

            return false;
        }
#else

        public delegate IFuture<T> RetryAction<T>();
        
        public IEnumerator RunFuture<T>(
            AccessToken accessToken,
            IFuture<T> requestFuture,
            RetryAction<T> retryAction)
        {
            bool isReopenTried = false;
            bool isAuthenticationTried = false;

            while (true)
            {
                yield return requestFuture;
                
                if (requestFuture.Error is SessionNotOpenException && !isReopenTried)
                {
                    isReopenTried = true;

                    AsyncResult<OpenResult> asyncOpenResult = null;

                    yield return _reopener.ReOpen(Gs2Session, Gs2RestSession, aor => asyncOpenResult = aor);

                    _reopener.Callback?.Invoke(asyncOpenResult);

                    if (asyncOpenResult.Error == null)
                    {
                        requestFuture = retryAction.Invoke();
                        
                        continue;
                    }
                }

                var authenticator = _authenticator;
                if (accessToken != null && authenticator != null && requestFuture.Error is UnauthorizedException && !isAuthenticationTried)
                {
                    isAuthenticationTried = true;

                    AsyncResult<AccessToken> asyncAuthenticationResult = null;

                    yield return authenticator.Authentication(aar => asyncAuthenticationResult = aar);

                    if (asyncAuthenticationResult.Error == null)
                    {
                        accessToken.Token = asyncAuthenticationResult.Result.Token;
                        accessToken.UserId = asyncAuthenticationResult.Result.UserId;
                        accessToken.Expire = asyncAuthenticationResult.Result.Expire;
                    }

                    authenticator.Callback?.Invoke(asyncAuthenticationResult);

                    if (asyncAuthenticationResult.Error == null)
                    {
                        requestFuture = retryAction.Invoke();
                        
                        continue;
                    }
                }

                break;
            }
        }

#endif
        public delegate void RetryIterator();

        public IEnumerator RunIterator<T>(
            AccessToken accessToken,
            Gs2Iterator<T> requestIterator,
            RetryIterator retryIterator)
        {
            bool isReopenTried = false;
            bool isAuthenticationTried = false;

            while (true)
            {
                yield return requestIterator.Next();

                if (requestIterator.Error is SessionNotOpenException && !isReopenTried)
                {
                    isReopenTried = true;

                    AsyncResult<OpenResult> asyncOpenResult = null;

                    yield return _reopener.ReOpen(Gs2Session, Gs2RestSession, aor => asyncOpenResult = aor);

                    _reopener.Callback?.Invoke(asyncOpenResult);

                    if (asyncOpenResult.Error == null)
                    {
                        retryIterator?.Invoke();
                        
                        continue;
                    }
                }

                var authenticator = _authenticator;
                if (accessToken != null && authenticator != null && requestIterator.Error is UnauthorizedException && !isAuthenticationTried)
                {
                    isAuthenticationTried = true;

                    AsyncResult<AccessToken> asyncAuthenticationResult = null;

                    yield return authenticator.Authentication(aar => asyncAuthenticationResult = aar);

                    if (asyncAuthenticationResult.Error == null)
                    {
                        accessToken.Token = asyncAuthenticationResult.Result.Token;
                        accessToken.UserId = asyncAuthenticationResult.Result.UserId;
                        accessToken.Expire = asyncAuthenticationResult.Result.Expire;
                    }

                    authenticator.Callback?.Invoke(asyncAuthenticationResult);

                    if (asyncAuthenticationResult.Error == null)
                    {
                        retryIterator?.Invoke();
                        
                        continue;
                    }
                }

                break;
            }
        }

        public delegate IEnumerator RequestAction<T>(UnityAction<AsyncResult<T>> callback);
        
        public IEnumerator Run<T>(
            UnityAction<AsyncResult<T>> callback,
            GameSession gameSession,
            RequestAction<T> requestAction)
        {
            bool isReopenTried = false;
            bool isAuthenticationTried = false;

            AsyncResult<T> asyncResult = null;

            while (true)
            {
                yield return requestAction.Invoke(ar => asyncResult = ar);

                if (asyncResult.Error is SessionNotOpenException && !isReopenTried)
                {
                    isReopenTried = true;

                    AsyncResult<OpenResult> asyncOpenResult = null;

                    yield return _reopener.ReOpen(Gs2Session, Gs2RestSession, aor => asyncOpenResult = aor);

                    _reopener.Callback?.Invoke(asyncOpenResult);

                    if (asyncOpenResult.Error == null)
                    {
                        continue;
                    }
                }

                var authenticator = _authenticator;
                if (gameSession != null && authenticator != null && asyncResult.Error is UnauthorizedException && !isAuthenticationTried)
                {
                    isAuthenticationTried = true;

                    AsyncResult<AccessToken> asyncAuthenticationResult = null;

                    yield return authenticator.Authentication(aar => asyncAuthenticationResult = aar);

                    if (asyncAuthenticationResult.Error == null)
                    {
                        gameSession.AccessToken = asyncAuthenticationResult.Result;
                    }

                    authenticator.Callback?.Invoke(asyncAuthenticationResult);

                    if (asyncAuthenticationResult.Error == null)
                    {
                        continue;
                    }
                }

                break;
            }
            
            callback.Invoke(asyncResult);
        }
        
        public Gs2WebSocketSession Gs2Session { get; }
        public Gs2RestSession Gs2RestSession { get; }

        public bool checkRevokeCertificate { get; }
    }
}