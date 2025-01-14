#if UNITY_INCLUDE_TESTS
using UnityEditor;
#endif
using UnityEngine;

namespace Gs2.Unity.Gs2Key.ScriptableObject
{
    [CreateAssetMenu(fileName = "Namespace", menuName = "Game Server Services/Gs2Key/Namespace")]
    public class Namespace : UnityEngine.ScriptableObject
    {
        public string namespaceName;
        
#if UNITY_INCLUDE_TESTS
        public static Namespace Load(
            string assetPath
        )
        {
            return Instantiate(
                AssetDatabase.LoadAssetAtPath<Namespace>(assetPath));
        }
#endif
        
        public static Namespace New(
            string namespaceName
        )
        {
            var instance = CreateInstance<Namespace>();
            instance.name = "Runtime";
            instance.namespaceName = namespaceName;
            return instance;
        }

        public Namespace Clone()
        {
            var instance = CreateInstance<Namespace>();
            instance.name = "Runtime";
            instance.namespaceName = namespaceName;
            return instance;
        }
    }
}