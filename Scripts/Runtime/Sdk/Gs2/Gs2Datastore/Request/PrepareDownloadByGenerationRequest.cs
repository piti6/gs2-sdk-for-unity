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
using Gs2.Gs2Datastore.Model;
using Gs2.Util.LitJson;
using UnityEngine.Scripting;

namespace Gs2.Gs2Datastore.Request
{
	[Preserve]
	[System.Serializable]
	public class PrepareDownloadByGenerationRequest : Gs2Request<PrepareDownloadByGenerationRequest>
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
        public PrepareDownloadByGenerationRequest WithNamespaceName(string namespaceName) {
            this.namespaceName = namespaceName;
            return this;
        }


        /** データオブジェクト */
		[UnityEngine.SerializeField]
        public string dataObjectId;

        /**
         * データオブジェクトを設定
         *
         * @param dataObjectId データオブジェクト
         * @return this
         */
        public PrepareDownloadByGenerationRequest WithDataObjectId(string dataObjectId) {
            this.dataObjectId = dataObjectId;
            return this;
        }


        /** 世代 */
		[UnityEngine.SerializeField]
        public string generation;

        /**
         * 世代を設定
         *
         * @param generation 世代
         * @return this
         */
        public PrepareDownloadByGenerationRequest WithGeneration(string generation) {
            this.generation = generation;
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
        public PrepareDownloadByGenerationRequest WithDuplicationAvoider(string duplicationAvoider) {
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
        public PrepareDownloadByGenerationRequest WithAccessToken(string accessToken) {
            this.accessToken = accessToken;
            return this;
        }

    	[Preserve]
        public static PrepareDownloadByGenerationRequest FromDict(JsonData data)
        {
            return new PrepareDownloadByGenerationRequest {
                namespaceName = data.Keys.Contains("namespaceName") && data["namespaceName"] != null ? data["namespaceName"].ToString(): null,
                dataObjectId = data.Keys.Contains("dataObjectId") && data["dataObjectId"] != null ? data["dataObjectId"].ToString(): null,
                generation = data.Keys.Contains("generation") && data["generation"] != null ? data["generation"].ToString(): null,
                duplicationAvoider = data.Keys.Contains("duplicationAvoider") && data["duplicationAvoider"] != null ? data["duplicationAvoider"].ToString(): null,
            };
        }

	}
}