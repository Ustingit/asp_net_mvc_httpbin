﻿using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class GraphicsController : Controller
    {
        DBContentContext db = new DBContentContext();
        
        public ActionResult Index()
        {
            IEnumerable<DBContent> contents = db.DBContents;
            
            var delayedResponses = contents.Where(r => r.DelayedResponseTime != 0).Select(x => x.DelayedResponseTime);
            var commonResponses = contents.Where(r => r.CommonResponseTime != 0).Select(x => x.CommonResponseTime);
            ViewBag.DelayedResponseTimes = delayedResponses.ToList();
            ViewBag.CommonResponseTimes = commonResponses.ToList();

            var ContentIds = new List<int>() { };
            for (var i = 1; i <= delayedResponses.Count(); i++) { ContentIds.Add(i); }
            ViewBag.ContentIds = ContentIds;
            
            return View();
        }

        [HttpPost]
        public ActionResult AjaxChart()
        {
            IEnumerable<DBContent> contents = db.DBContents;

            var delayedResponses = contents.Where(r => r.DelayedResponseTime != 0)
                                           .Select(x => x.DelayedResponseTime);
            var commonResponses = contents.Where(r => r.CommonResponseTime != 0)
                                          .Select(x => x.CommonResponseTime);

            var ContentIds = new List<int>();
            for (var i = 1; i <= delayedResponses.Count(); i++)
            {
                ContentIds.Add(i);
            }

            var result = new
            {
                DelayedResponseTimes = delayedResponses.ToList(),
                CommonResponseTimes = commonResponses.ToList(),
                ContentIds = ContentIds
            };
            return Json(result);
        }

        public ActionResult AjaxPartial()
        {
            IEnumerable<DBContent> contents = db.DBContents;

            var delayedResponses = contents.Where(r => r.DelayedResponseTime != 0)
                                           .Select(x => x.DelayedResponseTime);
            var commonResponses = contents.Where(r => r.CommonResponseTime != 0)
                                          .Select(x => x.CommonResponseTime);

            var ContentIds = new List<int>();
            for (var i = 1; i <= delayedResponses.Count(); i++)
            {
                ContentIds.Add(i);
            }

            var result = new
            {
                DelayedResponseTimes = delayedResponses.ToList(),
                CommonResponseTimes = commonResponses.ToList(),
                ContentIds = ContentIds
            };
            return PartialView("AjaxChart", Json(result));
        }
    }
}