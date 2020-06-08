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

namespace Gs2.Gs2Key.Model
{
	[Preserve]
	public class GitHubApiKey : IComparable
	{

        /** GitHub のAPIキー */
        public string apiKeyId { set; get; }

        /**
         * GitHub のAPIキーを設定
         *
         * @param apiKeyId GitHub のAPIキー
         * @return this
         */
        public GitHubApiKey WithApiKeyId(string apiKeyId) {
            this.apiKeyId = apiKeyId;
            return this;
        }

        /** GitHub APIキー名 */
        public string name { set; get; }

        /**
         * GitHub APIキー名を設定
         *
         * @param name GitHub APIキー名
         * @return this
         */
        public GitHubApiKey WithName(string name) {
            this.name = name;
            return this;
        }

        /** 説明文 */
        public string description { set; get; }

        /**
         * 説明文を設定
         *
         * @param description 説明文
         * @return this
         */
        public GitHubApiKey WithDescription(string description) {
            this.description = description;
            return this;
        }

        /** APIキー */
        public string apiKey { set; get; }

        /**
         * APIキーを設定
         *
         * @param apiKey APIキー
         * @return this
         */
        public GitHubApiKey WithApiKey(string apiKey) {
            this.apiKey = apiKey;
            return this;
        }

        /** APIキーの暗号化に使用する暗号鍵名 */
        public string encryptionKeyName { set; get; }

        /**
         * APIキーの暗号化に使用する暗号鍵名を設定
         *
         * @param encryptionKeyName APIキーの暗号化に使用する暗号鍵名
         * @return this
         */
        public GitHubApiKey WithEncryptionKeyName(string encryptionKeyName) {
            this.encryptionKeyName = encryptionKeyName;
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
        public GitHubApiKey WithCreatedAt(long? createdAt) {
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
        public GitHubApiKey WithUpdatedAt(long? updatedAt) {
            this.updatedAt = updatedAt;
            return this;
        }

        public void WriteJson(JsonWriter writer)
        {
            writer.WriteObjectStart();
            if(this.apiKeyId != null)
            {
                writer.WritePropertyName("apiKeyId");
                writer.Write(this.apiKeyId);
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
            if(this.apiKey != null)
            {
                writer.WritePropertyName("apiKey");
                writer.Write(this.apiKey);
            }
            if(this.encryptionKeyName != null)
            {
                writer.WritePropertyName("encryptionKeyName");
                writer.Write(this.encryptionKeyName);
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

    public static string GetApiKeyNameFromGrn(
        string grn
    )
    {
        var match = Regex.Match(grn, "grn:gs2:(?<region>.*):(?<ownerId>.*):key:(?<namespaceName>.*):github:(?<apiKeyName>.*)");
        if (!match.Groups["apiKeyName"].Success)
        {
            return null;
        }
        return match.Groups["apiKeyName"].Value;
    }

    public static string GetNamespaceNameFromGrn(
        string grn
    )
    {
        var match = Regex.Match(grn, "grn:gs2:(?<region>.*):(?<ownerId>.*):key:(?<namespaceName>.*):github:(?<apiKeyName>.*)");
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
        var match = Regex.Match(grn, "grn:gs2:(?<region>.*):(?<ownerId>.*):key:(?<namespaceName>.*):github:(?<apiKeyName>.*)");
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
        var match = Regex.Match(grn, "grn:gs2:(?<region>.*):(?<ownerId>.*):key:(?<namespaceName>.*):github:(?<apiKeyName>.*)");
        if (!match.Groups["region"].Success)
        {
            return null;
        }
        return match.Groups["region"].Value;
    }

    	[Preserve]
        public static GitHubApiKey FromDict(JsonData data)
        {
            return new GitHubApiKey()
                .WithApiKeyId(data.Keys.Contains("apiKeyId") && data["apiKeyId"] != null ? data["apiKeyId"].ToString() : null)
                .WithName(data.Keys.Contains("name") && data["name"] != null ? data["name"].ToString() : null)
                .WithDescription(data.Keys.Contains("description") && data["description"] != null ? data["description"].ToString() : null)
                .WithApiKey(data.Keys.Contains("apiKey") && data["apiKey"] != null ? data["apiKey"].ToString() : null)
                .WithEncryptionKeyName(data.Keys.Contains("encryptionKeyName") && data["encryptionKeyName"] != null ? data["encryptionKeyName"].ToString() : null)
                .WithCreatedAt(data.Keys.Contains("createdAt") && data["createdAt"] != null ? (long?)long.Parse(data["createdAt"].ToString()) : null)
                .WithUpdatedAt(data.Keys.Contains("updatedAt") && data["updatedAt"] != null ? (long?)long.Parse(data["updatedAt"].ToString()) : null);
        }

        public int CompareTo(object obj)
        {
            var other = obj as GitHubApiKey;
            var diff = 0;
            if (apiKeyId == null && apiKeyId == other.apiKeyId)
            {
                // null and null
            }
            else
            {
                diff += apiKeyId.CompareTo(other.apiKeyId);
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
            if (apiKey == null && apiKey == other.apiKey)
            {
                // null and null
            }
            else
            {
                diff += apiKey.CompareTo(other.apiKey);
            }
            if (encryptionKeyName == null && encryptionKeyName == other.encryptionKeyName)
            {
                // null and null
            }
            else
            {
                diff += encryptionKeyName.CompareTo(other.encryptionKeyName);
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