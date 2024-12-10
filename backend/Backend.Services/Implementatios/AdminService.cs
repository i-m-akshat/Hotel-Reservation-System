
using Backend.DataAccessLayer.Repository.Interfaces;
using Backend.Models.Admin_Domain;
using Backend.Services.Interfaces;
using Backend.Services.Mapper;


namespace Backend.Services.Implementatios
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepo _repo;
        public AdminService(IAdminRepo repo)
        {
            _repo=repo;
        }
        public async Task<Admin> Create(Admin admin)
        {
            var res=await _repo.Create(admin.TotblAdmin());
            return res.ToAdmin();
        }

        public async Task<Admin> GetById(long id)
        {
            var res=await _repo.GetById(id);
            return res.ToAdmin();   
        }

        public async Task<Admin> Update(Admin Admin, long id)
        {
            var res = await _repo.Update(id, Admin.TotblAdmin());
            return res.ToAdmin();
        }

        async Task<Admin> IAdminService.Delete(long id)
        {
            var res = await _repo.Delete(id);
            return res.ToAdmin();
        }

        async Task<List<Admin>> IAdminService.GetAll()
        {
            var res = await _repo.GetAll();
            return res.Select(x => x.ToAdminWithCountryAndAllNames()).ToList();
        }

        async Task<Admin> IAdminService.GetByUserName(string username)
        {
            var admin= await _repo.GetByUserName(username);
            if (admin != null)
            {
                return admin.ToAdmin();
            }
            else
            {
                return null;
            }
            
        }
    }
}
