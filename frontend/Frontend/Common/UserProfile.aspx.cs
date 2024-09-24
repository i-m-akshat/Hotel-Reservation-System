using Frontend.LogicLayer.Implementations;
using Frontend.LogicLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HotelReservationSystem_Part1.Common
{
    public partial class UserProfile : System.Web.UI.Page
    {
        private static readonly IUserDAO _userDao = new UserDao();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User_Name"] == null && Session["UserId"] == null)
            {
                Response.Redirect("/Common/Default.aspx");
            }
            
        }
    }
}