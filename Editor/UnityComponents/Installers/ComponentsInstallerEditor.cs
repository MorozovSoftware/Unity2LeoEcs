using UnityEditor;
using UnityEngine;

namespace MorozovSoftware.Unity2LeoEcs.Editor
{
    [CustomEditor(typeof(ComponentsInstaller)), CanEditMultipleObjects]
    public class ComponentsInstallerEditor : UnityEditor.Editor
    {
        ComponentsInstaller _component;
        SerializedProperty _components;
        SerializedProperty _structsForLeoEcs;
        SerializedProperty _unityObjects;
        SerializedProperty _includedComponents;
        SerializedProperty _excludedComponents;

        void OnEnable()
        {
            _component = (ComponentsInstaller)target;
            _components = serializedObject.FindProperty("_components");
            _structsForLeoEcs = serializedObject.FindProperty("_structsForLeoEcs");
            _unityObjects = serializedObject.FindProperty("_unityObjects");
            _includedComponents = serializedObject.FindProperty("_includedComponents");
            _excludedComponents = serializedObject.FindProperty("_excludedComponents");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.PropertyField(_components);

            EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);
            
            EditorGUILayout.BeginHorizontal();

                EditorGUILayout.PropertyField(_structsForLeoEcs);   
            
                EditorGUILayout.PropertyField(_unityObjects);

            EditorGUILayout.EndHorizontal();

            EditorGUILayout.PropertyField(_includedComponents);

            EditorGUILayout.PropertyField(_excludedComponents);

            if (GUILayout.Button("Update"))
            {
                Undo.RecordObject(_component, "Update components");

                _component.Setup();

                EditorUtility.SetDirty(_component);
            }

            serializedObject.ApplyModifiedProperties();
        }
    }
}
