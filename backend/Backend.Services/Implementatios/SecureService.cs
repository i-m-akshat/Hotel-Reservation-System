using Backend.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Services.Implementatios
{
    public class SecureService : ISecureService
    {
        private static readonly Random _rand=new Random();
        //public SecureService(Random random)
        //{
        //    _rand = random;   
        //}
        #region AsymmetricEncryption
        public string Decrypt(string text)
        {
            throw new NotImplementedException();
        }

        public string Encrypt(string text)
        {
            //RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            throw new NotImplementedException();
        }
        #endregion
        #region Symmetric Encryption
        public string Encrypt(out string _salt, out string key_secure, out string iv_secure, string Text)
        {
            //Generating Random words for salt to add them into text in order to secure them 
            _salt = generateRand();
            string _textToSecure = _salt + "+" + Text;
            //creating the instance of the aes class
            using var _aesAlgo = Aes.Create();
            //creating the key and iv using aes but also converting them into the base 64 strings   
            _aesAlgo.GenerateKey();
            _aesAlgo.GenerateIV();
            key_secure = Convert.ToBase64String(_aesAlgo.Key);
            iv_secure = Convert.ToBase64String(_aesAlgo.IV);
            //////////////////////////////////////////////////////////////////////
            //The CreateEncryptor() method returns an object that implements the ICryptoTransform interface. This object (_encryptor) can now be used to encrypt data with the specified AES algorithm, key, and IV.
            ICryptoTransform _encryptor = _aesAlgo.CreateEncryptor(_aesAlgo.Key, _aesAlgo.IV);
            /////////////////////////////////////////////////////////////////////
            using (MemoryStream _ms = new MemoryStream())
            {
                
                using (CryptoStream _csEncryptStream = new CryptoStream(_ms, _encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter sw = new StreamWriter(_csEncryptStream))
                    {
                        sw.Write(_textToSecure);
                    }
                    return Convert.ToBase64String(_ms.ToArray());
                }
            }

        }
        public string Decrypt(string Text, string salt, string key, string iv)
        {
            using (var _aesAlgo = Aes.Create())
            {

                _aesAlgo.Key = Convert.FromBase64String(key);
                _aesAlgo.IV = Convert.FromBase64String(iv);
                byte[] CipherTextBytes = Convert.FromBase64String(Text);
                ICryptoTransform _decryptor = _aesAlgo.CreateDecryptor(_aesAlgo.Key, _aesAlgo.IV);
                using (MemoryStream _ms = new MemoryStream(CipherTextBytes))
                {
                    using (CryptoStream _cs = new CryptoStream(_ms, _decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader sr = new StreamReader(_cs))
                        {
                           var read= sr.ReadToEnd();
                            return read;
                        }
                    }
                }
            }
        }
        #endregion
        #region Symmetric Encryption without salt
        public string Encrypt(string text,string key,string iv)
        {
            using (var _aesAlgo = Aes.Create())
            {
                _aesAlgo.Key = Encoding.UTF8.GetBytes(key);
                _aesAlgo.IV = Encoding.UTF8.GetBytes(iv);
                ICryptoTransform _encryptor = _aesAlgo.CreateEncryptor(_aesAlgo.Key,_aesAlgo.IV);
                using (var ms = new MemoryStream())
                {
                    using (var cs = new CryptoStream(ms, _encryptor, CryptoStreamMode.Write))
                    {
                        using(var sr=new StreamWriter(cs))
                        {
                            sr.Write(text);
                        }
                        return Convert.ToBase64String(ms.ToArray());
                    }
                }
            }
        }
        public string Decrypt(string text,string key,string iv)
        {
            using (var _aesAlgo = Aes.Create()) 
            
            { 
                _aesAlgo.Key=Encoding.UTF8.GetBytes(key);
                _aesAlgo.IV=Encoding.UTF8.GetBytes(iv);
                ICryptoTransform _decryptor= _aesAlgo.CreateDecryptor(_aesAlgo.Key,_aesAlgo.IV);
                using(var ms=new MemoryStream())
                {
                    using(var cs=new CryptoStream(ms, _decryptor, CryptoStreamMode.Read))
                    {
                        using(var sr=new StreamReader(cs))
                        {
                            return sr.ReadToEnd();
                        }
                    }
                }
            }
        }

        #endregion
        #region Random Word Generator

        private string generateRand()
        {
            string character = "abcdefghijklmnopqrstuvwxyz";
            StringBuilder sb = new StringBuilder(50);
            for (int i = 0; i < 5; i++)
            {
                int index = _rand.Next(character.Length); // Generate a random index
                sb.Append(character[index]); // Append the character at the random index
                //sb.Append(_rand.Next(character.Length));
            }
            return sb.ToString();
        }

        #endregion
    }
}
