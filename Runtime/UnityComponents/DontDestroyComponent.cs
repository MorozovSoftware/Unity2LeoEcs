using UnityEngine;

namespace MorozovSoftware.Unity2LeoEcs
{
    public class DontDestroyComponent : MonoBehaviour
    {
        private void Start()
        {
            transform.parent = SimpleInjectComponent.Container.DontDestroyRoot;
        }
    }
}
