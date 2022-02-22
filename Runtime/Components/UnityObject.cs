using UnityEngine;

namespace MorozovSoftware.Unity2LeoEcs.Components
{
    public struct UnityObject<T> where T : Object
    {
        public T Value;
    }
}