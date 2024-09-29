
using Backend.Models.Admin_Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Services.Interfaces
{
    public interface IAdminService
    {
        Task<Admin> GetByUserName(string username);
        Task<List<Admin>> GetAll();
        Task<Admin> Create(Admin Admin);
        Task<Admin> Update(Admin Admin);
        Task<Admin> Delete(int id);
    }
}
