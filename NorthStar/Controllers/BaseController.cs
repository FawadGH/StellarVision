using PTSS.Application.SMSCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace NorthStar.Controllers
{
    public class BaseController : Controller
    {
        //// GET: Base
        //public ActionResult Index()
        //{
        //    return View();
        //}
        private string selectedController;
        private string selectedAction;
        private int previousSelectedModuleIndex;
        private int previousSelectedModuleFunctionIndex;
        public BaseController()
        {
            
            

            
        }

        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);
            //Session Handling
            if (SessionWrapper.CurrentUserModel == null)
            {
                requestContext.HttpContext.Response.Clear();
                requestContext.HttpContext.Response.Redirect(Url.Action("SessionExpired", "Logout"));
                requestContext.HttpContext.Response.End();
            }
            //Clear Previously selected menu item and save its position.
            int k;
            k = 0;
            foreach (MenuItemModel Module in SessionWrapper.MainMenuItemModelList)
            {
                if (Module.isSelected)
                {
                    previousSelectedModuleIndex = k;
                    Module.isSelected = false;
                }
                k++;
            }
            k = 0;
            foreach (MenuItemModel ModuleFunction in SessionWrapper.ChildMenuItemModelList)
            {
                if (ModuleFunction.isSelected)
                {
                    previousSelectedModuleFunctionIndex = k;
                    ModuleFunction.isSelected = false;
                }
                k++;
            }

            //Set currently selected controller and action. If not found then select the previously selected
            var SelectedController = requestContext.RouteData.Values["controller"];
            var SelectedAction = requestContext.RouteData.Values["action"];

            for (int i = 0; i < SessionWrapper.MainMenuItemModelList.Count; i++) 
            {
                if (SessionWrapper.MainMenuItemModelList[i].ModuleController == SelectedController.ToString())
                    SessionWrapper.MainMenuItemModelList[i].isSelected = true;
            }
            if (SessionWrapper.MainMenuItemModelList.FirstOrDefault(x => x.isSelected) == null)
                SessionWrapper.MainMenuItemModelList[previousSelectedModuleIndex].isSelected = true;
            for (int i = 0; i < SessionWrapper.ChildMenuItemModelList.Count; i++) 
            {
                if (SessionWrapper.ChildMenuItemModelList[i].ModuleFunctionController == SelectedController.ToString() && SessionWrapper.ChildMenuItemModelList[i].ModuleFunctionAction == SelectedAction.ToString())
                //if (SessionWrapper.ChildMenuItemModelList[i].ModuleFunctionController == SelectedController.ToString() && SelectedAction.ToString().Contains(SessionWrapper.ChildMenuItemModelList[i].ModuleFunctionAction))
                    SessionWrapper.ChildMenuItemModelList[i].isSelected = true;
            }
            if (SessionWrapper.ChildMenuItemModelList.FirstOrDefault(x => x.isSelected) == null)
                SessionWrapper.ChildMenuItemModelList[previousSelectedModuleFunctionIndex].isSelected = true;
        }
        //protected override void Execute(System.Web.Routing.RequestContext requestContext)
        //{
        //    selectedController = requestContext.RouteData.GetRequiredString("controller");
        //    selectedAction = requestContext.RouteData.GetRequiredString("action");
        //}
    }
}