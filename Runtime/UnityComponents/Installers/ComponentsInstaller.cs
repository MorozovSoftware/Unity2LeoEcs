using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MorozovSoftware.Unity2LeoEcs
{
    public partial class ComponentsInstaller : MonoInstaller
    {
        [SerializeField]
        private List<Component> _components;
        public override void InstallBindings()
        {
            Container.Bind<List<Component>>().FromInstance(_components).AsSingle();
        }
    }
}
