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
using Gs2.Gs2Ranking.Domain.Iterator;
using Gs2.Gs2Ranking.Request;
using Gs2.Gs2Ranking.Result;
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

namespace Gs2.Unity.Gs2Ranking.Domain.Model
{

    public partial class EzUserDomain {
        private readonly Gs2.Gs2Ranking.Domain.Model.UserDomain _domain;
        private readonly Gs2.Unity.Util.Profile _profile;
        public string NextPageToken => _domain.NextPageToken;
        public bool? Processing => _domain.Processing;
        public string NamespaceName => _domain?.NamespaceName;
        public string UserId => _domain?.UserId;

        public EzUserDomain(
            Gs2.Gs2Ranking.Domain.Model.UserDomain domain,
            Gs2.Unity.Util.Profile profile
        ) {
            this._domain = domain;
            this._profile = profile;
        }

        public class EzSubscribesByCategoryNameIterator : Gs2Iterator<Gs2.Unity.Gs2Ranking.Model.EzSubscribeUser>
        {
            private readonly Gs2Iterator<Gs2.Gs2Ranking.Model.SubscribeUser> _it;

            public EzSubscribesByCategoryNameIterator(
                Gs2Iterator<Gs2.Gs2Ranking.Model.SubscribeUser> it
            )
            {
                _it = it;
            }

            public override bool HasNext()
            {
                return _it.HasNext();
            }

            protected override IEnumerator Next(Action<Gs2.Unity.Gs2Ranking.Model.EzSubscribeUser> callback)
            {
                yield return _it.Next();
                callback.Invoke(_it.Current == null ? null : Gs2.Unity.Gs2Ranking.Model.EzSubscribeUser.FromModel(_it.Current));
            }
        }

        #if GS2_ENABLE_UNITASK
        public Gs2Iterator<Gs2.Unity.Gs2Ranking.Model.EzSubscribeUser> SubscribesByCategoryName(
              string categoryName
        )
        {
            return new EzSubscribesByCategoryNameIterator(_domain.SubscribesByCategoryName(
               categoryName
            ));
        }

