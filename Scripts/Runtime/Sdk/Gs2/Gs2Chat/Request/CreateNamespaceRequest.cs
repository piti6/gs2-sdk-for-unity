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
using Gs2.Core.Control;
using Gs2.Core.Model;
using Gs2.Gs2Chat.Model;
using Gs2.Util.LitJson;
using UnityEngine.Scripting;

namespace Gs2.Gs2Chat.Request
{
	[Preserve]
	[System.Serializable]
	public class CreateNamespaceRequest : Gs2Request<CreateNamespaceRequest>
	{

        /** ネームスペース名 */
		[UnityEngine.SerializeField]
        public string name;

        /**
         * ネームスペース名を設定
         *
         * @param name ネームスペース名
         * @return this
         */
        public CreateNamespaceRequest WithName(string name) {
            this.name = name;
            return this;
        }


        /** ネームスペースの説明 */
		[UnityEngine.SerializeField]
        public string description;

        /**
         * ネームスペースの説明を設定
         *
         * @param description ネームスペースの説明
         * @return this
         */
        public CreateNamespaceRequest WithDescription(string description) {
            this.description = description;
            return this;
        }


        /** ゲームプレイヤーによるルームの作成を許可するか */
		[UnityEngine.SerializeField]
        public bool? allowCreateRoom;

        /**
         * ゲームプレイヤーによるルームの作成を許可するかを設定
         *
         * @param allowCreateRoom ゲームプレイヤーによるルームの作成を許可するか
         * @return this
         */
        public CreateNamespaceRequest WithAllowCreateRoom(bool? allowCreateRoom) {
            this.allowCreateRoom = allowCreateRoom;
            return this;
        }


        /** メッセージを投稿したときに実行するスクリプト */
		[UnityEngine.SerializeField]
        public global::Gs2.Gs2Chat.Model.ScriptSetting postMessageScript;

        /**
         * メッセージを投稿したときに実行するスクリプトを設定
         *
         * @param postMessageScript メッセージを投稿したときに実行するスクリプト
         * @return this
         */
        public CreateNamespaceRequest WithPostMessageScript(global::Gs2.Gs2Chat.Model.ScriptSetting postMessageScript) {
            this.postMessageScript = postMessageScript;
            return this;
        }


        /** ルームを作成したときに実行するスクリプト */
		[UnityEngine.SerializeField]
        public global::Gs2.Gs2Chat.Model.ScriptSetting createRoomScript;

        /**
         * ルームを作成したときに実行するスクリプトを設定
         *
         * @param createRoomScript ルームを作成したときに実行するスクリプト
         * @return this
         */
        public CreateNamespaceRequest WithCreateRoomScript(global::Gs2.Gs2Chat.Model.ScriptSetting createRoomScript) {
            this.createRoomScript = createRoomScript;
            return this;
        }


        /** ルームを削除したときに実行するスクリプト */
		[UnityEngine.SerializeField]
        public global::Gs2.Gs2Chat.Model.ScriptSetting deleteRoomScript;

        /**
         * ルームを削除したときに実行するスクリプトを設定
         *
         * @param deleteRoomScript ルームを削除したときに実行するスクリプト
         * @return this
         */
        public CreateNamespaceRequest WithDeleteRoomScript(global::Gs2.Gs2Chat.Model.ScriptSetting deleteRoomScript) {
            this.deleteRoomScript = deleteRoomScript;
            return this;
        }


        /** ルームを購読したときに実行するスクリプト */
		[UnityEngine.SerializeField]
        public global::Gs2.Gs2Chat.Model.ScriptSetting subscribeRoomScript;

        /**
         * ルームを購読したときに実行するスクリプトを設定
         *
         * @param subscribeRoomScript ルームを購読したときに実行するスクリプト
         * @return this
         */
        public CreateNamespaceRequest WithSubscribeRoomScript(global::Gs2.Gs2Chat.Model.ScriptSetting subscribeRoomScript) {
            this.subscribeRoomScript = subscribeRoomScript;
            return this;
        }


