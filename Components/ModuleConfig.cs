using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FortyFingers.ZendeskSso.Components
{
    public class ModuleConfig : ModuleConfigBase
    {
        public ModuleConfig(Hashtable settings, int moduleId, int tabModuleId) : base(settings, moduleId, tabModuleId)
        {
        }

        public string SharedKey
        {
            get
            {
                return GetSetting("40F_ZendeskSso_SharedKey");
            }
            set
            {
                ModuleCtrl.UpdateModuleSetting(ModuleId, "40F_ZendeskSso_SharedKey", value);
            }
        }
        public string SubDomain
        {
            get
            {
                return GetSetting("40F_ZendeskSso_SubDomain");
            }
            set
            {
                ModuleCtrl.UpdateModuleSetting(ModuleId, "40F_ZendeskSso_SubDomain", value);
            }
        }

        protected override string ConfigDefaultsResourceFile()
        {
            return "~/DesktopModules/40Fingers/ZendeskSso/App_LocalResources/ConfigDefaults.resx";
        }
    }
}