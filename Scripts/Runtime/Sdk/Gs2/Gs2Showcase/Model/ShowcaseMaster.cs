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

namespace Gs2.Gs2Showcase.Model
{
	[Preserve]
	public class ShowcaseMaster : IComparable
	{

        /** 陳列棚マスター */
        public string showcaseId { set; get; }

        /**
         * 陳列棚マスターを設定
         *
         * @param showcaseId 陳列棚マスター
         * @return this
         */
        public ShowcaseMaster WithShowcaseId(string showcaseId) {
            this.showcaseId = showcaseId;
            return this;
        }

        /** 陳列棚名 */
        public string name { set; get; }

        /**
         * 陳列棚名を設定
         *
         * @param name 陳列棚名
         * @return this
         */
        public ShowcaseMaster WithName(string name) {
            this.name = name;
            return this;
        }

        /** 陳列棚マスターの説明 */
        public string description { set; get; }

        /**
         * 陳列棚マスターの説明を設定
         *
         * @param description 陳列棚マスターの説明
         * @return this
         */
        public ShowcaseMaster WithDescription(string description) {
            this.description = description;
            return this;
        }

        /** 商品のメタデータ */
        public string metadata { set; get; }

        /**
         * 商品のメタデータを設定
         *
         * @param metadata 商品のメタデータ
         * @return this
         */
        public ShowcaseMaster WithMetadata(string metadata) {
            this.metadata = metadata;
            return this;
        }

        /** 陳列する商品モデル一覧 */
        public List<DisplayItemMaster> displayItems { set; get; }

        /**
         * 陳列する商品モデル一覧を設定
         *
         * @param displayItems 陳列する商品モデル一覧
         * @return this
         */
        public ShowcaseMaster WithDisplayItems(List<DisplayItemMaster> displayItems) {
            this.displayItems = displayItems;
            return this;
        }

        /** 販売期間とするイベントマスター のGRN */
        public string salesPeriodEventId { set; get; }

        /**
         * 販売期間とするイベントマスター のGRNを設定
         *
         * @param salesPeriodEventId 販売期間とするイベントマスター のGRN
         * @return this
         */
        public ShowcaseMaster WithSalesPeriodEventId(string salesPeriodEventId) {
            this.salesPeriodEventId = salesPeriodEventId;
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
        public ShowcaseMaster WithCreatedAt(long? createdAt) {
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
        public ShowcaseMaster WithUpdatedAt(long? updatedAt) {
            this.updatedAt = updatedAt;
            return this;
        }

        public void WriteJson(JsonWriter writer)
        {
            writer.WriteObjectStart();
            if(this.showcaseId != null)
            {
                writer.WritePropertyName("showcaseId");
                writer.Write(this.showcaseId);
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
            if(this.displayItems != null)
            {
                writer.WritePropertyName("displayItems");
                writer.WriteArrayStart();
                foreach(var item in this.displayItems)
                {
                    item.WriteJson(writer);
                }
                writer.WriteArrayEnd();
            }
            if(this.salesPeriodEventId != null)
            {
                writer.WritePropertyName("salesPeriodEventId");
                writer.Write(this.salesPeriodEventId);
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

    public static string GetShowcaseNameFromGrn(
        string grn
    )
    {
        var match = Regex.Match(grn, "grn:gs2:(?<region>.*):(?<ownerId>.*):showcase:(?<namespaceName>.*):showcase:(?<showcaseName>.*)");
        if (!match.Groups["showcaseName"].Success)
        {
            return null;
        }
        return match.Groups["showcaseName"].Value;
    }

    public static string GetNamespaceNameFromGrn(
        string grn
    )
    {
        var match = Regex.Match(grn, "grn:gs2:(?<region>.*):(?<ownerId>.*):showcase:(?<namespaceName>.*):showcase:(?<showcaseName>.*)");
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
        var match = Regex.Match(grn, "grn:gs2:(?<region>.*):(?<ownerId>.*):showcase:(?<namespaceName>.*):showcase:(?<showcaseName>.*)");
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
        var match = Regex.Match(grn, "grn:gs2:(?<region>.*):(?<ownerId>.*):showcase:(?<namespaceName>.*):showcase:(?<showcaseName>.*)");
        if (!match.Groups["region"].Success)
        {
            return null;
        }
        return match.Groups["region"].Value;
    }

    	[Preserve]
        public static ShowcaseMaster FromDict(JsonData data)
        {
            return new ShowcaseMaster()
                .WithShowcaseId(data.Keys.Contains("showcaseId") && data["showcaseId"] != null ? data["showcaseId"].ToString() : null)
                .WithName(data.Keys.Contains("name") && data["name"] != null ? data["name"].ToString() : null)
                .WithDescription(data.Keys.Contains("description") && data["description"] != null ? data["description"].ToString() : null)
                .WithMetadata(data.Keys.Contains("metadata") && data["metadata"] != null ? data["metadata"].ToString() : null)
                .WithDisplayItems(data.Keys.Contains("displayItems") && data["displayItems"] != null ? data["displayItems"].Cast<JsonData>().Select(value =>
                    {
                        return Gs2.Gs2Showcase.Model.DisplayItemMaster.FromDict(value);
                    }
                ).ToList() : null)
                .WithSalesPeriodEventId(data.Keys.Contains("salesPeriodEventId") && data["salesPeriodEventId"] != null ? data["salesPeriodEventId"].ToString() : null)
                .WithCreatedAt(data.Keys.Contains("createdAt") && data["createdAt"] != null ? (long?)long.Parse(data["createdAt"].ToString()) : null)
                .WithUpdatedAt(data.Keys.Contains("updatedAt") && data["updatedAt"] != null ? (long?)long.Parse(data["updatedAt"].ToString()) : null);
        }

        public int CompareTo(object obj)
        {
            var other = obj as ShowcaseMaster;
            var diff = 0;
            if (showcaseId == null && showcaseId == other.showcaseId)
            {
                // null and null
            }
            else
            {
                diff += showcaseId.CompareTo(other.showcaseId);
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
            if (displayItems == null && displayItems == other.displayItems)
            {
                // null and null
            }
            else
            {
                diff += displayItems.Count - other.displayItems.Count;
                for (var i = 0; i < displayItems.Count; i++)
                {
                    diff += displayItems[i].CompareTo(other.displayItems[i]);
                }
            }
            if (salesPeriodEventId == null && salesPeriodEventId == other.salesPeriodEventId)
            {
                // null and null
            }
            else
            {
                diff += salesPeriodEventId.CompareTo(other.salesPeriodEventId);
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