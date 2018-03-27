using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class GraphicsController : Controller
    {
        DBContentContext db = DBContentContext.Instance;

        // GET: Graphics
        public ActionResult Index()
        {
            IEnumerable<DBContent> contents = db.DBContents;
            
            var delayedResponses = contents.Where(r => r.DelayedResponseTime != 0).Select(x => x.DelayedResponseTime);
            var commonResponses = contents.Where(r => r.CommonResponseTime != 0).Select(x => x.CommonResponseTime);
            if (delayedResponses.Count() == 0)
            {
                var DefaultDoubleList = new List<double>() { 0 };
                ViewBag.DelayedResponseTimes = DefaultDoubleList;
            }
            else
            {
                ViewBag.DelayedResponseTimes = delayedResponses.ToList();
            }
            if (commonResponses.Count() == 0)
            {
                var DefaultDoubleList = new List<double>() { 0 };
                ViewBag.DelayedResponseTimes = DefaultDoubleList;
            }
            else
            {
                ViewBag.DelayedResponseTimes = commonResponses.ToList();
            }
            
            var ContentIds = new List<int>() { };
            if (delayedResponses.Count() == 0)
            {
                ContentIds.Add(0);
                ViewBag.ContentIds = ContentIds;
            }
            else
            {
                for (var i = 1; i <= delayedResponses.Count(); i++) { ContentIds.Add(i); }
                ViewBag.ContentIds = ContentIds;
            }
            
            return View();
        }
    }
}