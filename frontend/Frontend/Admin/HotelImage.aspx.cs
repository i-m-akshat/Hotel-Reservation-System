using Frontend.Logic.Implementations;
using Frontend.Logic.Interfaces;
using Frontend.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Frontend.Admin
{
    public partial class HotelImage : System.Web.UI.Page
    {
        private readonly IHotelDao _hotelDao = new HotelDao();
        private readonly ISecureDAO _secure = new SecureDao();
        private readonly IHotelImageDAO _service = new HotelImageDao();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadAllHotels();
            }
        }
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
        protected void btnAddHotelImage_Click(object sender, EventArgs e)
        {
            try
            {
                string Message = string.Empty;
                if(validate(out Message))
                {
                    if (btnAddHotelImage.Text == "Add")
                    {
                        var _hotelImage = new HotelImage
                        {

                        };
                    }else if (btnAddHotelImage.Text == "Update")
                    {

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
        }
        private bool validate(out string Message)
        {
            
            try
            {
                Message = string.Empty;
                if (!btnUploadImages.HasFiles)
                {
                    Message += "Please choose some files";
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
        protected void btnClear_Click(object sender, EventArgs e)
        {

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {

        }

        protected void btnView_Click(object sender, EventArgs e)
        {

        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {

        }
    }
}