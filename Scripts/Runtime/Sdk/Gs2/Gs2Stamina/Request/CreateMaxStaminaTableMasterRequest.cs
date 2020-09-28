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
using Gs2.Gs2Stamina.Model;
using Gs2.Util.LitJson;
using UnityEngine.Scripting;

namespace Gs2.Gs2Stamina.Request
{
	[Preserve]
	[System.Serializable]
	public class CreateMaxStaminaTableMasterRequest : Gs2Request<CreateMaxStaminaTableMasterRequest>
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
        public CreateMaxStaminaTableMasterRequest WithNamespaceName(string namespaceName) {
            this.namespaceName = namespaceName;
            return this;
        }


        /** 最大スタミナ値テーブル名 */
		[UnityEngine.SerializeField]
        public string name;

        /**
         * 最大スタミナ値テーブル名を設定
         *
         * @param name 最大スタミナ値テーブル名
         * @return this
         */
        public CreateMaxStaminaTableMasterRequest WithName(string name) {
            this.name = name;
            return this;
        }


        /** スタミナの最大値テーブルマスターの説明 */
		[UnityEngine.SerializeField]
        public string description;

        /**
         * スタミナの最大値テーブルマスターの説明を設定
         *
         * @param description スタミナの最大値テーブルマスターの説明
         * @return this
         */
        public CreateMaxStaminaTableMasterRequest WithDescription(string description) {
            this.description = description;
            return this;
        }


        /** 最大スタミナ値テーブルのメタデータ */
		[UnityEngine.SerializeField]
        public string metadata;

        /**
         * 最大スタミナ値テーブルのメタデータを設定
         *
         * @param metadata 最大スタミナ値テーブルのメタデータ
         * @return this
         */
        public CreateMaxStaminaTableMasterRequest WithMetadata(string metadata) {
            this.metadata = metadata;
            return this;
        }


        /** 経験値の種類マスター のGRN */
		[UnityEngine.SerializeField]
        public string experienceModelId;

        /**
         * 経験値の種類マスター のGRNを設定
         *
         * @param experienceModelId 経験値の種類マスター のGRN
         * @return this
         */
        public CreateMaxStaminaTableMasterRequest WithExperienceModelId(string experienceModelId) {
            this.experienceModelId = experienceModelId;
            return this;
        }


        /** ランク毎のスタミナの最大値テーブル */
		[UnityEngine.SerializeField]
        public List<int?> values;

        /**
         * ランク毎のスタミナの最大値テーブルを設定
         *
         * @param values ランク毎のスタミナの最大値テーブル
         * @return this
         */
        public CreateMaxStaminaTableMasterRequest WithValues(List<int?> values) {
            this.values = values;
            return this;
        }


    	[Preserve]
        public static CreateMaxStaminaTableMasterRequest FromDict(JsonData data)
        {
            return new CreateMaxStaminaTableMasterRequest {
                namespaceName = data.Keys.Contains("namespaceName") && data["namespaceName"] != null ? data["namespaceName"].ToString(): null,
                name = data.Keys.Contains("name") && data["name"] != null ? data["name"].ToString(): null,
                description = data.Keys.Contains("description") && data["description"] != null ? data["description"].ToString(): null,
                metadata = data.Keys.Contains("metadata") && data["metadata"] != null ? data["metadata"].ToString(): null,
                experienceModelId = data.Keys.Contains("experienceModelId") && data["experienceModelId"] != null ? data["experienceModelId"].ToString(): null,
                values = data.Keys.Contains("values") && data["values"] != null ? data["values"].Cast<JsonData>().Select(value =>
                    {
                        return (int?)int.Parse(value.ToString());
                    }
                ).ToList() : null,
            };
        }

	}
}