using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTSS.Application.SMSCore.Models
{
    public static class Constants
    {
        public static class ResponseMessages
        {
            public const string Success = "0000";
            public const string Failure = "9999";
        }
        public static class WebPageURLs
        {
            public const string Login = "Views/Login/LoginA.aspx";
        }
        public static class WebPageController
        {
            public const string UserManagement = "UserManagement";
            public const string Error = "Error";
        }
        public static class WebPageAction
        {
            public const string Index = "Index";
            public const string AddUserType = "AddUserType";
            public const string AddUserTypeDone = "AddUserTypeDone";
            public const string ViewUserType = "ViewUserType";
            public const string AddUserLevel = "AddUserLevel";
            public const string AddUserLevelDone = "AddUserLevelDone";
            public const string ViewUserLevel = "ViewUserLevel";
        }
        public static class WebConstants
        {
            public const string SMSCoreDBConName = "SMSCoreDB"; //Added to DataAccessConstants
        }
    }
}
