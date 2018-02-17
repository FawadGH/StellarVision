using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SMSCore.UI
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //AJAX CALL FOR BALOON COUNT AND INNER HEADING COUNT
        [WebMethod]
        public static Array BaloonAlerts()
        {
            //get value from database.
            return new int[] {4,5};
        }


        [WebMethod]
        public static Array Messages()
        {
            List<ExpandoObject> data = new List<ExpandoObject>();
            for (int i = 0; i < 3; i++)
            {
                dynamic oDObject = new ExpandoObject();
                oDObject.userid = i;
                oDObject.name = "Anwar"+i;
                oDObject.truncatedmsg = "Hi, I want to be ...";
                data.Add(oDObject);
            }

            return data.ToArray();
        }
    }
}