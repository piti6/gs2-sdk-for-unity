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
using Gs2.Gs2Limit.Model;
using LitJson;
using UnityEngine.Scripting;

namespace Gs2.Gs2Limit.Request
{
	[Preserve]
	public class GetLimitModelRequest : Gs2Request<GetLimitModelRequest>
	{

        /** ネームスペース名 */
        public string namespaceName { set; get; }

        /**
         * ネームスペース名を設定
         *
         * @param namespaceName ネームスペース名
         * @return this
         */
        public GetLimitModelRequest WithNamespaceName(string namespaceName) {
            this.namespaceName = namespaceName;
            return this;
        }


        /** 回数制限の種類名 */
        public string limitName { set; get; }

        /**
         * 回数制限の種類名を設定
         *
         * @param limitName 回数制限の種類名
         * @return this
         */
        public GetLimitModelRequest WithLimitName(string limitName) {
            this.limitName = limitName;
            return this;
        }


    	[Preserve]
        public static GetLimitModelRequest FromDict(JsonData data)
        {
            return new GetLimitModelRequest {
                namespaceName = data.Keys.Contains("namespaceName") && data["namespaceName"] != null ? (string) data["namespaceName"] : null,
                limitName = data.Keys.Contains("limitName") && data["limitName"] != null ? (string) data["limitName"] : null,
            };
        }

	}
}