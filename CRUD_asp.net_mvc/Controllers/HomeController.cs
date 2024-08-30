using CRUD_asp.net_mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD_asp.net_mvc.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            EmployeeDBContext db=new EmployeeDBContext();
            List<Employee> obj=db.GetEmployees();
            return View(obj);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Employee emp) {
            try
            {
                if (ModelState.IsValid == true) {
                    EmployeeDBContext db=new EmployeeDBContext();
                    Boolean check=db.AddEmployee(emp);
                    if (check == true) {
                        TempData["InsertMessage"]= "New Employee added successfully";
                        ModelState.Clear();
                        return RedirectToAction("Index");
                    }
                }
            }
            catch (Exception ex) { 
                Response.Write(ex.Message);
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            EmployeeDBContext db = new EmployeeDBContext();
            var row = db.GetEmployees().Find(model=>model.id==id);
            return View();
        }
        [HttpPost]
        public ActionResult Edit(int id, Employee emp) {
                if (ModelState.IsValid == true) {
                    EmployeeDBContext db = new EmployeeDBContext();
                    bool check = db.UpdateEmployee(emp);
                    if (check == true) {
                        TempData["UpdateMessage"] = "Data updated successfully";
                        ModelState.Clear();
                        return RedirectToAction("Index");
                    }
                }
            return View();
        }

        public ActionResult Details(int id)
        {
            EmployeeDBContext db = new EmployeeDBContext();
            var row = db.GetEmployees().Find(model => model.id == id);
            return View(row);
        }

        public ActionResult Delete(int id)
        {
            EmployeeDBContext db = new EmployeeDBContext();
            var row = db.GetEmployees().Find(model=>model.id==id);
            return View(row );
        }

        [HttpPost]
        public ActionResult Delete(int id,Employee emp)
        {
            EmployeeDBContext db=new EmployeeDBContext();
            bool check = db.DeleteEmployee(id);
            if (check == true)
            {
                TempData["DeleteMessage"] = "Data has been deleted.";
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}