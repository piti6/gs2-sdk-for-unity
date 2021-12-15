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
using Gs2.Gs2Money.Domain.Iterator;
using Gs2.Gs2Money.Request;
using Gs2.Gs2Money.Result;
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

namespace Gs2.Unity.Gs2Money.Domain.Model
{

    public partial class EzUserGameSessionDomain {
        private readonly Gs2.Gs2Money.Domain.Model.UserAccessTokenDomain _domain;
        public float? Price => _domain.Price;
        public string NextPageToken => _domain.NextPageToken;
        public string NamespaceName => _domain?.NamespaceName;
        public string UserId => _domain?.UserId;

        public EzUserGameSessionDomain(
            Gs2.Gs2Money.Domain.Model.UserAccessTokenDomain domain
        ) {
            this._domain = domain;
        }

        #if GS2_ENABLE_UNITASK
        public IUniTaskAsyncEnumerable<Gs2.Unity.Gs2Money.Model.EzWallet> Wallets(
        #else
        public class EzWalletsIterator : Gs2Iterator<Gs2.Unity.Gs2Money.Model.EzWallet>
        {
            private readonly Gs2Iterator<Gs2.Gs2Money.Model.Wallet> _it;

            public EzWalletsIterator(
                Gs2Iterator<Gs2.Gs2Money.Model.Wallet> it
            )
            {
                _it = it;
            }

            public override bool HasNext()
            {
                return _it.HasNext();
            }

            protected override IEnumerator Next(Action<Gs2.Unity.Gs2Money.Model.EzWallet> callback)
            {
                yield return _it.Next();
                callback.Invoke(Gs2.Unity.Gs2Money.Model.EzWallet.FromModel(_it.Current));
            }
        }

        public Gs2Iterator<Gs2.Unity.Gs2Money.Model.EzWallet> Wallets(
        #endif
        )
        {
        #if GS2_ENABLE_UNITASK
            return UniTaskAsyncEnumerable.Create<Gs2.Unity.Gs2Money.Model.EzWallet>(async (writer, token) =>
            {
                var it = _domain.Wallets(
                ).GetAsyncEnumerator();
                while(await it.MoveNextAsync())
                {
                    await writer.YieldAsync(Gs2.Unity.Gs2Money.Model.EzWallet.FromModel(it.Current));
                }
            });
        #else
            return new EzWalletsIterator(_domain.Wallets(
            ));
        #endif
        }

        public Gs2.Unity.Gs2Money.Domain.Model.EzWalletGameSessionDomain Wallet(
            int slot
        ) {
            return new Gs2.Unity.Gs2Money.Domain.Model.EzWalletGameSessionDomain(
                _domain.Wallet(
                    slot
                )
            );
        }

    }
}