using System.Globalization;
using System.Text.Json;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace lr_1_3
{
    public partial class Form1 : Form
    {
       //делегат
        public delegate int RoomSorter(Room a, Room b);
        //інтерфейси
        public interface IPriceable
        {
            int Price { get; }
        }

        public interface IComfort
        {
            bool Wifi { get; }
            bool Food { get; }
            string Climate { get; }
            string Toilet { get; }
        }

        public interface IRoomInfo
        {
            int Seats { get; }
            double Area { get; }
            int Beds { get; }
            string BedType { get; }
            string Furniture { get; }
            string RoomType { get; }
        }

        public class Room : IPriceable, IComfort, IRoomInfo
        {
            public int seats { get; set; }
            public double area { get; set; }
            public int beds { get; set; }
            public string bedType { get; set; }
            public string furniture { get; set; }
            public bool wifi { get; set; }
            public string climate { get; set; }
            public bool food { get; set; }
            public string toilet { get; set; }
            public int price { get; set; }
            public string RoomType { get; set; }

            // Інтерфейси
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

            public Room() { }

            public Room(int seats, double area, int beds, string bedType, string furniture, bool wifi, string climate, bool food, string toilet, int price)
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

            public static bool operator ==(Room a, Room b)
            {
                if (ReferenceEquals(a, b)) return true;
                if (ReferenceEquals(a, null) || ReferenceEquals(b, null)) return false;
                return a.seats == b.seats;
            }

            public static bool operator !=(Room a, Room b) => !(a == b);
            public static bool operator >(Room a, Room b) => a.price > b.price;
            public static bool operator <(Room a, Room b) => a.price < b.price;

            public override bool Equals(object obj) => obj is Room r && this == r;
            public override int GetHashCode() => seats.GetHashCode() ^ price.GetHashCode();
        }

        public class LuxuryRoom : Room
        {
            public string ExtraService { get; set; }
            public bool HasBalcony { get; set; }

            public LuxuryRoom() { } 

            public LuxuryRoom(int seats, double area, int beds, string bedType, string furniture, bool wifi,
                              string climate, bool food, string toilet, int price,
                              string extraService, bool hasBalcony)
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

                this.ExtraService = extraService;
                this.HasBalcony = hasBalcony;
                this.RoomType = "Luxury";
            }
        }


        public class EconomyRoom : Room
        {
            public bool SharedToilet { get; set; }

            public EconomyRoom() { }

            public EconomyRoom(int seats, double area, int beds, string bedType, string furniture, bool wifi,
                               string climate, bool food, string toilet, int price,
                               bool sharedToilet)
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

                this.SharedToilet = sharedToilet;
                this.RoomType = "Economy";
            }
        }
        // агрегація
        private Hotel hotel = new Hotel("Podillya");
        private Logger logger = new Logger();


        public Form1()
        {
            InitializeComponent();
            panel1.Hide();
            label28.Hide();
            // події
            hotel.RoomAdded += r => logger.Log($"Додано: {r.RoomType}, {r.price} грн");
            hotel.StatusMessage += msg => logger.Log(msg);



            dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView2.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView1.Columns.Add("Type", "Type");
            dataGridView1.Columns.Add("Seats", "Seats");
            dataGridView1.Columns.Add("Area", "Area (m²)");
            dataGridView1.Columns.Add("Beds", "Beds");
            dataGridView1.Columns.Add("BedType", "Bed type");
            dataGridView1.Columns.Add("Furniture", "Furniture / Tech");
            dataGridView1.Columns.Add("WiFi", "Wi-Fi");
            dataGridView1.Columns.Add("Climate", "Climate");
            dataGridView1.Columns.Add("Food", "Food");
            dataGridView1.Columns.Add("Toilet", "Toilet");
            dataGridView1.Columns.Add("Price", "Price (₴)");
            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                dataGridView2.Columns.Add((DataGridViewColumn)col.Clone());
            }
            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                dataGridView3.Columns.Add((DataGridViewColumn)col.Clone());
            }
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }
        private void FillGrid(DataGridView grid, List<Room> rooms)
        {
            grid.Rows.Clear();

            foreach (var r in rooms)
            {
                grid.Rows.Add(
                    r.RoomType,
                    r.seats,
                    r.area,
                    r.beds,
                    r.bedType,
                    r.furniture,
                    r.wifi ? "Yes" : "No",
                    r.climate,
                    r.food ? "Yes" : "No",
                    r.toilet,
                    r.price
                );
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int seats = int.Parse(textBox1.Text);
                double area = double.Parse(textBox2.Text);
                int beds = int.Parse(textBox3.Text);
                string bedType = comboBox1.Text;
                string furniture = string.Join("; ", checkedListBox1.CheckedItems.Cast<string>());
                string climate = string.Join("; ", checkedListBox2.CheckedItems.Cast<string>());
                bool wifi = checkBox1.Checked;
                bool food = checkBox2.Checked;
                string toilet = comboBox2.Text;
                int price = int.Parse(textBox4.Text);
                string roomType = comboBox3.Text;

                Room r;

                if (roomType == "Luxury")
                {
                    r = new LuxuryRoom(seats, area, beds, bedType, furniture, wifi, climate, food, toilet, price, "SPA, Mini-bar", true);
                }
                else if (roomType == "Economy")
                {
                    r = new EconomyRoom(seats, area, beds, bedType, furniture, wifi, climate, food, toilet, price, true);
                }
                else
                {
                    r = new Room(seats, area, beds, bedType, furniture, wifi, climate, food, toilet, price);
                }
                r.RoomType = roomType;
                hotel.AddRoom(r);

                int v = dataGridView1.Rows.Add(
                    r.RoomType,
                    r.seats,
                    r.area,
                    r.beds,
                    r.bedType,
                    r.furniture,
                    r.wifi ? "Yes" : "No",
                    r.climate,
                    r.food ? "Yes" : "No",
                    r.toilet,
                    r.price
                );

                MessageBox.Show($"{roomType} room added!");
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                comboBox1.SelectedIndex = -1;
                comboBox2.SelectedIndex = -1;
                comboBox3.SelectedIndex = -1;
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    checkedListBox1.SetItemChecked(i, false);
                }
                for (int i = 0; i < checkedListBox2.Items.Count; i++)
                {
                    checkedListBox2.SetItemChecked(i, false);
                }
            }
            catch
            {
                MessageBox.Show("Check entered data!");
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void вивестиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Show();
            label28.Show();
        }

        private void label28_Click(object sender, EventArgs e)
        {
            panel1.Hide();
            label28.Hide();
        }

        private void зберегтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "JSON Files (*.json)|*.json";
            if (save.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string json = JsonSerializer.Serialize(hotel.Rooms,
                        new JsonSerializerOptions { WriteIndented = true });
                    File.WriteAllText(save.FileName, json);
                    MessageBox.Show("Файл успішно збережено!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Помилка при збереженні: " + ex.Message);
                }
            }
        }


        private void створитиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "JSON Files (*.json)|*.json|All Files (*.*)|*.*";


            if (open.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string json = File.ReadAllText(open.FileName);


                    hotel.Rooms = JsonSerializer.Deserialize<SortedList<int, Room>>(json)
                    ?? new SortedList<int, Room>();


                    dataGridView1.Rows.Clear();


                    foreach (var kv in hotel.Rooms)
                    {
                        var r = kv.Value;
                        dataGridView1.Rows.Add(r.RoomType, r.seats, r.area, r.beds, r.bedType, r.furniture,
                        r.wifi ? "Yes" : "No", r.climate, r.food ? "Yes" : "No", r.toilet, r.price);
                    }


                    MessageBox.Show("Файл успішно відкрито!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Помилка відкриття: " + ex.Message);
                }
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView2.Rows.Clear();

            if (string.IsNullOrWhiteSpace(textBox5.Text))
            {
                MessageBox.Show("Введіть кількість місць!");
                return;
            }

            int seats = int.Parse(textBox5.Text);


            var filteredRooms = hotel.Rooms
            .Where(x => x.Value.seats == seats)
            .Select(x => x.Value)
            .ToList();


            if (filteredRooms.Count == 0)
            {
                MessageBox.Show("Кімнати не знайдено!");
                return;
            }


            foreach (var r in filteredRooms)
            {
                dataGridView2.Rows.Add(r.RoomType, r.seats, r.area, r.beds, r.bedType, r.furniture,
                r.wifi ? "Yes" : "No", r.climate, r.food ? "Yes" : "No", r.toilet, r.price);
            }


            if (filteredRooms.Count >= 2)
            {
                if (filteredRooms[0] > filteredRooms[1]) MessageBox.Show("Перша дорожча");
                else if (filteredRooms[0] < filteredRooms[1]) MessageBox.Show("Перша дешевша");
                else MessageBox.Show("Однакові");
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private List<Room> SortRooms(List<Room> rooms, RoomSorter sorter)
        {
            List<Room> result = new List<Room>(rooms);

            for (int i = 0; i < result.Count - 1; i++)
            {
                for (int j = i + 1; j < result.Count; j++)
                {
                    if (sorter(result[i], result[j]) > 0)
                    {
                        var tmp = result[i];
                        result[i] = result[j];
                        result[j] = tmp;
                    }
                }
            }

            return result;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            List<Room> list = new List<Room>();


            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) continue;


                Room r = new Room()
                {
                    RoomType = row.Cells[0].Value?.ToString(),
                    seats = int.Parse(row.Cells[1].Value.ToString()),
                    area = double.Parse(row.Cells[2].Value.ToString()),
                    beds = int.Parse(row.Cells[3].Value.ToString()),
                    bedType = row.Cells[4].Value.ToString(),
                    furniture = row.Cells[5].Value.ToString(),
                    wifi = row.Cells[6].Value.ToString() == "Yes",
                    climate = row.Cells[7].Value.ToString(),
                    food = row.Cells[8].Value.ToString() == "Yes",
                    toilet = row.Cells[9].Value.ToString(),
                    price = int.Parse(row.Cells[10].Value.ToString())
                };


                list.Add(r);
            }


            RoomSorter sorter = (a, b) => a.price.CompareTo(b.price);
            List<Room> sorted = SortRooms(list, sorter);


            FillGrid(dataGridView3, sorted);
            MessageBox.Show("Відсортовано!");
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
          
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Виберіть рядок для видалення!");
                return;
            }

            int index = dataGridView1.SelectedRows[0].Index;

            if (index >= hotel.Rooms.Count)
            {
                MessageBox.Show("Помилка видалення!");
                return;
            }

            int key = hotel.Rooms.Keys[index];
            hotel.Rooms.Remove(key);
            dataGridView1.Rows.RemoveAt(index);

            MessageBox.Show("Кімнату видалено!");
        }
    }
    }
