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
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Frontend.Admin
{
    public partial class HotelImage : System.Web.UI.Page
    {
        private readonly IHotelDao _hotelDao = new HotelDao();
        private static readonly ISecureDAO _secure = new SecureDao();
        private static readonly IHotelImageDAO _service = new HotelImageDao();
        private static readonly string[] allowedImgTypes = { ".png", ".jpg", ".jpeg" };
        #region events
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                LoadAllHotels();
            }
            if (ViewState["currentPageIndex"] != null)
            {
                BindHotelImages(Convert.ToInt32(ViewState["currentPageIndex"]));
            }
            else
            {
                BindHotelImages();
            }
            
        }
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton btnEdit = sender as LinkButton;
                long id = Convert.ToInt64(btnEdit.CommandArgument);
                if (id != 0 || !id.Equals(null))
                {
                    var dec_id = _secure.Encrypt(id.ToString(), ConfigurationManager.AppSettings["iv"], ConfigurationManager.AppSettings["key"]);
                    var res = _service.GetHotelImageById(dec_id).Result;
                    if (res != null)
                    {
                        var deserializedRes = JsonConvert.DeserializeObject<Response<string>>(res);
                        if (deserializedRes != null)
                        {
                            var dec_res = _secure.Decrypt(deserializedRes.Data, ConfigurationManager.AppSettings["iv"], ConfigurationManager.AppSettings["key"]);
                            var _deserializedData = JsonConvert.DeserializeObject<HotelImage_ModelWithoutDates>(dec_res);
                            //if (dec_res != null)
                            //{
                            //    if (ddlHotel.Items.FindByValue(_deserializedData.HotelId.ToString()) != null)
                            //    {
                            //        ddlHotel.SelectedItem.Value = Convert.ToString(_deserializedData.HotelId);

                            //    }

                            //}
                            LoadData(true, _deserializedData);
                            ViewState["HotelImageID"] = _deserializedData.HotelImageId;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        protected void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton btnView = sender as LinkButton;
                long id = Convert.ToInt64(btnView.CommandArgument);
                if (id != 0 || !id.Equals(null))
                {
                    var dec_id = _secure.Encrypt(id.ToString(), ConfigurationManager.AppSettings["iv"], ConfigurationManager.AppSettings["key"]);
                    var res = _service.GetHotelImageById(dec_id).Result;
                    if (res != null)
                    {
                        var deserializedRes = JsonConvert.DeserializeObject<Response<string>>(res);
                        if (deserializedRes != null)
                        {
                            var dec_res = _secure.Decrypt(deserializedRes.Data, ConfigurationManager.AppSettings["iv"], ConfigurationManager.AppSettings["key"]);
                            var _deserializedData = JsonConvert.DeserializeObject<HotelImage_ModelWithoutDates>(dec_res);
                            //if (dec_res != null)
                            //{
                            //    if (ddlHotel.Items.FindByValue(_deserializedData.HotelId.ToString()) != null)
                            //    {
                            //        ddlHotel.SelectedItem.Value = Convert.ToString(_deserializedData.HotelId);

                            //    }

                            //}
                            LoadData(false, _deserializedData);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            LinkButton btnDelete = (LinkButton)sender;
            string HotelImageId = btnDelete.CommandArgument;

            // Register the JavaScript function with the cityId as an argument
            string script = $"alertConfirm('Are you sure?', 'You won\\'t be able to revert this!', 'Yes, delete it!', 'HotelImage.aspx/Delete', {HotelImageId},bindHotelImages);";

            ScriptManager.RegisterStartupScript(this, GetType(), "DeleteConfirmation", script, true);
        }
        protected void btnClear_Click(object sender, EventArgs e)
        {
            clear();
        }
        protected void btnAddHotelImage_Click(object sender, EventArgs e)
        {
            try
            {
                string Message = string.Empty;

                if (validate(out Message))
                {
                    if (btnAddHotelImage.Text == "Add")
                    {

                        if (btnUploadImages.HasFiles)
                        {
                            List<HotelImage_model> list_imageModels = new List<HotelImage_model>();
                            //int _uploadedCount = 0;
                            foreach (var file in btnUploadImages.PostedFiles)
                            {
                                string fileExtension = System.IO.Path.GetExtension(file.FileName);
                                if (!allowedImgTypes.Contains(fileExtension))
                                {
                                    string script = $"alertError_Custom('bhai image hi upload krna h !', 'sirf .png ya .jpg ya .jpeg  ka hi use kro be', 'Ok Bhai ! ');";
                                    //Response.Write($"<script>alert('{Message}')</script>");
                                    ScriptManager.RegisterStartupScript(this, GetType(), "imgvalidation", script, true);
                                }
                                else
                                {
                                    var byteForm_File = imgToByte(file);
                                    var data = new HotelImage_model
                                    {
                                        ContentType = fileExtension,
                                        Createdby = 0,
                                        HotelId = Convert.ToInt64(ddlHotel.SelectedItem.Value),
                                        Image = byteForm_File,
                                        ImageName = file.FileName.Replace(fileExtension, "").Trim(),
                                        Isactive = true,
                                    };
                                    list_imageModels.Add(data);


                                }
                            }
                            if (list_imageModels.Count > 0 && list_imageModels.Count == btnUploadImages.PostedFiles.Count)
                            {
                                foreach (var data in list_imageModels)
                                {
                                    var json = JsonConvert.SerializeObject(data);
                                    var _encData = _secure.Encrypt(json, ConfigurationManager.AppSettings["iv"], ConfigurationManager.AppSettings["key"]);
                                    var res = _service.AddHotelImage(_encData).Result;
                                    var des_res = JsonConvert.DeserializeObject<Response<string>>(res);
                                    var result = _secure.Decrypt(des_res.Data, ConfigurationManager.AppSettings["iv"], ConfigurationManager.AppSettings["key"]);
                                    if (des_res.StatusCode.Equals((int)Enums.HttpStatusCode.Created))
                                    {
                                        string script = $"alertSuccess('Success', 'Created Successfully', 'Ok Bhai ! ');";
                                        ScriptManager.RegisterStartupScript(this, GetType(), "Success", script, true);
                                        //_uploadedCount += 1;
                                    }
                                    else if (des_res.Equals((int)Enums.HttpStatusCode.BadRequest))
                                    {
                                        string script = $"alertError('Error', 'Sahi Data Bhejo Yrrr !', 'Ok Bhai ! ');";
                                        ScriptManager.RegisterStartupScript(this, GetType(), "Error", script, true);
                                        break;
                                    }
                                    else if (des_res.Equals((int)Enums.HttpStatusCode.InternalServerError))
                                    {
                                        string script = $"alertError('Oops !', 'Something Went wrong !', 'Ok Bhai ! ');";
                                        ScriptManager.RegisterStartupScript(this, GetType(), "Error1", script, true);
                                        break;
                                    }
                                }

                            }
                            //if (btnUploadImages.PostedFiles.Count == _uploadedCount)
                            //{
                            //    string script = $"alertSuccess('Success', 'Uploaded Successfully', 'Ok Bhai ! ');";
                            //    ScriptManager.RegisterStartupScript(this, GetType(), "Success", script, true);
                            //}
                        }

                    }
                    else if (btnAddHotelImage.Text == "Update")
                    {
                        HotelImage_model model = new HotelImage_model();
                        if (btnUploadImages.HasFile)
                        {
                            var file = btnUploadImages.PostedFile;
                            string fileExtension = System.IO.Path.GetExtension(file.FileName);
                            if (!allowedImgTypes.Contains(fileExtension))
                            {
                                string script = $"alertError_Custom('bhai image hi upload krna h !', 'sirf .png ya .jpg ya .jpeg  ka hi use kro be', 'Ok Bhai ! ');";
                                //Response.Write($"<script>alert('{Message}')</script>");
                                ScriptManager.RegisterStartupScript(this, GetType(), "imgvalidation", script, true);
                            }
                            else
                            {
                                var byteForm_File = imgToByte(file);
                                //var data = new HotelImage_model
                                //{
                                //    ContentType = fileExtension,
                                //    Createdby = 0,
                                //    HotelId = Convert.ToInt64(ddlHotel.SelectedItem.Value),
                                //    Image = byteForm_File,
                                //    ImageName = file.FileName.Replace(fileExtension, "").Trim(),
                                //    Isactive = true,
                                //};
                                model.ContentType = fileExtension;
                                model.Image = byteForm_File;
                                model.ImageName = file.FileName.Replace(fileExtension, "").Trim();
                            }
                        }
                        model.HotelId = Convert.ToInt64(ddlHotel.SelectedItem.Value);
                        model.Updatedby = 0;
                        if (model != null && ViewState["HotelImageID"] != null)
                        {
                            var enc_id = _secure.Encrypt(Convert.ToString(ViewState["HotelImageID"]), ConfigurationManager.AppSettings["iv"], ConfigurationManager.AppSettings["key"]);
                            var serializeData = JsonConvert.SerializeObject(model);
                            var enc_model = _secure.Encrypt(serializeData, ConfigurationManager.AppSettings["iv"], ConfigurationManager.AppSettings["key"]);
                            var res = _service.UpdateHotelImage(enc_model, enc_id).Result;
                            if (res != null)
                            {
                                var _deserialized = JsonConvert.DeserializeObject<Response<string>>(res);


                                if (_deserialized.StatusCode.Equals((int)Enums.HttpStatusCode.OK))
                                {
                                    string script = $"alertSuccess('Success', 'Updated Successfully', 'Ok Bhai ! ');";
                                    ScriptManager.RegisterStartupScript(this, GetType(), "Success", script, true);
                                }
                                else if (_deserialized.Equals((int)Enums.HttpStatusCode.BadRequest))
                                {
                                    string script = $"alertError('Error', 'Sahi Data Bhejo Yrrr !', 'Ok Bhai ! ');";
                                    ScriptManager.RegisterStartupScript(this, GetType(), "Error", script, true);
                                }
                                else if (_deserialized.Equals((int)Enums.HttpStatusCode.InternalServerError))
                                {
                                    string script = $"alertError('Oops !', 'Something Went wrong !', 'Ok Bhai ! ');";
                                    ScriptManager.RegisterStartupScript(this, GetType(), "Error1", script, true);
                                }

                            }



                        }
                    }
                }
                else
                {
                    string script = $"alertError_Custom('Poora bharo yar?', '{Message}', 'Ok Bhai ! ');";

                    ScriptManager.RegisterStartupScript(this, GetType(), "validation", script, true);
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {
                clear();
            }
        }
        #endregion
        #region methods
        private void LoadAllHotels()
        {
            try
            {
                var res = _hotelDao.GetAllHotel().Result;
                if (res != null)
                {
                    var result = JsonConvert.DeserializeObject<Response<string>>(res);
                    if (result.IsSuccess && result.StatusCode.Equals((int)Enums.HttpStatusCode.OK))
                    {
                        var dec_res = _secure.Decrypt(result.Data, ConfigurationManager.AppSettings["iv"], ConfigurationManager.AppSettings["key"]);
                        var serializeData = JsonConvert.DeserializeObject<List<Hotel_model>>(dec_res);
                        serializeData.Insert(0, new Hotel_model { HotelId = 0, HotelName = "Please Select the Hotel" });
                        if (serializeData.Count > 0)
                        {
                            ddlHotel.DataSource = serializeData;
                            ddlHotel.DataTextField = "HotelName";
                            ddlHotel.DataValueField = "HotelID";
                            ddlHotel.DataBind();
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
        private byte[] imgToByte(HttpPostedFile file)
        {
            using (var ms = new MemoryStream())
            {
                file.InputStream.CopyTo(ms);
                return ms.ToArray();
            }
        }
        private void LoadData(bool isEditable, HotelImage_ModelWithoutDates model)
        {
            if (isEditable)
            {
                btnUploadImages.Enabled = true;
                img_HotelIMG.Enabled = true;
                btnAddHotelImage.Enabled = true;
                btnUploadImages.Visible = true;
                ddlHotel.Enabled = true;
                btnAddHotelImage.Text = "Update";
            }
            else
            {
                btnUploadImages.Enabled = false;
                btnUploadImages.Visible = false;
                ddlHotel.Enabled = false;
                btnAddHotelImage.Enabled = false;
                //string url = Convert.ToBase64String(model.Image) + model.ContentType;


            }
            img_HotelIMG.ImageUrl = MakeImgUrl(model.Image, model.ContentType);
            if (ddlHotel.Items.FindByValue(Convert.ToString(model.HotelId)) != null)
            {
                ddlHotel.SelectedValue = Convert.ToString(model.HotelId);
            }
            else
            {
                ddlHotel.SelectedIndex = -1; // Clear selection or set a default
            }
            img_HotelIMG.Visible = true;

        }
        private string MakeImgUrl(byte[] arr, string contentType)
        {
            if (arr != null && arr.Length != 0)
            {
                return $"data:image/{contentType.Replace(".", "").Trim()};base64,{Convert.ToBase64String(arr)}";
            }
            else
            {
                return "";
            }
        }
        private void BindHotelImages(int count =0)
            {
            try
            {
                string _encCount = _secure.Encrypt(count.ToString(), ConfigurationManager.AppSettings["iv"], ConfigurationManager.AppSettings["key"]);
                var res = _service.GetHotelImages_Count(_encCount).Result;
                var des_res = JsonConvert.DeserializeObject<ResponseGet<string>>(res);
                if (des_res.IsSuccess == true)
                {
                    ViewState["currentPageIndex"] = des_res.CurrentPageIndex;
                    ViewState["TotalPages"] = des_res.TotalPages;
                    //if (des_res.CurrentPageIndex == 0)
                    //{
                    //    btnPrev.Enabled = false;
                    //    btnPrev.Visible = false;
                    //}
                    //else
                    //{
                    //    btnPrev.Enabled = true;
                    //    btnPrev.Enabled = true;
                    //}
                    btnPrev.Enabled = !(des_res.CurrentPageIndex == 0);
                    btnPrev.Visible = !(des_res.CurrentPageIndex == 0);
                    btnNext.Enabled=!(des_res.CurrentPageIndex == (des_res.TotalPages-1));
                    btnNext.Visible = !(des_res.CurrentPageIndex == (des_res.TotalPages - 1));
                    //if (des_res.CurrentPageIndex==des_res.TotalPages) {
                    //    btnNext.Enabled = false;
                    //    btnNext.Visible = false;
                    //}
                    var dec_res = _secure.Decrypt(des_res.Data, ConfigurationManager.AppSettings["iv"], ConfigurationManager.AppSettings["key"]);
                    var deserializedData = JsonConvert.DeserializeObject<List<HotelImage_ModelWithoutDates>>(dec_res);
                    if (deserializedData.Count > 0)
                    {
                        rptHotelImageList.DataSource = deserializedData;
                        rptHotelImageList.DataBind();
                        
                    }
                }
                
                
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        private void clear()
        {
            LoadAllHotels();
            BindHotelImages(0);
            ddlHotel.SelectedIndex = -1;
            if (btnUploadImages.HasFiles)
            {
                btnUploadImages.Dispose();
                //btnUploadImages.PostedFiles.Clear();
            }
            btnUploadImages.Enabled = true;
            img_HotelIMG.Enabled = false;
            img_HotelIMG.Visible = false;
            btnUploadImages.Visible = true;
            btnAddHotelImage.Text = "Add";
            ddlHotel.Enabled = true;
            if (ViewState["HotelImageID"] != null)
            {
                ViewState["HotelImageID"] = null;
            }

        }
        [WebMethod]
        public static bool Delete(long id)
        {
            try
            {
                var enc_id = _secure.Encrypt(Convert.ToString(id), ConfigurationManager.AppSettings["iv"], ConfigurationManager.AppSettings["key"]);
                var res = _service.DeleteHotelImage(enc_id).Result;
                if (res != null)
                {

                    return true;


                }
                else
                {
                    HotelImage hotelImage = new HotelImage();
                    hotelImage.BindHotelImages(0);
                    return false;
                }
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        #endregion
        #region validation
        private bool validate(out string Message)
        {

            try
            {
                Message = string.Empty;
                if (ViewState["HotelImageID"] == null)
                {
                    if (!btnUploadImages.HasFiles)
                    {
                        Message += "Please choose some files";
                    }
                }

                if (ddlHotel.SelectedIndex == -1)
                {
                    Message += "Please select the hotel ";
                }
                if (Message != string.Empty)
                {
                    return false;
                }
                else
                    return true;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion

        protected void btnPrev_Click(object sender, EventArgs e)
        {
            try
            {
                //string count = "";

                if (ViewState["currentPageIndex"] != null)
                {
                    int c = Convert.ToInt32(ViewState["currentPageIndex"]);
                    c -= 1;
                    BindHotelImages(c);
                }

                
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                //string count = "";

                if (ViewState["currentPageIndex"] != null)
                {

                    int c = Convert.ToInt32(ViewState["currentPageIndex"]) + 1;
                    //count = _secure.Encrypt(c.ToString(), ConfigurationManager.AppSettings["iv"], ConfigurationManager.AppSettings["key"]);
                    BindHotelImages(c);
                }

                
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}