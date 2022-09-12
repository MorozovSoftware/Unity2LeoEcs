using Zenject;
using Leopotam.Ecs;

namespace MorozovSoftware.Unity2LeoEcs
{
    public class EcsWorldInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            EcsWorld world = new();
#if UNITY_EDITOR
            Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create(world);
#endif
            Container.Bind<EcsWorld>().FromInstance(world).AsSingle();
        }
    }
}
