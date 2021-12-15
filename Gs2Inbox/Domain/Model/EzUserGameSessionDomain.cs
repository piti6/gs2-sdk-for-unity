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
using Gs2.Gs2Inbox.Domain.Iterator;
using Gs2.Gs2Inbox.Request;
using Gs2.Gs2Inbox.Result;
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

namespace Gs2.Unity.Gs2Inbox.Domain.Model
{

    public partial class EzUserGameSessionDomain {
        private readonly Gs2.Gs2Inbox.Domain.Model.UserAccessTokenDomain _domain;
        public string NextPageToken => _domain.NextPageToken;
        public string NamespaceName => _domain?.NamespaceName;
        public string UserId => _domain?.UserId;

        public EzUserGameSessionDomain(
            Gs2.Gs2Inbox.Domain.Model.UserAccessTokenDomain domain
        ) {
            this._domain = domain;
        }

        #if GS2_ENABLE_UNITASK
        public async UniTask<Gs2.Unity.Gs2Inbox.Domain.Model.EzMessageGameSessionDomain[]> ReceiveGlobalMessageAsync(
        #else
        public IFuture<Gs2.Unity.Gs2Inbox.Domain.Model.EzMessageGameSessionDomain[]> ReceiveGlobalMessage(
        #endif
        ) {
        #if GS2_ENABLE_UNITASK
            var result = await _domain.ReceiveGlobalMessageAsync(
                new ReceiveGlobalMessageRequest()
            );
            return result.Select(v => new Gs2.Unity.Gs2Inbox.Domain.Model.EzMessageGameSessionDomain(v)).ToArray();
        #else
            IEnumerator Impl(Gs2Future<Gs2.Unity.Gs2Inbox.Domain.Model.EzMessageGameSessionDomain[]> self)
            {
                var future = _domain.ReceiveGlobalMessage(
                    new ReceiveGlobalMessageRequest()
                );
                yield return future;
                if (future.Error != null)
                {
                    self.OnError(future.Error);
                    yield break;
                }
                var result = future.Result;
                self.OnComplete(result.Select(v => new Gs2.Unity.Gs2Inbox.Domain.Model.EzMessageGameSessionDomain(v)).ToArray());
            }
            return new Gs2InlineFuture<Gs2.Unity.Gs2Inbox.Domain.Model.EzMessageGameSessionDomain[]>(Impl);
        #endif
        }

        #if GS2_ENABLE_UNITASK
        public IUniTaskAsyncEnumerable<Gs2.Unity.Gs2Inbox.Model.EzMessage> Messages(
        #else
        public class EzMessagesIterator : Gs2Iterator<Gs2.Unity.Gs2Inbox.Model.EzMessage>
        {
            private readonly Gs2Iterator<Gs2.Gs2Inbox.Model.Message> _it;

            public EzMessagesIterator(
                Gs2Iterator<Gs2.Gs2Inbox.Model.Message> it
            )
            {
                _it = it;
            }

            public override bool HasNext()
            {
                return _it.HasNext();
            }

            protected override IEnumerator Next(Action<Gs2.Unity.Gs2Inbox.Model.EzMessage> callback)
            {
                yield return _it.Next();
                callback.Invoke(Gs2.Unity.Gs2Inbox.Model.EzMessage.FromModel(_it.Current));
            }
        }

        public Gs2Iterator<Gs2.Unity.Gs2Inbox.Model.EzMessage> Messages(
        #endif
        )
        {
        #if GS2_ENABLE_UNITASK
            return UniTaskAsyncEnumerable.Create<Gs2.Unity.Gs2Inbox.Model.EzMessage>(async (writer, token) =>
            {
                var it = _domain.Messages(
                ).GetAsyncEnumerator();
                while(await it.MoveNextAsync())
                {
                    await writer.YieldAsync(Gs2.Unity.Gs2Inbox.Model.EzMessage.FromModel(it.Current));
                }
            });
        #else
            return new EzMessagesIterator(_domain.Messages(
            ));
        #endif
        }

        public Gs2.Unity.Gs2Inbox.Domain.Model.EzMessageGameSessionDomain Message(
            string messageName
        ) {
            return new Gs2.Unity.Gs2Inbox.Domain.Model.EzMessageGameSessionDomain(
                _domain.Message(
                    messageName
                )
            );
        }

    }
}