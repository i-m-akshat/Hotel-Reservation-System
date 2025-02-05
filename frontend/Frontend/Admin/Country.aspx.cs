using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
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
            if (!IsPostBack)
            {
                BindData();
            }
            else if (IsPostBack)
            {
                BindData();
            }
                
        }
        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtCountryName.Text = string.Empty;
            btnAddCountry.Text = "Add";
        }
        private void BindData()
        {
            var res = _dao.GetAll().Result;
            var res_dec=_secure.Decrypt(res, ConfigurationManager.AppSettings["key"].ToString(), ConfigurationManager.AppSettings["iv"].ToString());
            List<Country_Model> listCountry = JsonConvert.DeserializeObject<List<Country_Model>>(res_dec);
            rptTblCountry.DataSource = listCountry; rptTblCountry.DataBind();
        }

        protected void btnAddCountry_Click(object sender, EventArgs e)
        {
            if (btnAddCountry.Text == "Add")
            {
                var count = new Frontend.Models.Country_Model
                {
                    CountryName = txtCountryName.Text.Trim().ToString(),
                    IsActive= true, 
                };
                var encCount = _secure.Encrypt(JsonConvert.SerializeObject(count), ConfigurationManager.AppSettings["key"].ToString(), ConfigurationManager.AppSettings["iv"].ToString());
                var res = _dao.Create(encCount).Result;
                if (res != null)
                {
                    Response.Write("<script>alert('Created Successfully')</script>");
                    BindData();
                }
            }
            else if(btnAddCountry.Text =="Update"&& ViewState["CountryID"] != null)
            {
                var count = new Frontend.Models.Country_Model
                {
                    CountryName = txtCountryName.Text.Trim().ToString(),
                };
                var encCount = _secure.Encrypt(JsonConvert.SerializeObject(count), ConfigurationManager.AppSettings["key"].ToString(), ConfigurationManager.AppSettings["iv"].ToString());
                var enc_id= _secure.Encrypt(Convert.ToString(ViewState["CountryID"]), ConfigurationManager.AppSettings["key"].ToString(), ConfigurationManager.AppSettings["iv"].ToString());
                //var res = _dao.Update(enc_id,encCount).Result;
                var res = _dao.Update(enc_id, encCount).Result;
                if (res != null)
                {
                    Response.Write("<script>alert('Updated Successfully')</script>");
                    BindData();
                    txtCountryName.Text = string.Empty;
                }
            }
           

        }

        

        protected void btnView_Click(object sender, EventArgs e)
        {
            LinkButton btnEdit = sender as LinkButton;
            long id = Convert.ToInt64(btnEdit.CommandArgument);
            if (!id.Equals(null))
            {
                string enc_id = _secure.Encrypt(id.ToString(), ConfigurationManager.AppSettings["key"], ConfigurationManager.AppSettings["iv"]);
                string country = _dao.GetById(enc_id).Result;
                var dec = _secure.Decrypt(country, ConfigurationManager.AppSettings["key"], ConfigurationManager.AppSettings["iv"]);
                Country_Model _country = JsonConvert.DeserializeObject<Country_Model>(dec);
                txtCountryName.Text = _country.CountryName;
                //ViewState["CountryID"] = _country.CountryId;
                EnableDisable(false);
               
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            EnableDisable(true);
            LinkButton btnEdit = sender as LinkButton;
            long id = Convert.ToInt64(btnEdit.CommandArgument);
            if (!id.Equals(null))
            {
                string enc_id = _secure.Encrypt(id.ToString(), ConfigurationManager.AppSettings["key"], ConfigurationManager.AppSettings["iv"]);
                string country = _dao.GetById(enc_id).Result;
                var dec = _secure.Decrypt(country, ConfigurationManager.AppSettings["key"], ConfigurationManager.AppSettings["iv"]);
                Country_Model _country = JsonConvert.DeserializeObject<Country_Model>(dec);
                txtCountryName.Text = _country.CountryName;
                ViewState["CountryID"] = _country.CountryId;
                btnAddCountry.Text = "Update";
            }

        }
        public void EnableDisable(bool isEdit)
        {
                btnAddCountry.Enabled = isEdit;
           
                btnClear.Enabled = isEdit;
          
                txtCountryName.Enabled = isEdit;
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            LinkButton btnDelete = (LinkButton)sender;
            string countryId = btnDelete.CommandArgument;

            // Register the JavaScript function with the cityId as an argument
            string script = $"alertConfirm('Are you sure?', 'You won\\'t be able to revert this!', 'Yes, delete it!', 'Country.aspx/Delete', {countryId},bindCountry);";

            ScriptManager.RegisterStartupScript(this, GetType(), "DeleteConfirmation", script, true);
        }
        [WebMethod]
        public static bool Delete(int id)
        {
            try
            {
                var dec_id = _secure.Encrypt(Convert.ToString(id), ConfigurationManager.AppSettings["iv"], ConfigurationManager.AppSettings["key"]);
                var res = _dao.Delete(dec_id).Result;
                if (res != null)
                {
                    //City city = new City();
                    //city.BindCity();
                    return true;


                }
                else
                {
                    Country country= new Country();
                    country.BindData();
                    return false;
                }
            }
            catch (Exception ex)
            {

                throw;
            }

        }
    }
}