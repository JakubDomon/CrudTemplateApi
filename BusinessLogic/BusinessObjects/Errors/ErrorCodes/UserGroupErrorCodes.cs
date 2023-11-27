namespace BusinessLayer.BusinessObjects.Errors.ErrorCodes
{
    internal class UserGroupErrorCodes : IErrorResourceKey
    {
        public static readonly string UsersRequired = nameof(UsersRequired);
        public static readonly string GroupUserIdRequired = nameof(GroupUserIdRequired);
    }
}
