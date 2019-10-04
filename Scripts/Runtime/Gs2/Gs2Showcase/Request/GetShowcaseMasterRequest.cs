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
using Gs2.Gs2Showcase.Model;
using LitJson;
using UnityEngine.Scripting;

namespace Gs2.Gs2Showcase.Request
{
	[Preserve]
	public class GetShowcaseMasterRequest : Gs2Request<GetShowcaseMasterRequest>
	{

        /** ネームスペース名 */
        public string namespaceName { set; get; }

        /**
         * ネームスペース名を設定
         *
         * @param namespaceName ネームスペース名
         * @return this
         */
        public GetShowcaseMasterRequest WithNamespaceName(string namespaceName) {
            this.namespaceName = namespaceName;
            return this;
        }


        /** 陳列棚名 */
        public string showcaseName { set; get; }

        /**
         * 陳列棚名を設定
         *
         * @param showcaseName 陳列棚名
         * @return this
         */
        public GetShowcaseMasterRequest WithShowcaseName(string showcaseName) {
            this.showcaseName = showcaseName;
            return this;
        }


    	[Preserve]
        public static GetShowcaseMasterRequest FromDict(JsonData data)
        {
            return new GetShowcaseMasterRequest {
                namespaceName = data.Keys.Contains("namespaceName") && data["namespaceName"] != null ? (string) data["namespaceName"] : null,
                showcaseName = data.Keys.Contains("showcaseName") && data["showcaseName"] != null ? (string) data["showcaseName"] : null,
            };
        }

	}
}