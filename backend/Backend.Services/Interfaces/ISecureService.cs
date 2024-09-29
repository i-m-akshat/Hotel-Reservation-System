using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Services.Interfaces
{
    public interface ISecureService
    {
        string Encrypt(string text);
        string Encrypt(string text, string key, string iv);
        string Decrypt(string text, string key, string iv);
        string Decrypt(string text);
        string Decrypt(string Text, string salt,string key, string iv);
        string Encrypt(out string _salt, out string key_secure, out string iv_secure, string Text);
    }
}
