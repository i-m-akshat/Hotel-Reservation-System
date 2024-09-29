
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
            throw new NotImplementedException();
        }

        public Task<Admin> Update(Admin Admin)
        {
            throw new NotImplementedException();
        }

        Task<Admin> IAdminService.Delete(int id)
        {
            throw new NotImplementedException();
        }

        Task<List<Admin>> IAdminService.GetAll()
        {
            throw new NotImplementedException();
        }

        async Task<Admin> IAdminService.GetByUserName(string username)
        {
            var admin= await _repo.GetByUserName(username);
            return admin.ToAdmin();
        }
    }
}
