using System;
using System.Collections.Generic;
using System.Linq;
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

            var delayedResponses = contents.ToList();
            ViewBag.DR = delayedResponses;
           
            return View(delayedResponses);
        }

        public ActionResult MasterDetailsAjaxHandler()
        {
            IEnumerable<DBContent> contents = db.DBContents;
            var delayedResponses = contents.Where(r => r.DelayedResponseTime != 0).ToList();
            return Json(new
            {
                iTotalRecords = delayedResponses.Count,
                aaData = delayedResponses
            },
            JsonRequestBehavior.AllowGet);
        }
        /*
        public ActionResult AjaxDatabaseResultTable()
        {
            IEnumerable<DBContent> contents = db.DBContents;
            Dictionary<string, List<DBContent>> dict = new Dictionary<string, List<DBContent>>()
            {
                contents.Where(r => r.DelayedResponseTime != 0).ToList(),
                contents.Where(r => r.CommonResponseTime != 0).ToList()
            };
            return PartialView(delayedResponses);
        }*/

        public ActionResult AjaxDatabaseResultTableDelayed()
        {
            IEnumerable<DBContent> contents = db.DBContents;
            var delayedResponses = contents.Where(r => r.DelayedResponseTime != 0).ToList();
            return PartialView("AjaxDatabaseResultTable", delayedResponses);
        }

        public ActionResult AjaxDatabaseResultTableCommon()
        {
            IEnumerable<DBContent> contents = db.DBContents;
            var commonResponses = contents.Where(r => r.CommonResponseTime != 0).ToList();
            return PartialView("AjaxDatabaseResultTable", commonResponses);
        }
    }
}