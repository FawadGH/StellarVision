using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PTSS.Logger;
using PTSS.Application.SMSCore.Models;
using PTSS.Application.SMSCore.Structure;

namespace SMSCore
{
    public partial class TestForm : System.Web.UI.Page
    {
        string sClassName = "TestForm";
        //Logger oLog = new Logger();

        protected void Page_Load(object sender, EventArgs e)
        {
            string sFunctionName = "Page_load()";

            #region Logging
            Global.oLog.Log(
                sClassName, 
                sFunctionName, 
                "First Test Log");
            #endregion Logging

            lblTest.Text = "Log Created";

            ResponseModel Result = new ResponseModel();
            Result = AuthenticateUserLogin("TestLoginID", "TestPassword");
            if(Result.isSuccessful)
            {
                #region Text Logging
                Global.oLog.Log(
                    sClassName,
                    sFunctionName,
                    "Creating User Session and Logging in.");
                #endregion Text Logging
                lblTest.Text = "User Successfully Logged in";
            }
            else
            {
                #region Text Logging
                Global.oLog.Log(
                    sClassName,
                    sFunctionName,
                    "User Login Failed.");
                #endregion Text Logging
                lblTest.Text = "User Login Failed";
            }
        }



        private ResponseModel AuthenticateUserLogin(string sLoginID, string sPassword)
        {
            string sFunctionName = "AuthenticateUserLogin(,)";
            ResponseModel Result = new ResponseModel();
            LoginStructure Login = new LoginStructure();

            Result = Login.AuthenticateUserLogin(sLoginID, sPassword);

            return Result;
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string sFunctionName = "btnLogin_Click()";
            ResponseModel Result = new ResponseModel();
            #region Text Logging
            Global.oLog.Log(
                sClassName,
                sFunctionName,
                "Authenticating user..");
            #endregion Text Logging
            Result = AuthenticateUserLogin("", "");
            if(Result.isSuccessful)
            Response.Redirect(Constants.WebPageURLs.Login);
        }
    }
}