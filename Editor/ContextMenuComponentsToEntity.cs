using UnityEditor;

namespace MorozovSoftware.Unity2LeoEcs.Editor
{
    public class ContextMenuComponentsToEntity
    {
        [MenuItem("GameObject/Unity 2 LeoECS/Select Active To Entity", true, 25)]
        static bool ValidateSelectActive()
        {
            return Selection.activeTransform != null;
        }

        [MenuItem("GameObject/Unity 2 LeoECS/Select Alive To Entity", true, 25)]
        static bool ValidateSelectAlive()
        {
            return Selection.activeTransform != null;
        }

        [MenuItem("GameObject/Unity 2 LeoECS/Select Started To Entity", true, 25)]
        static bool ValidateSelectStarted()
        {
            return Selection.activeTransform != null;
        }

        
        
        [MenuItem("GameObject/Unity 2 LeoECS/Select Active To Entity", false, 25)]
        static void SelectActive()
        {
            Selection.activeTransform.gameObject.DestroyImmediate<ComponentsToEntity>();
            Selection.activeTransform.gameObject.AddComponent<ActiveToEntity>();
        }

        [MenuItem("GameObject/Unity 2 LeoECS/Select Alive To Entity", false, 25)]
        static void SelectAlive()
        {
            Selection.activeTransform.gameObject.DestroyImmediate<ComponentsToEntity>();
            Selection.activeTransform.gameObject.AddComponent<AliveToEntity>();
        }

        [MenuItem("GameObject/Unity 2 LeoECS/Select Started To Entity", false, 25)]
        static void SelectStarted()
        {
            Selection.activeTransform.gameObject.DestroyImmediate<ComponentsToEntity>();
            Selection.activeTransform.gameObject.AddComponent<StartedToEntity>();
        }
    }
}
