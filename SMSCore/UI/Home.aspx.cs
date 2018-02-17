using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SMSCore.UI
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        SMSCoreWebModel Web = new SMSCoreWebModel();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnTest1_Click(object sender, EventArgs e)
        {
            if (Web.ValidateLicense())
            {
                System.Threading.Thread.Sleep(3000);
                Label1.Text = "License Validated";
                Label2.Text = ":D";
            }
            else
            {
                System.Threading.Thread.Sleep(5000);
                Label1.Text = "License Validation fail";
                Label2.Text = ":(";
            }
        }

        protected void btnTest2_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(4000);
            Label2.Text = "Simply Changed Text";
        }
    }
}