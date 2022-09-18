using UnityEditor;
using UnityEngine;

namespace MorozovSoftware.Unity2LeoEcs.Editor
{
    public static class GameObjectExtension
    {
        public static T GetOrAddComponent<T>(this GameObject gameObject) where T : Component
        {
            if (!gameObject.TryGetComponent(out T component))
            {
                component = gameObject.AddComponent<T>();
            }
            return component;
        }
        public static void DestroyImmediate<T>(this GameObject gameObject) where T : Component
        {
            foreach (Component item in gameObject.GetComponents<T>())
            {
                Object.DestroyImmediate(item);
            }
        }
    }
}
