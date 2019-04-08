using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TelephoneDirectory.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult Index(string errorHeader,string errorMessage)
        {
            ViewBag.ErrorHeader = errorHeader;
            ViewBag.ErrorMessage = errorMessage;
            return View();
        }
    }
}