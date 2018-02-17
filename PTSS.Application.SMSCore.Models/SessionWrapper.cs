using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace PTSS.Application.SMSCore.Models
{
    public static class SessionWrapper
    {
        #region constants
        private const string licenseModel = "LicenseModel";
        private const string loginModel = "LoginModel";
        //private const string organizationModel = "OrganizationModel";
        private const string loginID = "LoginID";
        private const string currentUserModel = "CurrentUserModel";
        private const string addUserModel = "AddUserModel";
        private const string viewUserModel = "ViewUserModel";
        private const string mainMenuItemModelList = "MainMenuItemModelList";
        private const string childMenuItemModelList = "ChildMenuItemModelList";
        private const string userPermissionModel = "UserPermissionModel";
        #endregion constants
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
        ///// <summary>
        ///// Organization Model Object
        ///// </summary>
        //public static OrganizationModel OrganizationModel
        //{
        //    get
        //    {
        //        if (HttpContext.Current.Session[organizationModel] == null)
        //            return null;
        //        else
        //            return (OrganizationModel)HttpContext.Current.Session[organizationModel];
        //    }
        //    set
        //    {
        //        HttpContext.Current.Session[organizationModel] = value;
        //    }
        //}
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
        /// <summary>
        /// Add User, User Model Object
        /// </summary>
        public static UserModel AddUserModel
        {
            get
            {
                if (HttpContext.Current.Session[addUserModel] == null)
                    return null;
                else
                    return (UserModel)HttpContext.Current.Session[addUserModel];
            }
            set
            {
                HttpContext.Current.Session[addUserModel] = value;
            }
        }
        /// <summary>
        /// View User, User Model Object
        /// </summary>
        public static UserModel ViewUserModel
        {
            get
            {
                if (HttpContext.Current.Session[viewUserModel] == null)
                    return null;
                else
                    return (UserModel)HttpContext.Current.Session[viewUserModel];
            }
            set
            {
                HttpContext.Current.Session[viewUserModel] = value;
            }
        }
        /// <summary>
        /// Holds the Main Menu Item Models
        /// </summary>
        public static List<MenuItemModel> MainMenuItemModelList
        {
            get
            {
                if (HttpContext.Current.Session[mainMenuItemModelList] == null)
                    return null;
                else
                    return (List<MenuItemModel>)HttpContext.Current.Session[mainMenuItemModelList];
            }
            set
            {
                HttpContext.Current.Session[mainMenuItemModelList] = value;
            }
        }
        /// <summary>
        /// Holds the Child Menu Item Models
        /// </summary>
        public static List<MenuItemModel> ChildMenuItemModelList
        {
            get
            {
                if (HttpContext.Current.Session[childMenuItemModelList] == null)
                    return null;
                else
                    return (List<MenuItemModel>)HttpContext.Current.Session[childMenuItemModelList];
            }
            set
            {
                HttpContext.Current.Session[childMenuItemModelList] = value;
            }
        }

        public static UserPermissionsModel UserPermissionModel
        {
            get
            {
                if (HttpContext.Current.Session[userPermissionModel] == null)
                    return null;
                else
                    return (UserPermissionsModel)HttpContext.Current.Session[userPermissionModel];
            }
            set
            {
                HttpContext.Current.Session[userPermissionModel] = value;
            }
        }
    }
}
