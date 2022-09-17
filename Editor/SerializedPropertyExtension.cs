using UnityEditor;
using UnityEngine;

namespace MorozovSoftware.Unity2LeoEcs.Editor
{
    public static class SerializedPropertyExtension
    {
        public static void Add<T>(this SerializedProperty property, T item) where T : Object
        {
            property.GetArrayElementAtIndex(++property.arraySize - 1).objectReferenceValue = item;
        }
    }
}
