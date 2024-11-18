using Backend.DataAccessLayer.Repository.Interfaces;
using Backend.Models.Admin_Domain;
using Backend.Services.Interfaces;
using Backend.Services.Mapper;

namespace Backend.Services.Implementatios
{
    public class AccessService : IAccessService
    {
        private readonly IAccessRepo _repo;
        public AccessService(IAccessRepo repo) {
        
        _repo = repo;
        }
        public async Task<Access> Create(Access Data)
        {
            var res = await _repo.Create(Data.ToTblAccess());
            return res.ToAccess();
        }

        public async Task<Access> Delete(long id)
        {
            var res=await _repo.Delete(id); 
            return res.ToAccess();
        }

        public async Task<Access> Get(long id)
        {
            var res = await _repo.GetByID(id);
            return res.ToAccess();
        }

        public async Task<List<Access>> GetAll()
        {
            var res = await _repo.Get();
            return res.Select(x=>x.ToAccess()).ToList();
        }

        public async Task<Access> Update(Access Data, long id)
        {
            var res=await _repo.Update(Data.ToTblAccess(), id);
            return res.ToAccess();  
        }
    }
}
