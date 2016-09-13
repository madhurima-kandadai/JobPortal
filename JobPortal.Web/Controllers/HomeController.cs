using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobPortal.Services.Services;

namespace JobPortal.Web.Controllers
{
    public class HomeController : Controller
    {
        LoginService service;
        public HomeController(LoginService loginService)
        {
            this.service = loginService;
            service.GetUsers();
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            if (Request.RequestContext.HttpContext.User.Identity.IsAuthenticated)
            {
                ViewBag.Message = "Your Jobs Page page.";

                return View();
            }
            else
            {
                ViewBag.Message = "Please login to continue";
                return View("../Account/Login");
            }
        }

        public ActionResult Contact()
        {
            if (Request.RequestContext.HttpContext.User.Identity.IsAuthenticated)
            {
                ViewBag.Message = "Your Job Submissions page.";

                return View();
            }
            else
            {
                ViewBag.Message = "Please login to continue";
                return View("../Account/Login");
            }
        }
    }
}