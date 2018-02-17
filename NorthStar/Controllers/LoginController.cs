using NorthStar.Models;
using PTSS.Application.SMSCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NorthStar.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            LoginModel loginModel = new LoginModel();
            return View(loginModel);
        }
        [HttpPost]
        public ActionResult Index(LoginModel loginModel)
        {
            string sFunctionName = "Index(POST)";
            NorthStarWebModel Web = new NorthStarWebModel();
            ResponseModel Result = new ResponseModel();
            try
            {
                Result = Web.ValidateUserLogin(loginModel.sLoginID, loginModel.sPassword);
                if (!Result.isSuccessful)
                {
                    return View(loginModel);
                }
                //Load User Permissions
                Result = Web.GetUserPermissions(SessionWrapper.CurrentUserModel);
                //Load User Permissions
                if (SessionWrapper.MainMenuItemModelList == null)
                {
                    Result = Web.LoadMainMenuItemsList(SessionWrapper.CurrentUserModel.UserPermissions);
                }
                if(SessionWrapper.ChildMenuItemModelList == null)
                {
                    Result = Web.LoadChildMenuItemsList(SessionWrapper.CurrentUserModel.UserPermissions);
                }
                if (!Result.isSuccessful)
                {
                    return View(loginModel);
                }

                return RedirectToAction("Index", "Home");
            }
            catch(Exception ex)
            {

                return RedirectToAction("Index", "Error");
            }
        }
    }
}