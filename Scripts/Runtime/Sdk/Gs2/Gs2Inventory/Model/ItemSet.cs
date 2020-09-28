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

namespace Gs2.Gs2Inventory.Model
{
	[Preserve]
	public class ItemSet : IComparable
	{

        /** 有効期限ごとのアイテム所持数量 */
        public string itemSetId { set; get; }

        /**
         * 有効期限ごとのアイテム所持数量を設定
         *
         * @param itemSetId 有効期限ごとのアイテム所持数量
         * @return this
         */
        public ItemSet WithItemSetId(string itemSetId) {
            this.itemSetId = itemSetId;
            return this;
        }

        /** アイテムセットを識別する名前 */
        public string name { set; get; }

        /**
         * アイテムセットを識別する名前を設定
         *
         * @param name アイテムセットを識別する名前
         * @return this
         */
        public ItemSet WithName(string name) {
            this.name = name;
            return this;
        }

        /** インベントリの名前 */
        public string inventoryName { set; get; }

        /**
         * インベントリの名前を設定
         *
         * @param inventoryName インベントリの名前
         * @return this
         */
        public ItemSet WithInventoryName(string inventoryName) {
            this.inventoryName = inventoryName;
            return this;
        }

        /** ユーザーID */
        public string userId { set; get; }

        /**
         * ユーザーIDを設定
         *
         * @param userId ユーザーID
         * @return this
         */
        public ItemSet WithUserId(string userId) {
            this.userId = userId;
            return this;
        }

        /** アイテムマスターの名前 */
        public string itemName { set; get; }

        /**
         * アイテムマスターの名前を設定
         *
         * @param itemName アイテムマスターの名前
         * @return this
         */
        public ItemSet WithItemName(string itemName) {
            this.itemName = itemName;
            return this;
        }

        /** 所持数量 */
        public long? count { set; get; }

        /**
         * 所持数量を設定
         *
         * @param count 所持数量
         * @return this
         */
        public ItemSet WithCount(long? count) {
            this.count = count;
            return this;
        }

        /** この所持品の参照元リスト */
        public List<string> referenceOf { set; get; }

        /**
         * この所持品の参照元リストを設定
         *
         * @param referenceOf この所持品の参照元リスト
         * @return this
         */
        public ItemSet WithReferenceOf(List<string> referenceOf) {
            this.referenceOf = referenceOf;
            return this;
        }

        /** 表示順番 */
        public int? sortValue { set; get; }

        /**
         * 表示順番を設定
         *
         * @param sortValue 表示順番
         * @return this
         */
        public ItemSet WithSortValue(int? sortValue) {
            this.sortValue = sortValue;
            return this;
        }

        /** 有効期限 */
        public long? expiresAt { set; get; }

