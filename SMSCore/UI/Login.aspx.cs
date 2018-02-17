using PTSS.Application.SMSCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SMSCore.UI
{
    public partial class Login1 : System.Web.UI.Page
    {
        SMSCoreWebModel Web = new SMSCoreWebModel();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string sFunctionName = "btnLogin_Click(,)";
            ResponseModel Result = new ResponseModel();
            try
            {
                Result = Web.ValidateUserLogin(tbUserID.Text.Trim(), tbPassword.Text);
                if(Result.isSuccessful)
                {
                    Response.Redirect("~/UI/Home.aspx");
                }
                else
                {
                    Response.Redirect("~/UI/Sample4.aspx");
                }
            }
            catch (Exception ex)
            {

                Result.FailedWithException();
            }
        }
    }
}