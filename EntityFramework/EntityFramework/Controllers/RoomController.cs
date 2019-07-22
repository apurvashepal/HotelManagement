using EntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EntityFramework.Controllers
{
    public class RoomController : Controller
    {
        //
        static List<RoomDetail> RD = new List<RoomDetail>();
        public RoomDetail db = new RoomDetail();
        public RoomEntities RE = new RoomEntities();
        // GET: /Room/

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateRoom(FormCollection form)
        {
            RoomDetail rm = new RoomDetail();
  
            rm.RoomType = form["RoomType"];
            rm.R_Id = Convert.ToInt32(form["R_id"]);
            if (rm.RoomType == "Standard")
            {
               rm.NumRoomsST = rm.NumRoomsST + 1;
            }
            else if (rm.RoomType == "Premium")
            { 
             rm.NumRoomsPR = rm.NumRoomsPR + 1; }
    else if (rm.RoomType == "Delux")
            {  
              rm.NumRoomsDE = rm.NumRoomsDE + 1; }



            if (ModelState.IsValid)
            {
                RE.RoomDetails.Add(rm);
                
             
               
                return RedirectToAction("Index");
            }
            
           
            Console.Write("Success");
            return View();


        }


        public ActionResult Viewdetails(RoomDetail Rd)
        {
            TempData["Roomdetails"] = RD;
            return View();
        }


    }
}
