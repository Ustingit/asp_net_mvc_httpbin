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

        // GET: Configurations
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Duration = configurationsModel.ResponseDuration;
            return View();
        }

        [HttpPost]
        public string SetDuration(int duration)
        {
            configurationsModel.ResponseDuration = duration;
            return $"Вы установили длительность в: {configurationsModel.ResponseDuration} секунд.";
        }
    }
}