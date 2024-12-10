using Frontend.Logic;
using Frontend.Logic.Implementations;
using Frontend.Logic.Interfaces;
using Frontend.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Frontend.Admin
{
    public partial class Admin1 : System.Web.UI.Page
    {
        private static readonly IAdminDAO _admin = new AdminDao();
       private static readonly ICountryDAO _countryDao = new CountryDao();
        private static readonly IStateDAO _stateDao = new StateDao();
        private static readonly ISecureDAO _secure = new SecureDao();
        private static readonly ICityDao _cityDao = new CityDao();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                BindCountry();
                BindState();
                BindCity();
            }
        }

        protected void btnAddAdmin_Click(object sender, EventArgs e)
        {

        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            
        }
        public void BindCountry()
        {
            try
            {
                List<Country_Model> countryList = new List<Country_Model>();
                var res = _countryDao.GetAll().Result;
                var dec_res = _secure.Decrypt(res, ConfigurationManager.AppSettings["iv"], ConfigurationManager.AppSettings["key"]);
                countryList = JsonConvert.DeserializeObject<List<Country_Model>>(dec_res);
                countryList.Insert(0, new Country_Model { CountryId = 0, CountryName = "Please Select the Country" });
                ddlCountry.DataSource = countryList;
                ddlCountry.DataTextField = "CountryName";
                ddlCountry.DataValueField = "CountryId";
                ddlCountry.DataBind();
                //ddlCountry.Items.Insert(0, new ListItem("Please Select the Country", "0"));
                ddlCountry.SelectedIndex = 0;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public void BindState()
        {
            List<State_Model> stateList = new List<State_Model>();
            var res = _stateDao.GetAll().Result;
            var dec_res = _secure.Decrypt(res, ConfigurationManager.AppSettings["key"], ConfigurationManager.AppSettings["iv"]);
            List<State_Model> listDTO = JsonConvert.DeserializeObject<List<State_Model>>(dec_res);
            //stateList = listDTO.Select(x => x.FromDTOToModel()).ToList();
            stateList = listDTO.ToList();
            stateList.Insert(0, new State_Model { StateId = 0, StateName = "Please Select the State" });
            ddlState.DataSource = stateList;
            ddlState.DataTextField = "StateName";
            ddlState.DataValueField = "StateId";
            ddlState.DataBind();
            ddlState.SelectedIndex = 0;
        }
        public void BindCity()
        {
            List<City_Model> cityList = new List<City_Model>();
            var res = _cityDao.Get().Result;
            var dec_res = _secure.Decrypt(res, ConfigurationManager.AppSettings["iv"], ConfigurationManager.AppSettings["key"]);
            if (dec_res != string.Empty)
            {
                cityList = JsonConvert.DeserializeObject<List<City_Model>>(dec_res);]
                cityList.Insert(0, new City_Model { CityId = 0, CityName = "Please Select the City" });
                if (cityList != null)
                {
                    ddlCity.DataSource = cityList;
                    ddlCity.DataTextField = "CityName";
                    ddlCity.DataValueField = "CityId";
                    ddlCity.DataBind();
                    ddlCity.SelectedIndex = 0;

                }
            }
        }
        private void clear()
        {
            txtAddress.Text = string.Empty;
            txtAdminName.Text = string.Empty;   
            txtEmailId.Text=string.Empty;
            txtFullName.Text = string.Empty;
            txtMobileNo.Text = string.Empty;
            
        }
        private void LoadData(bool editable,Admin_model _model)
        {
            txtAddress.Text = _model.Address;
            txtAdminName.Text = _model.Adminname;
            txtEmailId.Text=_model.EmailId;
            txtFullName.Text=_model.FullName;
            txtMobileNo.Text = _model.PhoneNumber;
            btnAddAdmin.Enabled = editable;
            txtAddress.Enabled=editable;
            txtAdminName.Enabled = editable;
            txtEmailId.Enabled = editable;
            txtFullName.Enabled=editable;
            txtMobileNo.Enabled = editable;
            if (editable)
            {
                btnAddAdmin.Text = "Update";
                

            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {

        }

        protected void btnView_Click(object sender, EventArgs e)
        {

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {

        }
    }
}