        /** ルームの購読を解除したときに実行するスクリプト */
		[UnityEngine.SerializeField]
        public global::Gs2.Gs2Chat.Model.ScriptSetting unsubscribeRoomScript;

        /**
         * ルームの購読を解除したときに実行するスクリプトを設定
         *
         * @param unsubscribeRoomScript ルームの購読を解除したときに実行するスクリプト
         * @return this
         */
        public CreateNamespaceRequest WithUnsubscribeRoomScript(global::Gs2.Gs2Chat.Model.ScriptSetting unsubscribeRoomScript) {
            this.unsubscribeRoomScript = unsubscribeRoomScript;
            return this;
        }


        /** 購読しているルームに新しい投稿がきたときのプッシュ通知 */
		[UnityEngine.SerializeField]
        public global::Gs2.Gs2Chat.Model.NotificationSetting postNotification;

        /**
         * 購読しているルームに新しい投稿がきたときのプッシュ通知を設定
         *
         * @param postNotification 購読しているルームに新しい投稿がきたときのプッシュ通知
         * @return this
         */
        public CreateNamespaceRequest WithPostNotification(global::Gs2.Gs2Chat.Model.NotificationSetting postNotification) {
            this.postNotification = postNotification;
            return this;
        }


        /** ログの出力設定 */
		[UnityEngine.SerializeField]
        public global::Gs2.Gs2Chat.Model.LogSetting logSetting;

        /**
         * ログの出力設定を設定
         *
         * @param logSetting ログの出力設定
         * @return this
         */
        public CreateNamespaceRequest WithLogSetting(global::Gs2.Gs2Chat.Model.LogSetting logSetting) {
            this.logSetting = logSetting;
            return this;
        }


    	[Preserve]
        public static CreateNamespaceRequest FromDict(JsonData data)
        {
            return new CreateNamespaceRequest {
                name = data.Keys.Contains("name") && data["name"] != null ? data["name"].ToString(): null,
                description = data.Keys.Contains("description") && data["description"] != null ? data["description"].ToString(): null,
                allowCreateRoom = data.Keys.Contains("allowCreateRoom") && data["allowCreateRoom"] != null ? (bool?)bool.Parse(data["allowCreateRoom"].ToString()) : null,
                postMessageScript = data.Keys.Contains("postMessageScript") && data["postMessageScript"] != null ? global::Gs2.Gs2Chat.Model.ScriptSetting.FromDict(data["postMessageScript"]) : null,
                createRoomScript = data.Keys.Contains("createRoomScript") && data["createRoomScript"] != null ? global::Gs2.Gs2Chat.Model.ScriptSetting.FromDict(data["createRoomScript"]) : null,
                deleteRoomScript = data.Keys.Contains("deleteRoomScript") && data["deleteRoomScript"] != null ? global::Gs2.Gs2Chat.Model.ScriptSetting.FromDict(data["deleteRoomScript"]) : null,
                subscribeRoomScript = data.Keys.Contains("subscribeRoomScript") && data["subscribeRoomScript"] != null ? global::Gs2.Gs2Chat.Model.ScriptSetting.FromDict(data["subscribeRoomScript"]) : null,
                unsubscribeRoomScript = data.Keys.Contains("unsubscribeRoomScript") && data["unsubscribeRoomScript"] != null ? global::Gs2.Gs2Chat.Model.ScriptSetting.FromDict(data["unsubscribeRoomScript"]) : null,
                postNotification = data.Keys.Contains("postNotification") && data["postNotification"] != null ? global::Gs2.Gs2Chat.Model.NotificationSetting.FromDict(data["postNotification"]) : null,
                logSetting = data.Keys.Contains("logSetting") && data["logSetting"] != null ? global::Gs2.Gs2Chat.Model.LogSetting.FromDict(data["logSetting"]) : null,
            };
        }

	}
}