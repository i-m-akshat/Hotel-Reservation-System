
using Frontend.Admin;
using Frontend.Logic.Implementations;
using Frontend.Logic.Interfaces;
using Frontend.Models;
using Frontend.Models.Mappers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;

namespace Frontend.Admin
{
    public partial class State : System.Web.UI.Page
    {
        private static readonly ICountryDAO _countryDao = new CountryDao();
        private static readonly IStateDAO _stateDao = new StateDao();
        private static readonly ISecureDAO _secure=new SecureDao(); 
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCountries();
                BindStates();
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            ddlCountry.SelectedItem.Value = "0";
            txtStateName.Text = string.Empty;
            btnAddState.Text = "Add";
        }

        protected void btnAddState_Click(object sender, EventArgs e)
        {
            string Message=string.Empty;
            if (validate(out Message))
            {
                dynamic state = new State_Model();
                state.StateName = txtStateName.Text.ToString();
                state.CountryId = Convert.ToInt64(ddlCountry.SelectedItem.Value);
                if (state != null)
                {
                    var enc_state = _secure.Encrypt(JsonConvert.SerializeObject(state), ConfigurationManager.AppSettings["key"],ConfigurationManager.AppSettings["iv"]);
                    if (btnAddState.Text == "Add")
                    {
                        state.IsActive = true;
                        var res = _stateDao.Create(enc_state).Result;
                        if (res != null)
                        {
                            var dec_Res = _secure.Decrypt(res, ConfigurationManager.AppSettings["iv"], ConfigurationManager.AppSettings["key"] );
                            if (dec_Res != null)
                                Response.Write("<script>alert('Creation of state successfull)'</script>");
                        }
                    }else if (btnAddState.Text == "Update")
                    {
                        long StateID = Convert.ToInt64(ViewState["StateID"]);
                        string _stateid_Enc = _secure.Encrypt(StateID.ToString(), ConfigurationManager.AppSettings["iv"], ConfigurationManager.AppSettings["key"]);
                        var res = _stateDao.update(enc_state,_stateid_Enc).Result;
                        if (res != null)
                        {
                            var dec_Res = _secure.Decrypt(res, ConfigurationManager.AppSettings["key"], ConfigurationManager.AppSettings["iv"]);
                            if (dec_Res != null)
                                Response.Write("<script>alert('Update successfull)'</script>");
                        }
                    }
                        
                }
            }
            else{
                Response.Write($"<script>alert('{Message}')</script>");
            }
            
            clear();
            BindStates();
            BindCountries();
        }
        private void BindStates()
        {
            List<State_Model> stateList = new List<State_Model>();
            var res = _stateDao.GetAll().Result;
            var dec_res = _secure.Decrypt(res, ConfigurationManager.AppSettings["key"], ConfigurationManager.AppSettings["iv"]);
            List<State_DTO> listDTO=JsonConvert.DeserializeObject<List<State_DTO>>(dec_res);
            stateList=listDTO.Select(x=>x.FromDTOToModel()).ToList();
            rptStateList.DataSource = stateList;
            rptStateList.DataBind();
        }
        private void BindCountries()
        {
            List<Country_Model> countryList = new List<Country_Model>();
            var res = _countryDao.GetAll().Result;
            var dec_res = _secure.Decrypt(res, ConfigurationManager.AppSettings["iv"], ConfigurationManager.AppSettings["key"]);
            countryList =JsonConvert.DeserializeObject<List<Country_Model>>(dec_res);
            countryList.Insert(0, new Country_Model { CountryId = 0, CountryName = "Please Select the Country" });
            ddlCountry.DataSource = countryList;
            ddlCountry.DataTextField = "CountryName";
            ddlCountry.DataValueField = "CountryId";
            ddlCountry.DataBind();
            //ddlCountry.Items.Insert(0, new ListItem("Please Select the Country", "0"));
            ddlCountry.SelectedIndex = 0;
            
        }
        private void clear()
        {
            txtStateName.Text = string.Empty;
            ddlCountry.SelectedItem.Value = "0";
        }

        private bool validate(out string message)
        {
            string Message = string.Empty;
            if (txtStateName.Text == null)
            {
                Message += "Please enter the state name ,";
            }
            if (ddlCountry.SelectedIndex == 0)
            {
                Message += "Please select the country ,";
            }
            if (Message != string.Empty)
            {
                message = Message.ToString();
               
                return false;
            }
            else
            {
                message = string.Empty;
                return true;
            }
            
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            LinkButton btnEdit=sender as LinkButton;
            long Stateid = Convert.ToInt64(btnEdit.CommandArgument.ToString());
            string stateID = _secure.Encrypt(Convert.ToString(Stateid), ConfigurationManager.AppSettings["iv"], ConfigurationManager.AppSettings["key"]);
            string state = _stateDao.GetByid(stateID).Result;
            string dec_state = _secure.Decrypt(state, ConfigurationManager.AppSettings["iv"], ConfigurationManager.AppSettings["key"]);
            State_Model _state = JsonConvert.DeserializeObject<State_Model>(dec_state);
            txtStateName.Text = _state.StateName;
            ddlCountry.SelectedValue = _state.CountryId.ToString();
            ViewState["StateID"] = _state.StateId;
            EnableDisable(true);
            //BindStates();
            //BindCountries();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            LinkButton btnDelete = sender as LinkButton;
            long Stateid = Convert.ToInt64(btnDelete.CommandArgument.ToString());

            string stateID = _secure.Encrypt(Convert.ToString(Stateid), ConfigurationManager.AppSettings["iv"], ConfigurationManager.AppSettings["key"]);
            var res = _stateDao.Delete(stateID).Result;
            if (res!= null)
            {
                string dec_state = _secure.Decrypt(res, ConfigurationManager.AppSettings["iv"], ConfigurationManager.AppSettings["key"]);
                State_Model _state = JsonConvert.DeserializeObject<State_Model>(dec_state);
                if (_state != null)
                {
                    Response.Write($"<script>alert('{_state.StateName} deleted Successfully')</script>");
                }
            }
            EnableDisable(true);
            BindStates();
            BindCountries();


        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            LinkButton btnView = sender as LinkButton;
            long Stateid = Convert.ToInt64(btnView.CommandArgument.ToString());
            string stateID = _secure.Encrypt(Convert.ToString(Stateid), ConfigurationManager.AppSettings["iv"], ConfigurationManager.AppSettings["key"]);
            string state = _stateDao.GetByid(stateID).Result;
            string dec_state = _secure.Decrypt(state, ConfigurationManager.AppSettings["iv"], ConfigurationManager.AppSettings["key"]);
            State_Model _state = JsonConvert.DeserializeObject<State_Model>(dec_state);
            txtStateName.Text=_state.StateName;
            ddlCountry.SelectedValue = _state.CountryId.ToString();
            EnableDisable(false);

        }
        private void EnableDisable(bool flag)
        {
            txtStateName.Enabled=flag;
            ddlCountry.Enabled = flag;
            btnAddState.Enabled = flag;
            btnClear.Enabled = flag;
            if (flag == true)
            {
                btnAddState.Text = "Update";
            }
        }
    }
}