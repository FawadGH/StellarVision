using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PTSS.Application.SMSCore.Models;

namespace SMSCore
{
    public static class SessionWrapper
    {
        #region constants
        private const string licenseModel = "LicenseModel";
        private const string loginModel = "LoginModel";
        private const string organizationModel = "OrganizationModel";
        private const string loginID = "LoginID";
        private const string currentUserModel = "UserModel";
        #endregion
        /// <summary>
        /// License Model Object
        /// </summary>
        public static LicenseModel LicenseModel
        {
            get
            {
                if (HttpContext.Current.Session[licenseModel] == null)
                    return null;
                else
                    return (LicenseModel)HttpContext.Current.Session[licenseModel];
            }
            set
            {
                HttpContext.Current.Session[licenseModel] = value;
            }
        }
        /// <summary>
        /// Login Model Object
        /// </summary>
        public static LoginModel LoginModel
        {
            get
            {
                if (HttpContext.Current.Session[loginModel] == null)
                    return null;
                else
                    return (LoginModel)HttpContext.Current.Session[loginModel];
            }
            set
            {
                HttpContext.Current.Session[loginModel] = value;
            }
        }
        /// <summary>
        /// Organization Model Object
        /// </summary>
        public static OrganizationModel OrganizationModel
        {
            get
            {
                if (HttpContext.Current.Session[organizationModel] == null)
                    return null;
                else
                    return (OrganizationModel)HttpContext.Current.Session[organizationModel];
            }
            set
            {
                HttpContext.Current.Session[organizationModel] = value;
            }
        }
        /// <summary>
        /// Maintains the LoginID of the logged in user
        /// </summary>
        public static string LoginID
        {
            get
            {
                if (HttpContext.Current.Session[loginID] == null)
                    return null;
                else
                    return HttpContext.Current.Session[loginID].ToString();
            }
            set
            {
                HttpContext.Current.Session[loginID] = value;
            }
        }
        /// <summary>
        /// Currently Loggedin User Model Object
        /// </summary>
        public static UserModel CurrentUserModel
        {
            get
            {
                if (HttpContext.Current.Session[currentUserModel] == null)
                    return null;
                else
                    return (UserModel)HttpContext.Current.Session[currentUserModel];
            }
            set
            {
                HttpContext.Current.Session[currentUserModel] = value;
            }
        }

    }
}