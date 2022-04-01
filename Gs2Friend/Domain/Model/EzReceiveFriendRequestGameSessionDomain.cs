/*
 * Copyright 2016 Game Server Services, Inc. or its affiliates. All Rights
 * Reserved.
 *
 * Licensed under the Apache License, Version 2.0 (the "License").
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
// ReSharper disable RedundantNameQualifier
// ReSharper disable RedundantUsingDirective
// ReSharper disable CheckNamespace
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable UseObjectOrCollectionInitializer
// ReSharper disable ArrangeThisQualifier
// ReSharper disable NotAccessedField.Local

#pragma warning disable 1998

using System;
using System.Linq;
using System.Text.RegularExpressions;
using Gs2.Core.Model;
using Gs2.Core.Net;
using Gs2.Gs2Friend.Domain.Iterator;
using Gs2.Gs2Friend.Request;
using Gs2.Gs2Friend.Result;
using Gs2.Gs2Auth.Model;
using Gs2.Util.LitJson;
using Gs2.Core;
using Gs2.Core.Domain;
using Gs2.Core.Util;
using UnityEngine.Scripting;
using System.Collections;
#if GS2_ENABLE_UNITASK
using Cysharp.Threading;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.Linq;
using System.Collections.Generic;
#endif

namespace Gs2.Unity.Gs2Friend.Domain.Model
{

    public partial class EzReceiveFriendRequestGameSessionDomain {
        private readonly Gs2.Gs2Friend.Domain.Model.ReceiveFriendRequestAccessTokenDomain _domain;
        public string NamespaceName => _domain?.NamespaceName;
        public string UserId => _domain?.UserId;
        public string FromUserId => _domain?.FromUserId;

        public EzReceiveFriendRequestGameSessionDomain(
            Gs2.Gs2Friend.Domain.Model.ReceiveFriendRequestAccessTokenDomain domain
        ) {
            this._domain = domain;
        }

        #if GS2_ENABLE_UNITASK
        public IFuture<Gs2.Unity.Gs2Friend.Domain.Model.EzFriendRequestGameSessionDomain> Accept(
        )
        {
            IEnumerator Impl(Gs2Future<Gs2.Unity.Gs2Friend.Domain.Model.EzFriendRequestGameSessionDomain> self)
            {
                yield return AcceptAsync(
                ).ToCoroutine(
                    self.OnComplete,
                    e => self.OnError((Gs2.Core.Exception.Gs2Exception)e)
                );
            }
            return new Gs2InlineFuture<Gs2.Unity.Gs2Friend.Domain.Model.EzFriendRequestGameSessionDomain>(Impl);
        }

        public async UniTask<Gs2.Unity.Gs2Friend.Domain.Model.EzFriendRequestGameSessionDomain> AcceptAsync(
        #else
        public IFuture<Gs2.Unity.Gs2Friend.Domain.Model.EzFriendRequestGameSessionDomain> Accept(
        #endif
        ) {
        #if GS2_ENABLE_UNITASK
            var result = await _domain.AcceptAsync(
                new AcceptRequestRequest()
            );
            return new Gs2.Unity.Gs2Friend.Domain.Model.EzFriendRequestGameSessionDomain(result);
        #else
            IEnumerator Impl(Gs2Future<Gs2.Unity.Gs2Friend.Domain.Model.EzFriendRequestGameSessionDomain> self)
            {
                var future = _domain.Accept(
                    new AcceptRequestRequest()
                );
                yield return future;
                if (future.Error != null)
                {
                    self.OnError(future.Error);
                    yield break;
                }
                var result = future.Result;
                self.OnComplete(new Gs2.Unity.Gs2Friend.Domain.Model.EzFriendRequestGameSessionDomain(result));
            }
            return new Gs2InlineFuture<Gs2.Unity.Gs2Friend.Domain.Model.EzFriendRequestGameSessionDomain>(Impl);
        #endif
        }

        #if GS2_ENABLE_UNITASK
        public IFuture<Gs2.Unity.Gs2Friend.Domain.Model.EzFriendRequestGameSessionDomain> Reject(
        )
        {
            IEnumerator Impl(Gs2Future<Gs2.Unity.Gs2Friend.Domain.Model.EzFriendRequestGameSessionDomain> self)
            {
                yield return RejectAsync(
                ).ToCoroutine(
                    self.OnComplete,
                    e => self.OnError((Gs2.Core.Exception.Gs2Exception)e)
                );
            }
            return new Gs2InlineFuture<Gs2.Unity.Gs2Friend.Domain.Model.EzFriendRequestGameSessionDomain>(Impl);
        }

        public async UniTask<Gs2.Unity.Gs2Friend.Domain.Model.EzFriendRequestGameSessionDomain> RejectAsync(
        #else
        public IFuture<Gs2.Unity.Gs2Friend.Domain.Model.EzFriendRequestGameSessionDomain> Reject(
        #endif
        ) {
        #if GS2_ENABLE_UNITASK
            var result = await _domain.RejectAsync(
                new RejectRequestRequest()
            );
            return new Gs2.Unity.Gs2Friend.Domain.Model.EzFriendRequestGameSessionDomain(result);
        #else
            IEnumerator Impl(Gs2Future<Gs2.Unity.Gs2Friend.Domain.Model.EzFriendRequestGameSessionDomain> self)
            {
                var future = _domain.Reject(
                    new RejectRequestRequest()
                );
                yield return future;
                if (future.Error != null)
                {
                    self.OnError(future.Error);
                    yield break;
                }
                var result = future.Result;
                self.OnComplete(new Gs2.Unity.Gs2Friend.Domain.Model.EzFriendRequestGameSessionDomain(result));
            }
            return new Gs2InlineFuture<Gs2.Unity.Gs2Friend.Domain.Model.EzFriendRequestGameSessionDomain>(Impl);
        #endif
        }

    }
}
