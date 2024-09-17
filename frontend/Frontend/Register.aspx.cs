using Frontend.LogicLayer.Implementations;
using Frontend.LogicLayer.Interfaces;
using Frontend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace HotelReservationSystem_Part1
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }
        private readonly IUserDAO _dao=new UserDao();

        private  Task<bool> isSuccess;
        

        protected   void btnRegister_Click(object sender, EventArgs e)
        {
            User user = new User
            {
                UserId = txtUserID.Text,
                FullName = txtFullName.Text,
                Address = txtAddress.Text,
                StateId = 1,
                CountryId = 1,
                CityId = 1,
                EmailId = txtEmail.Text,
                MobileNo = txtPhoneNo.Text,
                Password = txtPassword.Text,
            };
            isSuccess=registerUser(user);
            bool res = isSuccess.Result;
            if (res)
            {
                ClearAll();
                Response.Write("<script>alert('User Registration Successfull')</script>");
            }
        }

        private async Task<bool> registerUser(User user)
        {
            
            isSuccess = _dao.Register(user);
            bool res = await isSuccess;
            return res;
        }
        private void ClearAll()
        {
            txtUserID.Text = string.Empty;
            txtFullName.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtPhoneNo.Text = string.Empty;
        }
    }
}