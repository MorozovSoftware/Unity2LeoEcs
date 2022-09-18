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

            [MenuItem("GameObject/Unity 2 LeoECS/Remove", true, 50)]
            static bool ValidateRemove()
            {
                return Selection.activeTransform != null;
            }

            [MenuItem("GameObject/Unity 2 LeoECS/Setup Game Object", false, 5)]
            static void SetupGameObject()
            {
                GameObject gameObject = Selection.activeTransform.gameObject;

                SerializedObject context = new(gameObject.GetOrAddComponent<GameObjectContext>());

                SerializedProperty monoInstallers = context.FindProperty("_monoInstallers");

                monoInstallers.AddOneEntry(new Object[]
                {
                    gameObject.GetOrAddComponent<EcsEntityInstaller>(),
                    gameObject.GetOrAddComponent<ComponentsInstaller>()
                });

                context.ApplyModifiedProperties();
            }

            [MenuItem("GameObject/Unity 2 LeoECS/Remove", false, 50)]
            static void Remove()
            {
                GameObject gameObject = Selection.activeTransform.gameObject;

                gameObject.DestroyImmediate<EcsEntityInstaller>();
                gameObject.DestroyImmediate<ComponentsInstaller>();
                gameObject.DestroyImmediate<ComponentsToEntity>();

                
                if (gameObject.TryGetComponent(out GameObjectContext contextComponent))
                {
                    SerializedObject context = new(contextComponent);

                    SerializedProperty monoInstallers = context.FindProperty("_monoInstallers");
                    SerializedProperty scriptableObjectInstallers = context.FindProperty("_scriptableObjectInstallers");
                    SerializedProperty installerPrefabs = context.FindProperty("_installerPrefabs");

                    monoInstallers.DeleteNulls();
                    scriptableObjectInstallers.DeleteNulls();
                    installerPrefabs.DeleteNulls();

                    context.ApplyModifiedProperties();

                    if ((monoInstallers.arraySize == 0) &&
                        (scriptableObjectInstallers.arraySize == 0) &&
                        (installerPrefabs.arraySize == 0))
                    {
                        Object.DestroyImmediate(contextComponent);
                    }
                }                   
            }
        }        
    }
}

