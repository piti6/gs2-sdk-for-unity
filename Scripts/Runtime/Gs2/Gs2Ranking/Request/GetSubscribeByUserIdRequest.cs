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
using Gs2.Gs2Ranking.Model;
using LitJson;
using UnityEngine.Scripting;

namespace Gs2.Gs2Ranking.Request
{
	[Preserve]
	public class GetSubscribeByUserIdRequest : Gs2Request<GetSubscribeByUserIdRequest>
	{

        /** ネームスペース名 */
        public string namespaceName { set; get; }

        /**
         * ネームスペース名を設定
         *
         * @param namespaceName ネームスペース名
         * @return this
         */
        public GetSubscribeByUserIdRequest WithNamespaceName(string namespaceName) {
            this.namespaceName = namespaceName;
            return this;
        }


        /** カテゴリ名 */
        public string categoryName { set; get; }

        /**
         * カテゴリ名を設定
         *
         * @param categoryName カテゴリ名
         * @return this
         */
        public GetSubscribeByUserIdRequest WithCategoryName(string categoryName) {
            this.categoryName = categoryName;
            return this;
        }


        /** 購読するユーザID */
        public string userId { set; get; }

        /**
         * 購読するユーザIDを設定
         *
         * @param userId 購読するユーザID
         * @return this
         */
        public GetSubscribeByUserIdRequest WithUserId(string userId) {
            this.userId = userId;
            return this;
        }


        /** 購読されるユーザID */
        public string targetUserId { set; get; }

        /**
         * 購読されるユーザIDを設定
         *
         * @param targetUserId 購読されるユーザID
         * @return this
         */
        public GetSubscribeByUserIdRequest WithTargetUserId(string targetUserId) {
            this.targetUserId = targetUserId;
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
        public GetSubscribeByUserIdRequest WithDuplicationAvoider(string duplicationAvoider) {
            this.duplicationAvoider = duplicationAvoider;
            return this;
        }


    	[Preserve]
        public static GetSubscribeByUserIdRequest FromDict(JsonData data)
        {
            return new GetSubscribeByUserIdRequest {
                namespaceName = data.Keys.Contains("namespaceName") && data["namespaceName"] != null ? (string) data["namespaceName"] : null,
                categoryName = data.Keys.Contains("categoryName") && data["categoryName"] != null ? (string) data["categoryName"] : null,
                userId = data.Keys.Contains("userId") && data["userId"] != null ? (string) data["userId"] : null,
                targetUserId = data.Keys.Contains("targetUserId") && data["targetUserId"] != null ? (string) data["targetUserId"] : null,
                duplicationAvoider = data.Keys.Contains("duplicationAvoider") && data["duplicationAvoider"] != null ? (string) data["duplicationAvoider"] : null,
            };
        }

	}
}