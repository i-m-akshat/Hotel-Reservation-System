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
using System.Web.Security;
using System.Web.Services;
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
                BindHotels();
            }
            else
            {
                BindHotels();
            }
        }
        #region events
        protected void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton btnView = sender as LinkButton;
                long id = Convert.ToInt64(btnView.CommandArgument);
                if (id != 0)
                {
                    ViewState["HotelID"] = id;
                    var enc_id=_secure.Encrypt(id.ToString(), ConfigurationManager.AppSettings["iv"], ConfigurationManager.AppSettings["key"]);
                    var res = _service.GetHotelById(enc_id).Result;
                    var serialized = JsonConvert.DeserializeObject<Response<string>>(res);
                    if (serialized.IsSuccess && serialized.StatusCode == (int)Enums.HttpStatusCode.OK)
                    {
                        var dec_data = JsonConvert.DeserializeObject<Hotel_model>(_secure.Decrypt(serialized.Data, ConfigurationManager.AppSettings["iv"], ConfigurationManager.AppSettings["key"]));
                        if (dec_data.HotelId != null || dec_data.HotelId != 0)
                        {
                            LoadData(false, dec_data);
                        }
                    }else if(serialized.IsSuccess==false&&serialized.StatusCode==(int)Enums.HttpStatusCode.NotFound)
                    {
                        string script = $"alertError('Error', 'No Data Found !', 'Ok Bhai ! ');";
                        ScriptManager.RegisterStartupScript(this, GetType(), "Error", script, true);
                    }else if(serialized.IsSuccess==false&&serialized.StatusCode==(int)Enums.HttpStatusCode.InternalServerError)
                    {
                        string script = $"alertError('Error', 'Something went wrong from our side !', 'Ok Bhai ! ');";
                        ScriptManager.RegisterStartupScript(this, GetType(), "Error500", script, true);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton btnEdit = sender as LinkButton;
                long id = Convert.ToInt64(btnEdit.CommandArgument);
                ViewState["HotelID"] = id;
                if (id != null||id!=0)
                {
                    var enc_id = _secure.Encrypt(id.ToString(), ConfigurationManager.AppSettings["iv"], ConfigurationManager.AppSettings["key"]);
                    var res = _service.GetHotelById(enc_id).Result;
                    if (res != null)
                    {
                        var response = JsonConvert.DeserializeObject<Response<string>>(res);
                        if (response.IsSuccess && response.StatusCode == (int)Enums.HttpStatusCode.OK)
                        {
                            var dec_res=JsonConvert.DeserializeObject<Hotel_model>(_secure.Decrypt(response.Data, ConfigurationManager.AppSettings["iv"], ConfigurationManager.AppSettings["key"]));
                            if (dec_res.HotelId != null || dec_res.HotelId != 0)
                            {
                                LoadData(true, dec_res);
                            }
                        }
                        else if (response.IsSuccess == false && response.StatusCode == (int)Enums.HttpStatusCode.NotFound)
                        {
                            string script = $"alertError('Error', 'No Data Found !', 'Ok Bhai ! ');";
                            ScriptManager.RegisterStartupScript(this, GetType(), "Error", script, true);
                        }
                        else if (response.IsSuccess == false && response.StatusCode == (int)Enums.HttpStatusCode.InternalServerError)
                        {
                            string script = $"alertError('Error', 'Something went wrong from our side !', 'Ok Bhai ! ');";
                            ScriptManager.RegisterStartupScript(this, GetType(), "Error500", script, true);
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            LinkButton btnDelete = (LinkButton)sender;
            string HotelId = btnDelete.CommandArgument;

            // Register the JavaScript function with the cityId as an argument
            string script = $"alertConfirm('Are you sure?', 'You won\\'t be able to revert this!', 'Yes, delete it!', 'Hotel.aspx/Delete', {HotelId},bindHotels);";

            ScriptManager.RegisterStartupScript(this, GetType(), "DeleteConfirmation", script, true);
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
                            
                            var dec_res= JsonConvert.DeserializeObject<Response<string>>(res);
                            var result = _secure.Decrypt(dec_res.Data, ConfigurationManager.AppSettings["iv"], ConfigurationManager.AppSettings["key"]);
                            if (dec_res.StatusCode.Equals((int)Enums.HttpStatusCode.Created))
                            {
                                string script = $"alertSuccess('Success', 'Created Successfully', 'Ok Bhai ! ');";
                                ScriptManager.RegisterStartupScript(this, GetType(), "Success", script, true);
                            }else if (dec_res.Equals((int)Enums.HttpStatusCode.BadRequest))
                            {
                                string script = $"alertError('Error', 'Sahi Data Bhejo Yrrr !', 'Ok Bhai ! ');";
                                ScriptManager.RegisterStartupScript(this, GetType(), "Error", script, true);
                            }else if (dec_res.Equals((int)Enums.HttpStatusCode.InternalServerError))
                            {
                                string script = $"alertError('Oops !', 'Something Went wrong !', 'Ok Bhai ! ');";
                                ScriptManager.RegisterStartupScript(this, GetType(), "Error1", script, true);
                            }
                        }
                        
                    }
                    else if (btnAddAdmin.Text == "Update" && ViewState["HotelID"]!=null)
                    {
                        var hotelId = Convert.ToInt64(ViewState["HotelID"]);


                        var Hotel = new Hotel_model
                        {
                            Address = txtAddress.Text,
                            HotelName = txtHotelName.Text,
                            CityId = Convert.ToInt64(ddlCity.SelectedItem.Value),
                            StateId = Convert.ToInt64(ddlState.SelectedItem.Value),
                            CountryId = Convert.ToInt64(ddlCountry.SelectedItem.Value),
                            HotelDescription = txtHotelDescription.Text,
                            Latitude = txtLattitude.Text,
                            Longitude = txtLongitude.Text,
                            IsActive = true,

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
                            string enc_model = _secure.Encrypt(JsonConvert.SerializeObject(Hotel), ConfigurationManager.AppSettings["iv"], ConfigurationManager.AppSettings["key"]);
                            string enc_id = _secure.Encrypt(Convert.ToString(hotelId), ConfigurationManager.AppSettings["iv"], ConfigurationManager.AppSettings["key"]);
                            var res = _service.UpdateHotel(enc_model,enc_id).Result;

                            var dec_res = JsonConvert.DeserializeObject<Response<string>>(res);
                            var result = _secure.Decrypt(dec_res.Data, ConfigurationManager.AppSettings["iv"], ConfigurationManager.AppSettings["key"]);
                            if (dec_res.StatusCode.Equals((int)Enums.HttpStatusCode.Created))
                            {
                                string script = $"alertSuccess('Success', 'Updated Successfully', 'Ok Bhai ! ');";
                                ScriptManager.RegisterStartupScript(this, GetType(), "Success", script, true);
                            }
                            else if (dec_res.Equals((int)Enums.HttpStatusCode.BadRequest))
                            {
                                string script = $"alertError('Error', 'Sahi Data Bhejo Yrrr !', 'Ok Bhai ! ');";
                                ScriptManager.RegisterStartupScript(this, GetType(), "Error", script, true);
                            }
                            else if (dec_res.Equals((int)Enums.HttpStatusCode.InternalServerError))
                            {
                                string script = $"alertError('Oops !', 'Something Went wrong !', 'Ok Bhai ! ');";
                                ScriptManager.RegisterStartupScript(this, GetType(), "Error1", script, true);
                            }
                        }
                    }
                    Clear();
                }
                BindHotels();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
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
            try
            {
                var res = _service.GetAllHotel().Result;
                if (res != null)
                {
                    var result = JsonConvert.DeserializeObject<Response<string>>(res);
                    if (result.IsSuccess && result.StatusCode.Equals((int)Enums.HttpStatusCode.OK))
                    {
                        var dec_res=_secure.Decrypt(result.Data,ConfigurationManager.AppSettings["iv"], ConfigurationManager.AppSettings["key"]);
                        var serializeData = JsonConvert.DeserializeObject<List<Hotel_model>>(dec_res);
                        if (serializeData.Count > 0)
                        {
                            rptHotelList.DataSource = serializeData;
                            rptHotelList.DataBind();
                        }
                    }
                    else if (result.IsSuccess == false && result.StatusCode == (int)Enums.HttpStatusCode.NotFound)
                    {
                        string script = $"alertError('Error', 'No Data Found !', 'Ok Bhai ! ');";
                        ScriptManager.RegisterStartupScript(this, GetType(), "Error", script, true);
                    }
                    else if (result.IsSuccess == false && result.StatusCode == (int)Enums.HttpStatusCode.InternalServerError)
                    {
                        string script = $"alertError('Error', 'Something went wrong from our side !', 'Ok Bhai ! ');";
                        ScriptManager.RegisterStartupScript(this, GetType(), "Error500", script, true);
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }
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
            if (ViewState["HotelID"] == null)
            {
                if (!btnIconImgUpload.HasFile)
                    message += "Icon image is necessary";
                else if (btnIconImgUpload.HasFile && !btnIconImgUpload.FileName.EndsWith(".png"))
                    message += "Icon image should be in png format";
                if (!btnBannerImgUpload.HasFile)
                    message += "Banner image is necessary";
                else if (btnBannerImgUpload.HasFile && !btnBannerImgUpload.FileName.EndsWith(".png"))
                    message += "Banner image should be in .png format";
            }
            if (message != string.Empty) {

                return true;
            }
            else
            {
                return false;
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
        private string ConvertToBase64(byte[] arr)
        {
            if (arr != null)
            {
                return "data:image/png;base64," + Convert.ToBase64String(arr);
            }
            else
                return "";

        }
        private void Clear()
        {
            BindCity();
            BindCountry();
            BindState();
            BindHotels();
            txtAddress.Text = string.Empty;
            txtHotelDescription.Text = string.Empty;
            txtHotelName.Text = string.Empty;
            txtLattitude.Text = string.Empty;
            txtLongitude.Text = string.Empty;
            if (ViewState["HotelID"] != null)
            {
                img_BannerIMG.Visible = true;
                btnBannerImgUpload.Visible = false;
                btnIconImgUpload.Visible =false;
                img_IconIMG.Visible = true;
            }
            else
            {
                img_BannerIMG.Visible = false;
                btnBannerImgUpload.Visible = true;
                btnIconImgUpload.Visible = true;
                img_IconIMG.Visible = false;
            }
            ddlCity.SelectedItem.Value = "0";
            ddlState.SelectedItem.Value = "0";
            ddlCountry.SelectedItem.Value = "0";
            txtAddress.Enabled = txtHotelName.Enabled = txtHotelDescription.Enabled = txtLattitude.Enabled = txtLongitude.Enabled = ddlCity.Enabled = ddlCountry.Enabled = ddlState.Enabled = btnBannerImgUpload.Visible = btnIconImgUpload.Visible =btnAddAdmin.Enabled= true;
            img_IconIMG.Visible=img_BannerIMG.Visible = false;

        }

        private void LoadData(bool isEditable, Hotel_model _model)
        {
            txtAddress.Text = _model.Address;
            txtHotelName.Text = _model.HotelName;
            txtHotelDescription.Text = _model.HotelDescription;
            txtLattitude.Text = _model.Latitude;
            txtLongitude.Text = _model.Longitude;
            ddlCity.Items.FindByValue(Convert.ToString(_model.CityId));
            if (ddlCity.Items.FindByValue(Convert.ToString(_model.CityId)) != null)
            {
                ddlCity.SelectedValue = Convert.ToString(_model.CityId) ;
            }
            else
            {
                ddlCity.SelectedIndex = -1; // Clear selection or set a default
            }
            if (ddlCountry.Items.FindByValue(Convert.ToString(_model.CountryId)) != null)
            {
                ddlCountry.SelectedValue= Convert.ToString(_model.CountryId);
            }
            else
            {
                ddlCountry.SelectedIndex = -1;
            }
            if (ddlState.Items.FindByValue(Convert.ToString(_model.StateId)) != null)
            {
                ddlState.SelectedValue = Convert.ToString(_model.StateId);
            }
            else
            {
                ddlState.SelectedIndex = -1;
            }
            //ddlCity.SelectedItem.Value = Convert.ToString(_model.CityId);
            //ddlState.SelectedItem.Value = Convert.ToString(_model.StateId);
            //ddlCountry.SelectedItem.Value = Convert.ToString(_model.CountryId);
            img_IconIMG.ImageUrl = ConvertToBase64(_model.IconImage);
            img_BannerIMG.ImageUrl = ConvertToBase64(_model.BannerImage);
            txtAddress.Enabled = txtHotelName.Enabled = txtHotelDescription.Enabled = txtLattitude.Enabled = txtLongitude.Enabled = ddlCity.Enabled = ddlCountry.Enabled = ddlState.Enabled = btnBannerImgUpload.Visible = btnIconImgUpload.Visible =  isEditable;
            img_BannerIMG.Visible = img_IconIMG.Visible = true;
            if (isEditable)
            {
                btnAddAdmin.Enabled = true;
                btnAddAdmin.Text = "Update";

            }
            else
            {
                btnAddAdmin.Text = "Add";
                btnAddAdmin.Enabled = false;
            }

        }

        [WebMethod]
        public static bool Delete(int id)
        {
            try
            {
                var enc_id = _secure.Encrypt(Convert.ToString(id), ConfigurationManager.AppSettings["iv"], ConfigurationManager.AppSettings["key"]);
                var res =_service.DeleteHotel(enc_id).Result;
                if (res != null)
                {

                    return true;


                }
                else
                {
                    Hotel hotel = new Hotel();
                    hotel.BindHotels();
                    return false;
                }
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        #endregion
    }
}