using System.Resources;

namespace BusinessLayer.Helpers.Resources
{
    internal class ResourceHelper<T>
    {
        private readonly ResourceManager ResourceManager;

        public ResourceHelper()
        {
            ResourceManager = new ResourceManager(typeof(T));
        }

        public string GetValue(string key)
        {
            return ResourceManager.GetString(key) ?? throw new ArgumentException($"Could not find key: {key} in resources");
        }
    }
}
