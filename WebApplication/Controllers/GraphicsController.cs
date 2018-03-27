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
            ViewBag.Content = contents;
            
            var delayedResponses = contents.Where(r => r.DelayedResponseTime != 0).Select(x => x.DelayedResponseTime);
            var length = delayedResponses.ToArray().Length;

            ViewBag.DelayedResponseTimes = delayedResponses.ToList();
            ViewBag.CommonResponseTimes = contents.Where(r => r.CommonResponseTime != 0).Select(x => x.CommonResponseTime).ToList();
            
            var ContentIds = new List<int>() { };
            for (var i = 0; i < length; i++){ ContentIds.Add(i); }
            ViewBag.ContentIds = ContentIds;
            
            return View();
        }
    }
}