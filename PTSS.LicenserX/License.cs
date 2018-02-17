using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PTSS.LicenserX
{
    public class License
    {
        private string PrivateLicenseKey = "1111111111111111";
        private string PrivateKey = "2222222222222222";
        private string PrivateFileKey = "3333333333333333";

        public string getPrivateLicenseKey()
        {
            return this.PrivateLicenseKey;
        }
        public string getPrivateKey()
        {
            return this.PrivateKey;
        }
        public string getPrivateFileKey()
        {
            return this.PrivateFileKey;
        }
        public byte[] AES_Encrypt(byte[] bytesToBeEncrypted, byte[] passwordBytes)
        {
            byte[] encryptedBytes = null;

            // Set your salt here, change it to meet your flavor:
            // The salt bytes must be at least 8 bytes.
            byte[] saltBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            using (MemoryStream ms = new MemoryStream())
            {
                using (RijndaelManaged AES = new RijndaelManaged())
                {
                    AES.KeySize = 256;
                    AES.BlockSize = 128;

                    var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);
                    AES.Key = key.GetBytes(AES.KeySize / 8);
                    AES.IV = key.GetBytes(AES.BlockSize / 8);

                    AES.Mode = CipherMode.CBC;

                    using (var cs = new CryptoStream(ms, AES.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesToBeEncrypted, 0, bytesToBeEncrypted.Length);
                        cs.Close();
                    }
                    encryptedBytes = ms.ToArray();
                }
            }

            return encryptedBytes;
        }
        public byte[] AES_Decrypt(byte[] bytesToBeDecrypted, byte[] passwordBytes)
        {
            byte[] decryptedBytes = null;

            // Set your salt here, change it to meet your flavor:
            // The salt bytes must be at least 8 bytes.
            byte[] saltBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            using (MemoryStream ms = new MemoryStream())
            {
                using (RijndaelManaged AES = new RijndaelManaged())
                {
                    AES.KeySize = 256;
                    AES.BlockSize = 128;

                    var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);
                    AES.Key = key.GetBytes(AES.KeySize / 8);
                    AES.IV = key.GetBytes(AES.BlockSize / 8);

                    AES.Mode = CipherMode.CBC;

                    using (var cs = new CryptoStream(ms, AES.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesToBeDecrypted, 0, bytesToBeDecrypted.Length);
                        cs.Close();
                    }
                    decryptedBytes = ms.ToArray();
                }
            }

            return decryptedBytes;
        }

        public string EncryptText(string input, string password)
        {
            // Get the bytes of the string
            byte[] bytesToBeEncrypted = Encoding.UTF8.GetBytes(input);
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

            // Hash the password with SHA256
            passwordBytes = SHA256.Create().ComputeHash(passwordBytes);

            byte[] bytesEncrypted = AES_Encrypt(bytesToBeEncrypted, passwordBytes);

            string result = Convert.ToBase64String(bytesEncrypted);

            return result;
        }

        public string DecryptText(string input, string password)
        {
            // Get the bytes of the string
            byte[] bytesToBeDecrypted = Convert.FromBase64String(input);
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            passwordBytes = SHA256.Create().ComputeHash(passwordBytes);

            byte[] bytesDecrypted = AES_Decrypt(bytesToBeDecrypted, passwordBytes);

            string result = Encoding.UTF8.GetString(bytesDecrypted);

            return result;
        }

        #region Using Private Key
        public string GenerateLicense(string sKeyString)
        {
            string License = "";

            License = EncryptText(sKeyString, getPrivateLicenseKey());

            return License;
        }

        public string DecodeLicense(string sLicense)
        {
            string DecodedLicense = "";

            DecodedLicense = DecryptText(sLicense, getPrivateLicenseKey());

            return DecodedLicense;
        }

        public string Encrypt(string sPlainText)
        {
            string Encrypted = "";

            Encrypted = EncryptText(sPlainText, getPrivateKey());

            return Encrypted;
        }

        public string Decrypt(string sEncrypted)
        {
            string Decrypted = "";

            Decrypted = DecryptText(sEncrypted, getPrivateKey());

            return Decrypted;
        }

        public void EncryptFile(string sSourcePath, string sDestinationPath)
        {
            //string file = "C:\\SampleFile.DLL";
            //string password = "abcd1234";
            string file = sSourcePath;
            string password = getPrivateFileKey();

            byte[] bytesToBeEncrypted = File.ReadAllBytes(file);
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

            // Hash the password with SHA256
            passwordBytes = SHA256.Create().ComputeHash(passwordBytes);

            byte[] bytesEncrypted = AES_Encrypt(bytesToBeEncrypted, passwordBytes);

            //string fileEncrypted = "C:\\SampleFileEncrypted.DLL";
            string fileEncrypted = sDestinationPath;

            File.WriteAllBytes(fileEncrypted, bytesEncrypted);
        }

        public void DecryptFile(string sSourcePath, string sDestinationPath)
        {
            //string fileEncrypted = "C:\\SampleFileEncrypted.DLL";
            //string password = "abcd1234";
            string fileEncrypted = sSourcePath;
            string password = getPrivateFileKey();

            byte[] bytesToBeDecrypted = File.ReadAllBytes(fileEncrypted);
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            passwordBytes = SHA256.Create().ComputeHash(passwordBytes);

            byte[] bytesDecrypted = AES_Decrypt(bytesToBeDecrypted, passwordBytes);

            //string file = "C:\\SampleFile.DLL";
            string file = sDestinationPath;
            File.WriteAllBytes(file, bytesDecrypted);
        }
        #endregion Using Private Key

        #region Using Private Custom Key
        public string GenerateLicense(string sKeyString, string sKey)
        {
            string License = "";

            License = EncryptText(sKeyString, sKey);

            return License;
        }

        public string DecodeLicense(string sLicense, string sKey)
        {
            string DecodedLicense = "";

            DecodedLicense = DecryptText(sLicense, sKey);

            return DecodedLicense;
        }

        public string Encrypt(string sPlainText, string sKey)
        {
            string Encrypted = "";

            Encrypted = EncryptText(sPlainText, sKey);

            return Encrypted;
        }

        public string Decrypt(string sEncrypted, string sKey)
        {
            string Decrypted = "";

            Decrypted = DecryptText(sEncrypted, sKey);

            return Decrypted;
        }

        public void EncryptFile(string sSourcePath, string sDestinationPath, string sKey)
        {
            //string file = "C:\\SampleFile.DLL";
            //string password = "abcd1234";
            string file = sSourcePath;
            string password = sKey;

            byte[] bytesToBeEncrypted = File.ReadAllBytes(file);
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

            // Hash the password with SHA256
            passwordBytes = SHA256.Create().ComputeHash(passwordBytes);

            byte[] bytesEncrypted = AES_Encrypt(bytesToBeEncrypted, passwordBytes);

            //string fileEncrypted = "C:\\SampleFileEncrypted.DLL";
            string fileEncrypted = sDestinationPath;

            File.WriteAllBytes(fileEncrypted, bytesEncrypted);
        }

        public void DecryptFile(string sSourcePath, string sDestinationPath, string sKey)
        {
            //string fileEncrypted = "C:\\SampleFileEncrypted.DLL";
            //string password = "abcd1234";
            string fileEncrypted = sSourcePath;
            string password = sKey;

            byte[] bytesToBeDecrypted = File.ReadAllBytes(fileEncrypted);
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            passwordBytes = SHA256.Create().ComputeHash(passwordBytes);

            byte[] bytesDecrypted = AES_Decrypt(bytesToBeDecrypted, passwordBytes);

            //string file = "C:\\SampleFile.DLL";
            string file = sDestinationPath;
            File.WriteAllBytes(file, bytesDecrypted);
        }
        #endregion Using Private Custom Key

        #region HASH Calculation
        public byte[] GetHash(string sText)
        {
            HashAlgorithm algo = MD5.Create();
            return algo.ComputeHash(Encoding.UTF8.GetBytes(sText));
        }
        public string GetHashString(string sText)
        {
            StringBuilder sb = new StringBuilder();
            foreach(byte b in GetHash(sText))
            {
                sb.Append(b.ToString("X2"));
            }
            return sb.ToString();
        }
        #endregion HASH Calculation
    }
}
