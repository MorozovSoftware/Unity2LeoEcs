#if UNITY_EDITOR
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MorozovSoftware.Unity2LeoEcs
{
    public partial class ComponentsInstaller
    {    
        [SerializeField]
        private bool _structsForLeoEcs;
        [SerializeField]
        private bool _unityObjects;
        [SerializeField]
        private List<Component> _includedComponents;
        [SerializeField]
        private List<Component> _excludedComponents;

        public void Setup()
        {
            List<Component> components = new();

            foreach (Component component in gameObject.GetComponents<Component>())
            {
                if (component is IStructForLeoEcs)
                {
                    if (_structsForLeoEcs)
                    {
                        components.Add(component);
                    }
                }
                else if (_unityObjects)
                {
                    components.Add(component);
                }
            }

            components.AddRange(_includedComponents);

            _components = components.Except(_excludedComponents).ToList();
        }
    }
}
#endif

