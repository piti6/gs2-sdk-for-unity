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
using System.Text.RegularExpressions;
using Gs2.Core.Model;
using Gs2.Util.LitJson;
using UnityEngine.Scripting;

namespace Gs2.Gs2Ranking.Model
{
	[Preserve]
	public class CategoryModelMaster : IComparable
	{

        /** カテゴリマスター */
        public string categoryModelId { set; get; }

        /**
         * カテゴリマスターを設定
         *
         * @param categoryModelId カテゴリマスター
         * @return this
         */
        public CategoryModelMaster WithCategoryModelId(string categoryModelId) {
            this.categoryModelId = categoryModelId;
            return this;
        }

        /** カテゴリモデル名 */
        public string name { set; get; }

        /**
         * カテゴリモデル名を設定
         *
         * @param name カテゴリモデル名
         * @return this
         */
        public CategoryModelMaster WithName(string name) {
            this.name = name;
            return this;
        }

        /** カテゴリマスターの説明 */
        public string description { set; get; }

        /**
         * カテゴリマスターの説明を設定
         *
         * @param description カテゴリマスターの説明
         * @return this
         */
        public CategoryModelMaster WithDescription(string description) {
            this.description = description;
            return this;
        }

        /** カテゴリマスターのメタデータ */
        public string metadata { set; get; }

        /**
         * カテゴリマスターのメタデータを設定
         *
         * @param metadata カテゴリマスターのメタデータ
         * @return this
         */
        public CategoryModelMaster WithMetadata(string metadata) {
            this.metadata = metadata;
            return this;
        }

        /** スコアの最小値 */
        public long? minimumValue { set; get; }

        /**
         * スコアの最小値を設定
         *
         * @param minimumValue スコアの最小値
         * @return this
         */
        public CategoryModelMaster WithMinimumValue(long? minimumValue) {
            this.minimumValue = minimumValue;
            return this;
        }

        /** スコアの最大値 */
        public long? maximumValue { set; get; }

        /**
         * スコアの最大値を設定
         *
         * @param maximumValue スコアの最大値
         * @return this
         */
        public CategoryModelMaster WithMaximumValue(long? maximumValue) {
            this.maximumValue = maximumValue;
            return this;
        }

        /** スコアのソート方向 */
        public string orderDirection { set; get; }

        /**
         * スコアのソート方向を設定
         *
         * @param orderDirection スコアのソート方向
         * @return this
         */
        public CategoryModelMaster WithOrderDirection(string orderDirection) {
            this.orderDirection = orderDirection;
            return this;
        }

        /** ランキングの種類 */
        public string scope { set; get; }

        /**
         * ランキングの種類を設定
         *
         * @param scope ランキングの種類
         * @return this
         */
        public CategoryModelMaster WithScope(string scope) {
            this.scope = scope;
            return this;
        }

        /** ユーザID毎にスコアを1つしか登録されないようにする */
        public bool? uniqueByUserId { set; get; }

        /**
         * ユーザID毎にスコアを1つしか登録されないようにするを設定
         *
         * @param uniqueByUserId ユーザID毎にスコアを1つしか登録されないようにする
         * @return this
         */
        public CategoryModelMaster WithUniqueByUserId(bool? uniqueByUserId) {
            this.uniqueByUserId = uniqueByUserId;
            return this;
        }

        /** スコアの集計間隔(分) */
        public int? calculateIntervalMinutes { set; get; }

        /**
         * スコアの集計間隔(分)を設定
         *
         * @param calculateIntervalMinutes スコアの集計間隔(分)
         * @return this
         */
        public CategoryModelMaster WithCalculateIntervalMinutes(int? calculateIntervalMinutes) {
            this.calculateIntervalMinutes = calculateIntervalMinutes;
            return this;
        }

        /** スコアの登録可能期間とするイベントマスター のGRN */
        public string entryPeriodEventId { set; get; }

        /**
         * スコアの登録可能期間とするイベントマスター のGRNを設定
         *
         * @param entryPeriodEventId スコアの登録可能期間とするイベントマスター のGRN
         * @return this
         */
        public CategoryModelMaster WithEntryPeriodEventId(string entryPeriodEventId) {
            this.entryPeriodEventId = entryPeriodEventId;
            return this;
        }

        /** アクセス可能期間とするイベントマスター のGRN */
        public string accessPeriodEventId { set; get; }

        /**
         * アクセス可能期間とするイベントマスター のGRNを設定
         *
         * @param accessPeriodEventId アクセス可能期間とするイベントマスター のGRN
         * @return this
         */
        public CategoryModelMaster WithAccessPeriodEventId(string accessPeriodEventId) {
            this.accessPeriodEventId = accessPeriodEventId;
            return this;
        }

