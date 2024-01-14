namespace DataAccessLayer.Utils.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    internal class StringValue : Attribute
    {
        public string Value { get; }

        public StringValue(string value)
        {
            Value = value;
        }
    }
}
