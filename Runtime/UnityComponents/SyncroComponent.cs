using UnityEngine;
using Leopotam.Ecs;
using Zenject;

namespace MorozovSoftware.Unity2LeoEcs
{
    public class SyncroComponent : MonoBehaviour
    {
        private EcsEntity _entity;

        [Inject]
        public void Construct(EcsEntity entity)
        {
            _entity = entity;
        }

        void Start()
        {
            foreach (var item in GetComponents<Component>())
            {
                if(item is IStructForLeoEcs structForLeoEcs)
                {
                    structForLeoEcs.Replace(_entity);
                } else
                {
                    _entity.AddUnityObjectByReflection(item);
                }                
            }
        }
        private void OnDestroy()
        {
            if(_entity.IsWorldAlive())
            {
                foreach (var item in GetComponents<Component>())
                {
                    if (item is IStructForLeoEcs structForLeoEcs)
                    {
                        structForLeoEcs.Del(_entity);
                    }
                    else
                    {
                        _entity.DelUnityObjectByReflection(item);
                    }
                }
            }            
        }
    }
}
