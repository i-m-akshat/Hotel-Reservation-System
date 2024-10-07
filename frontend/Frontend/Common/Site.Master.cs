using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HotelReservationSystem_Part1.Common
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["User_Name"] != null && Session["UserId"] != null)
                {
                    DdlProfile.Visible = true;
                    lblUserName.Text =  Session["User_Name"].ToString();
                    btn2Login.Visible = false;
                }
                else
                {
                    DdlProfile.Visible = false;
                    btn2Login.Visible = true;
                }
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("~/Common/Default.aspx");
        }
    }
}