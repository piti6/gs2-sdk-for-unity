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

namespace Gs2.Gs2Stamina.Model
{
	[Preserve]
	public class RecoverIntervalTable : IComparable
	{

        /** スタミナ回復間隔テーブルマスター */
        public string recoverIntervalTableId { set; get; }

        /**
         * スタミナ回復間隔テーブルマスターを設定
         *
         * @param recoverIntervalTableId スタミナ回復間隔テーブルマスター
         * @return this
         */
        public RecoverIntervalTable WithRecoverIntervalTableId(string recoverIntervalTableId) {
            this.recoverIntervalTableId = recoverIntervalTableId;
            return this;
        }

        /** スタミナ回復間隔テーブル名 */
        public string name { set; get; }

        /**
         * スタミナ回復間隔テーブル名を設定
         *
         * @param name スタミナ回復間隔テーブル名
         * @return this
         */
        public RecoverIntervalTable WithName(string name) {
            this.name = name;
            return this;
        }

        /** スタミナ回復間隔テーブルのメタデータ */
        public string metadata { set; get; }

        /**
         * スタミナ回復間隔テーブルのメタデータを設定
         *
         * @param metadata スタミナ回復間隔テーブルのメタデータ
         * @return this
         */
        public RecoverIntervalTable WithMetadata(string metadata) {
            this.metadata = metadata;
            return this;
        }

        /** 経験値の種類マスター のGRN */
        public string experienceModelId { set; get; }

        /**
         * 経験値の種類マスター のGRNを設定
         *
         * @param experienceModelId 経験値の種類マスター のGRN
         * @return this
         */
        public RecoverIntervalTable WithExperienceModelId(string experienceModelId) {
            this.experienceModelId = experienceModelId;
            return this;
        }

        /** ランク毎のスタミナ回復間隔テーブル */
        public List<int?> values { set; get; }

        /**
         * ランク毎のスタミナ回復間隔テーブルを設定
         *
         * @param values ランク毎のスタミナ回復間隔テーブル
         * @return this
         */
        public RecoverIntervalTable WithValues(List<int?> values) {
            this.values = values;
            return this;
        }

        public void WriteJson(JsonWriter writer)
        {
            writer.WriteObjectStart();
            if(this.recoverIntervalTableId != null)
            {
                writer.WritePropertyName("recoverIntervalTableId");
                writer.Write(this.recoverIntervalTableId);
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
            if(this.experienceModelId != null)
            {
                writer.WritePropertyName("experienceModelId");
                writer.Write(this.experienceModelId);
            }
            if(this.values != null)
            {
                writer.WritePropertyName("values");
                writer.WriteArrayStart();
                foreach(var item in this.values)
                {
                    writer.Write(item.Value);
                }
                writer.WriteArrayEnd();
            }
            writer.WriteObjectEnd();
        }

    public static string GetRecoverIntervalTableNameFromGrn(
        string grn
    )
    {
        var match = Regex.Match(grn, "grn:gs2:(?<region>.*):(?<ownerId>.*):stamina:(?<namespaceName>.*):recoverIntervalTable:(?<recoverIntervalTableName>.*)");
        if (!match.Groups["recoverIntervalTableName"].Success)
        {
            return null;
        }
        return match.Groups["recoverIntervalTableName"].Value;
    }

    public static string GetNamespaceNameFromGrn(
        string grn
    )
    {
        var match = Regex.Match(grn, "grn:gs2:(?<region>.*):(?<ownerId>.*):stamina:(?<namespaceName>.*):recoverIntervalTable:(?<recoverIntervalTableName>.*)");
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
        var match = Regex.Match(grn, "grn:gs2:(?<region>.*):(?<ownerId>.*):stamina:(?<namespaceName>.*):recoverIntervalTable:(?<recoverIntervalTableName>.*)");
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
        var match = Regex.Match(grn, "grn:gs2:(?<region>.*):(?<ownerId>.*):stamina:(?<namespaceName>.*):recoverIntervalTable:(?<recoverIntervalTableName>.*)");
        if (!match.Groups["region"].Success)
        {
            return null;
        }
        return match.Groups["region"].Value;
    }

    	[Preserve]
        public static RecoverIntervalTable FromDict(JsonData data)
        {
            return new RecoverIntervalTable()
                .WithRecoverIntervalTableId(data.Keys.Contains("recoverIntervalTableId") && data["recoverIntervalTableId"] != null ? data["recoverIntervalTableId"].ToString() : null)
                .WithName(data.Keys.Contains("name") && data["name"] != null ? data["name"].ToString() : null)
                .WithMetadata(data.Keys.Contains("metadata") && data["metadata"] != null ? data["metadata"].ToString() : null)
                .WithExperienceModelId(data.Keys.Contains("experienceModelId") && data["experienceModelId"] != null ? data["experienceModelId"].ToString() : null)
                .WithValues(data.Keys.Contains("values") && data["values"] != null ? data["values"].Cast<JsonData>().Select(value =>
                    {
                        return (int?)int.Parse(value.ToString());
                    }
                ).ToList() : null);
        }

        public int CompareTo(object obj)
        {
            var other = obj as RecoverIntervalTable;
            var diff = 0;
            if (recoverIntervalTableId == null && recoverIntervalTableId == other.recoverIntervalTableId)
            {
                // null and null
            }
            else
            {
                diff += recoverIntervalTableId.CompareTo(other.recoverIntervalTableId);
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
            if (experienceModelId == null && experienceModelId == other.experienceModelId)
            {
                // null and null
            }
            else
            {
                diff += experienceModelId.CompareTo(other.experienceModelId);
            }
            if (values == null && values == other.values)
            {
                // null and null
            }
            else
            {
                diff += values.Count - other.values.Count;
                for (var i = 0; i < values.Count; i++)
                {
                    diff += (int)(values[i] - other.values[i]);
                }
            }
            return diff;
        }
	}
}