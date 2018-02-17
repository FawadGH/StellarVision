using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PTSS.Logger;
using PTSS.Application.SMSCore.Models;

namespace PTSS.Application.SMSCore.Structure
{
    public class LoginStructure
    {
        private string sClassName = "LoginStructure";

        Logger.Logger oLog = new Logger.Logger();
        protected string sLoginID;
        protected string sPassword;


        public ResponseModel AuthenticateUserLogin(string sLoginID, string sPassword)
        {
            string sFunctionName = "AuthenticateUserLogin(,)";
            ResponseModel Result = new ResponseModel();
            UserModel User = new UserModel();
            User.Initialize(sLoginID);

            if (User.Initialized)
            {
                SessionWrapper.CurrentUserModel = User;
                Result = User.ValidatePassword(sPassword);
            }
            else
            {
                //Invalid Username or Password
                Result.FailedWithoutException();
            }


            return Result;
        }
        public ResponseModel GetUserPermissions(UserModel userModel)
        {
            string sFunctionName = "GetUserPermissions(,)";
            ResponseModel Result = new ResponseModel();
            UserModel User = new UserModel();
            User = userModel;
            Result = User.GetUserPermissions(User.UserTypeID, User.UserLevelID);

            SessionWrapper.CurrentUserModel = User;
            return Result;
        }
        public ResponseModel LoadMainMenuItemsList(List<UserModel.UserPermission> UserPermissions)
        {
            string sFunctionName = "LoadMainMenuItemsList(,)";
            ResponseModel Result = new ResponseModel();
            MenuItemModel MainMenuItem;
            Dictionary<string, string> MenuParent = new Dictionary<string, string>();
            //Clear Main Menu Items List Before Re-Populating it.
            SessionWrapper.MainMenuItemModelList = new List<MenuItemModel>();
            //Set Single Modules in Dictionary
            foreach (UserModel.UserPermission UserPermission in UserPermissions)
            {
                if (!MenuParent.ContainsKey(UserPermission.ModuleID))
                    MenuParent.Add(UserPermission.ModuleID, UserPermission.ModuleFunctionID);
            }
            foreach (UserModel.UserPermission UserPermission in UserPermissions)
            {
                //Only Fetch Single Module. Remove ModuleID so that same module is not fetched again.
                if (MenuParent.ContainsKey(UserPermission.ModuleID))
                {
                    MainMenuItem = new MenuItemModel();
                    Result = MainMenuItem.getMainMenuItem(UserPermission.ModuleID, UserPermission.ModuleFunctionID);
                    MenuParent.Remove(UserPermission.ModuleID);
                    SessionWrapper.MainMenuItemModelList.Add(MainMenuItem);
                }

            }
            Result.SuccessfullyPassed();
            return Result;
        }
        public ResponseModel LoadChildMenuItemsList(List<UserModel.UserPermission> UserPermissions)
        {
            string sFunctionName = "LoadChildMenuItemsList(,)";
            ResponseModel Result = new ResponseModel();
            MenuItemModel ChildMenuItem;
            //Clear Child Menu Items List Before Re-Populating it.
            SessionWrapper.ChildMenuItemModelList = new List<MenuItemModel>();
            foreach(UserModel.UserPermission UserPermission in UserPermissions)
            {
                ChildMenuItem = new MenuItemModel();
                Result = ChildMenuItem.getChildMenuItem(UserPermission.ModuleID, UserPermission.ModuleFunctionID);
                SessionWrapper.ChildMenuItemModelList.Add(ChildMenuItem);
            }
            Result.SuccessfullyPassed();
            return Result;
        }

    }
}
