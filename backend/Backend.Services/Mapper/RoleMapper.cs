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
        public static TblRole ToTblRole(this Role _role)
        {
            return new TblRole
            {
                Role = _role.RoleName.ToString()
            };
        }
        public static Role ToRole(this TblRole _tblRole)
        {
            return new Role
            {
                RoleName = _tblRole.Role.ToString()
            };
        }
    }
}
