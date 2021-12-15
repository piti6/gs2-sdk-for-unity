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
using Gs2.Gs2Account.Domain.Iterator;
using Gs2.Gs2Account.Request;
using Gs2.Gs2Account.Result;
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

namespace Gs2.Unity.Gs2Account.Domain.Model
{

    public partial class EzNamespaceDomain {
        private readonly Gs2.Gs2Account.Domain.Model.NamespaceDomain _domain;
        public string Status => _domain.Status;
        public string NextPageToken => _domain.NextPageToken;
        public string NamespaceName => _domain?.NamespaceName;

        public EzNamespaceDomain(
            Gs2.Gs2Account.Domain.Model.NamespaceDomain domain
        ) {
            this._domain = domain;
        }

        #if GS2_ENABLE_UNITASK
        public async UniTask<Gs2.Unity.Gs2Account.Domain.Model.EzAccountDomain> CreateAsync(
        #else
        public IFuture<Gs2.Unity.Gs2Account.Domain.Model.EzAccountDomain> Create(
        #endif
        ) {
        #if GS2_ENABLE_UNITASK
            var result = await _domain.CreateAccountAsync(
                new CreateAccountRequest()
            );
            return new Gs2.Unity.Gs2Account.Domain.Model.EzAccountDomain(result);
        #else
            IEnumerator Impl(Gs2Future<Gs2.Unity.Gs2Account.Domain.Model.EzAccountDomain> self)
            {
                var future = _domain.CreateAccount(
                    new CreateAccountRequest()
                );
                yield return future;
                if (future.Error != null)
                {
                    self.OnError(future.Error);
                    yield break;
                }
                var result = future.Result;
                self.OnComplete(new Gs2.Unity.Gs2Account.Domain.Model.EzAccountDomain(result));
            }
            return new Gs2InlineFuture<Gs2.Unity.Gs2Account.Domain.Model.EzAccountDomain>(Impl);
        #endif
        }

        #if GS2_ENABLE_UNITASK
        public async UniTask<Gs2.Unity.Gs2Account.Domain.Model.EzAccountDomain> DoTakeOverAsync(
        #else
        public IFuture<Gs2.Unity.Gs2Account.Domain.Model.EzAccountDomain> DoTakeOver(
        #endif
              int type,
              string userIdentifier,
              string password
        ) {
        #if GS2_ENABLE_UNITASK
            var result = await _domain.DoTakeOverAsync(
                new DoTakeOverRequest()
                    .WithType(type)
                    .WithUserIdentifier(userIdentifier)
                    .WithPassword(password)
            );
            return new Gs2.Unity.Gs2Account.Domain.Model.EzAccountDomain(result);
        #else
            IEnumerator Impl(Gs2Future<Gs2.Unity.Gs2Account.Domain.Model.EzAccountDomain> self)
            {
                var future = _domain.DoTakeOver(
                    new DoTakeOverRequest()
                        .WithType(type)
                        .WithUserIdentifier(userIdentifier)
                        .WithPassword(password)
                );
                yield return future;
                if (future.Error != null)
                {
                    self.OnError(future.Error);
                    yield break;
                }
                var result = future.Result;
                self.OnComplete(new Gs2.Unity.Gs2Account.Domain.Model.EzAccountDomain(result));
            }
            return new Gs2InlineFuture<Gs2.Unity.Gs2Account.Domain.Model.EzAccountDomain>(Impl);
        #endif
        }

        #if GS2_ENABLE_UNITASK
        public IUniTaskAsyncEnumerable<Gs2.Unity.Gs2Account.Model.EzAccount> Accounts(
        #else
        public class EzAccountsIterator : Gs2Iterator<Gs2.Unity.Gs2Account.Model.EzAccount>
        {
            private readonly Gs2Iterator<Gs2.Gs2Account.Model.Account> _it;

            public EzAccountsIterator(
                Gs2Iterator<Gs2.Gs2Account.Model.Account> it
            )
            {
                _it = it;
            }

            public override bool HasNext()
            {
                return _it.HasNext();
            }

            protected override IEnumerator Next(Action<Gs2.Unity.Gs2Account.Model.EzAccount> callback)
            {
                yield return _it.Next();
                callback.Invoke(Gs2.Unity.Gs2Account.Model.EzAccount.FromModel(_it.Current));
            }
        }

        public Gs2Iterator<Gs2.Unity.Gs2Account.Model.EzAccount> Accounts(
        #endif
        )
        {
        #if GS2_ENABLE_UNITASK
            return UniTaskAsyncEnumerable.Create<Gs2.Unity.Gs2Account.Model.EzAccount>(async (writer, token) =>
            {
                var it = _domain.Accounts(
                ).GetAsyncEnumerator();
                while(await it.MoveNextAsync())
                {
                    await writer.YieldAsync(Gs2.Unity.Gs2Account.Model.EzAccount.FromModel(it.Current));
                }
            });
        #else
            return new EzAccountsIterator(_domain.Accounts(
            ));
        #endif
        }

        public Gs2.Unity.Gs2Account.Domain.Model.EzAccountDomain Account(
            string userId
        ) {
            return new Gs2.Unity.Gs2Account.Domain.Model.EzAccountDomain(
                _domain.Account(
                    userId
                )
            );
        }

        public EzAccountGameSessionDomain Me(
            Gs2.Unity.Util.GameSession gameSession
        ) {
            return new EzAccountGameSessionDomain(
                _domain.AccessToken(
                    gameSession.AccessToken
                )
            );
        }

    }
}
