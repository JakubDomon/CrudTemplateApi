namespace DataAccessLayer.Utils.ExtensionMethods
{
    internal static class EnumStringValueExtensionMethod
    {
        public static string GetStringValue(this Enum value) => value.ToString();
    }
}