        /** 作成日時 */
        public long? createdAt { set; get; }

        /**
         * 作成日時を設定
         *
         * @param createdAt 作成日時
         * @return this
         */
        public CategoryModelMaster WithCreatedAt(long? createdAt) {
            this.createdAt = createdAt;
            return this;
        }

        /** 最終更新日時 */
        public long? updatedAt { set; get; }

        /**
         * 最終更新日時を設定
         *
         * @param updatedAt 最終更新日時
         * @return this
         */
        public CategoryModelMaster WithUpdatedAt(long? updatedAt) {
            this.updatedAt = updatedAt;
            return this;
        }

        public void WriteJson(JsonWriter writer)
        {
            writer.WriteObjectStart();
            if(this.categoryModelId != null)
            {
                writer.WritePropertyName("categoryModelId");
                writer.Write(this.categoryModelId);
            }
            if(this.name != null)
            {
                writer.WritePropertyName("name");
                writer.Write(this.name);
            }
            if(this.description != null)
            {
                writer.WritePropertyName("description");
                writer.Write(this.description);
            }
            if(this.metadata != null)
            {
                writer.WritePropertyName("metadata");
                writer.Write(this.metadata);
            }
            if(this.minimumValue.HasValue)
            {
                writer.WritePropertyName("minimumValue");
                writer.Write(this.minimumValue.Value);
            }
            if(this.maximumValue.HasValue)
            {
                writer.WritePropertyName("maximumValue");
                writer.Write(this.maximumValue.Value);
            }
            if(this.orderDirection != null)
            {
                writer.WritePropertyName("orderDirection");
                writer.Write(this.orderDirection);
            }
            if(this.scope != null)
            {
                writer.WritePropertyName("scope");
                writer.Write(this.scope);
            }
            if(this.uniqueByUserId.HasValue)
            {
                writer.WritePropertyName("uniqueByUserId");
                writer.Write(this.uniqueByUserId.Value);
            }
            if(this.calculateIntervalMinutes.HasValue)
            {
                writer.WritePropertyName("calculateIntervalMinutes");
                writer.Write(this.calculateIntervalMinutes.Value);
            }
            if(this.entryPeriodEventId != null)
            {
                writer.WritePropertyName("entryPeriodEventId");
                writer.Write(this.entryPeriodEventId);
            }
            if(this.accessPeriodEventId != null)
            {
                writer.WritePropertyName("accessPeriodEventId");
                writer.Write(this.accessPeriodEventId);
            }
            if(this.createdAt.HasValue)
            {
                writer.WritePropertyName("createdAt");
                writer.Write(this.createdAt.Value);
            }
            if(this.updatedAt.HasValue)
            {
                writer.WritePropertyName("updatedAt");
                writer.Write(this.updatedAt.Value);
            }
            writer.WriteObjectEnd();
        }

    public static string GetCategoryNameFromGrn(
        string grn
    )
    {
        var match = Regex.Match(grn, "grn:gs2:(?<region>.*):(?<ownerId>.*):ranking:(?<namespaceName>.*):category:(?<categoryName>.*)");
        if (!match.Groups["categoryName"].Success)
        {
            return null;
        }
        return match.Groups["categoryName"].Value;
    }

    public static string GetNamespaceNameFromGrn(
        string grn
    )
    {
        var match = Regex.Match(grn, "grn:gs2:(?<region>.*):(?<ownerId>.*):ranking:(?<namespaceName>.*):category:(?<categoryName>.*)");
        if (!match.Groups["namespaceName"].Success)
        {
            return null;
        }
        return match.Groups["namespaceName"].Value;
    }

    public static string GetOwnerIdFromGrn(
        string grn
    )
    {
        var match = Regex.Match(grn, "grn:gs2:(?<region>.*):(?<ownerId>.*):ranking:(?<namespaceName>.*):category:(?<categoryName>.*)");
        if (!match.Groups["ownerId"].Success)
        {
            return null;
        }
        return match.Groups["ownerId"].Value;
    }

    public static string GetRegionFromGrn(
        string grn
    )
    {
        var match = Regex.Match(grn, "grn:gs2:(?<region>.*):(?<ownerId>.*):ranking:(?<namespaceName>.*):category:(?<categoryName>.*)");
        if (!match.Groups["region"].Success)
        {
            return null;
        }
        return match.Groups["region"].Value;
    }

