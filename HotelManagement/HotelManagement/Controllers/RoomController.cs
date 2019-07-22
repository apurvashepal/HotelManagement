using HotelManagement.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelManagement.Controllers
{
    public class RoomController : Controller
    {
        //
        // GET: /Room/
        public int Total_rooms;
        public ActionResult Index()
        {
            return View();
        }



        public EmployeeEntities db = new EmployeeEntities();


        public ActionResult Create(FormCollection form)
        {
            RoomDetail rm = new RoomDetail();

            rm.RoomType = form["RoomType"];
           // rm.R_Id = Convert.ToInt32(form["R_Id"]);


            if (rm.RoomType == "Standard")
            {
                rm.Price = 1000;

            }
            if (rm.RoomType == "Premium")
            {
                rm.Price = 2000;


            }
            if (rm.RoomType == "Delux")
            {
                rm.Price = 3000;


            }


            if (ModelState.IsValid)
            {


                try
                {
                    db.RoomDetails.Add(rm);
                    db.SaveChanges();
                }
                catch (DbEntityValidationException ex)
                {
                    foreach (DbEntityValidationResult item in ex.EntityValidationErrors)
                    {
                        // Get entry

                        DbEntityEntry entry = item.Entry;
                        string entityTypeName = entry.Entity.GetType().Name;

                        // Display or log error messages

                        foreach (DbValidationError subItem in item.ValidationErrors)
                        {
                            string message = "Error";
                            Console.WriteLine(message);
                        }
                    }
                }

            }
            Total_rooms = Total_rooms + 1;
            return View();


        }




        public ActionResult Viewdetails(RoomDetail rm)
        {
            EmployeeEntities EE = new EmployeeEntities();
            List<RoomDetail> RList = EE.RoomDetails.ToList();


            return View(RList);
        }

        public ActionResult delete(int Id)
        {
            RoomDetail rm = new RoomDetail();

            RoomDetail Rd = db.RoomDetails.Find(Id);
            db.RoomDetails.Remove(Rd);
            db.SaveChanges();

            RedirectToAction("ViewDetails");
            Total_rooms = Total_rooms - 1;
            return View();
        }

        public ActionResult Edit(int Id)
        {

            return View();
        }


        [HttpPost]

        public ActionResult Edit(int Id, FormCollection form1)
        {
            try
            {
                RoomDetail rm = new RoomDetail();
                RoomDetail Rd = db.RoomDetails.Single(s => s.R_Id == Id);
                Rd.RoomType = form1["RoomType"];

                if (rm.RoomType == "Standard")
                {
                    rm.Price = 1000;

                }
                if (rm.RoomType == "Premium")
                {
                    rm.Price = 2000;


                }
                if (rm.RoomType == "Delux")
                {
                    rm.Price = 3000;

                }


                return RedirectToAction("Viewdetails");
            }
            catch
            {
                return View();
            }
        }







    }
}
