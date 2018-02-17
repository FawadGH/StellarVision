using PTSS.Application.SMSCore.DataAccess;
using PTSS.Application.SMSCore.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PTSS.Application.SMSCore.Models
{
    public class UserPermissionsModel
    {
        private string sClassName = "UserPermissionsModel";
        private SMSCoreData Data = new SMSCoreData();

        #region Column Names
        private const string cUserLevelID = "UserLevelID";
        private const string cUserTypeID = "UserTypeID";
        private const string cUserLevelName = "UserLevelName";
        private const string cUserTypeName = "UserTypeName";
        #endregion Column Names

        #region Get N Set
        public string UserLevelID { get; set; }
        public string UserTypeID { get; set; }
        public IEnumerable<SelectListItem> UserTypeSelectList { get; set; }
        public IEnumerable<SelectListItem> UserLevelSelectList { get; set; }
        public IEnumerable<UserTypeModel> UserTypeList { get; set; }
        public IEnumerable<UserLevelModel> UserLevelList { get; set; }
        public List<MenuItemModel> ModulesList { get; set; }
        #endregion Get N Set

        public void Initialize()
        {
            UserTypeList = ApplicationHelper.GetUserTypesList();
            UserLevelList = ApplicationHelper.GetUserLevelsList();
            
            UserTypeSelectList = ControlHelper.GetSelectList(UserTypeList, cUserTypeID, cUserTypeName);
            UserLevelSelectList = ControlHelper.GetSelectList(UserLevelList, cUserLevelID, cUserLevelName);
        }

        public void GetUserLevels(string UserTypeID)
        {
            UserLevelSelectList = ControlHelper.GetSelectList(UserLevelList.Where(x => x.UserTypeID == UserTypeID), cUserLevelID, cUserLevelName);
        }

        public ResponseModel LoadModulesList()
        {
            string sFunctionName = "LoadModulesList()";
            ResponseModel Result = new ResponseModel();
            MenuItemModel ModulesItem;
            Dictionary<string, string> ModulesDictionary = new Dictionary<string, string>();
            //Clear Module Items List Before Re-Populating it.
            ModulesList = new List<MenuItemModel>();
            
            ModulesItem = new MenuItemModel();
            Result = ModulesItem.getAllModules();
            if (Result.isSuccessful)
            {
                ModulesList = ModulesItem.ModulesList;
                Result.SuccessfullyPassed();
            }
            else
            {
                Result.FailedWithoutException();
            }
            
            return Result;
        }
        public ResponseModel LoadModuleFunctionsList(ref List<MenuItemModel> ModulesList)
        {
            string sFunctionName = "LoadModuleFunctionsList()";
            ResponseModel Result = new ResponseModel();
            MenuItemModel ModuleFunctionsItem;
            //Clear Child Menu Items List Before Re-Populating it.
            //ApplicationWrapper.ModuleFunctionsList = new List<MenuItemModel>();

            ModuleFunctionsItem = new MenuItemModel();
            Result = ModuleFunctionsItem.getAllModuleFunctions(ref ModulesList);
            if(Result.isSuccessful)
            {
                //ApplicationWrapper.ModuleFunctionsList = ModuleFunctionsItem.ModuleFunctionsList;
                Result.SuccessfullyPassed();
            }
            else
            {
                Result.FailedWithoutException();
            }

            
            return Result;
        }

        public ResponseModel SetPermissions()
        {
            string sFunctionName = "SetPermission()";
            ResponseModel Result = new ResponseModel();
            try
            {
                Data.RemovePermissions(UserTypeID, UserLevelID);
                foreach (MenuItemModel Item in ModulesList)
                {
                    if (Item?.ModuleFunctionsList.Count > 0)
                    {
                        foreach (MenuItemModel ChildItem in Item.ModuleFunctionsList)
                        {
                            Data.SetPermissions(UserTypeID, UserLevelID, ChildItem.ModuleID, ChildItem.ModuleFunctionID);
                        }
                    }
                    else
                        Data.SetPermissions(UserTypeID, UserLevelID, Item.ModuleID, "");
                }
                Result.SuccessfullyPassed();
            }
            catch(Exception ex)
            {
                Result.FailedWithException();
            }
            return Result;
        }
    }
}
