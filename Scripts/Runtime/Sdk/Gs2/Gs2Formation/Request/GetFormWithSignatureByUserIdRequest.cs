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
using Gs2.Gs2Formation.Model;
using Gs2.Util.LitJson;
using UnityEngine.Scripting;

namespace Gs2.Gs2Formation.Request
{
	[Preserve]
	[System.Serializable]
	public class GetFormWithSignatureByUserIdRequest : Gs2Request<GetFormWithSignatureByUserIdRequest>
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
        public GetFormWithSignatureByUserIdRequest WithNamespaceName(string namespaceName) {
            this.namespaceName = namespaceName;
            return this;
        }


        /** ユーザーID */
		[UnityEngine.SerializeField]
        public string userId;

        /**
         * ユーザーIDを設定
         *
         * @param userId ユーザーID
         * @return this
         */
        public GetFormWithSignatureByUserIdRequest WithUserId(string userId) {
            this.userId = userId;
            return this;
        }


        /** フォームの保存領域の名前 */
		[UnityEngine.SerializeField]
        public string moldName;

        /**
         * フォームの保存領域の名前を設定
         *
         * @param moldName フォームの保存領域の名前
         * @return this
         */
        public GetFormWithSignatureByUserIdRequest WithMoldName(string moldName) {
            this.moldName = moldName;
            return this;
        }


        /** 保存領域のインデックス */
		[UnityEngine.SerializeField]
        public int? index;

        /**
         * 保存領域のインデックスを設定
         *
         * @param index 保存領域のインデックス
         * @return this
         */
        public GetFormWithSignatureByUserIdRequest WithIndex(int? index) {
            this.index = index;
            return this;
        }


        /** 署名の発行に使用する暗号鍵 のGRN */
		[UnityEngine.SerializeField]
        public string keyId;

        /**
         * 署名の発行に使用する暗号鍵 のGRNを設定
         *
         * @param keyId 署名の発行に使用する暗号鍵 のGRN
         * @return this
         */
        public GetFormWithSignatureByUserIdRequest WithKeyId(string keyId) {
            this.keyId = keyId;
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
        public GetFormWithSignatureByUserIdRequest WithDuplicationAvoider(string duplicationAvoider) {
            this.duplicationAvoider = duplicationAvoider;
            return this;
        }


    	[Preserve]
        public static GetFormWithSignatureByUserIdRequest FromDict(JsonData data)
        {
            return new GetFormWithSignatureByUserIdRequest {
                namespaceName = data.Keys.Contains("namespaceName") && data["namespaceName"] != null ? data["namespaceName"].ToString(): null,
                userId = data.Keys.Contains("userId") && data["userId"] != null ? data["userId"].ToString(): null,
                moldName = data.Keys.Contains("moldName") && data["moldName"] != null ? data["moldName"].ToString(): null,
                index = data.Keys.Contains("index") && data["index"] != null ? (int?)int.Parse(data["index"].ToString()) : null,
                keyId = data.Keys.Contains("keyId") && data["keyId"] != null ? data["keyId"].ToString(): null,
                duplicationAvoider = data.Keys.Contains("duplicationAvoider") && data["duplicationAvoider"] != null ? data["duplicationAvoider"].ToString(): null,
            };
        }

	}
}