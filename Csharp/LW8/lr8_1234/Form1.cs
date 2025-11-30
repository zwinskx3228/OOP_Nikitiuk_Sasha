using ClassLibrary8.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Windows.Forms;
using ClassLibrary8.Extensions; 

using Lib = ClassLibrary8;

namespace lr_1_3
{
    public partial class Form1 : Form
    {
        // використовуємо клас Hotel з Lib.Models
        private Lib.Models.Hotel hotel = new Lib.Models.Hotel("Podillya");
        private Lib.Services.Logger logger = new Lib.Services.Logger();

        public Form1()
        {
            InitializeComponent();
            panel1.Hide();
            label28.Hide();

            hotel.RoomAdded += r => logger.Log($"Додано: {r.RoomType}, {r.Price} грн");
            hotel.StatusMessage += msg => logger.Log(msg);

            dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView2.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            AddColumns(dataGridView1);
            AddColumns(dataGridView2);
            AddColumns(dataGridView3);
        }


        private void AddColumns(DataGridView grid)
        {
            grid.Columns.Add("Type", "Type");
            grid.Columns.Add("Seats", "Seats");
            grid.Columns.Add("Area", "Area (m²)");
            grid.Columns.Add("Beds", "Beds");
            grid.Columns.Add("BedType", "Bed type");
            grid.Columns.Add("Furniture", "Furniture / Tech");
            grid.Columns.Add("WiFi", "Wi-Fi");
            grid.Columns.Add("Climate", "Climate");
            grid.Columns.Add("Food", "Food");
            grid.Columns.Add("Toilet", "Toilet");
            grid.Columns.Add("Price", "Price (₴)");
            grid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        // Заувага: тут тип List<Lib.Interfaces.Room> — бо Room знаходиться в Interfaces
        private void FillGrid(DataGridView grid, List<Lib.Interfaces.Room> rooms)
        {
            grid.Rows.Clear();
            foreach (var r in rooms)
            {
                grid.Rows.Add(
                    r.RoomType, r.Seats, r.Area, r.Beds, r.BedType,
                    r.Furniture, r.Wifi ? "Yes" : "No", r.Climate,
                    r.Food ? "Yes" : "No", r.Toilet, r.Price
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

                if (seats.IsEven())
                    MessageBox.Show("Нагадування: кількість місць парна!");
                area = area.RoundTo(1);
                bedType = bedType.Capitalize();
                // Ось ключове: тип змінної — Lib.Interfaces.Room (базовий тип у DLL)
                Lib.Interfaces.Room r;

                if (roomType == "Luxury")
                {
                    // LuxuryRoom знаходиться в ClassLibrary8.Hotel, але успадковує Interfaces.Room
                    r = new Lib.Hotel.LuxuryRoom(
                        seats, area, beds, bedType, furniture,
                        wifi, climate, food, toilet, price,
                        "SPA, Mini-bar", true);
                }
                else if (roomType == "Economy")
                {
                    r = new Lib.Hotel.EconomyRoom(
                        seats, area, beds, bedType, furniture,
                        wifi, climate, food, toilet, price,
                        true);
                }
                else
                {
                    // Стандартний Room — визначений у ClassLibrary8.Interfaces
                    r = new Lib.Interfaces.Room(
                        seats, area, beds, bedType, furniture,
                        wifi, climate, food, toilet, price);
                }

                r.RoomType = roomType;
                hotel.AddRoom(r);

                // додати в dataGridView1
                dataGridView1.Rows.Add(
                    r.RoomType, r.Seats, r.Area, r.Beds, r.BedType,
                    r.Furniture, r.Wifi ? "Yes" : "No", r.Climate,
                    r.Food ? "Yes" : "No", r.Toilet, r.Price
                );

                MessageBox.Show($"{roomType} room added!");
            }
            catch
            {
                MessageBox.Show("Check entered data!");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView2.Rows.Clear();

            if (!int.TryParse(textBox5.Text, out int seats))
            {
                MessageBox.Show("Введіть кількість місць!");
                return;
            }

            var filtered = hotel.Rooms
                .Where(x => x.Value.Seats == seats)
                .Select(x => x.Value)
                .ToList();

            if (filtered.Count == 0)
            {
                MessageBox.Show("Кімнати не знайдено!");
                return;
            }

            FillGrid(dataGridView2, filtered);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var sorted = hotel.Rooms.Values.OrderBy(r => r.Price).ToList();
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
            int key = hotel.Rooms.Keys.ElementAt(index);
            hotel.Rooms.Remove(key);
            dataGridView1.Rows.RemoveAt(index);
            MessageBox.Show("Кімнату видалено!");
        }

        private void label28_Click_1(object sender, EventArgs e)
        {
            panel1.Hide();
            label28.Hide();
        }

        private void вивестиToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            panel1.Show();
            label28.Show();
        }

        private void створитиToolStripMenuItem_Click_1(object sender, EventArgs e)
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

        private void зберегтиToolStripMenuItem_Click_1(object sender, EventArgs e)
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
    }
}