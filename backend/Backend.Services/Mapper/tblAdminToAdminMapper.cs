using Backend.DataAccessLayer.Context.Models;
using Backend.Models.Admin_Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Services.Mapper
{
    public static class tblAdminToAdminMapper
    {
        public static Admin ToAdmin(this TblAdmin tblAdmin)
        {
            try
            {
                return new Admin
                {
                    Address = tblAdmin.Address,
                    AdminId = tblAdmin.AdminId,
                    Adminname = tblAdmin.Adminname,
                    CityId = tblAdmin.CityId,
                    CountryId = tblAdmin.CountryId,
                    Createdby = tblAdmin.Createdby,
                    CreatedDate = tblAdmin.CreatedDate,
                    DeletedBy = tblAdmin.DeletedBy,
                    DeletedDate = tblAdmin.DeletedDate,
                    EmailId = tblAdmin.EmailId,
                    FullName = tblAdmin.FullName,
                    Isactive = tblAdmin.Isactive,
                    Image = tblAdmin.Image,
                    Password = tblAdmin.Password,
                    PhoneNumber = tblAdmin.PhoneNumber,
                    StateId = tblAdmin.StateId,
                    UpdatedBy = tblAdmin.UpdatedBy,
                    UpdatedDate = tblAdmin.UpdatedDate,
                    RoleID = (long)tblAdmin.RoleID,
                };
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }
        public static TblAdmin TotblAdmin(this Admin admin)
        {
            return new TblAdmin
            {
                Adminname=admin.Adminname,
                FullName=admin.FullName,
                Address=admin.Address,
                StateId=admin.StateId,
                CountryId=admin.CountryId,
                CityId=admin.CityId,
                Isactive=admin.Isactive,
                Image=admin.Image,
                PhoneNumber=admin.PhoneNumber,
                EmailId=admin.EmailId,
                Password=admin.Password,
                RoleID=admin.RoleID,
            };
        }
        public static Admin ToAdminWithCountryAndAllNames(this TblAdmin admin)
        {
            return new Admin
            {
                AdminId=admin.AdminId,
                Adminname = admin.Adminname,
                FullName = admin.FullName,
                Address = admin.Address,
                StateId = admin.StateId != null ? admin.StateId : 0,
                CountryId = admin.CountryId!=null?admin.CountryId:0,
                CityId = admin.CityId != null ? admin.CityId: 0,
                Isactive = admin.Isactive,
                Image = admin.Image,
                PhoneNumber = admin.PhoneNumber,
                EmailId = admin.EmailId,
                Password = admin.Password,
                CountryName=admin.Country.CountryName,
                StateName=admin.State.StateName,
                CityName=admin.City.CityName,
                RoleID=(long)admin.RoleID,
            };
        }
    }
}
