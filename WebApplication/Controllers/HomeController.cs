using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        DBContentContext db = new DBContentContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DBResults()
        {
            IEnumerable<DBContent> contents = db.DBContents;
            ViewBag.Content = contents;
            return View();
        }

        [HttpPost]
        public string Start()
        {
            return "Спасибо за покупку!";
        }
    }
}