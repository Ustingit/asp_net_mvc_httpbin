using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class DatabaseResultsController : Controller
    {
        DBContentContext db = DBContentContext.Instance;

        // GET: DatabaseResults
        public ActionResult Index()
        {
            IEnumerable<DBContent> contents = db.DBContents;
            ViewBag.Content = contents;
            return View();
        }
    }
}