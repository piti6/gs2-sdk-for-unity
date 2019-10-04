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
	public class GetItemModelRequest : Gs2Request<GetItemModelRequest>
	{

        /** カテゴリー名 */
        public string namespaceName { set; get; }

        /**
         * カテゴリー名を設定
         *
         * @param namespaceName カテゴリー名
         * @return this
         */
        public GetItemModelRequest WithNamespaceName(string namespaceName) {
            this.namespaceName = namespaceName;
            return this;
        }


        /** インベントリの種類名 */
        public string inventoryName { set; get; }

        /**
         * インベントリの種類名を設定
         *
         * @param inventoryName インベントリの種類名
         * @return this
         */
        public GetItemModelRequest WithInventoryName(string inventoryName) {
            this.inventoryName = inventoryName;
            return this;
        }


        /** アイテムモデルの種類名 */
        public string itemName { set; get; }

        /**
         * アイテムモデルの種類名を設定
         *
         * @param itemName アイテムモデルの種類名
         * @return this
         */
        public GetItemModelRequest WithItemName(string itemName) {
            this.itemName = itemName;
            return this;
        }


    	[Preserve]
        public static GetItemModelRequest FromDict(JsonData data)
        {
            return new GetItemModelRequest {
                namespaceName = data.Keys.Contains("namespaceName") && data["namespaceName"] != null ? (string) data["namespaceName"] : null,
                inventoryName = data.Keys.Contains("inventoryName") && data["inventoryName"] != null ? (string) data["inventoryName"] : null,
                itemName = data.Keys.Contains("itemName") && data["itemName"] != null ? (string) data["itemName"] : null,
            };
        }

	}
}