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
using Gs2.Core.Model;
using Gs2.Gs2Showcase.Model;
using LitJson;
using UnityEngine.Scripting;

namespace Gs2.Gs2Showcase.Result
{
	[Preserve]
	public class GetShowcaseByUserIdResult
	{
        /** 陳列棚 */
        public Showcase item { set; get; }

        /** 購入可能な商品 */
        public List<SalesItem> salesItems { set; get; }


    	[Preserve]
        public static GetShowcaseByUserIdResult FromDict(JsonData data)
        {
            return new GetShowcaseByUserIdResult {
                item = data.Keys.Contains("item") && data["item"] != null ? Showcase.FromDict(data["item"]) : null,
                salesItems = data.Keys.Contains("salesItems") && data["salesItems"] != null ? data["salesItems"].Cast<JsonData>().Select(value =>
                    {
                        return SalesItem.FromDict(value);
                    }
                ).ToList() : null,
            };
        }
	}
}