﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.3082
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace JRoland.MagicWords.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "9.0.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0, 0")]
        public global::System.Drawing.Point Position {
            get {
                return ((global::System.Drawing.Point)(this["Position"]));
            }
            set {
                this["Position"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("150, 20")]
        public global::System.Drawing.Size Size {
            get {
                return ((global::System.Drawing.Size)(this["Size"]));
            }
            set {
                this["Size"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Blue")]
        public global::System.Drawing.Color Backcolor {
            get {
                return ((global::System.Drawing.Color)(this["Backcolor"]));
            }
            set {
                this["Backcolor"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("White")]
        public global::System.Drawing.Color ForeColor {
            get {
                return ((global::System.Drawing.Color)(this["ForeColor"]));
            }
            set {
                this["ForeColor"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("CtrlF12")]
        public global::System.Windows.Forms.Shortcut TypeWordHotKey {
            get {
                return ((global::System.Windows.Forms.Shortcut)(this["TypeWordHotKey"]));
            }
            set {
                this["TypeWordHotKey"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("CtrlF11")]
        public global::System.Windows.Forms.Shortcut AddWordHotKey {
            get {
                return ((global::System.Windows.Forms.Shortcut)(this["AddWordHotKey"]));
            }
            set {
                this["AddWordHotKey"] = value;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("http://code.google.com/p/magicwords/wiki/Help")]
        public string HelpUrl {
            get {
                return ((string)(this["HelpUrl"]));
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool RunAtWindowsStart {
            get {
                return ((bool)(this["RunAtWindowsStart"]));
            }
            set {
                this["RunAtWindowsStart"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::System.Collections.Specialized.StringCollection ArgumentHistory {
            get {
                return ((global::System.Collections.Specialized.StringCollection)(this["ArgumentHistory"]));
            }
            set {
                this["ArgumentHistory"] = value;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("http://code.google.com/p/magicwords")]
        public string HomepageUrl {
            get {
                return ((string)(this["HomepageUrl"]));
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        [global::System.ComponentModel.Editor(typeof(System.Windows.Forms.Design.FolderNameEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string LiberkeyPath
        {
            get {
                return ((string)(this["LiberkeyPath"]));
            }
            set {
                this["LiberkeyPath"] = value;
            }
        }
    }
}
