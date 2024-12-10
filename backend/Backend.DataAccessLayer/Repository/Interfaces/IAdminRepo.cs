using Backend.DataAccessLayer.Context.Models;

namespace Backend.DataAccessLayer.Repository.Interfaces
{
    public interface IAdminRepo
    {
        /// <summary>
        /// Gets the admin details by username
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        Task<TblAdmin> GetByUserName(string username);
        /// <summary>
        /// Gets all the admins 
        /// </summary>
        /// <returns></returns>
        Task<List<TblAdmin>> GetAll();
        /// <summary>
        /// Create Admin
        /// </summary>
        /// <param name="tblAdmin"></param>
        /// <returns></returns>
        Task<TblAdmin> Create(TblAdmin tblAdmin);
        /// <summary>
        /// Update admin details 
        /// </summary>
        /// <param name="tblAdmin"></param>
        /// <returns></returns>
        Task<TblAdmin> Update(long id ,TblAdmin tblAdmin);
        /// <summary>
        /// Delete a particular admin details based on provided id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TblAdmin> Delete(long id);
        /// <summary>
        /// To get the admin by its id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TblAdmin> GetById(long id);
    }
}
