using Frontend.Logic;
using Frontend.Logic.Implementations;
using Frontend.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Frontend.Models;
using HotelReservationSystem_Part1.Admin;
using Newtonsoft.Json;

namespace HotelReservationSystem_Part1
{
    public partial class AdminLogin : System.Web.UI.Page
    {
        private static readonly IAdminDAO _dao=new AdminDao();
        private static readonly ISecureDAO _secureDAO=new SecureDao();  
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            var enc_user=_dao.Login(txtUserName.Text).Result;
            if (enc_user != null) {
                var user=_secureDAO.Decrypt(enc_user, ConfigurationManager.AppSettings["key"].ToString(), ConfigurationManager.AppSettings["iv"].ToString());
                Admin_model _admin = JsonConvert.DeserializeObject<Admin_model>(user);
                Response.Write($"<script>alert('Hello{_admin.FullName}')</script>");
            }
        }

        
    }
}