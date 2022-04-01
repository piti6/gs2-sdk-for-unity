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

using Gs2.Gs2JobQueue.Model;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Gs2.Util.LitJson;
using UnityEngine;
using UnityEngine.Scripting;

// ReSharper disable once CheckNamespace
namespace Gs2.Unity.Gs2JobQueue.Model
{
	[Preserve]
	[System.Serializable]
	[SuppressMessage("ReSharper", "InconsistentNaming")]
	public class EzJobResultBody
	{
		[SerializeField]
		public int TryNumber;
		[SerializeField]
		public int StatusCode;
		[SerializeField]
		public string Result;
		[SerializeField]
		public long TryAt;

        public Gs2.Gs2JobQueue.Model.JobResultBody ToModel()
        {
            return new Gs2.Gs2JobQueue.Model.JobResultBody {
                TryNumber = TryNumber,
                StatusCode = StatusCode,
                Result = Result,
                TryAt = TryAt,
            };
        }

        public static EzJobResultBody FromModel(Gs2.Gs2JobQueue.Model.JobResultBody model)
        {
            return new EzJobResultBody {
                TryNumber = model.TryNumber ?? 0,
                StatusCode = model.StatusCode ?? 0,
                Result = model.Result == null ? null : model.Result,
                TryAt = model.TryAt ?? 0,
            };
        }
    }
}