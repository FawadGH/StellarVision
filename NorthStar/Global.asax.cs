using NorthStar.Models;
using PTSS.Application.SMSCore.Models;
using PTSS.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace NorthStar
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public static Logger oLog;
        public static bool isLicenseValidated;
        private string sClassName = "Global";
        protected void Application_Start()
        {
            string sFunctionName = "Application_Start(,)";
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
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
            Application.Add("oLog", oLog);
            if (SetOrganizationConfiguration().isSuccessful)
            {
                ValidateLicense();
            }
            else
            {
                #region Text Logging
                MvcApplication.oLog.Log(
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
            NorthStarWebModel Web = new NorthStarWebModel();
            Response = Web.setOrganization();
            return Response;
        }
        private void ValidateLicense()
        {
            MvcApplication.isLicenseValidated = false;
            NorthStarWebModel Web = new NorthStarWebModel();
            MvcApplication.isLicenseValidated = Web.ValidateLicense();
        }
    }
}