        public IUniTaskAsyncEnumerable<Gs2.Unity.Gs2Ranking.Model.EzSubscribeUser> SubscribesByCategoryNameAsync(
        #else
        public Gs2Iterator<Gs2.Unity.Gs2Ranking.Model.EzSubscribeUser> SubscribesByCategoryName(
        #endif
              string categoryName
        )
        {
        #if GS2_ENABLE_UNITASK
            return UniTaskAsyncEnumerable.Create<Gs2.Unity.Gs2Ranking.Model.EzSubscribeUser>(async (writer, token) =>
            {
                var it = _domain.SubscribesByCategoryNameAsync(
                    categoryName
                ).GetAsyncEnumerator();
                while(await it.MoveNextAsync())
                {
                    await writer.YieldAsync(it.Current == null ? null : Gs2.Unity.Gs2Ranking.Model.EzSubscribeUser.FromModel(it.Current));
                }
            });
        #else
            return new EzSubscribesByCategoryNameIterator(_domain.SubscribesByCategoryName(
               categoryName
            ));
        #endif
        }

        public Gs2.Unity.Gs2Ranking.Domain.Model.EzSubscribeUserDomain SubscribeUser(
            string categoryName,
            string targetUserId
        ) {
            return new Gs2.Unity.Gs2Ranking.Domain.Model.EzSubscribeUserDomain(
                _domain.SubscribeUser(
                    categoryName,
                    targetUserId
                ),
                _profile
            );
        }

        public class EzRankingsIterator : Gs2Iterator<Gs2.Unity.Gs2Ranking.Model.EzRanking>
        {
            private readonly Gs2Iterator<Gs2.Gs2Ranking.Model.Ranking> _it;

            public EzRankingsIterator(
                Gs2Iterator<Gs2.Gs2Ranking.Model.Ranking> it
            )
            {
                _it = it;
            }

            public override bool HasNext()
            {
                return _it.HasNext();
            }

            protected override IEnumerator Next(Action<Gs2.Unity.Gs2Ranking.Model.EzRanking> callback)
            {
                yield return _it.Next();
                callback.Invoke(_it.Current == null ? null : Gs2.Unity.Gs2Ranking.Model.EzRanking.FromModel(_it.Current));
            }
        }

        #if GS2_ENABLE_UNITASK
        public Gs2Iterator<Gs2.Unity.Gs2Ranking.Model.EzRanking> Rankings(
              string categoryName
        )
        {
            return new EzRankingsIterator(_domain.Rankings(
               categoryName
            ));
        }

        public IUniTaskAsyncEnumerable<Gs2.Unity.Gs2Ranking.Model.EzRanking> RankingsAsync(
        #else
        public Gs2Iterator<Gs2.Unity.Gs2Ranking.Model.EzRanking> Rankings(
        #endif
              string categoryName
        )
        {
        #if GS2_ENABLE_UNITASK
            return UniTaskAsyncEnumerable.Create<Gs2.Unity.Gs2Ranking.Model.EzRanking>(async (writer, token) =>
            {
                var it = _domain.RankingsAsync(
                    categoryName
                ).GetAsyncEnumerator();
                while(await it.MoveNextAsync())
                {
                    await writer.YieldAsync(it.Current == null ? null : Gs2.Unity.Gs2Ranking.Model.EzRanking.FromModel(it.Current));
                }
            });
        #else
            return new EzRankingsIterator(_domain.Rankings(
               categoryName
            ));
        #endif
        }

        public class EzNearRankingsIterator : Gs2Iterator<Gs2.Unity.Gs2Ranking.Model.EzRanking>
        {
            private readonly Gs2Iterator<Gs2.Gs2Ranking.Model.Ranking> _it;

            public EzNearRankingsIterator(
                Gs2Iterator<Gs2.Gs2Ranking.Model.Ranking> it
            )
            {
                _it = it;
            }

            public override bool HasNext()
            {
                return _it.HasNext();
            }

            protected override IEnumerator Next(Action<Gs2.Unity.Gs2Ranking.Model.EzRanking> callback)
            {
                yield return _it.Next();
                callback.Invoke(_it.Current == null ? null : Gs2.Unity.Gs2Ranking.Model.EzRanking.FromModel(_it.Current));
            }
        }

        #if GS2_ENABLE_UNITASK
        public Gs2Iterator<Gs2.Unity.Gs2Ranking.Model.EzRanking> NearRankings(
              string categoryName,
              long score
        )
        {
            return new EzNearRankingsIterator(_domain.NearRankings(
               categoryName,
               score
            ));
        }

        public IUniTaskAsyncEnumerable<Gs2.Unity.Gs2Ranking.Model.EzRanking> NearRankingsAsync(
        #else
        public Gs2Iterator<Gs2.Unity.Gs2Ranking.Model.EzRanking> NearRankings(
        #endif
              string categoryName,
              long score
        )
        {
        #if GS2_ENABLE_UNITASK
            return UniTaskAsyncEnumerable.Create<Gs2.Unity.Gs2Ranking.Model.EzRanking>(async (writer, token) =>
            {
                var it = _domain.NearRankingsAsync(
                    categoryName,
                    score
                ).GetAsyncEnumerator();
                while(await it.MoveNextAsync())
                {
                    await writer.YieldAsync(it.Current == null ? null : Gs2.Unity.Gs2Ranking.Model.EzRanking.FromModel(it.Current));
                }
            });
        #else
            return new EzNearRankingsIterator(_domain.NearRankings(
               categoryName,
               score
            ));
        #endif
        }

        public Gs2.Unity.Gs2Ranking.Domain.Model.EzRankingDomain Ranking(
            string categoryName
        ) {
            return new Gs2.Unity.Gs2Ranking.Domain.Model.EzRankingDomain(
                _domain.Ranking(
                    categoryName
                ),
                _profile
            );
        }

        public class EzScoresIterator : Gs2Iterator<Gs2.Unity.Gs2Ranking.Model.EzScore>
        {
            private readonly Gs2Iterator<Gs2.Gs2Ranking.Model.Score> _it;

            public EzScoresIterator(
                Gs2Iterator<Gs2.Gs2Ranking.Model.Score> it
            )
            {
                _it = it;
            }

            public override bool HasNext()
            {
                return _it.HasNext();
            }

            protected override IEnumerator Next(Action<Gs2.Unity.Gs2Ranking.Model.EzScore> callback)
            {
                yield return _it.Next();
                callback.Invoke(_it.Current == null ? null : Gs2.Unity.Gs2Ranking.Model.EzScore.FromModel(_it.Current));
            }
        }

        #if GS2_ENABLE_UNITASK
        public Gs2Iterator<Gs2.Unity.Gs2Ranking.Model.EzScore> Scores(
              string categoryName,
              string scorerUserId
        )
        {
            return new EzScoresIterator(_domain.Scores(
               categoryName,
               scorerUserId
            ));
        }

        public IUniTaskAsyncEnumerable<Gs2.Unity.Gs2Ranking.Model.EzScore> ScoresAsync(
        #else
        public Gs2Iterator<Gs2.Unity.Gs2Ranking.Model.EzScore> Scores(
        #endif
              string categoryName,
              string scorerUserId
        )
        {
        #if GS2_ENABLE_UNITASK
            return UniTaskAsyncEnumerable.Create<Gs2.Unity.Gs2Ranking.Model.EzScore>(async (writer, token) =>
            {
                var it = _domain.ScoresAsync(
                    categoryName,
                    scorerUserId
                ).GetAsyncEnumerator();
                while(await it.MoveNextAsync())
                {
                    await writer.YieldAsync(it.Current == null ? null : Gs2.Unity.Gs2Ranking.Model.EzScore.FromModel(it.Current));
                }
            });
        #else
            return new EzScoresIterator(_domain.Scores(
               categoryName,
               scorerUserId
            ));
        #endif
        }

        public Gs2.Unity.Gs2Ranking.Domain.Model.EzScoreDomain Score(
            string categoryName,
            string scorerUserId,
            string uniqueId = null
        ) {
            return new Gs2.Unity.Gs2Ranking.Domain.Model.EzScoreDomain(
                _domain.Score(
                    categoryName,
                    scorerUserId,
                    uniqueId
                ),
                _profile
            );
        }

    }
}
