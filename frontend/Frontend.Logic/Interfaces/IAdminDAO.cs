using Frontend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontend.Logic

{
    public interface IAdminDAO
    {
        Task<string> Login(string Username);
    }
}
