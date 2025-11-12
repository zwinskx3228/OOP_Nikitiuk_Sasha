using System.Globalization;
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

            public Room(int seats, double area, int beds, string bedType, string furniture, bool wifi,
                        string climate, bool food, string toilet, int price)
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
        private List<Room> rooms = new List<Room>();
        public Form1()
        {
            InitializeComponent();
            panel1.Hide();
            label28.Hide();
            dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView2.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
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

                Room r = new Room(seats, area, beds, bedType, furniture, wifi, climate, food, toilet, price);
                rooms.Add(r);

                int v = dataGridView1.Rows.Add(
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

                MessageBox.Show("Room added!");
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                comboBox1.SelectedIndex = -1;
                comboBox2.SelectedIndex = -1;
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
            save.Filter = "CSV files (*.csv)|*.csv";
            save.Title = "Save table";

            if (save.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(save.FileName))
                {
                    for (int i = 0; i < dataGridView1.Columns.Count; i++)
                    {
                        sw.Write(dataGridView1.Columns[i].HeaderText);
                        if (i < dataGridView1.Columns.Count - 1)
                            sw.Write(";");
                    }
                    sw.WriteLine();

                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            for (int i = 0; i < row.Cells.Count; i++)
                            {
                                object value = row.Cells[i].Value;
                                string text = value == null ? "" : value.ToString().Trim();

                                if (double.TryParse(text.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out double dbl))
                                    text = dbl.ToString(CultureInfo.InvariantCulture);

                                if (text.Equals("True", StringComparison.OrdinalIgnoreCase))
                                    text = "Yes";
                                else if (text.Equals("False", StringComparison.OrdinalIgnoreCase))
                                    text = "No";

                                sw.Write(text);

                                if (i < row.Cells.Count - 1)
                                    sw.Write(";");
                            }
                            sw.WriteLine();
                        }
                    }
                }

                MessageBox.Show("Файл успішно збережено!", "Збереження", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void створитиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "CSV files (*.csv)|*.csv";
            open.Title = "Open table";

            if (open.ShowDialog() == DialogResult.OK)
            {
                rooms.Clear();
                dataGridView1.Rows.Clear();

                string[] lines = File.ReadAllLines(open.FileName);
                if (lines.Length == 0)
                {
                    MessageBox.Show("File is empty!");
                    return;
                }
                string[] headers = lines[0].Split(';');
                if (dataGridView1.Columns.Count == 0 || dataGridView1.Columns.Count != headers.Length)
                {
                    dataGridView1.Columns.Clear();
                    foreach (string h in headers)
                        dataGridView1.Columns.Add(h.Trim(), h.Trim());
                }

                for (int i = 1; i < lines.Length; i++)
                {
                    string[] cells = lines[i].Split(';');
                    if (cells.Length < headers.Length) continue;

                    try
                    {
                        int seats = int.TryParse(cells[0].Trim(), out var tmpSeats) ? tmpSeats : 0;
                        double area = double.TryParse(cells[1].Trim().Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out var tmpArea) ? tmpArea : 0;
                        int beds = int.TryParse(cells[2].Trim(), out var tmpBeds) ? tmpBeds : 0;
                        string bedType = cells[3].Trim();
                        string furniture = cells[4].Trim();
                        bool wifi = cells[5].Trim().ToLower() is "yes" or "є" or "true";
                        string climate = cells[6].Trim();
                        bool food = cells[7].Trim().ToLower() is "yes" or "є" or "true";
                        string toilet = cells[8].Trim();
                        int price = int.TryParse(cells[9].Trim().Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out var tmpPrice) ? tmpPrice : 0;

                        Room r = new Room(seats, area, beds, bedType, furniture, wifi, climate, food, toilet, price);
                        rooms.Add(r);

                        dataGridView1.Rows.Add(
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
                    catch
                    {
                     
                    }   
                } 
                MessageBox.Show("Файл відкрито успішно!");
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

            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Немає даних у таблиці!");
                return;
            }

            int seats = int.Parse(textBox5.Text);

            if (dataGridView2.Columns.Count == 0)
            {
                foreach (DataGridViewColumn col in dataGridView1.Columns)
                {
                    dataGridView2.Columns.Add((DataGridViewColumn)col.Clone());
                }
            }
            List<Room> filteredRooms = new List<Room>();

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (!row.IsNewRow && row.Cells[0].Value != null)
                {
                    if (int.TryParse(row.Cells[0].Value.ToString(), out int value) && value == seats)
                    {
                        int index = dataGridView2.Rows.Add();
                        for (int i = 0; i < row.Cells.Count; i++)
                        {
                            dataGridView2.Rows[index].Cells[i].Value = row.Cells[i].Value;
                        }

                        if (row.Cells[9].Value != null && int.TryParse(row.Cells[9].Value.ToString(), out int price))
                        {
                            Room r = new Room(
                                value,
                                double.TryParse(row.Cells[1].Value?.ToString().Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out var area) ? area : 0,
                                int.TryParse(row.Cells[2].Value?.ToString(), out var beds) ? beds : 0,
                                row.Cells[3].Value?.ToString(),
                                row.Cells[4].Value?.ToString(),
                                row.Cells[5].Value?.ToString().ToLower() == "yes",
                                row.Cells[6].Value?.ToString(),
                                row.Cells[7].Value?.ToString().ToLower() == "yes",
                                row.Cells[8].Value?.ToString(),
                                price
                            );
                            filteredRooms.Add(r);
                        }
                    }
                }
            }
            if (filteredRooms.Count < 2)
            {
                MessageBox.Show("Недостатньо кімнат для порівняння!");
                return;
            }
            if (filteredRooms[0] > filteredRooms[1])
                MessageBox.Show("Перша кімната дорожча за другу!");
            else if (filteredRooms[0] < filteredRooms[1])
                MessageBox.Show("Перша кімната дешевша за другу!");
            else
                MessageBox.Show("Ціни кімнат однакові!");
        }

    }
}