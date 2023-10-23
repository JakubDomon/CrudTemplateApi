﻿namespace BusinessLayer.BusinessObjects.Errors.ErrorCodes
{
    internal class UserManagementErrorCodes : IErrorResourceKey
    {
        // Id
        public static readonly string UserLoginRequired = nameof(UserLoginRequired);
        
        // Name
        public static readonly string UserNameRequired = nameof(UserNameRequired);
        public static readonly string UserNameTooShort = nameof(UserNameTooShort);
        public static readonly string UserNameTooLong = nameof(UserNameTooLong);

        // Surname
        public static readonly string UserSurnameRequired = nameof(UserSurnameRequired);
        public static readonly string UserSurnameTooShort = nameof(UserSurnameTooShort);
        public static readonly string UserSurnameTooLong = nameof(UserSurnameTooLong);

        // Email
        public static readonly string UserEmailRequired = nameof(UserEmailRequired);
        
        // Password
        public static readonly string UserPasswordRequired = nameof(UserPasswordRequired);
        public static readonly string UserPasswordTooShort = nameof(UserPasswordTooShort);
        public static readonly string UserPasswordRequirementsNotMet = nameof(UserPasswordRequirementsNotMet);

        // Database
        public static readonly string UserLoginAlreadyExists = nameof(UserLoginAlreadyExists);

        // Authentication
        public static readonly string UserLoginFailed = nameof(UserLoginFailed);
    }
}
