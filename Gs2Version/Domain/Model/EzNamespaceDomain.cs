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
using Gs2.Gs2Version.Domain.Iterator;
using Gs2.Gs2Version.Request;
using Gs2.Gs2Version.Result;
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

namespace Gs2.Unity.Gs2Version.Domain.Model
{

    public partial class EzNamespaceDomain {
        private readonly Gs2.Gs2Version.Domain.Model.NamespaceDomain _domain;
        public string Status => _domain.Status;
        public string NextPageToken => _domain.NextPageToken;
        public string NamespaceName => _domain?.NamespaceName;

        public EzNamespaceDomain(
            Gs2.Gs2Version.Domain.Model.NamespaceDomain domain
        ) {
            this._domain = domain;
        }

        #if GS2_ENABLE_UNITASK
        public IUniTaskAsyncEnumerable<Gs2.Unity.Gs2Version.Model.EzVersionModel> VersionModels(
        #else
        public class EzVersionModelsIterator : Gs2Iterator<Gs2.Unity.Gs2Version.Model.EzVersionModel>
        {
            private readonly Gs2Iterator<Gs2.Gs2Version.Model.VersionModel> _it;

            public EzVersionModelsIterator(
                Gs2Iterator<Gs2.Gs2Version.Model.VersionModel> it
            )
            {
                _it = it;
            }

            public override bool HasNext()
            {
                return _it.HasNext();
            }

            protected override IEnumerator Next(Action<Gs2.Unity.Gs2Version.Model.EzVersionModel> callback)
            {
                yield return _it.Next();
                callback.Invoke(Gs2.Unity.Gs2Version.Model.EzVersionModel.FromModel(_it.Current));
            }
        }

        public Gs2Iterator<Gs2.Unity.Gs2Version.Model.EzVersionModel> VersionModels(
        #endif
        )
        {
        #if GS2_ENABLE_UNITASK
            return UniTaskAsyncEnumerable.Create<Gs2.Unity.Gs2Version.Model.EzVersionModel>(async (writer, token) =>
            {
                var it = _domain.VersionModels(
                ).GetAsyncEnumerator();
                while(await it.MoveNextAsync())
                {
                    await writer.YieldAsync(Gs2.Unity.Gs2Version.Model.EzVersionModel.FromModel(it.Current));
                }
            });
        #else
            return new EzVersionModelsIterator(_domain.VersionModels(
            ));
        #endif
        }

        public Gs2.Unity.Gs2Version.Domain.Model.EzVersionModelDomain VersionModel(
            string versionName
        ) {
            return new Gs2.Unity.Gs2Version.Domain.Model.EzVersionModelDomain(
                _domain.VersionModel(
                    versionName
                )
            );
        }

        public Gs2.Unity.Gs2Version.Domain.Model.EzUserDomain User(
            string userId
        ) {
            return new Gs2.Unity.Gs2Version.Domain.Model.EzUserDomain(
                _domain.User(
                    userId
                )
            );
        }

        public EzUserGameSessionDomain Me(
            Gs2.Unity.Util.GameSession gameSession
        ) {
            return new EzUserGameSessionDomain(
                _domain.AccessToken(
                    gameSession.AccessToken
                )
            );
        }

    }
}
