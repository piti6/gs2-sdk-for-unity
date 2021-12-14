
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
using Gs2.Core.Domain;
using Gs2.Core.Util;
using Gs2.Gs2Auth.Model;
using Gs2.Util.LitJson;
using UnityEngine.Scripting;
#if GS2_ENABLE_UNITASK
using System.Threading;
using System.Collections.Generic;
using Cysharp.Threading;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.Linq;
#else
using System.Collections;
using UnityEngine.Events;
using Gs2.Core;
using Gs2.Core.Exception;
#endif

namespace Gs2.Unity.Gs2Inventory.Domain.Iterator
{

    #if GS2_ENABLE_UNITASK
    public class EzDescribeItemSetsIterator {
    #else
    public class EzDescribeItemSetsIterator : Gs2Iterator<EzGs2.Unity.Gs2Inventory.Model.EzItemSet> {
    #endif
        private readonly Gs2.Gs2Inventory.Domain.Iterator.DescribeItemSetsIterator _iterator;

        public EzDescribeItemSetsIterator(
            Gs2.Gs2Inventory.Domain.Iterator.DescribeItemSetsIterator iterator
        ) {
            this._iterator = iterator;
        }

        #if GS2_ENABLE_UNITASK
        public IUniTaskAsyncEnumerable<Gs2.Unity.Gs2Inventory.Model.EzItemSet> GetAsyncEnumerator(
            CancellationToken cancellationToken = new CancellationToken()
        #else

        public override bool HasNext()
        {
            return _iterator.HasNext();
        }

        protected override IEnumerator Next(
            Action<Gs2.Unity.Gs2Inventory.Model.EzItemSet> callback
        #endif
        )
        {
            return UniTaskAsyncEnumerable.Create<Gs2.Unity.Gs2Inventory.Model.EzItemSet>(async (writer, token) =>
            {
            });
        }
    }
}
