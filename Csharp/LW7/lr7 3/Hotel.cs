using static lr_1_3.Form1;

public class Hotel
{
    public event Action<Room>? RoomAdded;
    public event Action<string>? StatusMessage;

    public SortedList<int, Room> Rooms { get; set; } = new SortedList<int, Room>();

    public string HotelName { get; set; }

    public Hotel(string name)
    {
        HotelName = name;
    }

    public void AddRoom(Room r)
    {
        int key = Rooms.Count == 0 ? 1 : Rooms.Keys.Max() + 1;

        Rooms.Add(key, r);

        RoomAdded?.Invoke(r);
        StatusMessage?.Invoke($"Додано кімнату з ключем {key}");
    }
}
