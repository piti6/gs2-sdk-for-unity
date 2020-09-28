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

namespace Gs2.Gs2Lottery.Model
{
	[Preserve]
	public class PrizeTable : IComparable
	{

        /** 排出確率テーブルマスター */
        public string prizeTableId { set; get; }

        /**
         * 排出確率テーブルマスターを設定
         *
         * @param prizeTableId 排出確率テーブルマスター
         * @return this
         */
        public PrizeTable WithPrizeTableId(string prizeTableId) {
            this.prizeTableId = prizeTableId;
            return this;
        }

        /** 景品テーブル名 */
        public string name { set; get; }

        /**
         * 景品テーブル名を設定
         *
         * @param name 景品テーブル名
         * @return this
         */
        public PrizeTable WithName(string name) {
            this.name = name;
            return this;
        }

        /** 景品テーブルのメタデータ */
        public string metadata { set; get; }

        /**
         * 景品テーブルのメタデータを設定
         *
         * @param metadata 景品テーブルのメタデータ
         * @return this
         */
        public PrizeTable WithMetadata(string metadata) {
            this.metadata = metadata;
            return this;
        }

        /** 景品リスト */
        public List<Prize> prizes { set; get; }

        /**
         * 景品リストを設定
         *
         * @param prizes 景品リスト
         * @return this
         */
        public PrizeTable WithPrizes(List<Prize> prizes) {
            this.prizes = prizes;
            return this;
        }

        public void WriteJson(JsonWriter writer)
        {
            writer.WriteObjectStart();
            if(this.prizeTableId != null)
            {
                writer.WritePropertyName("prizeTableId");
                writer.Write(this.prizeTableId);
            }
            if(this.name != null)
            {
                writer.WritePropertyName("name");
                writer.Write(this.name);
            }
            if(this.metadata != null)
            {
                writer.WritePropertyName("metadata");
                writer.Write(this.metadata);
            }
            if(this.prizes != null)
            {
                writer.WritePropertyName("prizes");
                writer.WriteArrayStart();
                foreach(var item in this.prizes)
                {
                    item.WriteJson(writer);
                }
                writer.WriteArrayEnd();
            }
            writer.WriteObjectEnd();
        }

    public static string GetPrizeTableNameFromGrn(
        string grn
    )
    {
        var match = Regex.Match(grn, "grn:gs2:(?<region>.*):(?<ownerId>.*):lottery:(?<namespaceName>.*):table:(?<prizeTableName>.*)");
        if (!match.Groups["prizeTableName"].Success)
        {
            return null;
        }
        return match.Groups["prizeTableName"].Value;
    }

    public static string GetNamespaceNameFromGrn(
        string grn
    )
    {
        var match = Regex.Match(grn, "grn:gs2:(?<region>.*):(?<ownerId>.*):lottery:(?<namespaceName>.*):table:(?<prizeTableName>.*)");
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
        var match = Regex.Match(grn, "grn:gs2:(?<region>.*):(?<ownerId>.*):lottery:(?<namespaceName>.*):table:(?<prizeTableName>.*)");
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
        var match = Regex.Match(grn, "grn:gs2:(?<region>.*):(?<ownerId>.*):lottery:(?<namespaceName>.*):table:(?<prizeTableName>.*)");
        if (!match.Groups["region"].Success)
        {
            return null;
        }
        return match.Groups["region"].Value;
    }

    	[Preserve]
        public static PrizeTable FromDict(JsonData data)
        {
            return new PrizeTable()
                .WithPrizeTableId(data.Keys.Contains("prizeTableId") && data["prizeTableId"] != null ? data["prizeTableId"].ToString() : null)
                .WithName(data.Keys.Contains("name") && data["name"] != null ? data["name"].ToString() : null)
                .WithMetadata(data.Keys.Contains("metadata") && data["metadata"] != null ? data["metadata"].ToString() : null)
                .WithPrizes(data.Keys.Contains("prizes") && data["prizes"] != null ? data["prizes"].Cast<JsonData>().Select(value =>
                    {
                        return Gs2.Gs2Lottery.Model.Prize.FromDict(value);
                    }
                ).ToList() : null);
        }

        public int CompareTo(object obj)
        {
            var other = obj as PrizeTable;
            var diff = 0;
            if (prizeTableId == null && prizeTableId == other.prizeTableId)
            {
                // null and null
            }
            else
            {
                diff += prizeTableId.CompareTo(other.prizeTableId);
            }
            if (name == null && name == other.name)
            {
                // null and null
            }
            else
            {
                diff += name.CompareTo(other.name);
            }
            if (metadata == null && metadata == other.metadata)
            {
                // null and null
            }
            else
            {
                diff += metadata.CompareTo(other.metadata);
            }
            if (prizes == null && prizes == other.prizes)
            {
                // null and null
            }
            else
            {
                diff += prizes.Count - other.prizes.Count;
                for (var i = 0; i < prizes.Count; i++)
                {
                    diff += prizes[i].CompareTo(other.prizes[i]);
                }
            }
            return diff;
        }
	}
}