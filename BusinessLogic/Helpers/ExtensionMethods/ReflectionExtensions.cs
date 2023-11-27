using System.Reflection;

namespace BusinessLayer.Helpers.ExtensionMethods
{
    internal static class ReflectionExtensions
    {
        public static PropertyInfo[] GetPropertyInfos(this object obj, BindingFlags bindingAttr) => obj.GetType().GetProperties(bindingAttr);
    }
}
