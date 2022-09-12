using Leopotam.Ecs;
using Zenject;

namespace MorozovSoftware.Unity2LeoEcs
{
    public class EcsEntityInstaller : MonoInstaller
    {
        private EcsEntity _entity;

        [Inject]
        public void Construct(EcsWorld world)
        {
            _entity = world.NewEntity().Replace(new FromUnity());
        }
        public override void InstallBindings()
        {
            Container.Bind<EcsEntity>().FromInstance(_entity).AsSingle();
        }
        private void OnDestroy()
        {
            if (_entity.IsAlive())
            {
                _entity.Del<FromUnity>();
            }
        }
    }
}
