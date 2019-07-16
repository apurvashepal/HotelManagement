using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebService.Models;

namespace WebService.Controllers
{
    public class HomeController : Controller
    {

        public EmployeeEntities EmpObj = new EmployeeEntities();
        public EmployeeDet db = new EmployeeDet();
         List <EmployeeDet> emp = new List<EmployeeDet>();
        public ActionResult Index()
        {
         
            ViewBag.Title = "Home Page";

            return View();
        }

          public JsonResult GetEmployee()
        {
            return Json(emp,JsonRequestBehavior.AllowGet);
        }

        public JsonResult AddEmployee(EmployeeDet emp)
        {   
            
            return Json(emp, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetbyID(int ID)
        {
            var Employee = emp.Find(x => x.Id.Equals(ID));
            return Json(Employee, JsonRequestBehavior.AllowGet);
        }
      /*  public JsonResult Update(EmployeeDet emp)
        {
            return Json(db.Update(emp), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Delete(int ID)
        {
            return Json(db.Delete(ID), JsonRequestBehavior.AllowGet);
        }*/
    }

    }

