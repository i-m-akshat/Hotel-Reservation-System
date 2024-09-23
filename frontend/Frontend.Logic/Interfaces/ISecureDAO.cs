using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontend.Logic.Interfaces
{
    public interface ISecureDAO
    {
        string Encrypt(string text,string IV,string key);
        string Decrypt(string text,string IV,string key);
    }
}
