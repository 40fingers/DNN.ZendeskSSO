using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DotNetNuke;
using DotNetNuke.Common;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Entities.Modules.Actions;
using DotNetNuke.Framework;
using DotNetNuke.Services.Localization;
using FortyFingers.ZendeskSso.Components;

namespace FortyFingers.ZendeskSso
{
    public partial class View : PortalModuleBase //, IActionable
    {
        private ModuleConfig Config;
        protected void Page_Load(object sender, EventArgs e)
        {
            Config = new ModuleConfig(Settings, ModuleId, TabModuleId);

            if (UserInfo.IsInRole(PortalSettings.AdministratorRoleName) || UserInfo.IsSuperUser || IsEditable)
            {
                ToZendeskLink.Visible = true;
            }
            else
            {
                ToZendeskLink.Visible = false;
                RedirectToZendesk();
            }

        }

        public void RedirectToZendesk()
        {
            var context = HttpContext.Current;

            TimeSpan t = (DateTime.UtcNow - new DateTime(1970, 1, 1));
            int timestamp = (int)t.TotalSeconds;

            var payload = new Dictionary<string, object>() {
                { "iat", timestamp },
                { "jti", System.Guid.NewGuid().ToString() },
                { "name", UserInfo.DisplayName },
                { "email", UserInfo.Email }
            };

            string token = JWT.JsonWebToken.Encode(payload, Config.SharedKey, JWT.JwtHashAlgorithm.HS256);
            string redirectUrl = "https://" + Config.SubDomain + ".zendesk.com/access/jwt?jwt=" + token;

            string returnTo = context.Request.QueryString["return_to"];

            if (returnTo != null)
            {
                redirectUrl += "&return_to=" + HttpUtility.UrlEncode(returnTo);
            }

            context.Response.Redirect(redirectUrl);
        }

        protected void ToZendeskLink_OnClick(object sender, EventArgs e)
        {
            RedirectToZendesk();
        }
    }
}