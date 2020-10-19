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
using System;
using System.Collections.Generic;
using System.Linq;
using Gs2.Core.Control;
using Gs2.Core.Model;
using Gs2.Gs2Ranking.Model;
using Gs2.Util.LitJson;
using UnityEngine.Scripting;

namespace Gs2.Gs2Ranking.Request
{
	[Preserve]
	[System.Serializable]
	public class UpdateCategoryModelMasterRequest : Gs2Request<UpdateCategoryModelMasterRequest>
	{

        /** ネームスペース名 */
		[UnityEngine.SerializeField]
        public string namespaceName;

        /**
         * ネームスペース名を設定
         *
         * @param namespaceName ネームスペース名
         * @return this
         */
        public UpdateCategoryModelMasterRequest WithNamespaceName(string namespaceName) {
            this.namespaceName = namespaceName;
            return this;
        }


        /** カテゴリモデル名 */
		[UnityEngine.SerializeField]
        public string categoryName;

        /**
         * カテゴリモデル名を設定
         *
         * @param categoryName カテゴリモデル名
         * @return this
         */
        public UpdateCategoryModelMasterRequest WithCategoryName(string categoryName) {
            this.categoryName = categoryName;
            return this;
        }


        /** カテゴリマスターの説明 */
		[UnityEngine.SerializeField]
        public string description;

        /**
         * カテゴリマスターの説明を設定
         *
         * @param description カテゴリマスターの説明
         * @return this
         */
        public UpdateCategoryModelMasterRequest WithDescription(string description) {
            this.description = description;
            return this;
        }


        /** カテゴリマスターのメタデータ */
		[UnityEngine.SerializeField]
        public string metadata;

        /**
         * カテゴリマスターのメタデータを設定
         *
         * @param metadata カテゴリマスターのメタデータ
         * @return this
         */
        public UpdateCategoryModelMasterRequest WithMetadata(string metadata) {
            this.metadata = metadata;
            return this;
        }


        /** スコアの最小値 */
		[UnityEngine.SerializeField]
        public long? minimumValue;

        /**
         * スコアの最小値を設定
         *
         * @param minimumValue スコアの最小値
         * @return this
         */
        public UpdateCategoryModelMasterRequest WithMinimumValue(long? minimumValue) {
            this.minimumValue = minimumValue;
            return this;
        }


        /** スコアの最大値 */
		[UnityEngine.SerializeField]
        public long? maximumValue;

        /**
         * スコアの最大値を設定
         *
         * @param maximumValue スコアの最大値
         * @return this
         */
        public UpdateCategoryModelMasterRequest WithMaximumValue(long? maximumValue) {
            this.maximumValue = maximumValue;
            return this;
        }


        /** スコアのソート方向 */
		[UnityEngine.SerializeField]
        public string orderDirection;

        /**
         * スコアのソート方向を設定
         *
         * @param orderDirection スコアのソート方向
         * @return this
         */
        public UpdateCategoryModelMasterRequest WithOrderDirection(string orderDirection) {
            this.orderDirection = orderDirection;
            return this;
        }


        /** ランキングの種類 */
		[UnityEngine.SerializeField]
        public string scope;

        /**
         * ランキングの種類を設定
         *
         * @param scope ランキングの種類
         * @return this
         */
        public UpdateCategoryModelMasterRequest WithScope(string scope) {
            this.scope = scope;
            return this;
        }


        /** ユーザID毎にスコアを1つしか登録されないようにする */
		[UnityEngine.SerializeField]
        public bool? uniqueByUserId;

        /**
         * ユーザID毎にスコアを1つしか登録されないようにするを設定
         *
         * @param uniqueByUserId ユーザID毎にスコアを1つしか登録されないようにする
         * @return this
         */
        public UpdateCategoryModelMasterRequest WithUniqueByUserId(bool? uniqueByUserId) {
            this.uniqueByUserId = uniqueByUserId;
            return this;
        }


        /** スコアの固定集計開始時刻(時) */
		[UnityEngine.SerializeField]
        public int? calculateFixedTimingHour;

        /**
         * スコアの固定集計開始時刻(時)を設定
         *
         * @param calculateFixedTimingHour スコアの固定集計開始時刻(時)
         * @return this
         */
        public UpdateCategoryModelMasterRequest WithCalculateFixedTimingHour(int? calculateFixedTimingHour) {
            this.calculateFixedTimingHour = calculateFixedTimingHour;
            return this;
        }


        /** スコアの固定集計開始時刻(分) */
		[UnityEngine.SerializeField]
        public int? calculateFixedTimingMinute;

