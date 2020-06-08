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
using System.Text.RegularExpressions;
using Gs2.Core.Model;
using Gs2.Util.LitJson;
using UnityEngine.Scripting;

namespace Gs2.Gs2Quest.Model
{
	[Preserve]
	public class ConsumeAction : IComparable
	{

        /** スタンプタスクで実行するアクションの種類 */
        public string action { set; get; }

        /**
         * スタンプタスクで実行するアクションの種類を設定
         *
         * @param action スタンプタスクで実行するアクションの種類
         * @return this
         */
        public ConsumeAction WithAction(string action) {
            this.action = action;
            return this;
        }

        /** 消費リクエストのJSON */
        public string request { set; get; }

        /**
         * 消費リクエストのJSONを設定
         *
         * @param request 消費リクエストのJSON
         * @return this
         */
        public ConsumeAction WithRequest(string request) {
            this.request = request;
            return this;
        }

        public void WriteJson(JsonWriter writer)
        {
            writer.WriteObjectStart();
            if(this.action != null)
            {
                writer.WritePropertyName("action");
                writer.Write(this.action);
            }
            if(this.request != null)
            {
                writer.WritePropertyName("request");
                writer.Write(this.request);
            }
            writer.WriteObjectEnd();
        }

    	[Preserve]
        public static ConsumeAction FromDict(JsonData data)
        {
            return new ConsumeAction()
                .WithAction(data.Keys.Contains("action") && data["action"] != null ? data["action"].ToString() : null)
                .WithRequest(data.Keys.Contains("request") && data["request"] != null ? data["request"].ToString() : null);
        }

        public int CompareTo(object obj)
        {
            var other = obj as ConsumeAction;
            var diff = 0;
            if (action == null && action == other.action)
            {
                // null and null
            }
            else
            {
                diff += action.CompareTo(other.action);
            }
            if (request == null && request == other.request)
            {
                // null and null
            }
            else
            {
                diff += request.CompareTo(other.request);
            }
            return diff;
        }
	}
}