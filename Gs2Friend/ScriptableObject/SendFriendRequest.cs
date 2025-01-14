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
 *
 * deny overwrite
 */
#if UNITY_INCLUDE_TESTS
using UnityEditor;
#endif
using UnityEngine;

namespace Gs2.Unity.Gs2Friend.ScriptableObject
{
    [CreateAssetMenu(fileName = "SendFriendRequest", menuName = "Game Server Services/Gs2Friend/SendFriendRequest")]
    public class SendFriendRequest : UnityEngine.ScriptableObject
    {
        public User User;
        public string targetUserId;

        public string NamespaceName => this.User.NamespaceName;
        public string UserId => this.User.UserId;
        public string TargetUserId => this.targetUserId;

#if UNITY_INCLUDE_TESTS
        public static SendFriendRequest Load(
            string assetPath
        )
        {
            return Instantiate(
                AssetDatabase.LoadAssetAtPath<SendFriendRequest>(assetPath)
            );
        }
#endif

        public static SendFriendRequest New(
            User User,
            string targetUserId
        )
        {
            var instance = CreateInstance<SendFriendRequest>();
            instance.name = "Runtime";
            instance.User = User;
            instance.targetUserId = targetUserId;
            return instance;
        }

        public SendFriendRequest Clone()
        {
            var instance = CreateInstance<SendFriendRequest>();
            instance.name = "Runtime";
            instance.User = User;
            instance.targetUserId = targetUserId;
            return instance;
        }
    }
}