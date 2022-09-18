using UnityEditor;
using UnityEngine;
using Zenject;

namespace MorozovSoftware.Unity2LeoEcs.Editor
{
    namespace GameCore
    {
        public class ContextMenuBinding
        {
            [MenuItem("GameObject/Unity 2 LeoECS/Setup Game Object", true, 5)]
            static bool ValidateSetupGameObject()
            {
                return Selection.activeTransform != null;
            }

            [MenuItem("GameObject/Unity 2 LeoECS/Setup Game Object", false, 5)]
            static void SetupGameObject()
            {
                GameObject gameObject = Selection.activeTransform.gameObject;

                SerializedObject context = new(gameObject.GetOrAddComponent<GameObjectContext>());

                SerializedProperty installers = context.FindProperty("_monoInstallers");

                installers.AddOneEntry(new Object[] 
                {
                    gameObject.GetOrAddComponent<EcsEntityInstaller>(),
                    gameObject.GetOrAddComponent<ComponentsInstaller>()
                });                

                context.ApplyModifiedProperties();
            }
        }        
    }
}

