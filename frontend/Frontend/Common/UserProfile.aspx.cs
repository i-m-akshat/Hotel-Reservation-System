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
using Newtonsoft.Json;

namespace HotelReservationSystem_Part1.Common
{
    public partial class UserProfile : System.Web.UI.Page
    {
        public delegate void del_Load(string LoginId);
        private static readonly IUserDAO _userDao = new UserDao();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User_Name"] == null && Session["UserId"] == null)
            {
                Response.Redirect("/Common/Default.aspx");
            }
            else
            {
                LoadData(Convert.ToString(Session["UserId"]));
            }
            
        }
        
        private void LoadData(string LoginID)
        {
            string jsonUser=_userDao.GetUserByUserID(Convert.ToString(Session["UserId"])).Result;
            var _user=JsonConvert.DeserializeObject<User>(jsonUser);
            if (_user != null)
            {
                lblEmail.Text = _user.EmailId.ToString();
                lblCity.Text = _user.CityId.ToString();
                lblState.Text = _user.StateId.ToString();
                lblMobileNo.Text = _user.MobileNo.ToString();
                lblAddress.Text = _user.Address.ToString();
            }
            else
            {
                Response.Redirect("/Common/Default.aspx");
            }
        }
    }
}