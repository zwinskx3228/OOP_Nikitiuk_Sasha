// ClassLibrary8/Interfaces/Room.cs
using System;

namespace ClassLibrary8.Interfaces
{
    // partial-клас — основний вміст (властивості, конструктори, оператори)
    public partial class Room : IPriceable, IComfort, IRoomInfo
    {
        // Властивості
        public int seats { get; set; }
        public double area { get; set; }
        public int beds { get; set; }
        public string bedType { get; set; }
        public string furniture { get; set; }
        public bool wifi { get; set; }
        public string climate { get; set; }
        public bool food { get; set; }
        public string toilet { get; set; }

        private int _price;
        public int price
        {
            get => _price;
            set
            {
                _price = value;
                // виклик partial-методу
                OnPriceChanged();
            }
        }

        public string RoomType { get; set; }

        // Інтерфейсні реалізації (гетери)
        public int Price => price;
        public bool Wifi => wifi;
        public bool Food => food;
        public string Climate => climate;
        public string Toilet => toilet;

        public int Seats => seats;
        public double Area => area;
        public int Beds => beds;
        public string BedType => bedType;
        public string Furniture => furniture;

        // Конструктори
        public Room() { }

        public Room(int seats, double area, int beds, string bedType,
                    string furniture, bool wifi, string climate,
                    bool food, string toilet, int price)
        {
            this.seats = seats;
            this.area = area;
            this.beds = beds;
            this.bedType = bedType;
            this.furniture = furniture;
            this.wifi = wifi;
            this.climate = climate;
            this.food = food;
            this.toilet = toilet;
            this.price = price;
            this.RoomType = "Standard";
        }

        // Оператори та Equals/GetHashCode
        public static bool operator ==(Room a, Room b)
        {
            if (ReferenceEquals(a, b)) return true;
            if (a is null || b is null) return false;
            return a.seats == b.seats;
        }

        public static bool operator !=(Room a, Room b) => !(a == b);

        public static bool operator >(Room a, Room b) => a.price > b.price;
        public static bool operator <(Room a, Room b) => a.price < b.price;

        public override bool Equals(object obj) =>
            obj is Room r && this == r;

        public override int GetHashCode() =>
            seats.GetHashCode() ^ price.GetHashCode();

        // Оголошення partial-методу (тільки оголошення тут)
        partial void OnPriceChanged();
    }
}