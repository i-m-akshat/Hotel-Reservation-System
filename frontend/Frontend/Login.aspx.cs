
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HotelReservationSystem_Part1
{
    public partial class Login : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {

        } 

        protected void btnRegister_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }
    }
}