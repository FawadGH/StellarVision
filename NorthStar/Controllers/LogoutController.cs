using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NorthStar.Controllers
{
    public class LogoutController : Controller
    {
        // GET: Logout
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string id)
        {
            return RedirectToAction("Index", "Login", null);
        }
        [HttpGet]
        public ActionResult SessionExpired()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SessionExpired(string id)
        {
            return RedirectToAction("Index", "Login", null);
        }
    }
}