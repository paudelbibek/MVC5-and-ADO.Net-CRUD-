using MVC5_and_ADO.NET.Models;
using MVC5_and_ADO.NET.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace MVC5_and_ADO.NET.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeRepository ep = new EmployeeRepository();
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetAllEmployee()
        {
            return View(ep.GetAllEmployees());
        }

        public ActionResult EditEmployee(int id)
        {
            return View(ep.GetAllEmployees().Find(emp => emp.EmployerID == id));
        }

        [HttpPost]
        public ActionResult EditEmployee(int id, Employee obj)
        {
            ep.UpdateEmployee(obj);
            return RedirectToAction("GetAllEmployee");
        }




    }
}