        /**
         * 有効期限を設定
         *
         * @param expiresAt 有効期限
         * @return this
         */
        public ItemSet WithExpiresAt(long? expiresAt) {
            this.expiresAt = expiresAt;
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
        public ItemSet WithCreatedAt(long? createdAt) {
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
        public ItemSet WithUpdatedAt(long? updatedAt) {
            this.updatedAt = updatedAt;
            return this;
        }

        public void WriteJson(JsonWriter writer)
        {
            writer.WriteObjectStart();
            if(this.itemSetId != null)
            {
                writer.WritePropertyName("itemSetId");
                writer.Write(this.itemSetId);
            }
            if(this.name != null)
            {
                writer.WritePropertyName("name");
                writer.Write(this.name);
            }
            if(this.inventoryName != null)
            {
                writer.WritePropertyName("inventoryName");
                writer.Write(this.inventoryName);
            }
            if(this.userId != null)
            {
                writer.WritePropertyName("userId");
                writer.Write(this.userId);
            }
            if(this.itemName != null)
            {
                writer.WritePropertyName("itemName");
                writer.Write(this.itemName);
            }
            if(this.count.HasValue)
            {
                writer.WritePropertyName("count");
                writer.Write(this.count.Value);
            }
            if(this.referenceOf != null)
            {
                writer.WritePropertyName("referenceOf");
                writer.WriteArrayStart();
                foreach(var item in this.referenceOf)
                {
                    writer.Write(item);
                }
                writer.WriteArrayEnd();
            }
            if(this.sortValue.HasValue)
            {
                writer.WritePropertyName("sortValue");
                writer.Write(this.sortValue.Value);
            }
            if(this.expiresAt.HasValue)
            {
                writer.WritePropertyName("expiresAt");
                writer.Write(this.expiresAt.Value);
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

    public static string GetItemNameFromGrn(
        string grn
    )
    {
        var match = Regex.Match(grn, "grn:gs2:(?<region>.*):(?<ownerId>.*):inventory:(?<namespaceName>.*):user:(?<userId>.*):inventory:(?<inventoryName>.*):item:(?<itemName>.*):itemSet:(?<itemSetName>.*)");
        if (!match.Groups["itemName"].Success)
        {
            return null;
        }
        return match.Groups["itemName"].Value;
    }

    public static string GetItemSetNameFromGrn(
        string grn
    )
    {
        var match = Regex.Match(grn, "grn:gs2:(?<region>.*):(?<ownerId>.*):inventory:(?<namespaceName>.*):user:(?<userId>.*):inventory:(?<inventoryName>.*):item:(?<itemName>.*):itemSet:(?<itemSetName>.*)");
        if (!match.Groups["itemSetName"].Success)
        {
            return null;
        }
        return match.Groups["itemSetName"].Value;
    }

    public static string GetInventoryNameFromGrn(
        string grn
    )
    {
        var match = Regex.Match(grn, "grn:gs2:(?<region>.*):(?<ownerId>.*):inventory:(?<namespaceName>.*):user:(?<userId>.*):inventory:(?<inventoryName>.*):item:(?<itemName>.*):itemSet:(?<itemSetName>.*)");
        if (!match.Groups["inventoryName"].Success)
        {
            return null;
        }
        return match.Groups["inventoryName"].Value;
    }

    public static string GetUserIdFromGrn(
        string grn
    )
    {
        var match = Regex.Match(grn, "grn:gs2:(?<region>.*):(?<ownerId>.*):inventory:(?<namespaceName>.*):user:(?<userId>.*):inventory:(?<inventoryName>.*):item:(?<itemName>.*):itemSet:(?<itemSetName>.*)");
        if (!match.Groups["userId"].Success)
        {
            return null;
        }
        return match.Groups["userId"].Value;
    }

    public static string GetNamespaceNameFromGrn(
        string grn
    )
    {
        var match = Regex.Match(grn, "grn:gs2:(?<region>.*):(?<ownerId>.*):inventory:(?<namespaceName>.*):user:(?<userId>.*):inventory:(?<inventoryName>.*):item:(?<itemName>.*):itemSet:(?<itemSetName>.*)");
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
        var match = Regex.Match(grn, "grn:gs2:(?<region>.*):(?<ownerId>.*):inventory:(?<namespaceName>.*):user:(?<userId>.*):inventory:(?<inventoryName>.*):item:(?<itemName>.*):itemSet:(?<itemSetName>.*)");
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
        var match = Regex.Match(grn, "grn:gs2:(?<region>.*):(?<ownerId>.*):inventory:(?<namespaceName>.*):user:(?<userId>.*):inventory:(?<inventoryName>.*):item:(?<itemName>.*):itemSet:(?<itemSetName>.*)");
        if (!match.Groups["region"].Success)
        {
            return null;
        }
        return match.Groups["region"].Value;
    }

    	[Preserve]
        public static ItemSet FromDict(JsonData data)
        {
            return new ItemSet()
                .WithItemSetId(data.Keys.Contains("itemSetId") && data["itemSetId"] != null ? data["itemSetId"].ToString() : null)
                .WithName(data.Keys.Contains("name") && data["name"] != null ? data["name"].ToString() : null)
                .WithInventoryName(data.Keys.Contains("inventoryName") && data["inventoryName"] != null ? data["inventoryName"].ToString() : null)
                .WithUserId(data.Keys.Contains("userId") && data["userId"] != null ? data["userId"].ToString() : null)
                .WithItemName(data.Keys.Contains("itemName") && data["itemName"] != null ? data["itemName"].ToString() : null)
                .WithCount(data.Keys.Contains("count") && data["count"] != null ? (long?)long.Parse(data["count"].ToString()) : null)
                .WithReferenceOf(data.Keys.Contains("referenceOf") && data["referenceOf"] != null ? data["referenceOf"].Cast<JsonData>().Select(value =>
                    {
                        return value.ToString();
                    }
                ).ToList() : null)
                .WithSortValue(data.Keys.Contains("sortValue") && data["sortValue"] != null ? (int?)int.Parse(data["sortValue"].ToString()) : null)
                .WithExpiresAt(data.Keys.Contains("expiresAt") && data["expiresAt"] != null ? (long?)long.Parse(data["expiresAt"].ToString()) : null)
                .WithCreatedAt(data.Keys.Contains("createdAt") && data["createdAt"] != null ? (long?)long.Parse(data["createdAt"].ToString()) : null)
                .WithUpdatedAt(data.Keys.Contains("updatedAt") && data["updatedAt"] != null ? (long?)long.Parse(data["updatedAt"].ToString()) : null);
        }

        public int CompareTo(object obj)
        {
            var other = obj as ItemSet;
            var diff = 0;
            if (itemSetId == null && itemSetId == other.itemSetId)
            {
                // null and null
            }
            else
            {
                diff += itemSetId.CompareTo(other.itemSetId);
            }
            if (name == null && name == other.name)
            {
                // null and null
            }
            else
            {
                diff += name.CompareTo(other.name);
            }
            if (inventoryName == null && inventoryName == other.inventoryName)
            {
                // null and null
            }
            else
            {
                diff += inventoryName.CompareTo(other.inventoryName);
            }
            if (userId == null && userId == other.userId)
            {
                // null and null
            }
            else
            {
                diff += userId.CompareTo(other.userId);
            }
            if (itemName == null && itemName == other.itemName)
            {
                // null and null
            }
            else
            {
                diff += itemName.CompareTo(other.itemName);
            }
            if (count == null && count == other.count)
            {
                // null and null
            }
            else
            {
                diff += (int)(count - other.count);
            }
            if (referenceOf == null && referenceOf == other.referenceOf)
            {
                // null and null
            }
            else
            {
                diff += referenceOf.Count - other.referenceOf.Count;
                for (var i = 0; i < referenceOf.Count; i++)
                {
                    diff += referenceOf[i].CompareTo(other.referenceOf[i]);
                }
            }
            if (sortValue == null && sortValue == other.sortValue)
            {
                // null and null
            }
            else
            {
                diff += (int)(sortValue - other.sortValue);
            }
            if (expiresAt == null && expiresAt == other.expiresAt)
            {
                // null and null
            }
            else
            {
                diff += (int)(expiresAt - other.expiresAt);
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