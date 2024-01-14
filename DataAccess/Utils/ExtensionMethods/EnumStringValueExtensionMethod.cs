using DataAccessLayer.Utils.Attributes;

namespace DataAccessLayer.Utils.ExtensionMethods
{
    internal static class EnumStringValueExtensionMethod
    {
        public static string GetStringValue(this Enum value) 
        {
            var memInfo = value.GetType().GetMember(value.ToString());
            var attribute = memInfo[0].GetCustomAttributes(typeof(StringValue), false).Cast<StringValue>().SingleOrDefault();

            return attribute == null
                ? value.ToString()
                : attribute.Value;
        }
    }
}
