
using Frontend.LogicLayer.Implementations;
using Frontend.LogicLayer.Interfaces;
using Frontend.Models;
using Newtonsoft.Json;
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
        private static readonly IUserDAO _userService = new UserDao();
        protected void Page_Load(object sender, EventArgs e)
        {

        } 

        protected void btnRegister_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUserName != null && txtPassword != null) { 
                string Res=_userService.Login(txtUserName.Text.ToString().Trim(),txtPassword.Text.ToString().Trim()).Result;
               var _user = JsonConvert.DeserializeObject<User>(Res);
                   
                Response.Write("<script>alert('You have been successfully logged in.')</script>");
            }
        }
    }
}