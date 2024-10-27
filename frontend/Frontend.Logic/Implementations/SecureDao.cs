using Frontend.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Frontend.Logic.Implementations
{
    public class SecureDao : ISecureDAO
    {
        public string Decrypt(string text, string key, string IV)
        {
            try
            {
                using (var _aesAlgo = Aes.Create())
                {
                    _aesAlgo.Key = Encoding.UTF8.GetBytes(key);
                    _aesAlgo.IV = Encoding.UTF8.GetBytes(IV);
                    byte[] CipherTextBytes = Convert.FromBase64String(text);
                    ICryptoTransform decryptor = _aesAlgo.CreateDecryptor(_aesAlgo.Key,_aesAlgo.IV);
                    using (var ms = new MemoryStream(CipherTextBytes))
                    {
                        using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                        {
                            using (var sr = new StreamReader(cs))
                            {
                                return sr.ReadToEnd();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public string Encrypt(string text, string key, string IV)
        {
            try
            {
                using (var _aesAlg = Aes.Create())
                {
                    _aesAlg.Key=Encoding.UTF8.GetBytes(key);//Converting the string keys to byte array
                    _aesAlg.IV=Encoding.UTF8.GetBytes(IV); //converting the string iv to byte array 
                    //creating the instance of ICRyptoTransform and creating one encryptor for it 
                    //An ICryptoTransform object represents a cryptographic transformation that can be used to encrypt or decrypt data
                    ICryptoTransform encryptor =_aesAlg.CreateEncryptor(_aesAlg.Key,_aesAlg.IV);
                    using (MemoryStream memoryStream = new MemoryStream()) 
                    {
                        //cryptostream- a class in .NET framework that provides a stream based interface for cryptographic operations.

                        //here we are creating  a CryptoStream object, which is used to perform cryptographic operations on the memory stream.
                        using (CryptoStream cs=new CryptoStream(memoryStream,encryptor,CryptoStreamMode.Write))
                        {
                            using (StreamWriter sw = new StreamWriter(cs)) {
                                sw.Write(text);//Writes the plain text string to the StreamWriter, which in turn writes it to the CryptoStream, where it's encrypted.
                            }

                            string base64String = Convert.ToBase64String(memoryStream.ToArray());
                            while (base64String.Length % 4 != 0)
                            {
                                base64String += "=";
                            }
                            //base64String = base64String.Replace("+", "-");
                            return base64String;
                        }
                    }

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
