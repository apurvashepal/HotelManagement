using MvcApplication1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication1.Controllers
{
    public class RoomController : Controller
    {
        Room R1= new Room();
       // [HttpPost]
        public ActionResult RoomBook()
        {
           
             return View();  
        } 
        // GET: /Room/

    /*    public ActionResult Index()
        {
            return View();
        }
        */
    }
}
