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
using Gs2.Gs2Datastore.Domain.Iterator;
using Gs2.Gs2Datastore.Request;
using Gs2.Gs2Datastore.Result;
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

namespace Gs2.Unity.Gs2Datastore.Domain.Model
{

    public partial class EzDataObjectDomain {
        private readonly Gs2.Gs2Datastore.Domain.Model.DataObjectDomain _domain;
        public string UploadUrl => _domain.UploadUrl;
        public string FileUrl => _domain.FileUrl;
        public long? ContentLength => _domain.ContentLength;
        public string NextPageToken => _domain.NextPageToken;
        public string NamespaceName => _domain?.NamespaceName;
        public string UserId => _domain?.UserId;
        public string DataObjectName => _domain?.DataObjectName;

        public EzDataObjectDomain(
            Gs2.Gs2Datastore.Domain.Model.DataObjectDomain domain
        ) {
            this._domain = domain;
        }

        #if GS2_ENABLE_UNITASK
        public async UniTask<Gs2.Unity.Gs2Datastore.Domain.Model.EzDataObjectDomain> PrepareDownloadByUserIdAndDataObjectNameAsync(
        #else
        public IFuture<Gs2.Unity.Gs2Datastore.Domain.Model.EzDataObjectDomain> PrepareDownloadByUserIdAndDataObjectName(
        #endif
        ) {
            var result = await _domain.PrepareDownloadByUserIdAndNameAsync(
                new PrepareDownloadByUserIdAndDataObjectNameRequest()
            );
            return new Gs2.Unity.Gs2Datastore.Domain.Model.EzDataObjectDomain(result);
        }

        #if GS2_ENABLE_UNITASK
        public IUniTaskAsyncEnumerable<Gs2.Unity.Gs2Datastore.Model.EzDataObjectHistory> DataObjectHistories(
        #else
        public Gs2Iterator<Gs2.Unity.Gs2Datastore.Model.EzDataObjectHistory> DataObjectHistories(
        #endif
        )
        {
            return UniTaskAsyncEnumerable.Create<Gs2.Unity.Gs2Datastore.Model.EzDataObjectHistory>(async (writer, token) =>
            {
                var it = _domain.DataObjectHistories(
                ).GetAsyncEnumerator();
                while(await it.MoveNextAsync())
                {
                    await writer.YieldAsync(Gs2.Unity.Gs2Datastore.Model.EzDataObjectHistory.FromModel(it.Current));
                }
            });
        }

        public Gs2.Unity.Gs2Datastore.Domain.Model.EzDataObjectHistoryDomain DataObjectHistory(
            string generation
        ) {
            return new Gs2.Unity.Gs2Datastore.Domain.Model.EzDataObjectHistoryDomain(
                _domain.DataObjectHistory(
                    generation
                )
            );
        }

        #if GS2_ENABLE_UNITASK
        public async UniTask<Gs2.Unity.Gs2Datastore.Model.EzDataObject> Model() {
        #else
        public IFuture<Gs2.Unity.Gs2Datastore.Model.EzDataObject> Model() {
        #endif
            var item = await _domain.Model();
            if (item == null) {
                return null;
            }
            return Gs2.Unity.Gs2Datastore.Model.EzDataObject.FromModel(
                item
            );
        }

    }
}
