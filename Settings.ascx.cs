using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DotNetNuke.Entities.Modules;
using FortyFingers.ZendeskSso.Components;

namespace FortyFingers.ZendeskSso
{
    public partial class Settings : ModuleSettingsBase
    {
        private ModuleConfig Config;

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public override void LoadSettings()
        {
            Config = new ModuleConfig(Settings, ModuleId, TabModuleId);

            txtZendeskSharedKey.Text = Config.SharedKey;
            txtZendeskSubDomain.Text = Config.SubDomain;
        }
        public override void UpdateSettings()
        {
            Config = new ModuleConfig(Settings, ModuleId, TabModuleId);

            Config.SharedKey = txtZendeskSharedKey.Text;
            Config.SubDomain = txtZendeskSubDomain.Text;
        }
    }
}