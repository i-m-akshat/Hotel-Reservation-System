﻿using Frontend.Logic.Implementations;
using Frontend.Logic.Interfaces;
using Frontend.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using Frontend.Models.Mappers;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Web.UI;

namespace Frontend.Admin
{
    public partial class City : System.Web.UI.Page
    {
        private static readonly ICountryDAO _countryDao = new CountryDao();
        private static readonly IStateDAO _stateDao = new StateDao();
        private static readonly ISecureDAO _secure = new SecureDao();
        private static readonly ICityDao _cityDao = new CityDao();  
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                BindCountry();
                BindCity();
                BindState();
            }else if (IsPostBack)
            {
                BindCity();
            }
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
            List<State_DTO> listDTO = JsonConvert.DeserializeObject<List<State_DTO>>(dec_res);
            stateList = listDTO.Select(x => x.FromDTOToModel()).ToList();
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
                cityList=JsonConvert.DeserializeObject<List<City_Model>>(dec_res);
                if (cityList != null)
                {
                    rptCityList.DataSource = cityList;
                            rptCityList.DataBind();
                       
                }
            }
        }
      
        private bool validate(out string message)
        {
            string mes = String.Empty;
            if (ddlCountry.SelectedItem.Value=="0")
                mes += "Please select the country <br/>";
            if (ddlState.SelectedItem.Value == "0")
                mes += "Please select the State <br/>";
            if (txtCityName.Text == string.Empty)
                mes += "Please enter the city name <br/>";
            if (mes != string.Empty)
            {
                message = mes;
                return true;
            }
            else
            {
                message = "";
                return false;
            }
               
            
        }
        protected void btnAddCity_Click(object sender, EventArgs e)
        {
            string Message = string.Empty;
            if (validate(out Message))
            {
                string script = $"alertError_Custom('Poora bharo yar?', '{Message}', 'Ok Bhai ! ');";
                //Response.Write($"<script>alert('{Message}')</script>");
                ScriptManager.RegisterStartupScript(this, GetType(), "validation", script, true);
            }
            else
            {
                City_Model model = new City_Model
                {
                    StateId = Convert.ToInt32(ddlState.SelectedItem.Value),
                    CityName = txtCityName.Text.ToString(),
                    CountryId = Convert.ToInt32(ddlCountry.SelectedItem.Value),
                    IsActive=true,
                };
                string JsonCity = JsonConvert.SerializeObject(model);
                var enc_City = _secure.Encrypt(JsonCity, ConfigurationManager.AppSettings["iv"], ConfigurationManager.AppSettings["key"]);
                if (btnAddCity.Text == "Update")
                {
                    //LinkButton btnEdit = sender as LinkButton;
                    long Id = Convert.ToInt64(ViewState["CityID"]);
                    var enc_id = _secure.Encrypt(Id.ToString(), ConfigurationManager.AppSettings["iv"], ConfigurationManager.AppSettings["key"]);
                    var res = _cityDao.Update(enc_City, enc_id).Result;
                    var dec_res= _secure.Decrypt((res), ConfigurationManager.AppSettings["iv"], ConfigurationManager.AppSettings["key"]);
                    City_Model modelCity = JsonConvert.DeserializeObject<City_Model>(dec_res);
                    if (modelCity != null)
                    {
                        //Response.Write("<script>alert('Updated Successfully')</script>");
                        string script = $"alertSuccess('Success', 'Updated Successfully', 'Ok Bhai ! ');";
                        //Response.Write($"<script>alert('{Message}')</script>");
                        ScriptManager.RegisterStartupScript(this, GetType(), "Success", script, true);
                        BindCity();
                        Clear();
                    }
                }
                else
                {
                    var res = _cityDao.Create(enc_City).Result;
                    var dec_res = _secure.Decrypt((res), ConfigurationManager.AppSettings["iv"], ConfigurationManager.AppSettings["key"]);
                    City_Model modelCity = JsonConvert.DeserializeObject<City_Model>(dec_res);
                    if (modelCity != null)
                    {
                        string script = $"alertSuccess('Success', 'Created Successfully', 'Ok Bhai ! ');";
                        //Response.Write($"<script>alert('{Message}')</script>");
                        ScriptManager.RegisterStartupScript(this, GetType(), "Success", script, true);
                        BindCity();
                        Clear();

                    }
                }

            }
           
           
        }
        private void Clear()
        {
            BindCity();
            BindState();
            BindCountry();
            ddlCountry.SelectedIndex = 0;
            ddlState.SelectedIndex = 0;
            txtCityName.Text = string.Empty;
            txtCityName.Enabled = true;
            ddlState.Enabled = true;
            ddlCountry.Enabled = true;
            btnAddCity.Text = "Add";
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            LinkButton btnView = sender as LinkButton;
            long cityId = Convert.ToInt64(btnView.CommandArgument);
            if (cityId != null || !cityId.Equals(0))
            {
                string _encID = _secure.Encrypt(cityId.ToString(), ConfigurationManager.AppSettings["iv"], ConfigurationManager.AppSettings["key"]);
                if (_encID != string.Empty)
                {
                    var res = _cityDao.GetByID(_encID).Result;
                    if (res!=null)
                    {
                        var _decRes = _secure.Decrypt(res, ConfigurationManager.AppSettings["iv"], ConfigurationManager.AppSettings["key"]);
                        var _final = JsonConvert.DeserializeObject<City_Model>(_decRes);
                        LoadData(false, _final);
                    }
                }
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            
            LinkButton btnEdit = sender as LinkButton;
            long cityId = Convert.ToInt64(btnEdit.CommandArgument);
            ViewState["CityID"] = cityId;
            if (cityId != null || !cityId.Equals(0))
            {
                string _encID = _secure.Encrypt(cityId.ToString(), ConfigurationManager.AppSettings["iv"], ConfigurationManager.AppSettings["key"]);
                if (_encID != string.Empty)
                {
                    var res = _cityDao.GetByID(_encID).Result;
                    if (res != null)
                    {
                        var _decRes = _secure.Decrypt(res, ConfigurationManager.AppSettings["iv"], ConfigurationManager.AppSettings["key"]);
                        var _final = JsonConvert.DeserializeObject<City_Model>(_decRes);
                        LoadData(true, _final);
                        //pnlRPT.Update();
                    }
                }
            }
        }
        private void LoadData(bool EditMode,City_Model model)
        {
            txtCityName.Text = model.CityName;
            ddlCountry.SelectedIndex = model.CountryId;
            ddlState.SelectedIndex = model.StateId;
            txtCityName.Enabled = EditMode;
            ddlState.Enabled = EditMode;
            ddlCountry.Enabled = EditMode;
            btnAddCity.Enabled = EditMode;
            if (EditMode)
            {
                btnAddCity.Text = "Update";
            }
           
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            LinkButton btnDelete = (LinkButton)sender;
            string cityId = btnDelete.CommandArgument;

            // Register the JavaScript function with the cityId as an argument
            string script = $"alertConfirm('Are you sure?', 'You won\\'t be able to revert this!', 'Yes, delete it!', 'City.aspx/Delete', {cityId},bindCity);";

            ScriptManager.RegisterStartupScript(this, GetType(), "DeleteConfirmation", script, true);
            
        }
        [WebMethod]
        public static bool Delete(int id )
        {
            try
            {
                var dec_id = _secure.Encrypt(Convert.ToString(id), ConfigurationManager.AppSettings["iv"], ConfigurationManager.AppSettings["key"]);
                var res = _cityDao.Delete(dec_id).Result;
                if (res != null)
                {
                    //City city = new City();
                    //city.BindCity();
                    return true;
                    

                }
                else
                {
                    City city = new City();
                    city.BindCity();
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