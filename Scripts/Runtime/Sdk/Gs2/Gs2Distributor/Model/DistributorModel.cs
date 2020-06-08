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

namespace Gs2.Gs2Distributor.Model
{
	[Preserve]
	public class DistributorModel : IComparable
	{

        /** 配信設定 */
        public string distributorModelId { set; get; }

        /**
         * 配信設定を設定
         *
         * @param distributorModelId 配信設定
         * @return this
         */
        public DistributorModel WithDistributorModelId(string distributorModelId) {
            this.distributorModelId = distributorModelId;
            return this;
        }

        /** ディストリビューターの種類名 */
        public string name { set; get; }

        /**
         * ディストリビューターの種類名を設定
         *
         * @param name ディストリビューターの種類名
         * @return this
         */
        public DistributorModel WithName(string name) {
            this.name = name;
            return this;
        }

        /** ディストリビューターの種類のメタデータ */
        public string metadata { set; get; }

        /**
         * ディストリビューターの種類のメタデータを設定
         *
         * @param metadata ディストリビューターの種類のメタデータ
         * @return this
         */
        public DistributorModel WithMetadata(string metadata) {
            this.metadata = metadata;
            return this;
        }

        /** 所持品がキャパシティをオーバーしたときに転送するプレゼントボックスのネームスペース のGRN */
        public string inboxNamespaceId { set; get; }

        /**
         * 所持品がキャパシティをオーバーしたときに転送するプレゼントボックスのネームスペース のGRNを設定
         *
         * @param inboxNamespaceId 所持品がキャパシティをオーバーしたときに転送するプレゼントボックスのネームスペース のGRN
         * @return this
         */
        public DistributorModel WithInboxNamespaceId(string inboxNamespaceId) {
            this.inboxNamespaceId = inboxNamespaceId;
            return this;
        }

        /** ディストリビューターを通して処理出来る対象のリソースGRNのホワイトリスト */
        public List<string> whiteListTargetIds { set; get; }

        /**
         * ディストリビューターを通して処理出来る対象のリソースGRNのホワイトリストを設定
         *
         * @param whiteListTargetIds ディストリビューターを通して処理出来る対象のリソースGRNのホワイトリスト
         * @return this
         */
        public DistributorModel WithWhiteListTargetIds(List<string> whiteListTargetIds) {
            this.whiteListTargetIds = whiteListTargetIds;
            return this;
        }

        public void WriteJson(JsonWriter writer)
        {
            writer.WriteObjectStart();
            if(this.distributorModelId != null)
            {
                writer.WritePropertyName("distributorModelId");
                writer.Write(this.distributorModelId);
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
            if(this.inboxNamespaceId != null)
            {
                writer.WritePropertyName("inboxNamespaceId");
                writer.Write(this.inboxNamespaceId);
            }
            if(this.whiteListTargetIds != null)
            {
                writer.WritePropertyName("whiteListTargetIds");
                writer.WriteArrayStart();
                foreach(var item in this.whiteListTargetIds)
                {
                    writer.Write(item);
                }
                writer.WriteArrayEnd();
            }
            writer.WriteObjectEnd();
        }

    public static string GetDistributorNameFromGrn(
        string grn
    )
    {
        var match = Regex.Match(grn, "grn:gs2:(?<region>.*):(?<ownerId>.*):distributor:(?<namespaceName>.*):model:(?<distributorName>.*)");
        if (!match.Groups["distributorName"].Success)
        {
            return null;
        }
        return match.Groups["distributorName"].Value;
    }

    public static string GetNamespaceNameFromGrn(
        string grn
    )
    {
        var match = Regex.Match(grn, "grn:gs2:(?<region>.*):(?<ownerId>.*):distributor:(?<namespaceName>.*):model:(?<distributorName>.*)");
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
        var match = Regex.Match(grn, "grn:gs2:(?<region>.*):(?<ownerId>.*):distributor:(?<namespaceName>.*):model:(?<distributorName>.*)");
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
        var match = Regex.Match(grn, "grn:gs2:(?<region>.*):(?<ownerId>.*):distributor:(?<namespaceName>.*):model:(?<distributorName>.*)");
        if (!match.Groups["region"].Success)
        {
            return null;
        }
        return match.Groups["region"].Value;
    }

    	[Preserve]
        public static DistributorModel FromDict(JsonData data)
        {
            return new DistributorModel()
                .WithDistributorModelId(data.Keys.Contains("distributorModelId") && data["distributorModelId"] != null ? data["distributorModelId"].ToString() : null)
                .WithName(data.Keys.Contains("name") && data["name"] != null ? data["name"].ToString() : null)
                .WithMetadata(data.Keys.Contains("metadata") && data["metadata"] != null ? data["metadata"].ToString() : null)
                .WithInboxNamespaceId(data.Keys.Contains("inboxNamespaceId") && data["inboxNamespaceId"] != null ? data["inboxNamespaceId"].ToString() : null)
                .WithWhiteListTargetIds(data.Keys.Contains("whiteListTargetIds") && data["whiteListTargetIds"] != null ? data["whiteListTargetIds"].Cast<JsonData>().Select(value =>
                    {
                        return value.ToString();
                    }
                ).ToList() : null);
        }

        public int CompareTo(object obj)
        {
            var other = obj as DistributorModel;
            var diff = 0;
            if (distributorModelId == null && distributorModelId == other.distributorModelId)
            {
                // null and null
            }
            else
            {
                diff += distributorModelId.CompareTo(other.distributorModelId);
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
            if (inboxNamespaceId == null && inboxNamespaceId == other.inboxNamespaceId)
            {
                // null and null
            }
            else
            {
                diff += inboxNamespaceId.CompareTo(other.inboxNamespaceId);
            }
            if (whiteListTargetIds == null && whiteListTargetIds == other.whiteListTargetIds)
            {
                // null and null
            }
            else
            {
                diff += whiteListTargetIds.Count - other.whiteListTargetIds.Count;
                for (var i = 0; i < whiteListTargetIds.Count; i++)
                {
                    diff += whiteListTargetIds[i].CompareTo(other.whiteListTargetIds[i]);
                }
            }
            return diff;
        }
	}
}