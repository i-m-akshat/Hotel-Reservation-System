using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Frontend.Admin
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            {
                Page.DataBind();
                if (Session["AdminName"] == null)
                    Response.Redirect("~/Common/Default.aspx");
                else
                    lblAdminName.Text = Session["AdminName"].ToString();
                
            }
        }
        protected void btnProfile_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("Profile.aspx");
        }

        protected void btnDashboard_ServerClick(object sender, EventArgs e)
        {
            
            Response.Redirect("Dashboard.aspx");

        }
        protected void btnSettings_ServerClick(object sender, EventArgs e)
        {
            
            Response.Redirect("Settings.aspx");
        }

        protected void btnHelp_ServerClick(object sender, EventArgs e)
        {
            
            Response.Redirect("Help.aspx");
        }


        protected void btnLogout_ServerClick(object sender, EventArgs e)
        {
            Session.Abandon();
            //string script = "localStorage.clear()";

            //ScriptManager.RegisterStartupScript(this, this.GetType(), "ClearLocalStorage", script, false);
            Response.Redirect("~/Common/Default.aspx");
        }

       
        public string IsActive(string menu)
        {
            var activeMenu = Convert.ToString(ViewState["ActiveMenu"]);
            return activeMenu == menu ? "active":"";
        }
    }
}