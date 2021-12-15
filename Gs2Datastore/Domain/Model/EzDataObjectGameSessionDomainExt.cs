using System.Collections;
using System.Collections.Generic;
#if GS2_ENABLE_UNITASK
using Cysharp.Threading.Tasks;
#endif
using Gs2.Core;
using Gs2.Core.Domain;
using Gs2.Gs2Datastore.Request;
using Gs2.Unity.Gs2Datastore.Model;
using Gs2.Unity.Gs2Datastore.Result;
using UnityEngine.Events;

namespace Gs2.Unity.Gs2Datastore.Domain.Model
{

    public partial class EzDataObjectGameSessionDomain {

#if GS2_ENABLE_UNITASK
        public async UniTask<byte[]> DownloadAsync(
#else
        public Gs2Future<byte[]> Download(
#endif
        )
        {
#if GS2_ENABLE_UNITASK
            return await _domain.Download();
#else

            IEnumerator Impl(Gs2Future<byte[]> self)
            {
                var future = _domain.Download(
                );
                yield return future;
                if (future.Error != null)
                {
                    self.OnError(future.Error);
                    yield break;
                }
                self.OnComplete(future.Result);
            }
            return new Gs2InlineFuture<byte[]>(Impl);
#endif
        }
        
#if GS2_ENABLE_UNITASK
        public async UniTask<Gs2.Unity.Gs2Datastore.Domain.Model.EzDataObjectGameSessionDomain> ReUploadAsync(
#else
        public Gs2Future<Gs2.Gs2Datastore.Domain.Model.DataObjectAccessTokenDomain> ReUpload(
#endif
            byte[] data
        )
        {
#if GS2_ENABLE_UNITASK
            return new Gs2.Unity.Gs2Datastore.Domain.Model.EzDataObjectGameSessionDomain(
                await _domain.ReUpload(data)
            );
#else

            IEnumerator Impl(Gs2Future<Gs2.Gs2Datastore.Domain.Model.DataObjectAccessTokenDomain> self)
            {
                var future = _domain.ReUpload(
                    data
                );
                yield return future;
                if (future.Error != null)
                {
                    self.OnError(future.Error);
                    yield break;
                }
                self.OnComplete(future.Result);
            }
            return new Gs2InlineFuture<Gs2.Gs2Datastore.Domain.Model.DataObjectAccessTokenDomain>(Impl);
#endif
        }

    }
}