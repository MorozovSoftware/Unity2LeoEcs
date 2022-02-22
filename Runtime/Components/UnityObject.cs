using UnityEngine;

namespace MorozovSoftware.Unity2LeoEcs
{
    public struct UnityObject<T> where T : Object
    {
        public T Value;
    }
}