using static lr_1_3.Form1;

namespace lr_1_3
{
    public class Hotel
    {
        public string Name { get; set; }
        public List<Form1.Room> Rooms { get; set; } = new();

        // Делегати / Events
        public event Action<Form1.Room>? RoomAdded;
        public event Action<Form1.Room>? RoomUpdated;
        public event Action<Form1.Room>? RoomDeleted;
        public event Action<string>? StatusMessage;

        public Hotel(string name)
        {
            Name = name;
        }

        public void AddRoom(Form1.Room room)
        {
            Rooms.Add(room);
            RoomAdded?.Invoke(room);
            StatusMessage?.Invoke($"Додано кімнату: {room.RoomType}, {room.price} грн");
        }

        public void RemoveRoom(Form1.Room room)
        {
            Rooms.Remove(room);
            RoomDeleted?.Invoke(room);
            StatusMessage?.Invoke($"Видалено: {room.RoomType}");
        }

        // Сортування за допомогою Comparison<T>
        public List<Form1.Room> SortByPrice()
        {
            List<Form1.Room> sorted = Rooms.OrderBy(r => r.price).ToList();
            StatusMessage?.Invoke("Виконано сортування за ціною");
            return sorted;
        }
    }
}
