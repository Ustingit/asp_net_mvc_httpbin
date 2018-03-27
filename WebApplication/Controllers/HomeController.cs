using System.Web.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        ConfigurationsModel configurationsModel = ConfigurationsModel.Instance;
        DBContentContext db = DBContentContext.Instance;

        public ActionResult Index()
        {
            ViewBag.Duration = configurationsModel.ResponseDuration;
            return View();
        }

        [HttpGet]
        public void Start()
        {
            HomeModel homeModel = HomeModel.Instance;
            //Response.Redirect("/Graphics");
            homeModel.StartAppWorking(configurationsModel.ResponseDuration);
        }
    }
}