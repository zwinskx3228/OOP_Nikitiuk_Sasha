using static lr_1_3.Form1;

namespace lr_1_3
{
    public class Hotel
    {
        public string Name { get; set; }

        //АГРЕГАЦІЯ: Hotel МАЄ Room, але НЕ володіє ними
        public List<Room> Rooms { get; set; } = new List<Room>();

        public Hotel(string name)
        {
            Name = name;
        }

        public void AddRoom(Room room)
        {
            Rooms.Add(room);
        }

        public void RemoveRoom(Room room)
        {
            Rooms.Remove(room);
        }

        public List<Room> FindBySeats(int seats)
        {
            return Rooms.Where(r => r.seats == seats).ToList();
        }
    }
}
