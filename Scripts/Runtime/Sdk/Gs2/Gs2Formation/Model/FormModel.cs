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

namespace Gs2.Gs2Formation.Model
{
	[Preserve]
	public class FormModel : IComparable
	{

        /** フォームマスター */
        public string formModelId { set; get; }

        /**
         * フォームマスターを設定
         *
         * @param formModelId フォームマスター
         * @return this
         */
        public FormModel WithFormModelId(string formModelId) {
            this.formModelId = formModelId;
            return this;
        }

        /** フォームの種類名 */
        public string name { set; get; }

        /**
         * フォームの種類名を設定
         *
         * @param name フォームの種類名
         * @return this
         */
        public FormModel WithName(string name) {
            this.name = name;
            return this;
        }

        /** フォームの種類のメタデータ */
        public string metadata { set; get; }

        /**
         * フォームの種類のメタデータを設定
         *
         * @param metadata フォームの種類のメタデータ
         * @return this
         */
        public FormModel WithMetadata(string metadata) {
            this.metadata = metadata;
            return this;
        }

        /** スリットリスト */
        public List<SlotModel> slots { set; get; }

        /**
         * スリットリストを設定
         *
         * @param slots スリットリスト
         * @return this
         */
        public FormModel WithSlots(List<SlotModel> slots) {
            this.slots = slots;
            return this;
        }

        public void WriteJson(JsonWriter writer)
        {
            writer.WriteObjectStart();
            if(this.formModelId != null)
            {
                writer.WritePropertyName("formModelId");
                writer.Write(this.formModelId);
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
            if(this.slots != null)
            {
                writer.WritePropertyName("slots");
                writer.WriteArrayStart();
                foreach(var item in this.slots)
                {
                    item.WriteJson(writer);
                }
                writer.WriteArrayEnd();
            }
            writer.WriteObjectEnd();
        }

    public static string GetFormModelNameFromGrn(
        string grn
    )
    {
        var match = Regex.Match(grn, "grn:gs2:(?<region>.*):(?<ownerId>.*):formation:(?<namespaceName>.*):model:(?<formModelName>.*)");
        if (!match.Groups["formModelName"].Success)
        {
            return null;
        }
        return match.Groups["formModelName"].Value;
    }

    public static string GetMoldNameFromGrn(
        string grn
    )
    {
        var match = Regex.Match(grn, "grn:gs2:(?<region>.*):(?<ownerId>.*):formation:(?<namespaceName>.*):model:(?<formModelName>.*)");
        if (!match.Groups["moldName"].Success)
        {
            return null;
        }
        return match.Groups["moldName"].Value;
    }

    public static string GetNamespaceNameFromGrn(
        string grn
    )
    {
        var match = Regex.Match(grn, "grn:gs2:(?<region>.*):(?<ownerId>.*):formation:(?<namespaceName>.*):model:(?<formModelName>.*)");
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
        var match = Regex.Match(grn, "grn:gs2:(?<region>.*):(?<ownerId>.*):formation:(?<namespaceName>.*):model:(?<formModelName>.*)");
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
        var match = Regex.Match(grn, "grn:gs2:(?<region>.*):(?<ownerId>.*):formation:(?<namespaceName>.*):model:(?<formModelName>.*)");
        if (!match.Groups["region"].Success)
        {
            return null;
        }
        return match.Groups["region"].Value;
    }

    	[Preserve]
        public static FormModel FromDict(JsonData data)
        {
            return new FormModel()
                .WithFormModelId(data.Keys.Contains("formModelId") && data["formModelId"] != null ? data["formModelId"].ToString() : null)
                .WithName(data.Keys.Contains("name") && data["name"] != null ? data["name"].ToString() : null)
                .WithMetadata(data.Keys.Contains("metadata") && data["metadata"] != null ? data["metadata"].ToString() : null)
                .WithSlots(data.Keys.Contains("slots") && data["slots"] != null ? data["slots"].Cast<JsonData>().Select(value =>
                    {
                        return Gs2.Gs2Formation.Model.SlotModel.FromDict(value);
                    }
                ).ToList() : null);
        }

        public int CompareTo(object obj)
        {
            var other = obj as FormModel;
            var diff = 0;
            if (formModelId == null && formModelId == other.formModelId)
            {
                // null and null
            }
            else
            {
                diff += formModelId.CompareTo(other.formModelId);
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
            if (slots == null && slots == other.slots)
            {
                // null and null
            }
            else
            {
                diff += slots.Count - other.slots.Count;
                for (var i = 0; i < slots.Count; i++)
                {
                    diff += slots[i].CompareTo(other.slots[i]);
                }
            }
            return diff;
        }
	}
}