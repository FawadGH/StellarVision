using Newtonsoft.Json;
using PTSS.Application.SMSCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NorthStar.Controllers
{
    public class UserManagementController : BaseController
    {
        // GET: UserManagement
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult AddUserType()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddUserType(UserTypeModel userType)
        {
            string sFunctionName = "AddUserType()";
            ResponseModel Result = new ResponseModel();
            try
            {
                Result = userType.AddUserType(userType.UserTypeName);
                if (Result.isSuccessful)
                {
                    return Json(new
                    {
                        success = true,
                        ResponseMessage = "User Type \"" + userType.UserTypeName + "\" Successfully Added."
                    });
                    //return RedirectToAction(Constants.WebPageAction.AddUserTypeDone, Constants.WebPageController.UserManagement, userType);
                }
                else
                {
                    return Json(new
                    {
                        success = true,
                        ResponseMessage = "User Type \"" + userType.UserTypeName + "\" Already exist."
                    });
                    //return RedirectToAction(Constants.WebPageAction.Index, Constants.WebPageController.Error);
                }
            }
            catch(Exception ex)
            {
                Result.FailedWithException();
                return Json(new
                {
                    success = true,
                    ResponseMessage = "User Type \"" + userType.UserTypeName + "\" Failed to Add."
                });
            }
        }
        [HttpGet]
        public ActionResult AddUserTypeDone(UserTypeModel userType)
        {
            return View(userType);
        }
        [HttpPost]
        public ActionResult AddUserTypeDone()
        {
            return RedirectToAction(Constants.WebPageAction.AddUserType, Constants.WebPageController.UserManagement);
        }
        [HttpGet]
        public ActionResult AddUserLevel()
        {
            UserLevelModel userLevel = new UserLevelModel();
            userLevel.Initialize();
            return View(userLevel);
        }
        [HttpPost]
        public ActionResult AddUserLevel(UserLevelModel userLevel)
        //public ActionResult AddUserLevel(string model)
        {
            string sFunctionName = "AddUserLevel()";
            //UserLevelModel userLevel = (UserLevelModel)JsonConvert.DeserializeObject(model);
            ResponseModel Result = new ResponseModel();
            try
            {
                Result = userLevel.AddUserLevel(userLevel.UserTypeID, userLevel.UserLevelName);

                if (Result.isSuccessful)
                {
                    return Json(new
                    {
                        ResponseMessage = "User Level \"" + userLevel.UserLevelName + "\" Successfully Added.",
                        success = true
                    });
                    //return RedirectToAction(Constants.WebPageAction.AddUserLevelDone, Constants.WebPageController.UserManagement, userLevel);
                }
                else
                {
                    return Json(new
                    {
                        ResponseMessage = "User Level \"" + userLevel.UserLevelName + "\" already exist.",
                        success = false
                    });
                    //return RedirectToAction(Constants.WebPageAction.Index, Constants.WebPageController.Error);
                }
            }
            catch(Exception ex)
            {
                Result.FailedWithException();
                return Json(new
                {
                    ResponseMessage = "User Level \"" + userLevel.UserLevelName + "\" Failed to Add.",
                    success = false
                });
            }
            
        }
        [HttpGet]
        public ActionResult AddUserLevelDone(UserLevelModel userLevel)
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddUserLevelDone()
        {
            return RedirectToAction(Constants.WebPageAction.AddUserLevel, Constants.WebPageController.UserManagement);
        }
        [HttpGet]
        public ActionResult SetPermissions()
        {
            UserPermissionsModel userPermissions = new UserPermissionsModel();

            userPermissions.Initialize();

            userPermissions.LoadModulesList();
            List<MenuItemModel> ModulesList;
            ModulesList = userPermissions.ModulesList;

            //Adding Module Functions to the existing Modules List's Module Functions List
            userPermissions.LoadModuleFunctionsList(ref ModulesList);
            userPermissions.ModulesList = ModulesList;

            SessionWrapper.UserPermissionModel = userPermissions;
            return View(userPermissions);
        }
        [HttpPost]
        public ActionResult GetUserLevels(string UserTypeID)
        {
            UserPermissionsModel userPermissions = new UserPermissionsModel();
            UserModel userModel = new UserModel();
            if(SessionWrapper.UserPermissionModel != null)
            {
                userPermissions = SessionWrapper.UserPermissionModel;
                try
                {
                    userPermissions.GetUserLevels(UserTypeID);
                    return Json(new
                    {
                        UserLevelList = userPermissions.UserLevelSelectList,
                        success = true
                    });
                }
                catch (Exception ex)
                {
                    return Json(new
                    {
                        success = false
                    });
                }
            }
            if (SessionWrapper.AddUserModel != null)
            {
                userModel = SessionWrapper.AddUserModel;
                try
                {
                    userModel.GetUserLevels(UserTypeID);
                    return Json(new
                    {
                        UserLevelList = userModel.UserLevelSelectList,
                        success = true
                    });
                }
                catch (Exception ex)
                {
                    return Json(new
                    {
                        success = false
                    });
                }
            }
            if (SessionWrapper.ViewUserModel != null)
            {
                userModel = SessionWrapper.ViewUserModel;
                try
                {
                    userModel.GetUserLevels(UserTypeID);
                    return Json(new
                    {
                        UserLevelList = userModel.UserLevelSelectList,
                        success = true
                    });
                }
                catch (Exception ex)
                {
                    return Json(new
                    {
                        success = false
                    });
                }
            }
            return Json(new
            {
                success = false
            });

        }
        [HttpPost]
        public ActionResult SetPermissions(UserPermissionsModel userPermissions)
        {
            string sFunctionName = "SetPermissions(post)";
            ResponseModel Result = new ResponseModel();
            try
            {
                if(string.IsNullOrWhiteSpace(userPermissions.UserTypeID) || string.IsNullOrWhiteSpace(userPermissions.UserLevelID))
                {
                    return Json(new
                    {
                        ResponseMessage = "Please select User Type and User Level",
                        success = false
                    });
                }
                Result = userPermissions.SetPermissions();
                if(Result.isSuccessful)
                {
                    return Json(new
                    {
                        ResponseMessage = "Permissions Successfully set for User Type " + userPermissions.UserTypeID + " and User Level " + userPermissions.UserLevelID,
                        success = true
                    });
                }
                else
                {
                    return Json(new
                    {
                        ResponseMessage = "Failed to set Permissions",
                        success = false
                    });
                }
            }
            catch (Exception ex)
            {

                return Json(new
                {
                    ResponseMessage = "Failed to set Permissions",
                    success = false
                });
            }
            //return View(userPermissions);
        }
        [HttpGet]
        public ActionResult ViewUsers()
        {
            UserModel userModel = new UserModel();
            userModel.Initialize();
            SessionWrapper.ViewUserModel = userModel;
            return View(userModel);
        }
        [HttpPost]
        public ActionResult ViewUsers(LoginModel loginModel)
        {

            return View();
        }
        [HttpPost]
        public ActionResult SearchUsers(UserModel userModel)
        {
            string sFunctionName = "SearchUsers()";
            ResponseModel Result = new ResponseModel();
            Result.FailedWithoutException();
            try
            {
                Result = userModel.SearchUsersByFilter();
                if (userModel.FilteredUsersList.Count() > 0)
                {
                    return Json(new
                    {
                        UsersList = JsonConvert.SerializeObject(userModel.FilteredUsersList),
                        ResponseMessage = "Results Found.",
                        success = true
                    });
                }
                else
                {
                    return Json(new
                    {
                        ResponseMessage = "Your search did not return any results.",
                        success = false
                    });
                }
            }
            catch(Exception ex)
            {
                Result.FailedWithException();
                return Json(new
                {
                    ResponseMessage = "Failed to fetch the results. Please try again.",
                    success = false
                });
            }
        }
        [HttpGet]
        public ActionResult AddUser()
        {
            UserModel userModel = new UserModel();
            userModel.Initialize();
            SessionWrapper.AddUserModel = userModel;
            return View(userModel);
        }
        [HttpPost]
        public ActionResult AddUser(UserModel userModel)
        {
            ResponseModel Result = new ResponseModel();
            Result.FailedWithoutException();
            try
            {
                Result = userModel.AddUserLoginAndUserProfile();
            }
            catch(Exception ex)
            {
                Result.FailedWithException();
            }
            if(Result.isSuccessful)
            {
                return Json(new
                {
                    success = true,
                    ResponseMessage = "User " + userModel.UserID + " successfully added."
                });
            }
            else
            {
                return Json(new
                {
                    success = false,
                    ResponseMessage = "User " + userModel.UserID + " failed to add."
                });
            }
        }
        [HttpPost]
        public ActionResult CheckUserIDAvailability(string UserID)
        {
            ResponseModel Result = new ResponseModel();
            UserModel userModel = new UserModel();
            Result.FailedWithoutException();
            try
            {
                Result = userModel.CheckUserIDAvailability(UserID);
            }
            catch(Exception ex)
            {
                Result.FailedWithException();
            }

            if(userModel.isUserIDAvailable)
            {
                return Json(new
                {
                    success = true,
                    isUserIDAvailable = true
                });
            }
            else
            {
                return Json(new
                {
                    success = false,
                    isUserIDAvailable = false
                });
            }
        }
        [HttpGet]
        public ActionResult ViewUserType()
        {
            UserTypeModel userType = new UserTypeModel();
            userType.UserTypeList = ApplicationHelper.GetUserTypesList();
            return View(userType);
        }
        [HttpPost]
        public ActionResult GetUserTypes()
        {
            string sFunctionName = "GetUserTypes()";
            UserTypeModel userType = new UserTypeModel();
            try
            {
                userType.UserTypeList = ApplicationHelper.GetUserTypesList();
                return Json(new
                {
                    UserTypeList = JsonConvert.SerializeObject(userType.UserTypeList),
                    ResponseMessage = "User Types successfully loaded.",
                    success = true
                });
            }
            catch(Exception ex)
            {
                return Json(new
                {
                    ResponseMessage = "Failed to fetch User Types. Please try again.",
                    success = false
                });
            }
        }
        [HttpGet]
        public ActionResult ViewUserLevel()
        {
            UserLevelModel userLevel = new UserLevelModel();
            userLevel.Initialize();
            userLevel.UserLevelList = ApplicationHelper.GetUserLevelsList();
            return View(userLevel);
        }
        /// <summary>
        /// Get Complete User Levels List for HTML Table
        /// </summary>
        /// <param name="userLevel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult GetUserLevel(UserLevelModel userLevel)
        {
            string sFunctionName = "GetUserLevel()";
            try
            {
                if (userLevel.UserTypeID == null)
                {
                    userLevel.UserLevelList = ApplicationHelper.GetUserLevelsList();
                }
                else
                {
                    userLevel.UserLevelList = ApplicationHelper.GetUserLevelsList().Where(x => x.UserTypeID == userLevel.UserTypeID);
                }

                return Json(new
                {
                    UserLevelList = JsonConvert.SerializeObject(userLevel.UserLevelList),
                    ResponseMessage = "Successfully fetched User Levels.",
                    success = true
                });
            }
            catch(Exception ex)
            {
                return Json(new
                {
                    ResponseMessage = "failed to Fetch User Levels.",
                    success = false
                });
            }
        }
        [HttpPost]
        public ActionResult EditUserType(UserTypeModel userType)
        {
            string sFunctionName = "EditUserType()";
            ResponseModel Result = new ResponseModel();
            Result.FailedWithoutException();
            try
            {
                Result = userType.EditUserType();
                if(Result.isSuccessful)
                {
                    return Json(new
                    {
                        UserTypeList = JsonConvert.SerializeObject(userType.UserTypeList),
                        ResponseMessage = "User Type " + userType.UserTypeName + " successfully edited to " + userType.NewUserTypeName + ".",
                        success = true
                    });
                }
                else
                {
                    return Json(new
                    {
                        ResponseMessage = "Failed to edit the user type. Please try again.",
                        success = false
                    });
                }
            }
            catch(Exception ex)
            {
                return Json(new
                {
                    ResponseMessage = "Failed to edit the user type. Please try again.",
                    success = false
                });
            }
        }
        [HttpPost]
        public ActionResult EditUserLevel(UserLevelModel userLevel)
        {
            string sFunctionName = "EditUserLevel()";
            ResponseModel Result = new ResponseModel();
            Result.FailedWithoutException();
            try
            {
                Result = userLevel.EditUserLevel();
                if(Result.isSuccessful)
                {
                    return Json(new
                    {
                        UserLevelList = JsonConvert.SerializeObject(userLevel.UserLevelList),
                        ResponseMessage = "User Level " + userLevel.UserLevelName + " successfully edited to " + userLevel.NewUserLevelName + ".",
                        success = true
                    });
                }
                else
                {
                    return Json(new
                    {
                        ResponseMessage = "Failed to edit the user level. Please try again.",
                        success = false
                    });
                }
            }
            catch(Exception ex)
            {
                return Json(new
                {
                    ResponseMessage = "Failed to edit the user level. Please try again.",
                    success = false
                });
            }
        }
        [HttpPost]
        public ActionResult DeleteUserType(UserTypeModel userType)
        {
            string sFunctionName = "DeleteUserType()";
            ResponseModel Result = new ResponseModel();
            Result.FailedWithoutException();
            try
            {
                Result = userType.DeleteUserType();
                if (Result.isSuccessful)
                {
                    return Json(new
                    {
                        UserTypeList = JsonConvert.SerializeObject(userType.UserTypeList),
                        ResponseMessage = "Successfully deleted the " + userType.UserTypeName + " User Type.",
                        success = true
                    });
                }
                else
                {
                    return Json(new
                    {
                        ResponseMessage = "Failed to delete the " + userType.UserTypeName + " User Type.",
                        success = false
                    });
                }
            }
            catch(Exception ex)
            {
                return Json(new
                {
                    ResponseMessage = "Failed to delete the " + userType.UserTypeName + " User Type. Please try again later.",
                    success = false
                });
            }
        }
        [HttpPost]
        public ActionResult DeleteUserLevel(UserLevelModel userLevel)
        {
            string sFunctionName = "DeleteUserLevel()";
            ResponseModel Result = new ResponseModel();
            Result.FailedWithoutException();
            try
            {
                Result = userLevel.DeleteUserLevel();
                if (Result.isSuccessful)
                {
                    return Json(new
                    {
                        UserLevelList = JsonConvert.SerializeObject(userLevel.UserLevelList),
                        ResponseMessage = "Successfully delete the " + userLevel.UserTypeName + " User Type " + userLevel.UserLevelName + " User Level.",
                        success = true
                    });
                }
                else
                {
                    return Json(new
                    {
                        ResponseMessage = "Failed to delete the " + userLevel.UserTypeName + " User Type " + userLevel.UserLevelName + " User Level.",
                        success = false
                    });
                }
            }
            catch(Exception ex)
            {
                return Json(new
                {
                    ResponseMessage = "Failed to delete the " + userLevel.UserTypeName + " User Type " + userLevel.UserLevelName + " User Level. Please try again later.",
                    success = false
                });
            }
        }
    }
}