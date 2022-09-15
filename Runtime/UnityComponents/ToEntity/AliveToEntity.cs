namespace MorozovSoftware.Unity2LeoEcs
{
    public sealed class AliveToEntity : ComponentsToEntity
    {
        private void Start()
        {
            Replace();
        }
        private void OnDestroy()
        {
            Del();
        }
    }
}
