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
using Gs2.Gs2Gateway.Model;
using LitJson;
using UnityEngine.Scripting;

namespace Gs2.Gs2Gateway.Request
{
	[Preserve]
	public class SetUserIdRequest : Gs2Request<SetUserIdRequest>
	{

        /** ネームスペース名 */
        public string namespaceName { set; get; }

        /**
         * ネームスペース名を設定
         *
         * @param namespaceName ネームスペース名
         * @return this
         */
        public SetUserIdRequest WithNamespaceName(string namespaceName) {
            this.namespaceName = namespaceName;
            return this;
        }


        /** 同時に異なるクライアントからの接続を許容するか */
        public bool? allowConcurrentAccess { set; get; }

        /**
         * 同時に異なるクライアントからの接続を許容するかを設定
         *
         * @param allowConcurrentAccess 同時に異なるクライアントからの接続を許容するか
         * @return this
         */
        public SetUserIdRequest WithAllowConcurrentAccess(bool? allowConcurrentAccess) {
            this.allowConcurrentAccess = allowConcurrentAccess;
            return this;
        }


        /** 重複実行回避機能に使用するID */
        public string duplicationAvoider { set; get; }

        /**
         * 重複実行回避機能に使用するIDを設定
         *
         * @param duplicationAvoider 重複実行回避機能に使用するID
         * @return this
         */
        public SetUserIdRequest WithDuplicationAvoider(string duplicationAvoider) {
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
        public SetUserIdRequest WithAccessToken(string accessToken) {
            this.accessToken = accessToken;
            return this;
        }

    	[Preserve]
        public static SetUserIdRequest FromDict(JsonData data)
        {
            return new SetUserIdRequest {
                namespaceName = data.Keys.Contains("namespaceName") && data["namespaceName"] != null ? (string) data["namespaceName"] : null,
                allowConcurrentAccess = data.Keys.Contains("allowConcurrentAccess") && data["allowConcurrentAccess"] != null ? (bool?) data["allowConcurrentAccess"] : null,
                duplicationAvoider = data.Keys.Contains("duplicationAvoider") && data["duplicationAvoider"] != null ? (string) data["duplicationAvoider"] : null,
            };
        }

	}
}