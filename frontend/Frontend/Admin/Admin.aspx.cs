using Frontend.Logic;
using Frontend.Logic.Implementations;
using Frontend.Logic.Interfaces;
using Frontend.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
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
        private static readonly string[] allowedImgTypes = { ".jpg", ".jpeg", ".png" };
        public class ErrorResponse
        {
            public string Type { get; set; }
            public string Title { get; set; }
            public int Status { get; set; }
            public string TraceId { get; set; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                BindCountry();
                BindState();
                BindCity();
                
            }
        }
        private bool validate(out string message)
        {
            message = string.Empty;
            if (txtAddress.Text == null) {
                message += "Please enter the address";
            }
            if (txtAdminName.Text == null)
            {
                message += "Please enter the admin name";
            }
            if (txtEmailId.Text == null)
            {
                message += "Please enter the email id";

            }
            if (txtFullName.Text == null)
            {
                message += "please enter the full name";

            }
            if (txtMobileNo.Text == null)
            {
                message += "Please enter the mobile no";
            }
            if (!btnImgUpload.HasFile)
            {
                message += "please select the image in order to upload it ";
            }
            if (ddlCity.SelectedIndex == 0)
            {
                message += "please select the city";

            }
            if (ddlState.SelectedIndex == 0)
            {
                message += "please select the state";
            }
            if (ddlCountry.SelectedIndex == 0)
            {
                message += "please select the country";
            }
            if (txtMobileNo.Text == string.Empty)
            {
                message += "please enter the mobile no ";

            }
            if (txtEmailId.Text == string.Empty)
            {
                message += "Please enter the email id ";
            }
            if (message != string.Empty)
            {
                return false;
            }

            else
            {
                return true;
            }
        }
        protected void txtName_LostFocus(object sender, EventArgs e)
        {
            var enc_user = _admin.Login(txtAdminName.Text).Result;
            //var des_user = JsonConvert.DeserializeObject<ErrorResponse>(enc_user);
           
            if (enc_user != null&&!enc_user.Contains("Not Found"))
            {
                var user = _secure.Decrypt(enc_user, ConfigurationManager.AppSettings["key"].ToString(), ConfigurationManager.AppSettings["iv"].ToString());
                Admin_model _admin = JsonConvert.DeserializeObject<Admin_model>(user);
                if (_admin.FullName != null)
                {
                    

                    string script= $"alertError('bro not allowed !', 'bro use any other name but not this', 'Ok Bhai ! ');";
                    ScriptManager.RegisterStartupScript(this, GetType(), "validateAdminname", script, true);
                    txtAdminName.Text = string.Empty;
                    //lblAdminName_message.Text = "This name have been already taken. Please use any other name";
                }

            }

        }
        protected void btnAddAdmin_Click(object sender, EventArgs e)
        {
            string message = string.Empty;
            if(validate(out message)){
                if (btnAddAdmin.Text == "Add")
                {
                    Admin_model model = new Admin_model
                    {
                        Address=txtAddress.Text.Trim().ToString(),
                        FullName=txtFullName.Text.Trim().ToString(),
                        Adminname=txtAdminName.Text.Trim().ToString(),
                        PhoneNumber=txtMobileNo.Text.Trim().ToString(),
                        EmailId=txtEmailId.Text.Trim().ToString(),
                        CityId=Convert.ToInt64(ddlCity.SelectedItem.Value),
                        StateId= Convert.ToInt64(ddlState.SelectedItem.Value),
                        CountryId= Convert.ToInt64(ddlCountry.SelectedItem.Value)
                    };
                    if (btnImgUpload.HasFile)
                    {
                        string FileExtension = System.IO.Path.GetExtension(btnImgUpload.FileName).ToLower();
                        if (!allowedImgTypes.Contains(FileExtension))
                        {
                            string script = $"alertError_Custom('bhai image hi upload krna h !', 'sirf .png ya .jpg ya .jpeg ka hi use kro be', 'Ok Bhai ! ');";
                            //Response.Write($"<script>alert('{Message}')</script>");
                            ScriptManager.RegisterStartupScript(this, GetType(), "imgvalidation", script, true);
                        }
                        else
                        {
                            var res = imgToByte(btnImgUpload);
                            if (res != null)
                            {
                                model.Image = res;
                            }
                        }
                    }
                    if (model != null)
                    {
                        string json = JsonConvert.SerializeObject(model);
                        var enc_admin = _secure.Encrypt(json, ConfigurationManager.AppSettings["iv"], ConfigurationManager.AppSettings["key"]);
                        var res=_admin.Create(enc_admin).Result;

                        if (res != null)
                        {
                            var dec_res = _secure.Decrypt((res), ConfigurationManager.AppSettings["iv"], ConfigurationManager.AppSettings["key"]);
                            var _Resmodel = JsonConvert.DeserializeObject<Admin_model>(dec_res);
                            if (_Resmodel != null)
                            {
                                string script = $"alertSuccess('Success', 'Created Successfully', 'Ok Bhai ! ');";
                                //Response.Write($"<script>alert('{Message}')</script>");
                                ScriptManager.RegisterStartupScript(this, GetType(), "Success", script, true);
                                clear();
                            }
                        }
                    }
                }
                else if (btnAddAdmin.Text == "Update")
                {

                }
            }
            else if (message != string.Empty)
            {
                string script = $"alertError_Custom('Poora bharo yar?', '{message}', 'Ok Bhai ! ');";
                //Response.Write($"<script>alert('{Message}')</script>");
                ScriptManager.RegisterStartupScript(this, GetType(), "validation", script, true);
            }
            
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            
        }
        /// <summary>
        /// function to convert the uploaded image into byte[] array
        /// </summary>
        /// <returns></returns>
        private byte[] imgToByte(FileUpload btnImgUpload)
        {
            using (var ms = new MemoryStream())
            {
                btnImgUpload.FileContent.CopyTo(ms);
                return ms.ToArray();
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
        private void clear()
        {
            txtAddress.Text = string.Empty;
            txtAdminName.Text = string.Empty;   
            txtEmailId.Text=string.Empty;
            txtFullName.Text = string.Empty;
            txtMobileNo.Text = string.Empty;
            img_AdminIMG.Visible = false;
            
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
            btnImgUpload.Enabled = editable;
            if (editable)
            {
                btnAddAdmin.Text = "Update";
                img_AdminIMG.Visible = true;
            }
            else
            {
                img_AdminIMG.Visible = false;
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