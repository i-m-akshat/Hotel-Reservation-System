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
                UpdatedDate = tblAdmin.UpdatedDate
            };
        }
    }
}
