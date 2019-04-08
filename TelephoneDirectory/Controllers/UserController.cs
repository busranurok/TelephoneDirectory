using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TelephoneDirectory.Contexts;
using TelephoneDirectory.CustomException;
using TelephoneDirectory.Models;

namespace TelephoneDirectory.Controllers
{
    public class UserController : Controller
    {
        TelephoneDirectoryContext _context = new TelephoneDirectoryContext();
        // GET: User
        [HttpGet]
        public ActionResult Index(int id = 0)
        {
            var model = new UserViewModel();

            ViewBag.Departments = _context.Departments.ToList();
            ViewBag.Managers = _context.Users.ToList();

            if (id != 0)
            {
                var user = _context.Users.FirstOrDefault(u => u.UserId == id);
                model.User = user;
            }
            else
            {

            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Save(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (model.User.UserId != 0)
                    {
                        var user = _context.Users.FirstOrDefault(u => (u.UserId == model.User.UserId) && (u.DepartmentId == model.User.DepartmentId));
                        user.Name = model.User.Name;
                        user.Lastname = model.User.Lastname;
                        user.Username = model.User.Username;
                        user.PhoneNumber = model.User.PhoneNumber;
                        user.Password = model.User.Password;
                        user.DepartmentId = model.User.DepartmentId;
                    }

                    else
                    {
                        _context.Users.Add(model.User);
                    }

                    _context.SaveChanges();
                    return RedirectToAction(actionName: "List", controllerName: "User");
                }
                catch (Exception exception)
                {
                    ViewBag.Message = exception.Message;
                    return View();
                }
            }
            else
            {
                ViewBag.Message = "Model yanlış";
                return View();
            }
          
        }

        [HttpGet]
        public ActionResult List()
        {
            var list = _context.Users.ToList();
            ViewBag.IsCurrentUserAdmin = ((Entities.User)Session["CurrentUser"]).IsAdmin;
            return View(list);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            if (_context.Users.Any(x=> x.ManagerId==id))
            {
                return RedirectToAction("Index", "Error", new { errorHeader = "Silme işleminde hata!", errorMessage = "Silmek istediğiniz kullanıcı bir başka kullanıcının yöneticisidir." });
            }

            var user = _context.Users.FirstOrDefault(u => u.UserId == id);
            _context.Users.Remove(user);
            _context.SaveChanges();
            return RedirectToAction(actionName: "List", controllerName: "User");
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var model = new UserViewModel();
            var user = _context.Users.FirstOrDefault(u => u.UserId == id);
            model.User = user;
            ViewBag.IsCurrentUserAdmin = ((Entities.User)Session["CurrentUser"]).IsAdmin;
            return View(model);
        }
    }
}