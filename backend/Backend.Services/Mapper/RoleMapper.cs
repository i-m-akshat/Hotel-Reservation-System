using Backend.DataAccessLayer.Context.Models;
using Backend.Models.Admin_Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Services.Mapper
{
    public static class RoleMapper
    {
        public static TblRole ToTblRole_Create(this Role _role)
        {
            return new TblRole
            {
                Role = _role.RoleName.ToString(),
                IsActive=_role.IsActive,
                Createdby=_role.Createdby,
                CreatedDate=_role.CreatedDate
            };
        }
        public static TblRole ToTblRole_Update(this Role _role)
        {
            return new TblRole
            {
                Role = _role.RoleName.ToString(),
                IsActive = _role.IsActive,
                UpdatedBy = _role.UpdatedBy,
                UpdatedDate = _role.UpdatedDate
            };
        }
        public static TblRole ToTblRole(this Role _role)
        {
            return new TblRole
            {
                Role = _role.RoleName.ToString(),
                IsActive = _role.IsActive,
                UpdatedBy = _role.UpdatedBy,
                UpdatedDate = _role.UpdatedDate,
                Createdby = _role.Createdby,
                CreatedDate = _role.CreatedDate
            };
        }
        public static Role ToRole(this TblRole _tblRole)
        {
            return new Role
            {
                RoleName = _tblRole.Role.ToString(),
                RoleId=_tblRole.RoleId,
            };
        }
    }
}
