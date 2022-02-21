using UnityEngine;
using Leopotam.Ecs;

namespace Unity2LeoEcs.UnityComponents
{
    public class EntityComponent : MonoBehaviour
    {
        private EcsEntity _entity;
        public ref EcsEntity Entity
        {
            get
            {
                if (_entity.IsNull())
                {
                    _entity = SimpleInjectComponent.Container.World.NewEntity();
                };
                return ref _entity;
            }
        }        
    }
}
