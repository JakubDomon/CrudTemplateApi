namespace DataAccessLayer.Utils.Attributes
{
    internal class StringValueAttribute : Attribute
    {
        private readonly string Value;

        public StringValueAttribute(string value)
        {
            Value = value;
        }
    }
}
