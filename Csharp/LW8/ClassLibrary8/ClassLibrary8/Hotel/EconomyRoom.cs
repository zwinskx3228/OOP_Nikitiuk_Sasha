using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary8.Interfaces;

namespace ClassLibrary8.Hotel
{
    public class EconomyRoom : Room
    {
        public bool SharedToilet { get; set; }

        public EconomyRoom() { }

        public EconomyRoom(int seats, double area, int beds, string bedType, string furniture,
                           bool wifi, string climate, bool food, string toilet, int price,
                           bool sharedToilet)
            : base(seats, area, beds, bedType, furniture, wifi, climate, food, toilet, price)
        {
            SharedToilet = sharedToilet;
            RoomType = "Economy";
        }
    }
}
