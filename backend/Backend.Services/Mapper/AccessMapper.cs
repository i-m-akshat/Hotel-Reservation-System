using Backend.DataAccessLayer.Context.Models;
using Backend.Models.Admin_Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Services.Mapper
{
    public static class AccessMapper
    {
        public static TblAccess ToTblAccess(this Access _access)
        {
            return new TblAccess
            {
                AccessUrl = _access.AccessUrl,
                AccessProvidedBy = _access.AccessProvidedBy,
                IsActive = true,
                IconUrl = _access.IconUrl,
                Name = _access.Name,
                RoleId = _access.RoleId,
            };

        }
        public static Access ToAccess(this TblAccess _access) {
            return new Access
            {
                AccessUrl = _access.AccessUrl,
                AccessProvidedBy = _access.AccessProvidedBy,
                IsActive = true,
                IconUrl = _access.IconUrl,
                Name = _access.Name,
                RoleId = _access.RoleId,
            };
        }
    }
}
