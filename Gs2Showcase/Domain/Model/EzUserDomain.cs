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
using Gs2.Gs2Showcase.Domain.Iterator;
using Gs2.Gs2Showcase.Request;
using Gs2.Gs2Showcase.Result;
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

namespace Gs2.Unity.Gs2Showcase.Domain.Model
{

    public partial class EzUserDomain {
        private readonly Gs2.Gs2Showcase.Domain.Model.UserDomain _domain;
        public string NamespaceName => _domain?.NamespaceName;
        public string UserId => _domain?.UserId;

        public EzUserDomain(
            Gs2.Gs2Showcase.Domain.Model.UserDomain domain
        ) {
            this._domain = domain;
        }

        public class EzShowcasesIterator : Gs2Iterator<Gs2.Unity.Gs2Showcase.Model.EzShowcase>
        {
            private readonly Gs2Iterator<Gs2.Gs2Showcase.Model.Showcase> _it;

            public EzShowcasesIterator(
                Gs2Iterator<Gs2.Gs2Showcase.Model.Showcase> it
            )
            {
                _it = it;
            }

            public override bool HasNext()
            {
                return _it.HasNext();
            }

            protected override IEnumerator Next(Action<Gs2.Unity.Gs2Showcase.Model.EzShowcase> callback)
            {
                yield return _it.Next();
                callback.Invoke(_it.Current == null ? null : Gs2.Unity.Gs2Showcase.Model.EzShowcase.FromModel(_it.Current));
            }
        }

        #if GS2_ENABLE_UNITASK
        public Gs2Iterator<Gs2.Unity.Gs2Showcase.Model.EzShowcase> Showcases(
        )
        {
            return new EzShowcasesIterator(_domain.Showcases(
            ));
        }

        public IUniTaskAsyncEnumerable<Gs2.Unity.Gs2Showcase.Model.EzShowcase> ShowcasesAsync(
        #else
        public Gs2Iterator<Gs2.Unity.Gs2Showcase.Model.EzShowcase> Showcases(
        #endif
        )
        {
        #if GS2_ENABLE_UNITASK
            return UniTaskAsyncEnumerable.Create<Gs2.Unity.Gs2Showcase.Model.EzShowcase>(async (writer, token) =>
            {
                var it = _domain.ShowcasesAsync(
                ).GetAsyncEnumerator();
                while(await it.MoveNextAsync())
                {
                    await writer.YieldAsync(Gs2.Unity.Gs2Showcase.Model.EzShowcase.FromModel(it.Current));
                }
            });
        #else
            return new EzShowcasesIterator(_domain.Showcases(
            ));
        #endif
        }

        public Gs2.Unity.Gs2Showcase.Domain.Model.EzShowcaseDomain Showcase(
            string showcaseName
        ) {
            return new Gs2.Unity.Gs2Showcase.Domain.Model.EzShowcaseDomain(
                _domain.Showcase(
                    showcaseName
                )
            );
        }

    }
}
