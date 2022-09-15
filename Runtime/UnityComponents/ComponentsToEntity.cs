using Leopotam.Ecs;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MorozovSoftware.Unity2LeoEcs
{
    public abstract class ComponentsToEntity : MonoBehaviour
    {
        List<Component> _components;
        EcsEntity _entity;

        [Inject]
        public void Construct(List<Component> components, EcsEntity entity)
        {
            _components = components;
            _entity = entity;
        }

        protected void Replace()
        {
            foreach (var item in _components)
            {
                if (item is IStructForLeoEcs structForLeoEcs)
                {
                    structForLeoEcs.Replace(_entity);
                }
                else
                {
                    _entity.AddUnityObjectByReflection(item);
                }
            }
        }

        protected void Del()
        {
            if (_entity.IsWorldAlive())
            {
                foreach (var item in _components)
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
    
