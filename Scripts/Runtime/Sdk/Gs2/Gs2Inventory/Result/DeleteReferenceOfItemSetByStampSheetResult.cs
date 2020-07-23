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
using Gs2.Gs2Inventory.Model;
using Gs2.Util.LitJson;
using UnityEngine.Scripting;

namespace Gs2.Gs2Inventory.Result
{
	[Preserve]
	public class DeleteReferenceOfItemSetByStampSheetResult
	{
        /** この所持品の参照元 */
        public string item { set; get; }

        /** 参照元削除後の有効期限ごとのアイテム所持数量 */
        public ItemSet itemSet { set; get; }

        /** アイテムモデル */
        public ItemModel itemModel { set; get; }

        /** インベントリ */
        public Inventory inventory { set; get; }


    	[Preserve]
        public static DeleteReferenceOfItemSetByStampSheetResult FromDict(JsonData data)
        {
            return new DeleteReferenceOfItemSetByStampSheetResult {
                item = data.Keys.Contains("item") && data["item"] != null ? data["item"].ToString() : null,
                itemSet = data.Keys.Contains("itemSet") && data["itemSet"] != null ? Gs2.Gs2Inventory.Model.ItemSet.FromDict(data["itemSet"]) : null,
                itemModel = data.Keys.Contains("itemModel") && data["itemModel"] != null ? Gs2.Gs2Inventory.Model.ItemModel.FromDict(data["itemModel"]) : null,
                inventory = data.Keys.Contains("inventory") && data["inventory"] != null ? Gs2.Gs2Inventory.Model.Inventory.FromDict(data["inventory"]) : null,
            };
        }
	}
}