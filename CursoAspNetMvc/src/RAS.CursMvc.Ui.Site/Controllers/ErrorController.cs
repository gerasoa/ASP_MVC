using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RAS.CursMvc.Ui.Site.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult Index(int? code)
        {
            return View("Error");
        }

        public ActionResult AccessDenied()
        {
            return View("AccessDenied");
        }

        public ActionResult NotFound()
        {
            return View("NotFound");
        }
    }
    
}