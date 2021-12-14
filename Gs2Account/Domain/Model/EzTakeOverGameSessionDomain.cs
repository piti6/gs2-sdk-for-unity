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

    public partial class EzTakeOverGameSessionDomain {
        private readonly Gs2.Gs2Account.Domain.Model.TakeOverAccessTokenDomain _domain;
        public string NamespaceName => _domain?.NamespaceName;
        public string UserId => _domain?.UserId;
        public int? Type => _domain?.Type;

        public EzTakeOverGameSessionDomain(
            Gs2.Gs2Account.Domain.Model.TakeOverAccessTokenDomain domain
        ) {
            this._domain = domain;
        }

        #if GS2_ENABLE_UNITASK
        public async UniTask<Gs2.Unity.Gs2Account.Domain.Model.EzTakeOverGameSessionDomain> AddTakeOverSettingAsync(
        #else
        public IFuture<Gs2.Unity.Gs2Account.Domain.Model.EzTakeOverGameSessionDomain> AddTakeOverSetting(
        #endif
              string userIdentifier,
              string password
        ) {
            var result = await _domain.CreateAsync(
                new CreateTakeOverRequest()
                    .WithUserIdentifier(userIdentifier)
                    .WithPassword(password)
            );
            return new Gs2.Unity.Gs2Account.Domain.Model.EzTakeOverGameSessionDomain(result);
        }

        #if GS2_ENABLE_UNITASK
        public async UniTask<Gs2.Unity.Gs2Account.Domain.Model.EzTakeOverGameSessionDomain> UpdateTakeOverSettingAsync(
        #else
        public IFuture<Gs2.Unity.Gs2Account.Domain.Model.EzTakeOverGameSessionDomain> UpdateTakeOverSetting(
        #endif
              string oldPassword,
              string password
        ) {
            var result = await _domain.UpdateAsync(
                new UpdateTakeOverRequest()
                    .WithOldPassword(oldPassword)
                    .WithPassword(password)
            );
            return new Gs2.Unity.Gs2Account.Domain.Model.EzTakeOverGameSessionDomain(result);
        }

        #if GS2_ENABLE_UNITASK
        public async UniTask<Gs2.Unity.Gs2Account.Domain.Model.EzTakeOverGameSessionDomain> DeleteTakeOverSettingAsync(
        #else
        public IFuture<Gs2.Unity.Gs2Account.Domain.Model.EzTakeOverGameSessionDomain> DeleteTakeOverSetting(
        #endif
        ) {
            var result = await _domain.DeleteAsync(
                new DeleteTakeOverRequest()
            );
            return new Gs2.Unity.Gs2Account.Domain.Model.EzTakeOverGameSessionDomain(result);
        }

        #if GS2_ENABLE_UNITASK
        public async UniTask<Gs2.Unity.Gs2Account.Model.EzTakeOver> Model() {
        #else
        public IFuture<Gs2.Unity.Gs2Account.Model.EzTakeOver> Model() {
        #endif
            var item = await _domain.Model();
            if (item == null) {
                return null;
            }
            return Gs2.Unity.Gs2Account.Model.EzTakeOver.FromModel(
                item
            );
        }

    }
}
