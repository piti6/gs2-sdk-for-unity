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

using Gs2.Gs2Account.Model;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Gs2.Util.LitJson;
using UnityEngine;
using UnityEngine.Scripting;

// ReSharper disable once CheckNamespace
namespace Gs2.Unity.Gs2Account.Result
{
	[Preserve]
	[System.Serializable]
	[SuppressMessage("ReSharper", "InconsistentNaming")]
	public class EzAuthenticationResult
	{
		[SerializeField]
		public Gs2.Unity.Gs2Account.Model.EzAccount Item;
		[SerializeField]
		public string Body;
		[SerializeField]
		public string Signature;

        public static EzAuthenticationResult FromModel(Gs2.Gs2Account.Result.AuthenticationResult model)
        {
            return new EzAuthenticationResult {
                Item = model.Item == null ? null : Gs2.Unity.Gs2Account.Model.EzAccount.FromModel(model.Item),
                Body = model.Body == null ? null : model.Body,
                Signature = model.Signature == null ? null : model.Signature,
            };
        }
    }
}