    	[Preserve]
        public static CategoryModelMaster FromDict(JsonData data)
        {
            return new CategoryModelMaster()
                .WithCategoryModelId(data.Keys.Contains("categoryModelId") && data["categoryModelId"] != null ? data["categoryModelId"].ToString() : null)
                .WithName(data.Keys.Contains("name") && data["name"] != null ? data["name"].ToString() : null)
                .WithDescription(data.Keys.Contains("description") && data["description"] != null ? data["description"].ToString() : null)
                .WithMetadata(data.Keys.Contains("metadata") && data["metadata"] != null ? data["metadata"].ToString() : null)
                .WithMinimumValue(data.Keys.Contains("minimumValue") && data["minimumValue"] != null ? (long?)long.Parse(data["minimumValue"].ToString()) : null)
                .WithMaximumValue(data.Keys.Contains("maximumValue") && data["maximumValue"] != null ? (long?)long.Parse(data["maximumValue"].ToString()) : null)
                .WithOrderDirection(data.Keys.Contains("orderDirection") && data["orderDirection"] != null ? data["orderDirection"].ToString() : null)
                .WithScope(data.Keys.Contains("scope") && data["scope"] != null ? data["scope"].ToString() : null)
                .WithUniqueByUserId(data.Keys.Contains("uniqueByUserId") && data["uniqueByUserId"] != null ? (bool?)bool.Parse(data["uniqueByUserId"].ToString()) : null)
                .WithCalculateIntervalMinutes(data.Keys.Contains("calculateIntervalMinutes") && data["calculateIntervalMinutes"] != null ? (int?)int.Parse(data["calculateIntervalMinutes"].ToString()) : null)
                .WithEntryPeriodEventId(data.Keys.Contains("entryPeriodEventId") && data["entryPeriodEventId"] != null ? data["entryPeriodEventId"].ToString() : null)
                .WithAccessPeriodEventId(data.Keys.Contains("accessPeriodEventId") && data["accessPeriodEventId"] != null ? data["accessPeriodEventId"].ToString() : null)
                .WithCreatedAt(data.Keys.Contains("createdAt") && data["createdAt"] != null ? (long?)long.Parse(data["createdAt"].ToString()) : null)
                .WithUpdatedAt(data.Keys.Contains("updatedAt") && data["updatedAt"] != null ? (long?)long.Parse(data["updatedAt"].ToString()) : null);
        }

        public int CompareTo(object obj)
        {
            var other = obj as CategoryModelMaster;
            var diff = 0;
            if (categoryModelId == null && categoryModelId == other.categoryModelId)
            {
                // null and null
            }
            else
            {
                diff += categoryModelId.CompareTo(other.categoryModelId);
            }
            if (name == null && name == other.name)
            {
                // null and null
            }
            else
            {
                diff += name.CompareTo(other.name);
            }
            if (description == null && description == other.description)
            {
                // null and null
            }
            else
            {
                diff += description.CompareTo(other.description);
            }
            if (metadata == null && metadata == other.metadata)
            {
                // null and null
            }
            else
            {
                diff += metadata.CompareTo(other.metadata);
            }
            if (minimumValue == null && minimumValue == other.minimumValue)
            {
                // null and null
            }
            else
            {
                diff += (int)(minimumValue - other.minimumValue);
            }
            if (maximumValue == null && maximumValue == other.maximumValue)
            {
                // null and null
            }
            else
            {
                diff += (int)(maximumValue - other.maximumValue);
            }
            if (orderDirection == null && orderDirection == other.orderDirection)
            {
                // null and null
            }
            else
            {
                diff += orderDirection.CompareTo(other.orderDirection);
            }
            if (scope == null && scope == other.scope)
            {
                // null and null
            }
            else
            {
                diff += scope.CompareTo(other.scope);
            }
            if (uniqueByUserId == null && uniqueByUserId == other.uniqueByUserId)
            {
                // null and null
            }
            else
            {
                diff += uniqueByUserId == other.uniqueByUserId ? 0 : 1;
            }
            if (calculateIntervalMinutes == null && calculateIntervalMinutes == other.calculateIntervalMinutes)
            {
                // null and null
            }
            else
            {
                diff += (int)(calculateIntervalMinutes - other.calculateIntervalMinutes);
            }
            if (entryPeriodEventId == null && entryPeriodEventId == other.entryPeriodEventId)
            {
                // null and null
            }
            else
            {
                diff += entryPeriodEventId.CompareTo(other.entryPeriodEventId);
            }
            if (accessPeriodEventId == null && accessPeriodEventId == other.accessPeriodEventId)
            {
                // null and null
            }
            else
            {
                diff += accessPeriodEventId.CompareTo(other.accessPeriodEventId);
            }
            if (createdAt == null && createdAt == other.createdAt)
            {
                // null and null
            }
            else
            {
                diff += (int)(createdAt - other.createdAt);
            }
            if (updatedAt == null && updatedAt == other.updatedAt)
            {
                // null and null
            }
            else
            {
                diff += (int)(updatedAt - other.updatedAt);
            }
            return diff;
        }
	}
}