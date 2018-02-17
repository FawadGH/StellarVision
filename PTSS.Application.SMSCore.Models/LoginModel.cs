using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PTSS.Logger;
using PTSS.Application.SMSCore.DataAccess;
using System.Data;

namespace PTSS.Application.SMSCore.Models
{
    public class LoginModel
    {
        private string sClassName = "LoginModel";

        Logger.Logger oLog = new Logger.Logger();
        public string sLoginID { get; set; }
        public string sPassword { get; set; }


        public ResponseModel AuthenticateUserLogin(string sLoginID, string sPassword)
        {
            string sFunctionName = "AuthenticateUserLogin(,)";
            ResponseModel Result = new ResponseModel();
            try
            {
                
                SMSCoreData CoreData = new SMSCoreData();
                DataView oDV = new DataView();

                CoreData.getUserProfile(sLoginID, out oDV);
                if (oDV != null)
                {
                    Result.isSuccessful = true;
                    Result.sResponseCode = Constants.ResponseMessages.Success;
                }
            }
            catch (Exception ex)
            {
                #region Text Logging
                oLog.Log(
                    sClassName,
                    sFunctionName,
                    ex.Message);
                #endregion Text Logging
                Result.isSuccessful = false;
                Result.sResponseCode = Constants.ResponseMessages.Failure;
            }
            return Result;
        }
    }
}
