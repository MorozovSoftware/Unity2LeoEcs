using System;
using System.Reflection;
using Leopotam.Ecs;

namespace MorozovSoftware.Unity2LeoEcs
{
    public static class EntityExtension
    {
        readonly private static MethodInfo addUnityObjectByGeneric = typeof(EntityExtension).GetMethod("AddUnityObjectByGeneric", BindingFlags.Public | BindingFlags.Static);
        public static void AddUnityObjectByGeneric<T>(this in EcsEntity entity, T unityObject) where T : UnityEngine.Object
        {
            entity.Get<UnityObject<T>>().Value = unityObject;
        }
        public static void AddUnityObjectByReflection<T>(this in EcsEntity entity, T unityObject) where T : UnityEngine.Object
        {            
            addUnityObjectByGeneric.MakeGenericMethod(unityObject.GetType()).Invoke(null , new object[] {entity, unityObject});
        }

        readonly private static MethodInfo delUnityObjectByGeneric = typeof(EntityExtension).GetMethod("DelUnityObjectByGeneric", BindingFlags.Public | BindingFlags.Static);
        public static void DelUnityObjectByGeneric<T>(this in EcsEntity entity) where T : UnityEngine.Object
        {
            entity.Del<UnityObject<T>>();
        }
        private static void DelUnityObjectByReflection(this in EcsEntity entity, Type typeOfUnityObject)
        { 
            delUnityObjectByGeneric.MakeGenericMethod(typeOfUnityObject).Invoke(null, new object[] { entity });
        }
        public static void DelUnityObjectByReflection<T>(this in EcsEntity entity, T unityObject) where T : UnityEngine.Object
        {
            DelUnityObjectByReflection(entity, unityObject.GetType());
        }
    }
}
