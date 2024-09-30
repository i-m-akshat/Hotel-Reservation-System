using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Frontend.Logic.Implementations;
using Frontend.Logic.Interfaces;
using Frontend.Models;
using Newtonsoft.Json;

namespace Frontend.Admin
{
    public partial class Country : System.Web.UI.Page
    {
        private static readonly ICountryDAO _dao=new CountryDao();
        private static readonly ISecureDAO _secure=new SecureDao(); 
        protected void Page_Load(object sender, EventArgs e)
        {
            BindData();
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtCountryName.Text = string.Empty;
        }
        private void BindData()
        {
            DataTable dt = new DataTable();
            var res = _dao.GetAll().Result;
            var res_dec=_secure.Decrypt(res, ConfigurationManager.AppSettings["key"].ToString(), ConfigurationManager.AppSettings["iv"].ToString());
            List<Country_Model> listCountry = JsonConvert.DeserializeObject<List<Country_Model>>(res_dec);
            grdCountryList.DataSource = listCountry; grdCountryList.DataBind();
        }

        protected void btnAddCountry_Click(object sender, EventArgs e)
        {
            var count = new Frontend.Models.Country_Model
            {
                CountryName = txtCountryName.Text.Trim().ToString(),
            };
            var encCount = _secure.Encrypt(JsonConvert.SerializeObject(count), ConfigurationManager.AppSettings["key"].ToString(), ConfigurationManager.AppSettings["iv"].ToString());
            var res = _dao.Create(encCount).Result;
            if (res != null) {
                Response.Write("<script>alert('Created Successfully')</script>");
                BindData();
                }

        }
    }
}