using Backend.DataAccessLayer.Repository.Interfaces;
using Backend.Models.Admin_Domain;
using Backend.Services.Interfaces;
using Backend.Services.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Services.Implementatios
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepo _roleRepo;
        public RoleService(IRoleRepo Role) {
            _roleRepo = Role;
        }
        public async Task<Role> Create(Role _Role)
        {
         var res=await _roleRepo.Create(_Role.ToTblRole_Create());
            return res.ToRole();
        }

        public async Task<Role> Delete(long id)
        {
            var res = await _roleRepo.Delete(id);
            return res.ToRole();
        }

        public async Task<List<Role>> getAll()
        {
            var res=await _roleRepo.GetAll();
            return res.Select(x=>x.ToRole()).ToList();
        }

        public async Task<Role> GetById(long id)
        {
            var res=await _roleRepo.GetByID(id);
            return res.ToRole();
        }

        public async Task<Role> Update(Role _Role, long id)
        {
            var res = await _roleRepo.Update(_Role.ToTblRole_Update(), id);
            return res.ToRole();
        }
    }
}
