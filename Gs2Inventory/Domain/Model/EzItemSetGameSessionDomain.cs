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
using Gs2.Gs2Inventory.Domain.Iterator;
using Gs2.Gs2Inventory.Request;
using Gs2.Gs2Inventory.Result;
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

namespace Gs2.Unity.Gs2Inventory.Domain.Model
{

    public partial class EzItemSetGameSessionDomain {
        private readonly Gs2.Gs2Inventory.Domain.Model.ItemSetAccessTokenDomain _domain;
        public string Body => _domain.Body;
        public string Signature => _domain.Signature;
        public long? OverflowCount => _domain.OverflowCount;
        public string NamespaceName => _domain?.NamespaceName;
        public string UserId => _domain?.UserId;
        public string InventoryName => _domain?.InventoryName;
        public string ItemName => _domain?.ItemName;
        public string ItemSetName => _domain?.ItemSetName;

        public EzItemSetGameSessionDomain(
            Gs2.Gs2Inventory.Domain.Model.ItemSetAccessTokenDomain domain
        ) {
            this._domain = domain;
        }

        #if GS2_ENABLE_UNITASK
        public IFuture<Gs2.Unity.Gs2Inventory.Domain.Model.EzItemSetGameSessionDomain> GetItemWithSignature(
              string keyId
        )
        {
            IEnumerator Impl(Gs2Future<Gs2.Unity.Gs2Inventory.Domain.Model.EzItemSetGameSessionDomain> self)
            {
                yield return GetItemWithSignatureAsync(
                    keyId
                ).ToCoroutine(
                    self.OnComplete,
                    e => self.OnError((Gs2.Core.Exception.Gs2Exception)e)
                );
            }
            return new Gs2InlineFuture<Gs2.Unity.Gs2Inventory.Domain.Model.EzItemSetGameSessionDomain>(Impl);
        }

        public async UniTask<Gs2.Unity.Gs2Inventory.Domain.Model.EzItemSetGameSessionDomain> GetItemWithSignatureAsync(
        #else
        public IFuture<Gs2.Unity.Gs2Inventory.Domain.Model.EzItemSetGameSessionDomain> GetItemWithSignature(
        #endif
              string keyId
        ) {
        #if GS2_ENABLE_UNITASK
            var result = await _domain.GetItemWithSignatureAsync(
                new GetItemWithSignatureRequest()
                    .WithKeyId(keyId)
            );
            return new Gs2.Unity.Gs2Inventory.Domain.Model.EzItemSetGameSessionDomain(result);
        #else
            IEnumerator Impl(Gs2Future<Gs2.Unity.Gs2Inventory.Domain.Model.EzItemSetGameSessionDomain> self)
            {
                var future = _domain.GetItemWithSignature(
                    new GetItemWithSignatureRequest()
                        .WithKeyId(keyId)
                );
                yield return future;
                if (future.Error != null)
                {
                    self.OnError(future.Error);
                    yield break;
                }
                var result = future.Result;
                self.OnComplete(new Gs2.Unity.Gs2Inventory.Domain.Model.EzItemSetGameSessionDomain(result));
            }
            return new Gs2InlineFuture<Gs2.Unity.Gs2Inventory.Domain.Model.EzItemSetGameSessionDomain>(Impl);
        #endif
        }

        #if GS2_ENABLE_UNITASK
        public IFuture<Gs2.Unity.Gs2Inventory.Domain.Model.EzItemSetGameSessionDomain> Consume(
              long consumeCount
        )
        {
            IEnumerator Impl(Gs2Future<Gs2.Unity.Gs2Inventory.Domain.Model.EzItemSetGameSessionDomain> self)
            {
                yield return ConsumeAsync(
                    consumeCount
                ).ToCoroutine(
                    self.OnComplete,
                    e => self.OnError((Gs2.Core.Exception.Gs2Exception)e)
                );
            }
            return new Gs2InlineFuture<Gs2.Unity.Gs2Inventory.Domain.Model.EzItemSetGameSessionDomain>(Impl);
        }

        public async UniTask<Gs2.Unity.Gs2Inventory.Domain.Model.EzItemSetGameSessionDomain> ConsumeAsync(
        #else
        public IFuture<Gs2.Unity.Gs2Inventory.Domain.Model.EzItemSetGameSessionDomain> Consume(
        #endif
              long consumeCount
        ) {
        #if GS2_ENABLE_UNITASK
            var result = await _domain.ConsumeAsync(
                new ConsumeItemSetRequest()
                    .WithConsumeCount(consumeCount)
            );
            return new Gs2.Unity.Gs2Inventory.Domain.Model.EzItemSetGameSessionDomain(result);
        #else
            IEnumerator Impl(Gs2Future<Gs2.Unity.Gs2Inventory.Domain.Model.EzItemSetGameSessionDomain> self)
            {
                var future = _domain.Consume(
                    new ConsumeItemSetRequest()
                        .WithConsumeCount(consumeCount)
                );
                yield return future;
                if (future.Error != null)
                {
                    self.OnError(future.Error);
                    yield break;
                }
                var result = future.Result;
                self.OnComplete(new Gs2.Unity.Gs2Inventory.Domain.Model.EzItemSetGameSessionDomain(result));
            }
            return new Gs2InlineFuture<Gs2.Unity.Gs2Inventory.Domain.Model.EzItemSetGameSessionDomain>(Impl);
        #endif
        }

        #if GS2_ENABLE_UNITASK
        public IFuture<Gs2.Unity.Gs2Inventory.Model.EzItemSet> Model()
        {
            IEnumerator Impl(Gs2Future<Gs2.Unity.Gs2Inventory.Model.EzItemSet> self)
            {
                yield return ModelAsync().ToCoroutine(
                    self.OnComplete,
                    e => self.OnError((Gs2.Core.Exception.Gs2Exception)e)
                );
            }
            return new Gs2InlineFuture<Gs2.Unity.Gs2Inventory.Model.EzItemSet>(Impl);
        }

        public async UniTask<Gs2.Unity.Gs2Inventory.Model.EzItemSet> ModelAsync()
        {
            var item = await _domain.Model();
            if (item == null) {
                return null;
            }
            return Gs2.Unity.Gs2Inventory.Model.EzItemSet.FromModel(
                item
            );
        }
        #else
        public IFuture<Gs2.Unity.Gs2Inventory.Model.EzItemSet> Model()
        {
            IEnumerator Impl(Gs2Future<Gs2.Unity.Gs2Inventory.Model.EzItemSet> self)
            {
                var future = _domain.Model();
                yield return future;
                if (future.Error != null) {
                    self.OnError(future.Error);
                    yield break;
                }
                var item = future.Result;
                if (item == null) {
                    self.OnComplete(null);
                    yield break;
                }
                self.OnComplete(Gs2.Unity.Gs2Inventory.Model.EzItemSet.FromModel(
                    item
                ));
            }
            return new Gs2InlineFuture<Gs2.Unity.Gs2Inventory.Model.EzItemSet>(Impl);
        }
        #endif

    }
}
