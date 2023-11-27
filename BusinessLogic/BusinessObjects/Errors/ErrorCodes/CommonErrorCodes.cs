namespace BusinessLayer.BusinessObjects.Errors.ErrorCodes
{
    internal class CommonErrorCodes : IErrorResourceKey
    {
        public static readonly string ServerError = nameof(ServerError);
        public static readonly string DatabaseError = nameof(DatabaseError);
        public static readonly string ObjectEveryPropertyNull = nameof(ObjectEveryPropertyNull);
        public static readonly string ObjectIdRequired = nameof(ObjectIdRequired);
    }
}
