using System.Collections.Generic;
using System.Web.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class DatabaseResultsController : Controller
    {
        DBContentContext db = new DBContentContext();

        public ActionResult Index()
        {
            IEnumerable<DBContent> contents = db.DBContents;
            ViewBag.Content = contents;
            return View();
        }
    }
}