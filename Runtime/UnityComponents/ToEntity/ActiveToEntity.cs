namespace MorozovSoftware.Unity2LeoEcs
{
    public sealed class ActiveToEntity : ComponentsToEntity
    {
        private bool _isStarted = false;
        private void OnEnable()
        {
            if(_isStarted)
                Replace();
        }
        private void Start()
        {
            _isStarted = true;
            Replace();
        }
        private void OnDisable()
        {
            Del();
        }
    }
}
