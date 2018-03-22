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
        DBContentContext db = new DBContentContext();

        // GET: DatabaseResults
        public ActionResult Index()
        {
            IEnumerable<DBContent> contents = db.DBContents;
            ViewBag.Content = contents;
            return View();
        }
    }
}