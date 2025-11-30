using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary8.Interfaces;

namespace ClassLibrary8.Hotel
{
    public class LuxuryRoom : Room
    {
        public string ExtraService { get; set; }
        public bool HasBalcony { get; set; }

        public LuxuryRoom() { }

        public LuxuryRoom(int seats, double area, int beds, string bedType, string furniture,
                          bool wifi, string climate, bool food, string toilet, int price,
                          string extraService, bool hasBalcony)
            : base(seats, area, beds, bedType, furniture, wifi, climate, food, toilet, price)
        {
            ExtraService = extraService;
            HasBalcony = hasBalcony;
            RoomType = "Luxury";
        }
    }
}