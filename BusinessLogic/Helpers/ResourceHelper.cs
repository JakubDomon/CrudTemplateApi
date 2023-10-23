using System.Resources;

namespace BusinessLayer.Helpers
{
    internal class ResourceHelper<T>
    {
        private readonly ResourceManager _resourceManager;

        public ResourceHelper()
        {
            _resourceManager = new ResourceManager(typeof(T));
        }

        public string GetValue(string key)
        {
            return _resourceManager.GetString(key) ?? throw new ArgumentException($"Could not find key: {key} in resources");
        }
    }
}
