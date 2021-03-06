﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Resources {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class ErrorMessages {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal ErrorMessages() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("MemoDTO.Resources.ErrorMessages", typeof(ErrorMessages).Assembly);
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
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Only numbers, letters and -_.:#+/&amp;() are allowed!.
        /// </summary>
        public static string INCORRECT_INPUT {
            get {
                return ResourceManager.GetString("INCORRECT_INPUT", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Such name already exists! .
        /// </summary>
        public static string NAME_EXISTS {
            get {
                return ResourceManager.GetString("NAME_EXISTS", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Only numbers and letters are allowed!.
        /// </summary>
        public static string ONLY_ALPHANUMERIC {
            get {
                return ResourceManager.GetString("ONLY_ALPHANUMERIC", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Only numbers from 0 to 1000 are allowed!.
        /// </summary>
        public static string ONLY_NUMBERS {
            get {
                return ResourceManager.GetString("ONLY_NUMBERS", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Incorrect email input!.
        /// </summary>
        public static string PATTERN_NOT_VALID {
            get {
                return ResourceManager.GetString("PATTERN_NOT_VALID", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This field is required!.
        /// </summary>
        public static string REQUIRED {
            get {
                return ResourceManager.GetString("REQUIRED", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Maximum length 20 characters!.
        /// </summary>
        public static string TOO_LONG {
            get {
                return ResourceManager.GetString("TOO_LONG", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Maximum length 250 characters!.
        /// </summary>
        public static string TOO_LONG_AREA {
            get {
                return ResourceManager.GetString("TOO_LONG_AREA", resourceCulture);
            }
        }
    }
}
