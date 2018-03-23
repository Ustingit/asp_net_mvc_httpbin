using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class ConfigurationsController : Controller
    {
        ConfigurationsModel configurationsModel = ConfigurationsModel.Instance;

        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Duration = configurationsModel.ResponseDuration;
            return View();
        }

        [HttpPost]
        public void SetDuration(int duration)
        {
            configurationsModel.ResponseDuration = duration;
            Response.Redirect("/");
        }
    }
}