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
using Gs2.Gs2Account.Model;
using LitJson;
using UnityEngine.Scripting;

namespace Gs2.Gs2Account.Request
{
	[Preserve]
	public class DeleteTakeOverByUserIdentifierRequest : Gs2Request<DeleteTakeOverByUserIdentifierRequest>
	{

        /** ネームスペース名 */
        public string namespaceName { set; get; }

        /**
         * ネームスペース名を設定
         *
         * @param namespaceName ネームスペース名
         * @return this
         */
        public DeleteTakeOverByUserIdentifierRequest WithNamespaceName(string namespaceName) {
            this.namespaceName = namespaceName;
            return this;
        }


        /** スロット番号 */
        public int? type { set; get; }

        /**
         * スロット番号を設定
         *
         * @param type スロット番号
         * @return this
         */
        public DeleteTakeOverByUserIdentifierRequest WithType(int? type) {
            this.type = type;
            return this;
        }


        /** 引き継ぎ用ユーザーID */
        public string userIdentifier { set; get; }

        /**
         * 引き継ぎ用ユーザーIDを設定
         *
         * @param userIdentifier 引き継ぎ用ユーザーID
         * @return this
         */
        public DeleteTakeOverByUserIdentifierRequest WithUserIdentifier(string userIdentifier) {
            this.userIdentifier = userIdentifier;
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
        public DeleteTakeOverByUserIdentifierRequest WithDuplicationAvoider(string duplicationAvoider) {
            this.duplicationAvoider = duplicationAvoider;
            return this;
        }


    	[Preserve]
        public static DeleteTakeOverByUserIdentifierRequest FromDict(JsonData data)
        {
            return new DeleteTakeOverByUserIdentifierRequest {
                namespaceName = data.Keys.Contains("namespaceName") && data["namespaceName"] != null ? (string) data["namespaceName"] : null,
                type = data.Keys.Contains("type") && data["type"] != null ? (int?) data["type"] : null,
                userIdentifier = data.Keys.Contains("userIdentifier") && data["userIdentifier"] != null ? (string) data["userIdentifier"] : null,
                duplicationAvoider = data.Keys.Contains("duplicationAvoider") && data["duplicationAvoider"] != null ? (string) data["duplicationAvoider"] : null,
            };
        }

	}
}