using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotelM1.Models;


namespace HotelM1.Models
{
    public class RoomController : Controller
    {
        //
        // GET: /Room/
        static List<RoomModel> Roomdetails = new List<RoomModel>();

        public ActionResult Details(int id)
        {

            return View();
        }




      /* [HttpPost]
        public ActionResult Create()
        {
            try
            {
                RoomModel rm = new RoomModel();

                rm.RoomType = collection["RoomType"];

                rm.NumRooms = Convert.ToInt32(collection["NumRooms"]);
               
                rm.Quantity = Convert.ToInt32(collection["Quantity"]);
                rm.Price = rm.Quantity * 1000;
                Roomdetails.Add(rm);

                return View();
            }
            catch
            {
                return View();
            }
        }*/
       [Authorize]

        public ActionResult Create(FormCollection form)
        {
            RoomModel rm = new RoomModel();

            rm.RoomType = form["RoomType"];
            rm.R_id = Convert.ToInt32(form["R_id"]);
           
            rm.Quantity = Convert.ToInt32(form["Quantity"]);
            if (rm.RoomType == "Standard")
            {
            rm.NumRoomsST = rm.NumRooms+1;
            }
            if (rm.RoomType == "Premium")
            { rm.NumRoomsPR = rm.NumRooms +1 ; }
            if (rm.RoomType == "Delux")
            { rm.NumRoomsDE = rm.NumRooms +1; }




            Roomdetails.Add(rm);


            return View();
          
            
        }

        
        public ActionResult Viewdetails(RoomModel rm)
        {
           TempData["Roomdetails"] = Roomdetails;
            return View();
        }

        public ActionResult delete(int Id)
        {
             
            Roomdetails.RemoveAt(Id);

            return View();
        }





  
        public ActionResult Edit(int Id)
        {
            
            return View();
        }
        //  
        // 
        [HttpPost]
        [Authorize]
        public ActionResult Edit(int Id, FormCollection form1)
        {
            try
            {
                 RoomModel rm1 = new RoomModel();
            RoomModel Rd = Roomdetails.Single(s => s.R_id == Id);
            Rd.RoomType = form1["RoomType"];
            Rd.Quantity = Convert.ToInt32(form1["Quantity"]);
            if (Rd.RoomType == "Standard")
                Rd.Price = Rd.Quantity * 1000;
            if (Rd.RoomType == "Premium")
                Rd.Price = Rd.Quantity * 2000;
            if (Rd.RoomType == "Delux")
                Rd.Price = Rd.Quantity * 1000;
            
                return RedirectToAction("Viewdetails");
            }
            catch
            {
                return View();
            }
        }  










    }
}
