using UnityEngine;

namespace MorozovSoftware.Unity2LeoEcs
{
    [System.Serializable]
    public struct UnityObject<T> where T : Object
    {
        public T Value;
    }
}