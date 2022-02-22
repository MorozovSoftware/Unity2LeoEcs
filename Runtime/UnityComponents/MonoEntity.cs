using UnityEngine;
using Leopotam.Ecs;

namespace MorozovSoftware.Unity2LeoEcs.UnityComponents
{
    [RequireComponent(typeof(EntityComponent))]
    public abstract class MonoEntity : MonoBehaviour
    {
        protected ref EcsEntity Entity => ref EntityComponent.Entity;

        [SerializeField]
        private EntityComponent _entityComponent;
        private EntityComponent EntityComponent
        {
            get
            {
                if(_entityComponent == null)
                {
                    _entityComponent = gameObject.GetOrAddComponent<EntityComponent>();
                }
                return _entityComponent;
            }
        }

#if UNITY_EDITOR
        private void OnValidate()
        {
            if (_entityComponent == null)
            {
                _entityComponent = GetComponent<EntityComponent>();
            }
        }
#endif

    }
}