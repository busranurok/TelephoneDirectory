using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TelephoneDirectory.Contexts;

namespace TelephoneDirectory.Controllers
{
    public class LoginController : Controller
    {
        TelephoneDirectoryContext _context = new TelephoneDirectoryContext();
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Logon(String userName, String password)
        {
            //var diye de tip tanımlanır
            Entities.User user = _context.Users.FirstOrDefault(u => u.Password == password && u.Username == userName);

            if (user !=null)
            {
                Session["CurrentUser"] = user;
                return RedirectToAction(actionName: "List", controllerName: "User");
            }

            else
            {
                ViewBag.Message = "Giriş Hatalı!";
                return View();
            }
            
        }
    }
}