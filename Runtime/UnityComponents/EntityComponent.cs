using UnityEngine;
using Leopotam.Ecs;

namespace MorozovSoftware.Unity2LeoEcs
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
