﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MBS.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "17.10.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=172.23.1.84\\WINCC;Initial Catalog=aaaa;User ID=a;Password=11111111")]
        public string ReportConnectionString {
            get {
                return ((string)(this["ReportConnectionString"]));
            }
            set
            {
                this["ReportConnectionString"] = value;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=172.23.1.84\\WINCC;Initial Catalog=MBS1_Alarm;User ID=a;Password=11111" +
            "111")]
        public string AlarmConnectionString {
            get {
                return ((string)(this["AlarmConnectionString"]));
            }
            set
            {
                this["AlarmConnectionString"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("C:\\Users\\www.DESKTOP-NGC89DL\\Desktop\\practice")]
        public string ReportPatch {
            get {
                return ((string)(this["ReportPatch"]));
            }
            set {
                this["ReportPatch"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("MBS. Линия 2as")]
        public string ProjectName {
            get {
                return ((string)(this["ProjectName"]));
            }
            set {
                this["ProjectName"] = value;
            }
        }
    }
}
