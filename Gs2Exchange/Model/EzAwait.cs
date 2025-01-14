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
using Gs2.Gs2Exchange.Model;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Gs2.Util.LitJson;
using UnityEngine;
using UnityEngine.Scripting;

// ReSharper disable once CheckNamespace
namespace Gs2.Unity.Gs2Exchange.Model
{

	[Preserve]
	[System.Serializable]
	[SuppressMessage("ReSharper", "InconsistentNaming")]
	public class EzAwait
	{
		[SerializeField]
		public string UserId;
		[SerializeField]
		public string RateName;
		[SerializeField]
		public string Name;
		[SerializeField]
		public long ExchangedAt;

        public Gs2.Gs2Exchange.Model.Await ToModel()
        {
            return new Gs2.Gs2Exchange.Model.Await {
                UserId = UserId,
                RateName = RateName,
                Name = Name,
                ExchangedAt = ExchangedAt,
            };
        }

        public static EzAwait FromModel(Gs2.Gs2Exchange.Model.Await model)
        {
            return new EzAwait {
                UserId = model.UserId == null ? null : model.UserId,
                RateName = model.RateName == null ? null : model.RateName,
                Name = model.Name == null ? null : model.Name,
                ExchangedAt = model.ExchangedAt ?? 0,
            };
        }
    }
}