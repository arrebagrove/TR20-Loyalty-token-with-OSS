﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MileageTokenService.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "16.1.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(@"
                  [
                  {
                  ""Name"": ""Contoso Airline"",
                  ""ContractAddress"": ""0xbf18537886acee06c35e533312c8f989d4ccfb85"",
                  ""Address"": ""0x0071df3755926F5C38b4cb68d550807db74DcbAc"",
                  ""TokenAddress"": """"
                  }
                  ,
                  {
                  ""Name"": ""Contoso Rent a Car"",
                  ""ContractAddress"": ""0xe6482a8752d2caecd2de997e06e0b9f562c4fbc2"",
                  ""Address"": ""0xB897f342D673fB16C38D8Ca4e31F39EE727720A1"",
                  ""TokenAddress"": """"
                  }

                  ]")]
        public string CompanyInfo {
            get {
                return ((string)(this["CompanyInfo"]));
            }
            set {
                this["CompanyInfo"] = value;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("https://ready20loyalty.azurefd.net")]
        public string APILocation {
            get {
                return ((string)(this["APILocation"]));
            }
        }
    }
}
