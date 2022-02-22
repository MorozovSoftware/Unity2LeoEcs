using UnityEngine;

namespace MorozovSoftware.Unity2LeoEcs.UnityComponents
{
    public class DontDestroyComponent : MonoBehaviour
    {
        private void Start()
        {
            transform.parent = SimpleInjectComponent.Container.DontDestroyRoot;
        }
    }
}
