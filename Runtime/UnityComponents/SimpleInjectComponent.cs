using UnityEngine;
using Leopotam.Ecs;

namespace MorozovSoftware.Unity2LeoEcs.UnityComponents
{
    public class SimpleInjectComponent : MonoBehaviour
    {
        public static SimpleInjectComponent Container { get; private set; }

        private EcsWorld _world;
        public EcsWorld World => _world ??= new EcsWorld();

        public Transform DontDestroyRoot { get; private set; }

        private void Awake()
        {
            if (Container != null)
            {
                Destroy(gameObject);
            }
            else
            {
                Container = this;
                DontDestroyOnLoad(gameObject);
                DontDestroyRoot = transform;
            }
        }
    }
}
