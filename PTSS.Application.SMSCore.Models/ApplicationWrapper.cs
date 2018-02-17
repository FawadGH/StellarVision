using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace PTSS.Application.SMSCore.Models
{
    public static class ApplicationWrapper
    {
        #region constant
        private const string organizationModel = "OrganizationModel";
        private const string modulesList = "ModulesList";
        private const string moduleFunctionsList = "ModuleFunctionsList";
        private const string userTypesList = "UserTypesList";
        private const string userLevelsList = "UserLevelsList";
        private const string userStatusList = "UserStatusList";
        #endregion constant
        /// <summary>
        /// Organization Model Object
        /// </summary>
        public static OrganizationModel OrganizationModel
        {
            get
            {
                if (HttpContext.Current.Application[organizationModel] == null)
                    return null;
                else
                    return (OrganizationModel)HttpContext.Current.Application[organizationModel];
            }
            set
            {
                HttpContext.Current.Application[organizationModel] = value;
            }
        }
        /// <summary>
        /// Holds All The Modules Item
        /// </summary>
        public static List<MenuItemModel> ModulesList
        {
            get
            {
                if (HttpContext.Current.Application[modulesList] == null)
                    return null;
                else
                    return (List<MenuItemModel>)HttpContext.Current.Application[modulesList];
            }
            set
            {
                HttpContext.Current.Application[modulesList] = value;
            }
        }
        /// <summary>
        /// Holds All the Module Functions Item
        /// </summary>
        public static List<MenuItemModel> ModuleFunctionsList
        {
            get
            {
                if (HttpContext.Current.Application[moduleFunctionsList] == null)
                    return null;
                else
                    return (List<MenuItemModel>)HttpContext.Current.Application[moduleFunctionsList];
            }
            set
            {
                HttpContext.Current.Application[moduleFunctionsList] = value;
            }
        }
        /// <summary>
        /// Holds All the User Types
        /// </summary>
        public static List<UserTypeModel> UserTypesList
        {
            get
            {
                if (HttpContext.Current.Application[userTypesList] == null)
                    return null;
                else
                    return (List<UserTypeModel>)HttpContext.Current.Application[userTypesList];
            }
            set
            {
                HttpContext.Current.Application[userTypesList] = value;
            }
        }
        /// <summary>
        /// Holds All the User Levels
        /// </summary>
        public static List<UserLevelModel> UserLevelsList
        {
            get
            {
                if (HttpContext.Current.Application[userLevelsList] == null)
                    return null;
                else
                    return (List<UserLevelModel>)HttpContext.Current.Application[userLevelsList];
            }
            set
            {
                HttpContext.Current.Application[userLevelsList] = value;
            }
        }
        /// <summary>
        /// Holds All the User Status
        /// </summary>
        public static List<UserStatusModel> UserStatusList
        {
            get
            {
                if (HttpContext.Current.Application[userStatusList] == null)
                    return null;
                else
                    return (List<UserStatusModel>)HttpContext.Current.Application[userStatusList];
            }
            set
            {
                HttpContext.Current.Application[userStatusList] = value;
            }
        }
    }
}
