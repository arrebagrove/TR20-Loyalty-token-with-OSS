﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TokenManager.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "16.1.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0xFF1D19EBE9Da2D81Ce5480a2Dab1C1C5faA3e2dD")]
        public string ApplicationAddress {
            get {
                return ((string)(this["ApplicationAddress"]));
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string TokenInfos {
            get {
                return ((string)(this["TokenInfos"]));
            }
            set {
                this["TokenInfos"] = value;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0xa82fd99261b16f92f9f7bb7010bb39b6d845603b")]
        public string TokenFactoryAddress {
            get {
                return ((string)(this["TokenFactoryAddress"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.WebServiceUrl)]
        [global::System.Configuration.DefaultSettingValueAttribute("https://ready20loyalty.azurefd.net")]
        public string APILocation {
            get {
                return ((string)(this["APILocation"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(@"[{""AccountName"":""Consoto Airline"",""AccountPubAddress"":""0xFF1D19EBE9Da2D81Ce5480a2Dab1C1C5faA3e2dD""},{""AccountName"":""Consoto Airline"",""AccountPubAddress"":""0x0071df3755926F5C38b4cb68d550807db74DcbAc""},{""AccountName"":""Contoso Rent a car"",""AccountPubAddress"":""0xB897f342D673fB16C38D8Ca4e31F39EE727720A1""},{""AccountName"":""Bob"",""AccountPubAddress"":""0x1F9B9484188b42C01f4aaC308D4848659901F17b""},{""AccountName"":""Mary"",""AccountPubAddress"":""0x0f5DDacC06A44163badc5eD4f09dE0d3eFfC2716""},{""AccountName"":""Jason"",""AccountPubAddress"":""0xC3c76b85b44840CD8E03C01c09cC85522108faAE""},{""AccountName"":""DB"",""AccountPubAddress"":""0xdDE43471B86d4e001a0ad122CbF8b1F3011f17b3""}]")]
        public string AccountInfos {
            get {
                return ((string)(this["AccountInfos"]));
            }
        }
    }
}
