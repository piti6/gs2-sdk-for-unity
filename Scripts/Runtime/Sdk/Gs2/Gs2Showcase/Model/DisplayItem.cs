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
	public class DisplayItem : IComparable
	{

        /** 陳列商品ID */
        public string displayItemId { set; get; }

        /**
         * 陳列商品IDを設定
         *
         * @param displayItemId 陳列商品ID
         * @return this
         */
        public DisplayItem WithDisplayItemId(string displayItemId) {
            this.displayItemId = displayItemId;
            return this;
        }

        /** 種類 */
        public string type { set; get; }

        /**
         * 種類を設定
         *
         * @param type 種類
         * @return this
         */
        public DisplayItem WithType(string type) {
            this.type = type;
            return this;
        }

        /** 陳列する商品 */
        public Gs2.Gs2Showcase.Model.SalesItem salesItem { set; get; }

        /**
         * 陳列する商品を設定
         *
         * @param salesItem 陳列する商品
         * @return this
         */
        public DisplayItem WithSalesItem(Gs2.Gs2Showcase.Model.SalesItem salesItem) {
            this.salesItem = salesItem;
            return this;
        }

        /** 陳列する商品グループ */
        public Gs2.Gs2Showcase.Model.SalesItemGroup salesItemGroup { set; get; }

        /**
         * 陳列する商品グループを設定
         *
         * @param salesItemGroup 陳列する商品グループ
         * @return this
         */
        public DisplayItem WithSalesItemGroup(Gs2.Gs2Showcase.Model.SalesItemGroup salesItemGroup) {
            this.salesItemGroup = salesItemGroup;
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
        public DisplayItem WithSalesPeriodEventId(string salesPeriodEventId) {
            this.salesPeriodEventId = salesPeriodEventId;
            return this;
        }

        public void WriteJson(JsonWriter writer)
        {
            writer.WriteObjectStart();
            if(this.displayItemId != null)
            {
                writer.WritePropertyName("displayItemId");
                writer.Write(this.displayItemId);
            }
            if(this.type != null)
            {
                writer.WritePropertyName("type");
                writer.Write(this.type);
            }
            if(this.salesItem != null)
            {
                writer.WritePropertyName("salesItem");
                this.salesItem.WriteJson(writer);
            }
            if(this.salesItemGroup != null)
            {
                writer.WritePropertyName("salesItemGroup");
                this.salesItemGroup.WriteJson(writer);
            }
            if(this.salesPeriodEventId != null)
            {
                writer.WritePropertyName("salesPeriodEventId");
                writer.Write(this.salesPeriodEventId);
            }
            writer.WriteObjectEnd();
        }

    public static string GetDisplayItemIdFromGrn(
        string grn
    )
    {
        var match = Regex.Match(grn, "grn:gs2:(?<region>.*):(?<ownerId>.*):showcase:(?<namespaceName>.*):salesItem:(?<salesItemName>.*)");
        if (!match.Groups["displayItemId"].Success)
        {
            return null;
        }
        return match.Groups["displayItemId"].Value;
    }

    public static string GetNamespaceNameFromGrn(
        string grn
    )
    {
        var match = Regex.Match(grn, "grn:gs2:(?<region>.*):(?<ownerId>.*):showcase:(?<namespaceName>.*):salesItem:(?<salesItemName>.*)");
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
        var match = Regex.Match(grn, "grn:gs2:(?<region>.*):(?<ownerId>.*):showcase:(?<namespaceName>.*):salesItem:(?<salesItemName>.*)");
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
        var match = Regex.Match(grn, "grn:gs2:(?<region>.*):(?<ownerId>.*):showcase:(?<namespaceName>.*):salesItem:(?<salesItemName>.*)");
        if (!match.Groups["region"].Success)
        {
            return null;
        }
        return match.Groups["region"].Value;
    }

    	[Preserve]
        public static DisplayItem FromDict(JsonData data)
        {
            return new DisplayItem()
                .WithDisplayItemId(data.Keys.Contains("displayItemId") && data["displayItemId"] != null ? data["displayItemId"].ToString() : null)
                .WithType(data.Keys.Contains("type") && data["type"] != null ? data["type"].ToString() : null)
                .WithSalesItem(data.Keys.Contains("salesItem") && data["salesItem"] != null ? Gs2.Gs2Showcase.Model.SalesItem.FromDict(data["salesItem"]) : null)
                .WithSalesItemGroup(data.Keys.Contains("salesItemGroup") && data["salesItemGroup"] != null ? Gs2.Gs2Showcase.Model.SalesItemGroup.FromDict(data["salesItemGroup"]) : null)
                .WithSalesPeriodEventId(data.Keys.Contains("salesPeriodEventId") && data["salesPeriodEventId"] != null ? data["salesPeriodEventId"].ToString() : null);
        }

        public int CompareTo(object obj)
        {
            var other = obj as DisplayItem;
            var diff = 0;
            if (displayItemId == null && displayItemId == other.displayItemId)
            {
                // null and null
            }
            else
            {
                diff += displayItemId.CompareTo(other.displayItemId);
            }
            if (type == null && type == other.type)
            {
                // null and null
            }
            else
            {
                diff += type.CompareTo(other.type);
            }
            if (salesItem == null && salesItem == other.salesItem)
            {
                // null and null
            }
            else
            {
                diff += salesItem.CompareTo(other.salesItem);
            }
            if (salesItemGroup == null && salesItemGroup == other.salesItemGroup)
            {
                // null and null
            }
            else
            {
                diff += salesItemGroup.CompareTo(other.salesItemGroup);
            }
            if (salesPeriodEventId == null && salesPeriodEventId == other.salesPeriodEventId)
            {
                // null and null
            }
            else
            {
                diff += salesPeriodEventId.CompareTo(other.salesPeriodEventId);
            }
            return diff;
        }
	}
}