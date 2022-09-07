using UnityEngine;

namespace MorozovSoftware.Unity2LeoEcs
{
    public abstract class StructHolder<T> : MonoBehaviour where T : struct
    {
        [SerializeField] protected T value;
    }
}

