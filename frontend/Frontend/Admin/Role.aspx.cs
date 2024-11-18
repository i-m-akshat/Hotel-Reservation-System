using Frontend.Logic.Implementations;
using Frontend.Logic.Interfaces;
using Frontend.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Frontend.Admin
{
    public partial class Role : System.Web.UI.Page
    {

        private readonly IRoleDAO _dal = new RoleDao();
        private readonly ISecureDAO _secure = new SecureDao();
        protected void Page_Load(object sender, EventArgs e)
        {
            BindRole();
        }
        private void BindRole()
        {
            try
            {
                var res = _dal.getAll().Result;
                if (res != null) {
                    var dec_res = _secure.Decrypt(res, ConfigurationManager.AppSettings["iv"], ConfigurationManager.AppSettings["key"]);
                    var _data = JsonConvert.DeserializeObject<List<Role_Model>>(dec_res);
                    if (_data != null)
                    {
                        rptRoleList.DataSource = _data;
                        rptRoleList.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex} is being thrown ");

            }
        }
        protected void btnAddRole_Click(object sender, EventArgs e)
        {
            Role_Model _model = new Role_Model();
            string Message = string.Empty;
            if (validate(out Message))
            {
                string script = $"alertError_Custom('Poora bharo yar?', '{Message}', 'Ok Bhai ! ');";
                //Response.Write($"<script>alert('{Message}')</script>");
                ScriptManager.RegisterStartupScript(this, GetType(), "validation", script, true);

            }
            else
            {
                _model.RoleName = txtRoleName.Text.ToString();
                //_model.Createdby = Session["AdminName"].ToString();



                if (btnAddRole.Text == "Add")
                {
                    _model.CreatedDate = DateTime.Now;
                    _model.IsActive = true;
                    var data = JsonConvert.SerializeObject(_model);
                    var enc_data = _secure.Encrypt(data, ConfigurationManager.AppSettings["iv"], ConfigurationManager.AppSettings["key"]);
                    var res = _dal.Create(enc_data).Result;
                    Role_Model Model = JsonConvert.DeserializeObject<Role_Model>(_secure.Decrypt(res, ConfigurationManager.AppSettings["iv"], ConfigurationManager.AppSettings["key"]));
                    if (Model != null)
                    {
                        string script = $"alertSuccess('Success', 'Updated Successfully', 'Ok Bhai ! ');";
                        //Response.Write($"<script>alert('{Message}')</script>");
                        ScriptManager.RegisterStartupScript(this, GetType(), "Success", script, true);
                        BindRole();
                        Clear();
                    }
                }
                else
                {
                    _model.UpdatedDate = DateTime.Now;
                    var data = JsonConvert.SerializeObject(_model);
                    var enc_data = _secure.Encrypt(data, ConfigurationManager.AppSettings["iv"], ConfigurationManager.AppSettings["key"]);
                    //_model.IsActive = true;
                }
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {

        }
        private void Clear()
        {
            txtRoleName.Text = string.Empty; txtRoleName.Focus();
        }

        protected void btnView_Click(object sender, EventArgs e)
        {

        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            LinkButton btnEdit = sender as LinkButton;
            long Roleid = Convert.ToInt64(btnEdit.CommandArgument);
            ViewState["RoleID"] = Roleid;
            if (Roleid != 0||Roleid.Equals(0) )
            { 
                string enc_id = _secure.Encrypt(Convert.ToString(Roleid), ConfigurationManager.AppSettings["iv"], ConfigurationManager.AppSettings["key"]);
                var res = _dal.GetById(enc_id).Result;
                var dec_res= _secure.Decrypt( res, ConfigurationManager.AppSettings["iv"], ConfigurationManager.AppSettings["key"]);
                Role_Model _model = JsonConvert.DeserializeObject<Role_Model>(dec_res);
                if(_model != null)
                {
                    LoadData(true, _model);

                }
            }
        }
        private void LoadData(bool EditMode,Role_Model model)
        {
            if (EditMode)
            {
                btnAddRole.Text = "Update";
            }
            txtRoleName.Text=(string)model.RoleName;
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {

        }
        private bool validate(out string message)
        {
            message = string.Empty;
            if (txtRoleName.Text == string.Empty)
            {
                message += "Please enter the role";
                return true;
            }
            else
                return false;
        }
    }
}