using UnityEngine;

namespace Unity2LeoEcs.Components
{
    public struct UnityObject<T> where T : Object
    {
        public T Value;
    }
}