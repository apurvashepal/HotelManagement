using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotelM1.Models;

namespace HotelM1.Controllers
{
    public class CheckinController : Controller
    {
        //
        // GET: /Checkin/
        static List<Checkinmodel> Guestdetails = new List<Checkinmodel>();
        static int st_room = 15;
        static int pr_room = 10;
        static int De_room = 5;
        

        public ActionResult checkin(FormCollection form)
        {
            Checkinmodel cm = new Checkinmodel();
            RoomModel rm = new RoomModel();
            cm.GuestName = form["Guestname"];
            cm.contact = Convert.ToInt32(form["contact"]);
            cm.address = form["address"];
            cm.RoomType = form ["RoomType"];
            cm.quantity = Convert.ToInt32(form["quantity"]);
            cm.Total_days = Convert.ToInt32(form["Total_days"]);
            int st_room = rm.NumRoomsST;
               int pr_room = rm.NumRoomsPR;
                int De_room = rm.NumRoomsDE;
           
            if (cm.RoomType == "Standard" && cm.quantity < st_room)
            {
                st_room = st_room - cm.quantity;
                cm.price = cm.quantity * 1000;

            }
            else
                Response.Write("Rooms quantity not available") ;
                 
 
            if (cm.RoomType == "Premium" && cm.quantity < pr_room)
            {
                pr_room = pr_room - cm.quantity;
                cm.price = cm.quantity * 2000;  }
            else
                Response.Write("Rooms quantity not available");

            if (cm.RoomType == "Delux" && cm.quantity < De_room)
            {
                De_room = De_room - cm.quantity;
                cm.price = cm.quantity * 1000;
            }
            else
            {
                Response.Write("Rooms quantity not available");
              
            }

            Guestdetails.Add(cm);

            return View();
        }


        public ActionResult Viewchekin(Checkinmodel cm)
        {
            TempData["Guestdetails"] = Guestdetails;
            return View();
        }

        public ActionResult checkout(Checkinmodel cm)
        {
            TempData["guestdetails"] = Guestdetails;
            Guestdetails.Remove(cm);
            return View();
           
        }
    }
}
