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
using Gs2.Gs2Version.Model;
using Gs2.Util.LitJson;
using UnityEngine.Scripting;

namespace Gs2.Gs2Version.Request
{
	[Preserve]
	[System.Serializable]
	public class CreateVersionModelMasterRequest : Gs2Request<CreateVersionModelMasterRequest>
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
        public CreateVersionModelMasterRequest WithNamespaceName(string namespaceName) {
            this.namespaceName = namespaceName;
            return this;
        }


        /** バージョン名 */
		[UnityEngine.SerializeField]
        public string name;

        /**
         * バージョン名を設定
         *
         * @param name バージョン名
         * @return this
         */
        public CreateVersionModelMasterRequest WithName(string name) {
            this.name = name;
            return this;
        }


        /** バージョンマスターの説明 */
		[UnityEngine.SerializeField]
        public string description;

        /**
         * バージョンマスターの説明を設定
         *
         * @param description バージョンマスターの説明
         * @return this
         */
        public CreateVersionModelMasterRequest WithDescription(string description) {
            this.description = description;
            return this;
        }


        /** バージョンのメタデータ */
		[UnityEngine.SerializeField]
        public string metadata;

        /**
         * バージョンのメタデータを設定
         *
         * @param metadata バージョンのメタデータ
         * @return this
         */
        public CreateVersionModelMasterRequest WithMetadata(string metadata) {
            this.metadata = metadata;
            return this;
        }


        /** バージョンアップを促すバージョン */
		[UnityEngine.SerializeField]
        public global::Gs2.Gs2Version.Model.Version_ warningVersion;

        /**
         * バージョンアップを促すバージョンを設定
         *
         * @param warningVersion バージョンアップを促すバージョン
         * @return this
         */
        public CreateVersionModelMasterRequest WithWarningVersion(global::Gs2.Gs2Version.Model.Version_ warningVersion) {
            this.warningVersion = warningVersion;
            return this;
        }


        /** バージョンチェックを蹴るバージョン */
		[UnityEngine.SerializeField]
        public global::Gs2.Gs2Version.Model.Version_ errorVersion;

        /**
         * バージョンチェックを蹴るバージョンを設定
         *
         * @param errorVersion バージョンチェックを蹴るバージョン
         * @return this
         */
        public CreateVersionModelMasterRequest WithErrorVersion(global::Gs2.Gs2Version.Model.Version_ errorVersion) {
            this.errorVersion = errorVersion;
            return this;
        }


        /** 判定に使用するバージョン値の種類 */
		[UnityEngine.SerializeField]
        public string scope;

        /**
         * 判定に使用するバージョン値の種類を設定
         *
         * @param scope 判定に使用するバージョン値の種類
         * @return this
         */
        public CreateVersionModelMasterRequest WithScope(string scope) {
            this.scope = scope;
            return this;
        }


        /** 現在のバージョン */
		[UnityEngine.SerializeField]
        public global::Gs2.Gs2Version.Model.Version_ currentVersion;

        /**
         * 現在のバージョンを設定
         *
         * @param currentVersion 現在のバージョン
         * @return this
         */
        public CreateVersionModelMasterRequest WithCurrentVersion(global::Gs2.Gs2Version.Model.Version_ currentVersion) {
            this.currentVersion = currentVersion;
            return this;
        }


        /** 判定するバージョン値に署名検証を必要とするか */
		[UnityEngine.SerializeField]
        public bool? needSignature;

        /**
         * 判定するバージョン値に署名検証を必要とするかを設定
         *
         * @param needSignature 判定するバージョン値に署名検証を必要とするか
         * @return this
         */
        public CreateVersionModelMasterRequest WithNeedSignature(bool? needSignature) {
            this.needSignature = needSignature;
            return this;
        }


        /** 署名検証に使用する暗号鍵 のGRN */
		[UnityEngine.SerializeField]
        public string signatureKeyId;

        /**
         * 署名検証に使用する暗号鍵 のGRNを設定
         *
         * @param signatureKeyId 署名検証に使用する暗号鍵 のGRN
         * @return this
         */
        public CreateVersionModelMasterRequest WithSignatureKeyId(string signatureKeyId) {
            this.signatureKeyId = signatureKeyId;
            return this;
        }


    	[Preserve]
        public static CreateVersionModelMasterRequest FromDict(JsonData data)
        {
            return new CreateVersionModelMasterRequest {
                namespaceName = data.Keys.Contains("namespaceName") && data["namespaceName"] != null ? data["namespaceName"].ToString(): null,
                name = data.Keys.Contains("name") && data["name"] != null ? data["name"].ToString(): null,
                description = data.Keys.Contains("description") && data["description"] != null ? data["description"].ToString(): null,
                metadata = data.Keys.Contains("metadata") && data["metadata"] != null ? data["metadata"].ToString(): null,
                warningVersion = data.Keys.Contains("warningVersion") && data["warningVersion"] != null ? global::Gs2.Gs2Version.Model.Version_.FromDict(data["warningVersion"]) : null,
                errorVersion = data.Keys.Contains("errorVersion") && data["errorVersion"] != null ? global::Gs2.Gs2Version.Model.Version_.FromDict(data["errorVersion"]) : null,
                scope = data.Keys.Contains("scope") && data["scope"] != null ? data["scope"].ToString(): null,
                currentVersion = data.Keys.Contains("currentVersion") && data["currentVersion"] != null ? global::Gs2.Gs2Version.Model.Version_.FromDict(data["currentVersion"]) : null,
                needSignature = data.Keys.Contains("needSignature") && data["needSignature"] != null ? (bool?)bool.Parse(data["needSignature"].ToString()) : null,
                signatureKeyId = data.Keys.Contains("signatureKeyId") && data["signatureKeyId"] != null ? data["signatureKeyId"].ToString(): null,
            };
        }

	}
}