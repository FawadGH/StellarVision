using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Configuration;
using PTSS.Logger;
using PTSS.Application.SMSCore.Models;

namespace SMSCore
{
    public class Global : System.Web.HttpApplication
    {
        #region comment
        //private string sLogDirectory;
        //private string sLogFileName;
        //private bool isDateWiseLogs;
        //private string sLogPath;
        #endregion comment

        public static Logger oLog;
        public static bool isLicenseValidated;
        private string sClassName = "Global";

        protected void Application_Start(object sender, EventArgs e)
        {
            string sFunctionName = "Application_Start(,)";

        }

        protected void Session_Start(object sender, EventArgs e)
        {
            string sFunctionName = "Session_Start(,)";
            #region comment
            //sLogDirectory = ConfigurationManager.AppSettings["LogDirectory"].ToString();
            //sLogFileName = ConfigurationManager.AppSettings["LogFileName"].ToString();
            //isDateWiseLogs = ConfigurationManager.AppSettings["isDateWiseLogs"].ToString() == "1" ? true : false;

            //oLog.Initialize(sLogDirectory, sLogFileName, isDateWiseLogs);
            #endregion comment

            oLog = new Logger();

            if (SetOrganizationConfiguration().isSuccessful)
            {
                ValidateLicense();
            }
            else
            {
                #region Text Logging
                Global.oLog.Log(
                    sClassName,
                    sFunctionName,
                    "Failed to fetch Organization Configuration.");
                #endregion Text Logging

            }
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
        private ResponseModel SetOrganizationConfiguration()
        {
            ResponseModel Response = new ResponseModel();
            SMSCoreWebModel Web = new SMSCoreWebModel();
            Response = Web.setOrganization();
            return Response;
        }
        private void ValidateLicense()
        {
            Global.isLicenseValidated = false;
            SMSCoreWebModel Web = new SMSCoreWebModel();
            Global.isLicenseValidated = Web.ValidateLicense();
        }
    }
}