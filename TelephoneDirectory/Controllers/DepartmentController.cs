using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TelephoneDirectory.Contexts;
using TelephoneDirectory.Entities;
using TelephoneDirectory.Models;

namespace TelephoneDirectory.Controllers
{
    public class DepartmentController : Controller
    {
        TelephoneDirectoryContext _context = new TelephoneDirectoryContext();
        // GET: Department
        [HttpGet]
        public ActionResult Index(int id=0)
        {
            var model = new DepartmentViewModel();
            //Burayı newlememizin sebebi null gelmesin diyedir.index.cshmtl de value değerlerini girdiğimizden dolayı burada newlemez isek null gelir.o da hataya sebep olur
            if (id!=0)
            {
                var department = _context.Departments.FirstOrDefault(x => x.DepartmentId == id);
                model.Department = department;
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Save(DepartmentViewModel model)
        {
            if (model.Department.DepartmentId!=0)
            {
                var department = _context.Departments.FirstOrDefault(x => x.DepartmentId == model.Department.DepartmentId);
                department.DepartmentName = model.Department.DepartmentName;
                department.DepartmentDescription = model.Department.DepartmentDescription;
            }
            else
            {
                _context.Departments.Add(model.Department);
            }
           
            _context.SaveChanges();
            return RedirectToAction(actionName: "List",controllerName: "Department");
        }

        [HttpGet]
        public ActionResult List()
        {
            var list = _context.Departments.ToList();
            return View(list);
        }

        public ActionResult Delete(int id)
        {
            if (_context.Users.Any(x=> x.DepartmentId==id))
            {
                return RedirectToAction("Index", "Error", new { errorHeader = "Silme işleminde hata!", errorMessage = "Silmek istediğiniz departmanda çalışan kullanıcılar bulunmaktadır." });
            }

            var department = _context.Departments.FirstOrDefault(d=> d.DepartmentId == id);
            _context.Departments.Remove(department);
            _context.SaveChanges();
            return RedirectToAction(actionName:"List",controllerName:"Department");
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var model = new DepartmentViewModel();
            var department = _context.Departments.FirstOrDefault(d=> d.DepartmentId == id);
            model.Department = department;
            return View(model);
        }
    }
}