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
using Gs2.Gs2Experience.Model;
using LitJson;
using UnityEngine.Scripting;

namespace Gs2.Gs2Experience.Request
{
	[Preserve]
	public class CreateNamespaceRequest : Gs2Request<CreateNamespaceRequest>
	{

        /** ネームスペース名 */
        public string name { set; get; }

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
        public string description { set; get; }

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


        /** ランクキャップ取得時 に実行されるスクリプト のGRN */
        public string experienceCapScriptId { set; get; }

        /**
         * ランクキャップ取得時 に実行されるスクリプト のGRNを設定
         *
         * @param experienceCapScriptId ランクキャップ取得時 に実行されるスクリプト のGRN
         * @return this
         */
        public CreateNamespaceRequest WithExperienceCapScriptId(string experienceCapScriptId) {
            this.experienceCapScriptId = experienceCapScriptId;
            return this;
        }


        /** 経験値変化したときに実行するスクリプト */
        public ScriptSetting changeExperienceScript { set; get; }

        /**
         * 経験値変化したときに実行するスクリプトを設定
         *
         * @param changeExperienceScript 経験値変化したときに実行するスクリプト
         * @return this
         */
        public CreateNamespaceRequest WithChangeExperienceScript(ScriptSetting changeExperienceScript) {
            this.changeExperienceScript = changeExperienceScript;
            return this;
        }


        /** ランク変化したときに実行するスクリプト */
        public ScriptSetting changeRankScript { set; get; }

        /**
         * ランク変化したときに実行するスクリプトを設定
         *
         * @param changeRankScript ランク変化したときに実行するスクリプト
         * @return this
         */
        public CreateNamespaceRequest WithChangeRankScript(ScriptSetting changeRankScript) {
            this.changeRankScript = changeRankScript;
            return this;
        }


        /** ランクキャップ変化したときに実行するスクリプト */
        public ScriptSetting changeRankCapScript { set; get; }

        /**
         * ランクキャップ変化したときに実行するスクリプトを設定
         *
         * @param changeRankCapScript ランクキャップ変化したときに実行するスクリプト
         * @return this
         */
        public CreateNamespaceRequest WithChangeRankCapScript(ScriptSetting changeRankCapScript) {
            this.changeRankCapScript = changeRankCapScript;
            return this;
        }


    	[Preserve]
        public static CreateNamespaceRequest FromDict(JsonData data)
        {
            return new CreateNamespaceRequest {
                name = data.Keys.Contains("name") && data["name"] != null ? (string) data["name"] : null,
                description = data.Keys.Contains("description") && data["description"] != null ? (string) data["description"] : null,
                experienceCapScriptId = data.Keys.Contains("experienceCapScriptId") && data["experienceCapScriptId"] != null ? (string) data["experienceCapScriptId"] : null,
                changeExperienceScript = data.Keys.Contains("changeExperienceScript") && data["changeExperienceScript"] != null ? ScriptSetting.FromDict(data["changeExperienceScript"]) : null,
                changeRankScript = data.Keys.Contains("changeRankScript") && data["changeRankScript"] != null ? ScriptSetting.FromDict(data["changeRankScript"]) : null,
                changeRankCapScript = data.Keys.Contains("changeRankCapScript") && data["changeRankCapScript"] != null ? ScriptSetting.FromDict(data["changeRankCapScript"]) : null,
            };
        }

	}
}