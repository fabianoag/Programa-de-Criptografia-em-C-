using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;//Biblioteca para a criptografia

namespace Cryptography
{
    /// <summary>
    /// Classe usada para criptografar messagem.
    /// </summary>
    public class Encrypt : Cryptography
    {
        /// <summary>
        /// Criptografa a messagem enviada.
        /// </summary>
        /// <param name="Message">Recebe a messagem normal.</param>
        /// <returns>Retorna a messagem criptografada.</returns>
        public static string EncryptData(dynamic Message)
        {
            byte[] Results;
            System.Text.UTF8Encoding UTF8 = new UTF8Encoding();
            MD5CryptoServiceProvider HashProvider = new MD5CryptoServiceProvider();
            byte[] TDEKey = HashProvider.ComputeHash(UTF8.GetBytes(ENCRYPTKEY));
            TripleDESCryptoServiceProvider TDESAlgorithm = new TripleDESCryptoServiceProvider();
            TDESAlgorithm.Key = TDEKey;
            TDESAlgorithm.Mode = CipherMode.ECB;
            TDESAlgorithm.Padding = PaddingMode.PKCS7;
            try
            {
                byte[] DataToEncrypt = UTF8.GetBytes(Message);
                ICryptoTransform Encryptor = TDESAlgorithm.CreateEncryptor();
                Results = Encryptor.TransformFinalBlock(DataToEncrypt, 0, DataToEncrypt.Length);
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                TDESAlgorithm.Clear();
                HashProvider.Clear();
            }
            return Convert.ToBase64String(Results);
        }
    }
}
