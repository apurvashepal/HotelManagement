using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelManagement.Models
{
    public class Roommodel
    {

        public int id { get; set;}


        public int num_rooms
        {
            get;
            set;
        }
        public int price
        {
            get;
            set;
        }
        public int quantity
        {
            get;
            set;
        }
        public string RoomType { get; set; }

     /*    private int Calculateprice
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
        }

        */


       
       



    } 
}