using Leopotam.Ecs;

namespace MorozovSoftware.Unity2LeoEcs
{
    public abstract class StructForLeoEcs<T> : StructHolder<T>, IStructForLeoEcs where T : struct
    {        
        public void Replace(EcsEntity entity)
        {
            entity.Replace(value);
        }
        public void Del(EcsEntity entity)
        {
            entity.Del(value);
        }
    }
}

