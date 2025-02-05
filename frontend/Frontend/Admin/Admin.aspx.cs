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
using System.IO;
using System.Drawing;
using System.Web.Services;

namespace Frontend.Admin
{
    public partial class Admin1 : System.Web.UI.Page
    {
        private static readonly IAdminDAO _admin = new AdminDao();
       private static readonly ICountryDAO _countryDao = new CountryDao();
        private static readonly IStateDAO _stateDao = new StateDao();
        private static readonly ISecureDAO _secure = new SecureDao();
        private static readonly ICityDao _cityDao = new CityDao();
        private static readonly IRoleDAO _Roledal = new RoleDao();
        private static readonly string[] allowedImgTypes = {  ".png" };//".jpg", ".jpeg",
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
                BindAdmins();
                BindCountry();
                BindState();
                BindCity();
                BindRoles();
                
            }
            else if (IsPostBack)
            {
                BindAdmins();
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
            if (!btnImgUpload.HasFile && ViewState["AdminID"]==null)
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
            if (ddlRole.SelectedIndex == 0)
            {
                message += "Please select the roles";
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
                        CountryId= Convert.ToInt64(ddlCountry.SelectedItem.Value),
                        RoleID=Convert.ToInt64(ddlRole.SelectedItem.Value),
                    };
                    if (btnImgUpload.HasFile)
                    {
                        string FileExtension = System.IO.Path.GetExtension(btnImgUpload.FileName).ToLower();
                        if (!allowedImgTypes.Contains(FileExtension))
                        {
                            string script = $"alertError_Custom('bhai image hi upload krna h !', 'sirf .png  ka hi use kro be', 'Ok Bhai ! ');";
                            //Response.Write($"<script>alert('{Message}')</script>");
                            ScriptManager.RegisterStartupScript(this, GetType(), "imgvalidation", script, true);
                            return;
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
                    Admin_model model = new Admin_model
                    {
                        Address = txtAddress.Text.Trim().ToString(),
                        FullName = txtFullName.Text.Trim().ToString(),
                        Adminname = txtAdminName.Text.Trim().ToString(),
                        PhoneNumber = txtMobileNo.Text.Trim().ToString(),
                        EmailId = txtEmailId.Text.Trim().ToString(),
                        CityId = Convert.ToInt64(ddlCity.SelectedItem.Value),
                        StateId = Convert.ToInt64(ddlState.SelectedItem.Value),
                        CountryId = Convert.ToInt64(ddlCountry.SelectedItem.Value),
                        RoleID = Convert.ToInt64(ddlRole.SelectedItem.Value),
                    };
                    if (btnImgUpload.HasFile)
                    {
                        string FileExtension = System.IO.Path.GetExtension(btnImgUpload.FileName).ToLower();
                        if (!allowedImgTypes.Contains(FileExtension))
                        {
                            string script = $"alertError_Custom('bhai image hi upload krna h !', 'sirf .png  ka hi use kro be', 'Ok Bhai ! ');";
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
                        long id = Convert.ToInt64(ViewState["AdminID"]);
                        var enc_id = _secure.Encrypt(id.ToString(), ConfigurationManager.AppSettings["iv"], ConfigurationManager.AppSettings["key"]);
                        var res = _admin.Update(enc_admin,enc_id).Result;

                        if (res != null)
                        {
                            var dec_res = _secure.Decrypt((res), ConfigurationManager.AppSettings["iv"], ConfigurationManager.AppSettings["key"]);
                            var _Resmodel = JsonConvert.DeserializeObject<Admin_model>(dec_res);
                            if (_Resmodel != null)
                            {
                                string script = $"alertSuccess('Success', 'Updated Successfully', 'Ok Bhai ! ');";
                                //Response.Write($"<script>alert('{Message}')</script>");
                                ScriptManager.RegisterStartupScript(this, GetType(), "Success", script, true);
                                clear();
                            }
                        }
                    }
                }
            }
            else if (message != string.Empty)
            {
                string script = $"alertError_Custom('Poora bharo yar?', '{message}', 'Ok Bhai ! ');";
                //Response.Write($"<script>alert('{Message}')</script>");
                ScriptManager.RegisterStartupScript(this, GetType(), "validation", script, true);
            }
            BindAdmins();
            
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            clear();
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

        #region Methods
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

        private void BindRoles()
        {
            try
            {
                var res = _Roledal.getAll().Result;
                if (res != null)
                {
                    var dec_res = _secure.Decrypt(res, ConfigurationManager.AppSettings["iv"], ConfigurationManager.AppSettings["key"]);
                    var _data = JsonConvert.DeserializeObject<List<Role_Model>>(dec_res);
                    _data.Insert(0, new Role_Model { RoleId = 0, RoleName = "Please Select the Role" });
                    if (_data != null)
                    {
                        ddlRole.DataSource = _data;
                        ddlRole.DataTextField = "RoleName";
                        ddlRole.DataValueField = "RoleId";
                        ddlRole.DataBind();
                        ddlRole.SelectedItem.Value = "0";
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex} is being thrown ");

            }
        }
        /// <summary>
        /// to bind city to dropdown
        /// </summary>
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
        /// <summary>
        /// To bind admin data to gridview
        /// </summary>
        public void BindAdmins()
        {
            List<Admin_model> _list = new List<Admin_model>();
            var res = _admin.GetAll().Result;
            var dec_res = _secure.Decrypt(res, ConfigurationManager.AppSettings["iv"], ConfigurationManager.AppSettings["key"]);
            if (dec_res != string.Empty)
            {
                var serAdmin = JsonConvert.DeserializeObject<List<Admin_model>>(dec_res);
                if(serAdmin != null)
                {
                    rptAdminList.DataSource = serAdmin;
                    rptAdminList.DataBind();
                }
            }
        }
        /// <summary>
        /// to clear the values 
        /// 
        /// </summary>
        /// 
        private void clear()
        {
            txtAddress.Text = string.Empty;
            txtAdminName.Text = string.Empty;
            txtEmailId.Text = string.Empty;
            txtFullName.Text = string.Empty;
            txtMobileNo.Text = string.Empty;
            img_AdminIMG.Visible = false;
            ddlCity.SelectedIndex = 0;
            ddlState.SelectedIndex = 0;
            ddlCountry.SelectedIndex = 0;
            txtAddress.Enabled = txtAdminName.Enabled = txtEmailId.Enabled = txtFullName.Enabled = txtMobileNo.Enabled = ddlCountry.Enabled = ddlCity.Enabled = ddlState.Enabled
                = btnImgUpload.Enabled = btnImgUpload.Visible = ddlRole.Enabled = true;
            ddlRole.SelectedIndex = 0;
            btnAddAdmin.Text = "Add";
            btnAddAdmin.Enabled = true;

        }
        /// <summary>
        /// To load the data 
        /// </summary>
        /// <param name="editable"></param>
        /// <param name="_model"></param>
        private void LoadData(bool editable, Admin_model _model)
        {
            clear();
            //BindCity();
            //BindCountry();
            //BindState();
            //BindRoles();
            txtAddress.Text = _model.Address;
            txtAdminName.Text = _model.Adminname;
            txtEmailId.Text = _model.EmailId;
            txtFullName.Text = _model.FullName;
            txtMobileNo.Text = _model.PhoneNumber;
            ddlCountry.SelectedIndex = Convert.ToInt32(_model.CountryId);
            ddlCity.SelectedIndex = Convert.ToInt32(_model.CityId);
            ddlState.SelectedIndex = Convert.ToInt32(_model.StateId);
            string roleId = Convert.ToString(_model.RoleID);
            if (ddlRole.Items.FindByValue(roleId) != null)
            {
                ddlRole.SelectedValue = roleId;
            }
            else
            {
                ddlRole.SelectedIndex = -1; // Clear selection or set a default
            }
            //ddlRole.SelectedItem.Value = Convert.ToString(_model.RoleID);
            ddlRole.Enabled = editable;
            btnAddAdmin.Enabled = editable;
            txtAddress.Enabled = editable;
            txtAdminName.Enabled = editable;
            txtEmailId.Enabled = editable;
            txtFullName.Enabled = editable;
            txtMobileNo.Enabled = editable;
            btnImgUpload.Enabled = editable;
            ddlCity.Enabled = editable;
            ddlCountry.Enabled = editable;
            ddlState.Enabled = editable;
            if (editable)
            {
                btnAddAdmin.Text = "Update";
                img_AdminIMG.Visible = true;
                img_AdminIMG.ImageUrl = ConvertToBase64(_model.Image);
                btnImgUpload.Visible = true;

            }
            else
            {
                img_AdminIMG.Visible = true;
                img_AdminIMG.ImageUrl = ConvertToBase64(_model.Image);
                btnImgUpload.Visible = false;
            }
        }

        /// <summary>
        /// Convert byte array to image
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        private System.Drawing.Image byteToImage(byte[] arr)
        {
            using (var ms = new MemoryStream(arr))
            {
                return System.Drawing.Image.FromStream(ms);
            }
        }
        ///////////////////////////////////////////////////
        private string ConvertToBase64(byte[] arr)
        {
            if (arr != null)
            {
                return "data:image/png;base64," + Convert.ToBase64String(arr);
            }
            else
                return "";

        }
        #endregion

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            LinkButton btnEdit = sender as LinkButton;
            long id = Convert.ToInt64(btnEdit.CommandArgument);
            if (id != null || !id.Equals(0))
            {
                ViewState["AdminID"] = id;
                string _encID = _secure.Encrypt(id.ToString(), ConfigurationManager.AppSettings["iv"], ConfigurationManager.AppSettings["key"]);
                if (_encID != string.Empty)
                {
                    var res = _admin.Get(_encID).Result;
                    if (res != null)
                    {
                        var _decRes = _secure.Decrypt(res, ConfigurationManager.AppSettings["iv"], ConfigurationManager.AppSettings["key"]);
                        var _final = JsonConvert.DeserializeObject<Admin_model>(_decRes);
                        LoadData(true, _final);
                    }
                }
            }
        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            LinkButton btnView = sender as LinkButton;
            long id = Convert.ToInt64(btnView.CommandArgument);
            if (id != null || !id.Equals(0))
            {
                string _encID = _secure.Encrypt(id.ToString(), ConfigurationManager.AppSettings["iv"], ConfigurationManager.AppSettings["key"]);
                if (_encID != string.Empty)
                {
                    var res = _admin.Get(_encID).Result;
                    if (res != null)
                    {
                        var _decRes = _secure.Decrypt(res, ConfigurationManager.AppSettings["iv"], ConfigurationManager.AppSettings["key"]);
                        var _final = JsonConvert.DeserializeObject<Admin_model>(_decRes);
                        LoadData(false, _final);
                    }
                }
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            LinkButton btnDelete = (LinkButton)sender;
            string Id= btnDelete.CommandArgument;

            // Register the JavaScript function with the cityId as an argument
            string script = $"alertConfirm('Are you sure?', 'You won\\'t be able to revert this!', 'Yes, delete it!', 'Admin.aspx/Delete', {Id},bindAdmins);";

            ScriptManager.RegisterStartupScript(this, GetType(), "DeleteConfirmation", script, true);
        }

        [WebMethod]
        public static bool Delete(int id)
        {
            try
            {
                var dec_id = _secure.Encrypt(Convert.ToString(id), ConfigurationManager.AppSettings["iv"], ConfigurationManager.AppSettings["key"]);
                var res = _admin.Delete(dec_id).Result;
                if (res != null)
                {
                    return true;


                }
                else
                {
                    Admin1 admin = new Admin1();
                    admin.BindAdmins();
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