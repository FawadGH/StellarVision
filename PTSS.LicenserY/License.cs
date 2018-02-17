using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PTSS.LicenserX;

namespace PTSS.LicenserY
{
    public class License
    {
        LicenserX.License LicenseX = new LicenserX.License();

        #region With Private Key
        public String GenerateLicense(string sKeyString)
        {
            String License;

            License = LicenseX.GenerateLicense(sKeyString);

            return License;
        }

        public String DecodeLicense(string sLicense)
        {
            String KeyString;

            KeyString = LicenseX.DecodeLicense(sLicense);

            return KeyString;
        }

        public String Encrypt(string sPlainText)
        {
            String Encrypted;

            Encrypted = LicenseX.Encrypt(sPlainText);

            return Encrypted;
        }

        public String Decrypt(string sEncrypted)
        {
            String Decrypted;

            Decrypted = LicenseX.Decrypt(sEncrypted);

            return Decrypted;
        }
        #endregion With Private Key

        #region With Custom Private Key
        public String GenerateLicense(string sKeyString, string sKey)
        {
            String License;

            License = LicenseX.GenerateLicense(sKeyString, sKey);

            return License;
        }

        public String DecodeLicense(string sLicense, string sKey)
        {
            String KeyString;

            KeyString = LicenseX.DecodeLicense(sLicense, sKey);

            return KeyString;
        }

        public String Encrypt(string sPlainText, string sKey)
        {
            String Encrypted;

            Encrypted = LicenseX.Encrypt(sPlainText, sKey);

            return Encrypted;
        }

        public String Decrypt(string sEncrypted, string sKey)
        {
            String Decrypted;

            Decrypted = LicenseX.Decrypt(sEncrypted, sKey);

            return Decrypted;
        }
        #endregion With Custom Private Key
        #region HASH Calculaion

        public string GetHash(string sText)
        {
            String Hash;
            Hash = LicenseX.GetHashString(sText);
            return Hash;
        }

        #endregion HASH Calculation
    }
}
