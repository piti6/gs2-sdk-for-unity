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

namespace Gs2.Gs2Inbox.Model
{
	[Preserve]
	public class Namespace : IComparable
	{

        /** ネームスペース */
        public string namespaceId { set; get; }

        /**
         * ネームスペースを設定
         *
         * @param namespaceId ネームスペース
         * @return this
         */
        public Namespace WithNamespaceId(string namespaceId) {
            this.namespaceId = namespaceId;
            return this;
        }

        /** オーナーID */
        public string ownerId { set; get; }

        /**
         * オーナーIDを設定
         *
         * @param ownerId オーナーID
         * @return this
         */
        public Namespace WithOwnerId(string ownerId) {
            this.ownerId = ownerId;
            return this;
        }

        /** ネームスペース名 */
        public string name { set; get; }

        /**
         * ネームスペース名を設定
         *
         * @param name ネームスペース名
         * @return this
         */
        public Namespace WithName(string name) {
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
        public Namespace WithDescription(string description) {
            this.description = description;
            return this;
        }

        /** 開封したメッセージを自動的に削除するか */
        public bool? isAutomaticDeletingEnabled { set; get; }

        /**
         * 開封したメッセージを自動的に削除するかを設定
         *
         * @param isAutomaticDeletingEnabled 開封したメッセージを自動的に削除するか
         * @return this
         */
        public Namespace WithIsAutomaticDeletingEnabled(bool? isAutomaticDeletingEnabled) {
            this.isAutomaticDeletingEnabled = isAutomaticDeletingEnabled;
            return this;
        }

        /** メッセージ受信したときに実行するスクリプト */
        public Gs2.Gs2Inbox.Model.ScriptSetting receiveMessageScript { set; get; }

        /**
         * メッセージ受信したときに実行するスクリプトを設定
         *
         * @param receiveMessageScript メッセージ受信したときに実行するスクリプト
         * @return this
         */
        public Namespace WithReceiveMessageScript(Gs2.Gs2Inbox.Model.ScriptSetting receiveMessageScript) {
            this.receiveMessageScript = receiveMessageScript;
            return this;
        }

        /** メッセージ開封したときに実行するスクリプト */
        public Gs2.Gs2Inbox.Model.ScriptSetting readMessageScript { set; get; }

        /**
         * メッセージ開封したときに実行するスクリプトを設定
         *
         * @param readMessageScript メッセージ開封したときに実行するスクリプト
         * @return this
         */
        public Namespace WithReadMessageScript(Gs2.Gs2Inbox.Model.ScriptSetting readMessageScript) {
            this.readMessageScript = readMessageScript;
            return this;
        }

        /** メッセージ削除したときに実行するスクリプト */
        public Gs2.Gs2Inbox.Model.ScriptSetting deleteMessageScript { set; get; }

        /**
         * メッセージ削除したときに実行するスクリプトを設定
         *
         * @param deleteMessageScript メッセージ削除したときに実行するスクリプト
         * @return this
         */
        public Namespace WithDeleteMessageScript(Gs2.Gs2Inbox.Model.ScriptSetting deleteMessageScript) {
            this.deleteMessageScript = deleteMessageScript;
            return this;
        }

        /** 報酬付与処理をジョブとして追加するキューネームスペース のGRN */
        public string queueNamespaceId { set; get; }

        /**
         * 報酬付与処理をジョブとして追加するキューネームスペース のGRNを設定
         *
         * @param queueNamespaceId 報酬付与処理をジョブとして追加するキューネームスペース のGRN
         * @return this
         */
        public Namespace WithQueueNamespaceId(string queueNamespaceId) {
            this.queueNamespaceId = queueNamespaceId;
            return this;
        }

        /** 報酬付与処理のスタンプシートで使用する暗号鍵GRN */
        public string keyId { set; get; }

        /**
         * 報酬付与処理のスタンプシートで使用する暗号鍵GRNを設定
         *
         * @param keyId 報酬付与処理のスタンプシートで使用する暗号鍵GRN
         * @return this
         */
        public Namespace WithKeyId(string keyId) {
            this.keyId = keyId;
            return this;
        }

        /** メッセージを受信したときのプッシュ通知 */
        public Gs2.Gs2Inbox.Model.NotificationSetting receiveNotification { set; get; }

        /**
         * メッセージを受信したときのプッシュ通知を設定
         *
         * @param receiveNotification メッセージを受信したときのプッシュ通知
         * @return this
         */
        public Namespace WithReceiveNotification(Gs2.Gs2Inbox.Model.NotificationSetting receiveNotification) {
            this.receiveNotification = receiveNotification;
            return this;
        }

        /** ログの出力設定 */
        public Gs2.Gs2Inbox.Model.LogSetting logSetting { set; get; }

        /**
         * ログの出力設定を設定
         *
         * @param logSetting ログの出力設定
         * @return this
         */
        public Namespace WithLogSetting(Gs2.Gs2Inbox.Model.LogSetting logSetting) {
            this.logSetting = logSetting;
            return this;
        }

        /** None */
        public string status { set; get; }

        /**
         * Noneを設定
         *
         * @param status None
         * @return this
         */
        public Namespace WithStatus(string status) {
            this.status = status;
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
        public Namespace WithCreatedAt(long? createdAt) {
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
        public Namespace WithUpdatedAt(long? updatedAt) {
            this.updatedAt = updatedAt;
            return this;
        }

        public void WriteJson(JsonWriter writer)
        {
            writer.WriteObjectStart();
            if(this.namespaceId != null)
            {
                writer.WritePropertyName("namespaceId");
                writer.Write(this.namespaceId);
            }
            if(this.ownerId != null)
            {
                writer.WritePropertyName("ownerId");
                writer.Write(this.ownerId);
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
            if(this.isAutomaticDeletingEnabled.HasValue)
            {
                writer.WritePropertyName("isAutomaticDeletingEnabled");
                writer.Write(this.isAutomaticDeletingEnabled.Value);
            }
            if(this.receiveMessageScript != null)
            {
                writer.WritePropertyName("receiveMessageScript");
                this.receiveMessageScript.WriteJson(writer);
            }
            if(this.readMessageScript != null)
            {
                writer.WritePropertyName("readMessageScript");
                this.readMessageScript.WriteJson(writer);
            }
            if(this.deleteMessageScript != null)
            {
                writer.WritePropertyName("deleteMessageScript");
                this.deleteMessageScript.WriteJson(writer);
            }
            if(this.queueNamespaceId != null)
            {
                writer.WritePropertyName("queueNamespaceId");
                writer.Write(this.queueNamespaceId);
            }
            if(this.keyId != null)
            {
                writer.WritePropertyName("keyId");
                writer.Write(this.keyId);
            }
            if(this.receiveNotification != null)
            {
                writer.WritePropertyName("receiveNotification");
                this.receiveNotification.WriteJson(writer);
            }
            if(this.logSetting != null)
            {
                writer.WritePropertyName("logSetting");
                this.logSetting.WriteJson(writer);
            }
            if(this.status != null)
            {
                writer.WritePropertyName("status");
                writer.Write(this.status);
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

    public static string GetNamespaceNameFromGrn(
        string grn
    )
    {
        var match = Regex.Match(grn, "grn:gs2:(?<region>.*):(?<ownerId>.*):inbox:(?<namespaceName>.*)");
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
        var match = Regex.Match(grn, "grn:gs2:(?<region>.*):(?<ownerId>.*):inbox:(?<namespaceName>.*)");
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
        var match = Regex.Match(grn, "grn:gs2:(?<region>.*):(?<ownerId>.*):inbox:(?<namespaceName>.*)");
        if (!match.Groups["region"].Success)
        {
            return null;
        }
        return match.Groups["region"].Value;
    }

    	[Preserve]
        public static Namespace FromDict(JsonData data)
        {
            return new Namespace()
                .WithNamespaceId(data.Keys.Contains("namespaceId") && data["namespaceId"] != null ? data["namespaceId"].ToString() : null)
                .WithOwnerId(data.Keys.Contains("ownerId") && data["ownerId"] != null ? data["ownerId"].ToString() : null)
                .WithName(data.Keys.Contains("name") && data["name"] != null ? data["name"].ToString() : null)
                .WithDescription(data.Keys.Contains("description") && data["description"] != null ? data["description"].ToString() : null)
                .WithIsAutomaticDeletingEnabled(data.Keys.Contains("isAutomaticDeletingEnabled") && data["isAutomaticDeletingEnabled"] != null ? (bool?)bool.Parse(data["isAutomaticDeletingEnabled"].ToString()) : null)
                .WithReceiveMessageScript(data.Keys.Contains("receiveMessageScript") && data["receiveMessageScript"] != null ? Gs2.Gs2Inbox.Model.ScriptSetting.FromDict(data["receiveMessageScript"]) : null)
                .WithReadMessageScript(data.Keys.Contains("readMessageScript") && data["readMessageScript"] != null ? Gs2.Gs2Inbox.Model.ScriptSetting.FromDict(data["readMessageScript"]) : null)
                .WithDeleteMessageScript(data.Keys.Contains("deleteMessageScript") && data["deleteMessageScript"] != null ? Gs2.Gs2Inbox.Model.ScriptSetting.FromDict(data["deleteMessageScript"]) : null)
                .WithQueueNamespaceId(data.Keys.Contains("queueNamespaceId") && data["queueNamespaceId"] != null ? data["queueNamespaceId"].ToString() : null)
                .WithKeyId(data.Keys.Contains("keyId") && data["keyId"] != null ? data["keyId"].ToString() : null)
                .WithReceiveNotification(data.Keys.Contains("receiveNotification") && data["receiveNotification"] != null ? Gs2.Gs2Inbox.Model.NotificationSetting.FromDict(data["receiveNotification"]) : null)
                .WithLogSetting(data.Keys.Contains("logSetting") && data["logSetting"] != null ? Gs2.Gs2Inbox.Model.LogSetting.FromDict(data["logSetting"]) : null)
                .WithStatus(data.Keys.Contains("status") && data["status"] != null ? data["status"].ToString() : null)
                .WithCreatedAt(data.Keys.Contains("createdAt") && data["createdAt"] != null ? (long?)long.Parse(data["createdAt"].ToString()) : null)
                .WithUpdatedAt(data.Keys.Contains("updatedAt") && data["updatedAt"] != null ? (long?)long.Parse(data["updatedAt"].ToString()) : null);
        }

        public int CompareTo(object obj)
        {
            var other = obj as Namespace;
            var diff = 0;
            if (namespaceId == null && namespaceId == other.namespaceId)
            {
                // null and null
            }
            else
            {
                diff += namespaceId.CompareTo(other.namespaceId);
            }
            if (ownerId == null && ownerId == other.ownerId)
            {
                // null and null
            }
            else
            {
                diff += ownerId.CompareTo(other.ownerId);
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
            if (isAutomaticDeletingEnabled == null && isAutomaticDeletingEnabled == other.isAutomaticDeletingEnabled)
            {
                // null and null
            }
            else
            {
                diff += isAutomaticDeletingEnabled == other.isAutomaticDeletingEnabled ? 0 : 1;
            }
            if (receiveMessageScript == null && receiveMessageScript == other.receiveMessageScript)
            {
                // null and null
            }
            else
            {
                diff += receiveMessageScript.CompareTo(other.receiveMessageScript);
            }
            if (readMessageScript == null && readMessageScript == other.readMessageScript)
            {
                // null and null
            }
            else
            {
                diff += readMessageScript.CompareTo(other.readMessageScript);
            }
            if (deleteMessageScript == null && deleteMessageScript == other.deleteMessageScript)
            {
                // null and null
            }
            else
            {
                diff += deleteMessageScript.CompareTo(other.deleteMessageScript);
            }
            if (queueNamespaceId == null && queueNamespaceId == other.queueNamespaceId)
            {
                // null and null
            }
            else
            {
                diff += queueNamespaceId.CompareTo(other.queueNamespaceId);
            }
            if (keyId == null && keyId == other.keyId)
            {
                // null and null
            }
            else
            {
                diff += keyId.CompareTo(other.keyId);
            }
            if (receiveNotification == null && receiveNotification == other.receiveNotification)
            {
                // null and null
            }
            else
            {
                diff += receiveNotification.CompareTo(other.receiveNotification);
            }
            if (logSetting == null && logSetting == other.logSetting)
            {
                // null and null
            }
            else
            {
                diff += logSetting.CompareTo(other.logSetting);
            }
            if (status == null && status == other.status)
            {
                // null and null
            }
            else
            {
                diff += status.CompareTo(other.status);
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