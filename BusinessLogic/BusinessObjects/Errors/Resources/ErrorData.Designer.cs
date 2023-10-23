﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BusinessLayer.BusinessObjects.Errors.Resources {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class ErrorData {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal ErrorData() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("BusinessLayer.BusinessObjects.Errors.Resources.ErrorData", typeof(ErrorData).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Email użytkownika wymagany.
        /// </summary>
        internal static string UserEmailRequired {
            get {
                return ResourceManager.GetString("UserEmailRequired", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Użytkownik o podanych danych już istnieje.
        /// </summary>
        internal static string UserLoginAlreadyExists {
            get {
                return ResourceManager.GetString("UserLoginAlreadyExists", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Logowanie użytkownika nie powiodło się.
        /// </summary>
        internal static string UserLoginFailed {
            get {
                return ResourceManager.GetString("UserLoginFailed", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Login użytkownika wymagany.
        /// </summary>
        internal static string UserLoginRequired {
            get {
                return ResourceManager.GetString("UserLoginRequired", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Imię użytkownika wymagane.
        /// </summary>
        internal static string UserNameRequired {
            get {
                return ResourceManager.GetString("UserNameRequired", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Zbyt długie imię użytkownika.
        /// </summary>
        internal static string UserNameTooLong {
            get {
                return ResourceManager.GetString("UserNameTooLong", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Zbyt krótkie imię użytkownika.
        /// </summary>
        internal static string UserNameTooShort {
            get {
                return ResourceManager.GetString("UserNameTooShort", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Hasło użytkownika wymagane.
        /// </summary>
        internal static string UserPasswordRequired {
            get {
                return ResourceManager.GetString("UserPasswordRequired", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Nie spełniono wymagań hasła użytkownika.
        /// </summary>
        internal static string UserPasswordRequirementsNotMet {
            get {
                return ResourceManager.GetString("UserPasswordRequirementsNotMet", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Zbyt krótkie hasło użytkownika.
        /// </summary>
        internal static string UserPasswordTooShort {
            get {
                return ResourceManager.GetString("UserPasswordTooShort", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Nazwisko użytkownika wymagane.
        /// </summary>
        internal static string UserSurnameRequired {
            get {
                return ResourceManager.GetString("UserSurnameRequired", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Zbyt długie nazwisko użytkownika.
        /// </summary>
        internal static string UserSurnameTooLong {
            get {
                return ResourceManager.GetString("UserSurnameTooLong", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Zbyt krótkie nazwisko użytkownika.
        /// </summary>
        internal static string UserSurnameTooShort {
            get {
                return ResourceManager.GetString("UserSurnameTooShort", resourceCulture);
            }
        }
    }
}
