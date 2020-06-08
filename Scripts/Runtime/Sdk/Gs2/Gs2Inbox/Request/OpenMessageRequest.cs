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
using Gs2.Gs2Inbox.Model;
using Gs2.Util.LitJson;
using UnityEngine.Scripting;

namespace Gs2.Gs2Inbox.Request
{
	[Preserve]
	[System.Serializable]
	public class OpenMessageRequest : Gs2Request<OpenMessageRequest>
	{

        /** ネームスペース名 */
		[UnityEngine.SerializeField]
        public string namespaceName;

        /**
         * ネームスペース名を設定
         *
         * @param namespaceName ネームスペース名
         * @return this
         */
        public OpenMessageRequest WithNamespaceName(string namespaceName) {
            this.namespaceName = namespaceName;
            return this;
        }


        /** メッセージID */
		[UnityEngine.SerializeField]
        public string messageName;

        /**
         * メッセージIDを設定
         *
         * @param messageName メッセージID
         * @return this
         */
        public OpenMessageRequest WithMessageName(string messageName) {
            this.messageName = messageName;
            return this;
        }


        /** 重複実行回避機能に使用するID */
		[UnityEngine.SerializeField]
        public string duplicationAvoider;

        /**
         * 重複実行回避機能に使用するIDを設定
         *
         * @param duplicationAvoider 重複実行回避機能に使用するID
         * @return this
         */
        public OpenMessageRequest WithDuplicationAvoider(string duplicationAvoider) {
            this.duplicationAvoider = duplicationAvoider;
            return this;
        }


        /** アクセストークン */
        public string accessToken { set; get; }

        /**
         * アクセストークンを設定
         *
         * @param accessToken アクセストークン
         * @return this
         */
        public OpenMessageRequest WithAccessToken(string accessToken) {
            this.accessToken = accessToken;
            return this;
        }

    	[Preserve]
        public static OpenMessageRequest FromDict(JsonData data)
        {
            return new OpenMessageRequest {
                namespaceName = data.Keys.Contains("namespaceName") && data["namespaceName"] != null ? data["namespaceName"].ToString(): null,
                messageName = data.Keys.Contains("messageName") && data["messageName"] != null ? data["messageName"].ToString(): null,
                duplicationAvoider = data.Keys.Contains("duplicationAvoider") && data["duplicationAvoider"] != null ? data["duplicationAvoider"].ToString(): null,
            };
        }

	}
}