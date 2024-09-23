using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Domain.User_Domain;

namespace Backend.Services.Interfaces
{
    public interface IUserService
    {
        Task<List<User>> GetAll();
        Task<User> CreateUser(User user);
        Task<User> GetUserByUserNameAndPassword(string UserName, string password);
    }
}
