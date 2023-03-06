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
#if UNITY_INCLUDE_TESTS
using UnityEditor;
#endif
using UnityEngine;

namespace Gs2.Unity.Gs2Limit.ScriptableObject
{
    [CreateAssetMenu(fileName = "Counter", menuName = "Game Server Services/Gs2Limit/Counter")]
    public class Counter : UnityEngine.ScriptableObject
    {
        public User User;
        public string limitName;
        public string counterName;

        public string NamespaceName => this.User?.NamespaceName;
        public string UserId => this.User?.UserId;
        public string LimitName => this.limitName;
        public string CounterName => this.counterName;

#if UNITY_INCLUDE_TESTS
        public static Counter Load(
            string assetPath
        )
        {
            return Instantiate(
                AssetDatabase.LoadAssetAtPath<Counter>(assetPath)
            );
        }
#endif

        public static Counter New(
            User User,
            string limitName,
            string counterName
        )
        {
            var instance = CreateInstance<Counter>();
            instance.name = "Runtime";
            instance.User = User;
            instance.limitName = limitName;
            instance.counterName = counterName;
            return instance;
        }

        public Counter Clone()
        {
            var instance = CreateInstance<Counter>();
            instance.name = "Runtime";
            instance.User = User;
            instance.limitName = limitName;
            instance.counterName = counterName;
            return instance;
        }
    }
}