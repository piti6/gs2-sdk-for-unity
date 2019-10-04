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
using Gs2.Gs2Inventory.Model;
using LitJson;
using UnityEngine.Scripting;

namespace Gs2.Gs2Inventory.Request
{
	[Preserve]
	public class UpdateCurrentItemModelMasterRequest : Gs2Request<UpdateCurrentItemModelMasterRequest>
	{

        /** カテゴリー名 */
        public string namespaceName { set; get; }

        /**
         * カテゴリー名を設定
         *
         * @param namespaceName カテゴリー名
         * @return this
         */
        public UpdateCurrentItemModelMasterRequest WithNamespaceName(string namespaceName) {
            this.namespaceName = namespaceName;
            return this;
        }


        /** マスターデータ */
        public string settings { set; get; }

        /**
         * マスターデータを設定
         *
         * @param settings マスターデータ
         * @return this
         */
        public UpdateCurrentItemModelMasterRequest WithSettings(string settings) {
            this.settings = settings;
            return this;
        }


    	[Preserve]
        public static UpdateCurrentItemModelMasterRequest FromDict(JsonData data)
        {
            return new UpdateCurrentItemModelMasterRequest {
                namespaceName = data.Keys.Contains("namespaceName") && data["namespaceName"] != null ? (string) data["namespaceName"] : null,
                settings = data.Keys.Contains("settings") && data["settings"] != null ? (string) data["settings"] : null,
            };
        }

	}
}