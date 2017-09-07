// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Crypto.cs" company="jayDev">
//   Jan Jalinski
// </copyright>
// <summary>
//   Defines the Crypto type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Mowa
{
    using System;
    using System.IO;
    using System.Security.Cryptography;
    using System.Threading.Tasks;

    /// <summary>
    /// The crypt type.
    /// </summary>
    public enum CryptType
    {
        /// <summary>
        /// The encrypt.
        /// </summary>
        Encrypt,

        /// <summary>
        /// The decrypt.
        /// </summary>
        Decrypt
    }

    /// <summary>
    /// The crypto.
    /// </summary>
    public class Crypto
    {
        /// <summary>
        /// The encrypt.
        /// </summary>
        /// <param name="bytesToEncrypt">
        /// The bytes to encrypt.
        /// </param>
        /// <param name="passwordBytes">
        /// The password bytes.
        /// </param>
        /// <param name="cryptType">
        /// The crypt Type.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        private async Task<byte[]> Crypt(byte[] bytesToEncrypt, byte[] passwordBytes, CryptType cryptType)
        {
            byte[] encryptedBytes = null;

            // set some salt here - at leasr 8 bytes
            var saltBytes = new byte[] { 1, 3, 3, 7, 1, 3, 3, 7 };

            using (var ms = new MemoryStream())
            {
                // ReSharper disable once StyleCop.SA1306
                // ReSharper disable once StyleCop.SA1306
                // ReSharper disable once InconsistentNaming
                using (var AES = new RijndaelManaged())
                {
                    var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);

                    AES.KeySize = 256;
                    AES.BlockSize = 128;
                    AES.Key = key.GetBytes(AES.KeySize / 8);
                    AES.IV = key.GetBytes(AES.BlockSize / 8);

                    AES.Mode = CipherMode.CBC;

                    switch (cryptType)
                    {
                        case CryptType.Encrypt:
                            using (var cs = new CryptoStream(ms, AES.CreateEncryptor(), CryptoStreamMode.Write))
                            {
                                await cs.WriteAsync(bytesToEncrypt, 0, bytesToEncrypt.Length);
                                cs.Close();
                            }

                            break;
                        case CryptType.Decrypt:
                            using (var cs = new CryptoStream(ms, AES.CreateDecryptor(), CryptoStreamMode.Write))
                            {
                                await cs.WriteAsync(bytesToEncrypt, 0, bytesToEncrypt.Length);
                                cs.Close();
                            }

                            break;
                        default:
                            throw new ArgumentOutOfRangeException(nameof(cryptType), cryptType, null);
                    }


                    encryptedBytes = ms.ToArray();
                }
            }

            return encryptedBytes;
        }
    }
}
