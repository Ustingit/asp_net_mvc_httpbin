using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        ConfigurationsModel configurationsModel = ConfigurationsModel.Instance;

        public ActionResult Index()
        {
            ViewBag.Duration = configurationsModel.ResponseDuration;
            return View();
        }

        [HttpGet]
        public void Start()
        {
            HomeModel homeModel = HomeModel.Instance;
            Response.Redirect("/Graphics");
            var w = homeModel.StartAppWorking(configurationsModel.ResponseDuration);
        }
    }
}