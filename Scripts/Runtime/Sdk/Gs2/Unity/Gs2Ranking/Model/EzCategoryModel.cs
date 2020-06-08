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
using Gs2.Gs2Ranking.Model;
using System.Collections.Generic;
using System.Linq;
using Gs2.Util.LitJson;
using UnityEngine.Scripting;


namespace Gs2.Unity.Gs2Ranking.Model
{
	[Preserve]
	[System.Serializable]
	public class EzCategoryModel
	{
		/** カテゴリ名 */
		[UnityEngine.SerializeField]
		public string Name;
		/** カテゴリのメタデータ */
		[UnityEngine.SerializeField]
		public string Metadata;
		/** スコアの登録可能期間とするイベントマスター のGRN */
		[UnityEngine.SerializeField]
		public string EntryPeriodEventId;
		/** アクセス可能期間とするイベントマスター のGRN */
		[UnityEngine.SerializeField]
		public string AccessPeriodEventId;

		public EzCategoryModel()
		{

		}

		public EzCategoryModel(Gs2.Gs2Ranking.Model.CategoryModel @categoryModel)
		{
			Name = @categoryModel.name;
			Metadata = @categoryModel.metadata;
			EntryPeriodEventId = @categoryModel.entryPeriodEventId;
			AccessPeriodEventId = @categoryModel.accessPeriodEventId;
		}

        public virtual CategoryModel ToModel()
        {
            return new CategoryModel {
                name = Name,
                metadata = Metadata,
                entryPeriodEventId = EntryPeriodEventId,
                accessPeriodEventId = AccessPeriodEventId,
            };
        }

        public virtual void WriteJson(JsonWriter writer)
        {
            writer.WriteObjectStart();
            if(this.Name != null)
            {
                writer.WritePropertyName("name");
                writer.Write(this.Name);
            }
            if(this.Metadata != null)
            {
                writer.WritePropertyName("metadata");
                writer.Write(this.Metadata);
            }
            if(this.EntryPeriodEventId != null)
            {
                writer.WritePropertyName("entryPeriodEventId");
                writer.Write(this.EntryPeriodEventId);
            }
            if(this.AccessPeriodEventId != null)
            {
                writer.WritePropertyName("accessPeriodEventId");
                writer.Write(this.AccessPeriodEventId);
            }
            writer.WriteObjectEnd();
        }
	}
}
