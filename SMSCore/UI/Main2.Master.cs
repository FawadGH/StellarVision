using PTSS.Application.SMSCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SMSCore.UI
{
    public partial class Main2 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                lblTitle.Text = getWebTitle();
            }
        }
        public string getWebTitle()
        {
            string sWebTitle = "";
            if (Global.isLicenseValidated)
            {
                sWebTitle = ApplicationWrapper.OrganizationModel.Name;
            }
            else
            {
                sWebTitle = "Failed Validation";
            }

            return sWebTitle;
        }
    }
}