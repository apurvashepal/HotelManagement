using HotelManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelManagement.Controllers
{
    public class RoomController : Controller
    {
       //
        static List<Roommodel> Roomdetails = new List<Roommodel>();
        // GET: /Default1/

        public ActionResult Index(Roommodel rm)
        {
            TempData["Roomdetails"] = Roomdetails;

            return View();
        }

        //
        // GET: /Default1/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Default1/Create

        public ActionResult Create()
        {
          
            return View();
        }

        //
        // POST: /Default1/Create

       

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                Roommodel rm=new Roommodel();

               rm.RoomType  = collection["RoomType"];

               rm.num_rooms = Convert.ToInt32(collection["num_rooms"]);
               rm.price= Convert.ToInt32(collection["price"]);
               rm.quantity = Convert.ToInt32(collection["quantity"]);
               Roomdetails.Add(rm);
               
                return View();
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Default1/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Default1/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Default1/Delete/5

        public ActionResult Delete(string RoomType)
        {

             foreach (var item in TempData["Roomdetails"] as IList<HotelManagement.Models.Roommodel>)
            {
            
            }
            return View();
        }

        //
        // POST: /Default1/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
      /*  private int Calculateprice(String Roomtype, int quantity)
        {
            if (RoomType == "Standard")
            { return 2000 * quantity; }
            if (RoomType == "Premium")
            { return 3000 * quantity; }
            if (RoomType == "Delux")
            { return 4000 * quantity; }
        }



        private int Numberroom (String Roomtype)
        {
            if (RoomType == "Standard")
            { return 10; }
            if (RoomType == "Premium")
            { return 15; }
            if (RoomType == "Delux")
            { return 5; }
        }*/



        
    }
