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

namespace Gs2.Unity.Gs2JobQueue.ScriptableObject
{
    [CreateAssetMenu(fileName = "DeadLetterJob", menuName = "Game Server Services/Gs2JobQueue/DeadLetterJob")]
    public class DeadLetterJob : UnityEngine.ScriptableObject
    {
        public User User;
        public string deadLetterJobName;

        public string NamespaceName => this.User?.NamespaceName;
        public string UserId => this.User?.UserId;
        public string DeadLetterJobName => this.deadLetterJobName;

#if UNITY_INCLUDE_TESTS
        public static DeadLetterJob Load(
            string assetPath
        )
        {
            return Instantiate(
                AssetDatabase.LoadAssetAtPath<DeadLetterJob>(assetPath)
            );
        }
#endif

        public static DeadLetterJob New(
            User User,
            string deadLetterJobName
        )
        {
            var instance = CreateInstance<DeadLetterJob>();
            instance.name = "Runtime";
            instance.User = User;
            instance.deadLetterJobName = deadLetterJobName;
            return instance;
        }

        public DeadLetterJob Clone()
        {
            var instance = CreateInstance<DeadLetterJob>();
            instance.name = "Runtime";
            instance.User = User;
            instance.deadLetterJobName = deadLetterJobName;
            return instance;
        }
    }
}