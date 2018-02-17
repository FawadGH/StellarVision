using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PTSS.Logger;

namespace PTSS.Application.SMSCore.Models
{
    public class SecurityModel
    {
        string sClassName = "PTSS.Application.SMSCore.Models.SecurityModel";
        Logger.Logger oLog = new Logger.Logger();
        public string sEncrypt(string sPlainText, string sKey)
        {
            string sFunctionName = "sEncrypt(,)";
            string sEncryptedString = "";
            try
            {
                sEncryptedString = sPlainText;
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
                sPlainText = sCipherText;
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
                sEncryptedString = sPlainText;
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
                sPlainText = sCipherText;
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
