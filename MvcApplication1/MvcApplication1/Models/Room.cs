using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication1.Models
{
    public class Room
    {

        public int ID { get; set; }

        public string RoomType { get; set; }
        public int  No_of_Rooms{ get; set; }
        public int  price{ get; set; }
        public int  Quantity{ get; set; }
       

    }
}