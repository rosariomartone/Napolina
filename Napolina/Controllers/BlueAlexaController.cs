using System.Web.Mvc;

namespace Napolina.Controllers
{
    public class BlueAlexaController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Blue Alexa Home Page";

            return View();
        }
    }
}
