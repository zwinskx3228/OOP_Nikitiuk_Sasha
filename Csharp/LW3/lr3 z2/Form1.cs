using System.Globalization;
using System.Text.Json;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace lr_1_3
{
    public partial class Form1 : Form
    {
        public class Room
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


            public Room(int seats, double area, int beds, string bedType, string furniture, bool wifi,
                        string climate, bool food, string toilet, int price, string roomType = "")
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
                this.RoomType = roomType;
            }
            public static bool operator ==(Room a, Room b)
            {
                if (ReferenceEquals(a, b)) return true;
                if (ReferenceEquals(a, null) || ReferenceEquals(b, null)) return false;
                return a.seats == b.seats;
            }

            public static bool operator !=(Room a, Room b)
            {
                return !(a == b);
            }

            public static bool operator >(Room a, Room b)
            {
                return a.price > b.price;
            }

            public static bool operator <(Room a, Room b)
            {
                return a.price < b.price;
            }
            public override bool Equals(object obj)
            {
                if (obj is Room r)
                    return this == r;
                return false;
            }

            public override int GetHashCode()
            {
                return seats.GetHashCode() ^ price.GetHashCode();
            }

        }
        public class LuxuryRoom : Room
        {
            public string ExtraService { get; set; }
            public bool HasBalcony { get; set; }

            public LuxuryRoom(int seats, double area, int beds, string bedType, string furniture, bool wifi,
                              string climate, bool food, string toilet, int price,
                              string extraService, bool hasBalcony)
                : base(seats, area, beds, bedType, furniture, wifi, climate, food, toilet, price)
            {
                ExtraService = extraService;
                HasBalcony = hasBalcony;
            }

            public override string ToString()
            {
                return base.ToString() + $" | Extra: {ExtraService}, Balcony: {(HasBalcony ? "Yes" : "No")}";
            }
        }

        public class EconomyRoom : Room
        {
            public bool SharedToilet { get; set; }

            public EconomyRoom(int seats, double area, int beds, string bedType, string furniture, bool wifi,
                               string climate, bool food, string toilet, int price,
                               bool sharedToilet)
                : base(seats, area, beds, bedType, furniture, wifi, climate, food, toilet, price)
            {
                SharedToilet = sharedToilet;
            }

            public override string ToString()
            {
                return base.ToString() + $" | Shared Toilet: {(SharedToilet ? "Yes" : "No")}";
            }
        }
        private List<Room> rooms = new List<Room>();
        public Form1()
        {
            InitializeComponent();
            panel1.Hide();
            label28.Hide();
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

            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
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
                rooms.Add(r);

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
            save.Title = "Зберегти таблицю";

            if (save.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Зберігаємо список кімнат у JSON форматі
                    string json = JsonSerializer.Serialize(rooms, new JsonSerializerOptions { WriteIndented = true });
                    File.WriteAllText(save.FileName, json);

                    MessageBox.Show("Файл успішно збережено!", "Збереження", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            open.Title = "Відкрити таблицю";

            if (open.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string json = File.ReadAllText(open.FileName);
                    List<Room>? loadedRooms = JsonSerializer.Deserialize<List<Room>>(json);

                    if (loadedRooms == null || loadedRooms.Count == 0)
                    {
                        MessageBox.Show("Файл порожній або некоректний!");
                        return;
                    }

                    rooms = loadedRooms;
                    dataGridView1.Rows.Clear();

                    foreach (var r in rooms)
                    {
                        dataGridView1.Rows.Add(
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

                    MessageBox.Show("Файл успішно відкрито!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Помилка при відкритті: " + ex.Message);
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

            if (rooms.Count == 0)
            {
                MessageBox.Show("Немає даних!");
                return;
            }

            int seats = int.Parse(textBox5.Text);
            var filteredRooms = rooms.Where(r => r.seats == seats).ToList();

            if (filteredRooms.Count == 0)
            {
                MessageBox.Show("Кімнати з такою кількістю місць не знайдено!");
                return;
            }

            foreach (var r in filteredRooms)
            {
                dataGridView2.Rows.Add(
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

            if (filteredRooms.Count >= 2)
            {
                if (filteredRooms[0] > filteredRooms[1])
                    MessageBox.Show("Перша кімната дорожча за другу!");
                else if (filteredRooms[0] < filteredRooms[1])
                    MessageBox.Show("Перша кімната дешевша за другу!");
                else
                    MessageBox.Show("Ціни кімнат однакові!");
            }
            else
            {
                MessageBox.Show("Знайдено лише одну кімнату!");
            }
        }


        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}