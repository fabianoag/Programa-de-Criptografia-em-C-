using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;//Biblioteca para a criptografia


namespace Cryptography
{
    /// <summary>
    /// Classe usada para Descriptografar messagem.
    /// </summary>
    public class Decrypt : Cryptography
    {
        /// <summary>
        /// Descriptografa a messagem enviada.
        /// </summary>
        /// <param name="Message">Recebe a messagem Criptografada.</param>
        /// <returns>Retorna a messagem normal.</returns>
        public static string DecryptData(dynamic Message)
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
                byte[] DataToDecrypt = Convert.FromBase64String(Message);
                ICryptoTransform Decryptor = TDESAlgorithm.CreateDecryptor();
                Results = Decryptor.TransformFinalBlock(DataToDecrypt, 0, DataToDecrypt.Length);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                TDESAlgorithm.Clear();
                HashProvider.Clear();
            }
            return UTF8.GetString(Results);
        }
    }
}
