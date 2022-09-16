using UnityEditor;
using UnityEngine;

namespace MorozovSoftware.Unity2LeoEcs.Editor
{
    public class ContextMenuComponentsToEntity
    {
        [MenuItem("GameObject/Unity2LeoEcs/Active", true, 25)]
        static bool ValidateActive()
        {
            return Selection.activeTransform != null;
        }

        [MenuItem("GameObject/Unity2LeoEcs/Alive", true, 25)]
        static bool ValidateAlive()
        {
            return Selection.activeTransform != null;
        }

        [MenuItem("GameObject/Unity2LeoEcs/Started", true, 25)]
        static bool ValidateStarted()
        {
            return Selection.activeTransform != null;
        }

        
        
        [MenuItem("GameObject/Unity2LeoEcs/Active", false, 25)]
        static void InstallActive()
        {
            DestroyComponentsToEntity();
            Selection.activeTransform.gameObject.AddComponent<ActiveToEntity>();
        }

        [MenuItem("GameObject/Unity2LeoEcs/Alive", false, 25)]
        static void InstallAlive()
        {
            DestroyComponentsToEntity();
            Selection.activeTransform.gameObject.AddComponent<AliveToEntity>();
        }

        [MenuItem("GameObject/Unity2LeoEcs/Started", false, 25)]
        static void InstallStarted()
        {
            DestroyComponentsToEntity();
            Selection.activeTransform.gameObject.AddComponent<StartedToEntity>();
        }
        
        
        static void DestroyComponentsToEntity()
        {
            foreach (Component item in Selection.activeTransform.gameObject.GetComponents<ComponentsToEntity>())
            {
                Object.DestroyImmediate(item);
            }
        }
    }
}
