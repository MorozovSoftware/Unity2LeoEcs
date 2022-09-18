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

        public static void DeleteNulls(this SerializedProperty property)
        {
            for (int i = property.arraySize - 1; i >= 0; i--)
            {
                if (property.GetArrayElementAtIndex(i).objectReferenceValue == null)
                {
                    property.DeleteArrayElementAtIndex(i);
                }
            }
        }

        public static void AddOneEntry(this SerializedProperty property, Object[] objects)
        {

            bool[] isAdded = new bool[objects.Length];


            for (int i = property.arraySize - 1; i >= 0; i--)
            {
                var item = property.GetArrayElementAtIndex(i).objectReferenceValue;

                if (item == null)
                {
                    property.DeleteArrayElementAtIndex(i);
                    continue;
                }
                for (int j = 0; j < objects.Length; j++)
                {
                    if (item == objects[j])
                    {
                        if (isAdded[j])
                        {
                            property.DeleteArrayElementAtIndex(i);
                            break;
                        }
                        else
                        {
                            isAdded[j] = true;
                        }
                    }
                }
            }

            for (int i = 0; i < objects.Length; i++)
            {
                if (!isAdded[i])
                {
                    property.Add(objects[i]);
                }
            }
        }
    }
}
