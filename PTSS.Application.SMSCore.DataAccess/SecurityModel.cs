using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PTSS.LicenserY;

namespace PTSS.Application.SMSCore.DataAccess
{
    public class SecurityModel
    {
        string sClassName = "PTSS.Application.SMSCore.Models.SecurityModel";
        Logger.Logger oLog = new Logger.Logger();
        LicenserY.License LicenseY = new License();
        public string sEncrypt(string sPlainText, string sKey)
        {
            string sFunctionName = "sEncrypt(,)";
            string sEncryptedString = "";
            try
            {
                sEncryptedString = LicenseY.Encrypt(sPlainText, sKey);
            }
            catch (Exception ex)
            {
                #region Text Logging
                oLog.Log(
                    sClassName,
                    sFunctionName,
                    ex.Message);
                #endregion Text Logging
            }
            return sEncryptedString;
        }
        public string sDecrypt(string sCipherText, string sKey)
        {
            string sFunctionName = "sDecrypt(,)";
            string sPlainText = "";
            try
            {
                sPlainText = LicenseY.Decrypt(sCipherText, sKey);
            }
            catch (Exception ex)
            {
                #region Text Logging
                oLog.Log(
                    sClassName,
                    sFunctionName,
                    ex.Message);
                #endregion Text Logging
            }
            return sPlainText;
        }

        public string sEncrypt(string sPlainText)
        {
            string sFunctionName = "sEncrypt()";
            string sEncryptedString = "";
            try
            {
                sEncryptedString = LicenseY.Encrypt(sPlainText);
            }
            catch (Exception ex)
            {
                #region Text Logging
                oLog.Log(
                    sClassName,
                    sFunctionName,
                    ex.Message);
                #endregion Text Logging
            }
            return sEncryptedString;
        }
        public string sDecrypt(string sCipherText)
        {
            string sFunctionName = "sDecrypt()";
            string sPlainText = "";
            try
            {
                sPlainText = LicenseY.Decrypt(sCipherText);
            }
            catch (Exception ex)
            {
                #region Text Logging
                oLog.Log(
                    sClassName,
                    sFunctionName,
                    ex.Message);
                #endregion Text Logging
            }
            return sPlainText;
        }
    }
}
