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

namespace Gs2.Unity.Gs2Chat.ScriptableObject
{
    [CreateAssetMenu(fileName = "OwnSubscribe", menuName = "Game Server Services/Gs2Chat/OwnSubscribe")]
    public class OwnSubscribe : UnityEngine.ScriptableObject
    {
        public Namespace Namespace;
        public string roomName;

        public string NamespaceName => this.Namespace.NamespaceName;
        public string RoomName => this.roomName;

#if UNITY_INCLUDE_TESTS
        public static OwnSubscribe Load(
            string assetPath
        )
        {
            return Instantiate(
                AssetDatabase.LoadAssetAtPath<OwnSubscribe>(assetPath)
            );
        }
#endif

        public static OwnSubscribe New(
            Namespace Namespace,
            string roomName
        )
        {
            var instance = CreateInstance<OwnSubscribe>();
            instance.name = "Runtime";
            instance.Namespace = Namespace;
            instance.roomName = roomName;
            return instance;
        }

        public OwnSubscribe Clone()
        {
            var instance = CreateInstance<OwnSubscribe>();
            instance.name = "Runtime";
            instance.Namespace = Namespace;
            instance.roomName = roomName;
            return instance;
        }
    }
}