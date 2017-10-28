using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Napolina.Controllers
{
    public class BlueAlexaHomeController : Controller
    {
        [HttpGet,HttpPost]
        [Route(Name = "StoreToken")]
        public ActionResult Index()
        {
            return View();
        }
    }
}