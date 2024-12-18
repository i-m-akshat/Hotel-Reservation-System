using Frontend.Logic.Implementations;
using Frontend.Logic.Interfaces;
using Frontend.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Frontend.Admin
{
    public partial class Hotel : System.Web.UI.Page
    {
        private static readonly ICountryDAO _countryDao = new CountryDao();
        private static readonly IStateDAO _stateDao = new StateDao();
        private static readonly ISecureDAO _secure = new SecureDao();
        private static readonly ICityDao _cityDao = new CityDao();
        private static readonly IHotelDao _service=new HotelDao();
        private static readonly string[] allowedImgTypes = { ".png" };//".jpg", ".jpeg",
        //private static readonly IHotel
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCountry();
                BindState();
                BindCity();
            }
        }
        #region events
        protected void btnView_Click(object sender, EventArgs e)
        {

        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {

        }

        protected void btnAddAdmin_Click(object sender, EventArgs e)
        {
            try
            {
                string Message=string.Empty;
                if(validate(out Message))
                {
                    string script = $"alertError_Custom('Poora bharo yar?', '{Message}', 'Ok Bhai ! ');";
                   
                    ScriptManager.RegisterStartupScript(this, GetType(), "validation", script, true);
                }
                else
                {
                    if (btnAddAdmin.Text == "Add")
                    {
                        var Hotel = new Hotel_model
                        {
                            Address=txtAddress.Text,
                            HotelName=txtHotelName.Text,
                            CityId=Convert.ToInt64(ddlCity.SelectedItem.Value),
                            StateId= Convert.ToInt64(ddlState.SelectedItem.Value),
                            CountryId=Convert.ToInt64(ddlCountry.SelectedItem.Value),
                            HotelDescription=txtHotelDescription.Text,
                            Latitude=txtLattitude.Text,
                            Longitude=txtLongitude.Text,
                            IsActive=true,
                            
                        };
                        if (btnBannerImgUpload.HasFile)
                        {
                            string FileExtension = System.IO.Path.GetExtension(btnBannerImgUpload.FileName).ToLower();
                            if (!allowedImgTypes.Contains(FileExtension))
                            {
                                string script = $"alertError_Custom('bhai image hi upload krna h !', 'sirf .png  ka hi use kro be', 'Ok Bhai ! ');";
                                //Response.Write($"<script>alert('{Message}')</script>");
                                ScriptManager.RegisterStartupScript(this, GetType(), "imgvalidation", script, true);
                            }
                            else
                            {
                                var res = imgToByte(btnBannerImgUpload);
                                if (res != null)
                                {
                                    Hotel.BannerImage = res;
                                }
                            }
                        }
                        if (btnIconImgUpload.HasFile)
                        {
                            string FileExtension = System.IO.Path.GetExtension(btnIconImgUpload.FileName).ToLower();
                            if (!allowedImgTypes.Contains(FileExtension))
                            {
                                string script = $"alertError_Custom('bhai image hi upload krna h !', 'sirf .png  ka hi use kro be', 'Ok Bhai ! ');";
                                //Response.Write($"<script>alert('{Message}')</script>");
                                ScriptManager.RegisterStartupScript(this, GetType(), "imgvalidation", script, true);
                            }
                            else
                            {
                                var res = imgToByte(btnIconImgUpload);
                                if (res != null)
                                {
                                    Hotel.IconImage = res;
                                }
                            }
                        }
                        if (Hotel != null)
                        {
                            string enc_model=_secure.Encrypt(JsonConvert.SerializeObject(Hotel), ConfigurationManager.AppSettings["iv"], ConfigurationManager.AppSettings["key"]);

                            var res = _service.AddHotel(enc_model).Result;
                            var dec_res= JsonConvert.DeserializeObject<Response<string>>(_secure.Decrypt(res, ConfigurationManager.AppSettings["iv"], ConfigurationManager.AppSettings["key"]));
                            if(dec_res.StatusCode.Equals(Enums.HttpStatusCode.Created))
                            {
                                string script = $"alertSuccess('Success', 'Created Successfully', 'Ok Bhai ! ');";
                                ScriptManager.RegisterStartupScript(this, GetType(), "Success", script, true);
                            }else if (dec_res.Equals(Enums.HttpStatusCode.BadRequest))
                            {
                                string script = $"alertError('Error', 'Sahi Data Bhejo Yrrr !', 'Ok Bhai ! ');";
                                ScriptManager.RegisterStartupScript(this, GetType(), "Success", script, true);
                            }else if (dec_res.Equals(Enums.HttpStatusCode.InternalServerError))
                            {
                                string script = $"alertError('Oops !', 'Something Went wrong !', 'Ok Bhai ! ');";
                                ScriptManager.RegisterStartupScript(this, GetType(), "Success", script, true);
                            }
                        }
                    }
                    else if (btnAddAdmin.Text == "Update")
                    {

                    }
                }
                
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region Bind Methods
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
                cityList = JsonConvert.DeserializeObject<List<City_Model>>(dec_res);
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
        public void BindHotels()
        {

        }

        #endregion

        #region Methods
        public bool validate(out string message)
        {
            message = string.Empty;
            if (txtHotelName.Text == null)
                message += "Hotel Name is compulsary";
            if (txtHotelDescription.Text == null)
                message += "Hotel Description is necessary";
            if (txtAddress.Text == null)
                message += "Address is necessary";
            if (txtLattitude.Text == null)
                message += "Lattitude is necessary";
            if (txtLongitude.Text == null)
                message += "Longitude is necessary";
            if (ViewState["HotelID"] != null)
            {
                if (btnIconImgUpload.HasFile)
                    message += "Icon image is necessary";
                if (btnBannerImgUpload.HasFile)
                    message += "Banner image is necessary";
            }
            if (message != string.Empty) {

                return false;
            }
            else
            {
                return true;
            }
        }
        private byte[] imgToByte(FileUpload btnImgUpload)
        {
            using (var ms = new MemoryStream())
            {
                btnImgUpload.FileContent.CopyTo(ms);
                return ms.ToArray();
            }
        }
        #endregion
    }
}