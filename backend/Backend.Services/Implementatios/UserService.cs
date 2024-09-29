using Backend.Domain.User_Domain;
using Backend.Infrastructure.Repository.Interfaces;
using Backend.Services.Interfaces;
using Backend.DataAccessLayer.Context.Models;
using Backend.Services.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Services.Implementatios
{
    public class UserService : IUserService
    {
        private readonly IUserRepo _repo;
        private readonly ISecureService _secureService;
        
        public UserService(IUserRepo repo, ISecureService secureService)
        {
            _repo = repo;
            _secureService = secureService;
        }
        public async Task<List<User>> GetAll()
        {
            try
            {
                var users = await _repo.GetAll();
                //List<User> _listUsers=new List<User>();
                //foreach (var user in users) {
                //    var user_mod=user.ToUser();
                //    _listUsers.Add(user_mod);
                //}
                //return _listUsers;
                return users.Select(x=>x.ToUser()).ToList();
			}
			catch (Exception ex)
			{
				throw;
			}
        }
        public async Task<User> CreateUser(User user)
        {
            var tblUser=user.ToTblUser();
            string key_secure = string.Empty;
            string iv_secure = string.Empty;
            string hashedPassword = null;
            string _salt = null;
            var encryptedPass=_secureService.Encrypt(out _salt,out key_secure,out iv_secure,user.Password);
            //string[]values=encryptedPass.Split("++");
            //_salt=values[0].Trim();
            //hashedPassword = values[1].Trim();
            tblUser.Password=encryptedPass;
            tblUser.Key=key_secure;
            tblUser.Iv=iv_secure;
            tblUser.Salt = _salt;
            var res= await _repo.CreateUser(tblUser);
            return res.ToUser();
        }
        public async Task<User> GetUserByUserName(string Username){
            var user=  _repo.GetUserByUsername(Username);
            if (user.Result != null)
            {
                return user.Result.ToUser();
            }
            else
            {
                return null;
            }
            
        }
        public async Task<User> GetUserByUserNameAndPassword(string UserName,string password)
        {
            try
            {
                
                var user=_repo.GetUserByUsername(UserName);
                if((user.Result!=null) && (password != null))
                {

                    string dec_pass = _secureService.Decrypt(user.Result.Password, user.Result.Salt, user.Result.Key, user.Result.Iv);
                    if (password == dec_pass.Replace(user.Result.Salt + "+", ""))
                    {
                        return user.Result.ToUser();
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
                
                
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
