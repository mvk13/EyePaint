﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EyePaint.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "12.0.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("default@default.default")]
        public string AdminEmail {
            get {
                return ((string)(this["AdminEmail"]));
            }
            set {
                this["AdminEmail"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("default.default.default")]
        public string SmtpServer {
            get {
                return ((string)(this["SmtpServer"]));
            }
            set {
                this["SmtpServer"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("a81591b96318cd9799982c11663df750")]
        public string FlickrKey {
            get {
                return ((string)(this["FlickrKey"]));
            }
            set {
                this["FlickrKey"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("05e84b538d7d4cf5")]
        public string FlickrSecret {
            get {
                return ((string)(this["FlickrSecret"]));
            }
            set {
                this["FlickrSecret"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("10")]
        public int Spacing {
            get {
                return ((int)(this["Spacing"]));
            }
            set {
                this["Spacing"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("10")]
        public int Stability {
            get {
                return ((int)(this["Stability"]));
            }
            set {
                this["Stability"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("60")]
        public int Blink {
            get {
                return ((int)(this["Blink"]));
            }
            set {
                this["Blink"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("120")]
        public int Inertia {
            get {
                return ((int)(this["Inertia"]));
            }
            set {
                this["Inertia"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("10")]
        public int ConnectionAttempts {
            get {
                return ((int)(this["ConnectionAttempts"]));
            }
            set {
                this["ConnectionAttempts"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::FlickrNet.OAuthAccessToken FlickrAccessToken {
            get {
                return ((global::FlickrNet.OAuthAccessToken)(this["FlickrAccessToken"]));
            }
            set {
                this["FlickrAccessToken"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string FlickrVerificationCode {
            get {
                return ((string)(this["FlickrVerificationCode"]));
            }
            set {
                this["FlickrVerificationCode"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Måla med ögonen")]
        public string FlickrPhotoset {
            get {
                return ((string)(this["FlickrPhotoset"]));
            }
            set {
                this["FlickrPhotoset"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Målning med ögonen")]
        public string FlickrTitle {
            get {
                return ((string)(this["FlickrTitle"]));
            }
            set {
                this["FlickrTitle"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("En målning gjord med ögonen.")]
        public string FlickrDescription {
            get {
                return ((string)(this["FlickrDescription"]));
            }
            set {
                this["FlickrDescription"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string FlickrTags {
            get {
                return ((string)(this["FlickrTags"]));
            }
            set {
                this["FlickrTags"] = value;
            }
        }
    }
}