        /**
         * スコアの固定集計開始時刻(分)を設定
         *
         * @param calculateFixedTimingMinute スコアの固定集計開始時刻(分)
         * @return this
         */
        public UpdateCategoryModelMasterRequest WithCalculateFixedTimingMinute(int? calculateFixedTimingMinute) {
            this.calculateFixedTimingMinute = calculateFixedTimingMinute;
            return this;
        }


        /** スコアの集計間隔(分) */
		[UnityEngine.SerializeField]
        public int? calculateIntervalMinutes;

        /**
         * スコアの集計間隔(分)を設定
         *
         * @param calculateIntervalMinutes スコアの集計間隔(分)
         * @return this
         */
        public UpdateCategoryModelMasterRequest WithCalculateIntervalMinutes(int? calculateIntervalMinutes) {
            this.calculateIntervalMinutes = calculateIntervalMinutes;
            return this;
        }


        /** スコアの登録可能期間とするイベントマスター のGRN */
		[UnityEngine.SerializeField]
        public string entryPeriodEventId;

        /**
         * スコアの登録可能期間とするイベントマスター のGRNを設定
         *
         * @param entryPeriodEventId スコアの登録可能期間とするイベントマスター のGRN
         * @return this
         */
        public UpdateCategoryModelMasterRequest WithEntryPeriodEventId(string entryPeriodEventId) {
            this.entryPeriodEventId = entryPeriodEventId;
            return this;
        }


        /** アクセス可能期間とするイベントマスター のGRN */
		[UnityEngine.SerializeField]
        public string accessPeriodEventId;

        /**
         * アクセス可能期間とするイベントマスター のGRNを設定
         *
         * @param accessPeriodEventId アクセス可能期間とするイベントマスター のGRN
         * @return this
         */
        public UpdateCategoryModelMasterRequest WithAccessPeriodEventId(string accessPeriodEventId) {
            this.accessPeriodEventId = accessPeriodEventId;
            return this;
        }


        /** ランキングの世代 */
		[UnityEngine.SerializeField]
        public string generation;

        /**
         * ランキングの世代を設定
         *
         * @param generation ランキングの世代
         * @return this
         */
        public UpdateCategoryModelMasterRequest WithGeneration(string generation) {
            this.generation = generation;
            return this;
        }


    	[Preserve]
        public static UpdateCategoryModelMasterRequest FromDict(JsonData data)
        {
            return new UpdateCategoryModelMasterRequest {
                namespaceName = data.Keys.Contains("namespaceName") && data["namespaceName"] != null ? data["namespaceName"].ToString(): null,
                categoryName = data.Keys.Contains("categoryName") && data["categoryName"] != null ? data["categoryName"].ToString(): null,
                description = data.Keys.Contains("description") && data["description"] != null ? data["description"].ToString(): null,
                metadata = data.Keys.Contains("metadata") && data["metadata"] != null ? data["metadata"].ToString(): null,
                minimumValue = data.Keys.Contains("minimumValue") && data["minimumValue"] != null ? (long?)long.Parse(data["minimumValue"].ToString()) : null,
                maximumValue = data.Keys.Contains("maximumValue") && data["maximumValue"] != null ? (long?)long.Parse(data["maximumValue"].ToString()) : null,
                orderDirection = data.Keys.Contains("orderDirection") && data["orderDirection"] != null ? data["orderDirection"].ToString(): null,
                scope = data.Keys.Contains("scope") && data["scope"] != null ? data["scope"].ToString(): null,
                uniqueByUserId = data.Keys.Contains("uniqueByUserId") && data["uniqueByUserId"] != null ? (bool?)bool.Parse(data["uniqueByUserId"].ToString()) : null,
                calculateFixedTimingHour = data.Keys.Contains("calculateFixedTimingHour") && data["calculateFixedTimingHour"] != null ? (int?)int.Parse(data["calculateFixedTimingHour"].ToString()) : null,
                calculateFixedTimingMinute = data.Keys.Contains("calculateFixedTimingMinute") && data["calculateFixedTimingMinute"] != null ? (int?)int.Parse(data["calculateFixedTimingMinute"].ToString()) : null,
                calculateIntervalMinutes = data.Keys.Contains("calculateIntervalMinutes") && data["calculateIntervalMinutes"] != null ? (int?)int.Parse(data["calculateIntervalMinutes"].ToString()) : null,
                entryPeriodEventId = data.Keys.Contains("entryPeriodEventId") && data["entryPeriodEventId"] != null ? data["entryPeriodEventId"].ToString(): null,
                accessPeriodEventId = data.Keys.Contains("accessPeriodEventId") && data["accessPeriodEventId"] != null ? data["accessPeriodEventId"].ToString(): null,
                generation = data.Keys.Contains("generation") && data["generation"] != null ? data["generation"].ToString(): null,
            };
        }

	}
}