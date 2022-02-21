using UnityEngine;
using Leopotam.Ecs;
using Unity2LeoEcs.Components;


namespace Unity2LeoEcs.UnityComponents
{
    public class SyncroComponent : MonoEntity
    {
        void Start()
        {
            foreach (var item in GetComponents<Component>())
            {
                Entity.AddUnityObjectByReflection(item);
            }
        }
        private void OnDestroy()
        {
            if(Entity.IsWorldAlive())
            {
                foreach (var item in GetComponents<Component>())
                {
                    Entity.DelUnityObjectByReflection(item);
                }
            }            
        }

        public T GetOrAdd<T>() where T : Component
        {
            var component = gameObject.GetOrAddComponent<T>();
            Entity.AddUnityObjectByGeneric(component);

            return component;
        }
        public void Del<T>() where T : Component
        {
            ref var ecsComponent = ref Entity.Get<UnityObject<T>>();
            var unityComponent = ecsComponent.Value;
            if(unityComponent != null)
            {
                Destroy(unityComponent);
            }
            Entity.Del<UnityObject<T>>();
        }
    }
}
