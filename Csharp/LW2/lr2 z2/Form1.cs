using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace lr_1_3
{
    public partial class Form1 : Form
    {
        public class Room
        {
            private static int id = 1;
            public int ID { get; private set; }

            public int Місця { get; set; }
            public double Площа { get; set; }
            public int КількістьЛіжок { get; set; }
            public string ВидЛіжка { get; set; }
            public string Меблі { get; set; }
            public bool WiFi { get; set; }
            public string Клімат { get; set; }
            public bool Харчування { get; set; }
            public string Санвузол { get; set; }
            public decimal Ціна { get; set; }

            public Room(int місця, double площа, int ліжка, string видЛіжка,
                        string меблі, bool wifi, string клімат,
                        bool харчування, string санвузол, decimal ціна)
            {
                ID = id++;
                Місця = місця;
                Площа = площа;
                КількістьЛіжок = ліжка;
                ВидЛіжка = видЛіжка;
                Меблі = меблі;
                WiFi = wifi;
                Клімат = клімат;
                Харчування = харчування;
                Санвузол = санвузол;
                Ціна = ціна;
            }
            public static bool operator >(Room a, Room b)
            {
                return a.Ціна > b.Ціна;
            }

            public static bool operator <(Room a, Room b)
            {
                return a.Ціна < b.Ціна;
            }

            public static bool operator ==(Room a, Room b)
            {
                if (ReferenceEquals(a, b)) return true;
                if ((object)a == null || (object)b == null) return false;
                return a.Місця == b.Місця && a.Ціна == b.Ціна;
            }

            public static bool operator !=(Room a, Room b)
            {
                return !(a == b);
            }

            public static Room operator +(Room a, Room b)
            {
                return new Room(
                    a.Місця + b.Місця,
                    a.Площа + b.Площа,
                    a.КількістьЛіжок + b.КількістьЛіжок,
                    a.ВидЛіжка + " + " + b.ВидЛіжка,
                    a.Меблі + "; " + b.Меблі,
                    a.WiFi || b.WiFi,
                    a.Клімат + "; " + b.Клімат,
                    a.Харчування || b.Харчування,
                    a.Санвузол + " + " + b.Санвузол,
                    a.Ціна + b.Ціна
                );
            }

            public override bool Equals(object obj)
            {
                if (obj is Room room)
                    return this == room;
                return false;
            }

            public override int GetHashCode()
            {
                return (Місця, Ціна).GetHashCode();
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
            dataGridView1.Columns.Add("ID", "№ кімнати");
            dataGridView1.Columns.Add("Місця", "К-сть місць");
            dataGridView1.Columns.Add("Площа", "Площа (м²)");
            dataGridView1.Columns.Add("Ліжко", "К-сть ліжок");
            dataGridView1.Columns.Add("ВидЛіжка", "Вид ліжка");
            dataGridView1.Columns.Add("Меблі", "Меблі / Техніка");
            dataGridView1.Columns.Add("WiFi", "Wi-Fi");
            dataGridView1.Columns.Add("Клімат", "Клімат");
            dataGridView1.Columns.Add("Харчування", "Харчування");
            dataGridView1.Columns.Add("Санвузол", "Санвузол");

            DataGridViewTextBoxColumn priceColumn = new DataGridViewTextBoxColumn();
            priceColumn.Name = "Ціна";
            priceColumn.HeaderText = "Ціна (грн)";
            priceColumn.ValueType = typeof(decimal);
            priceColumn.SortMode = DataGridViewColumnSortMode.Automatic;
            dataGridView1.Columns.Add(priceColumn);

            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                DataGridViewColumn copyCol = (DataGridViewColumn)col.Clone();
                copyCol.SortMode = DataGridViewColumnSortMode.Automatic;
                dataGridView2.Columns.Add(copyCol);
            }
            dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView2.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }


        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int місця = int.Parse(textBox1.Text);
                double площа = double.Parse(textBox2.Text);
                int ліжка = int.Parse(textBox3.Text);
                string видЛіжка = comboBox1.Text;
                string меблі = string.Join("; ", checkedListBox1.CheckedItems.Cast<string>());
                string клімат = string.Join("; ", checkedListBox2.CheckedItems.Cast<string>());

                bool wifi = checkBox1.Checked;
                bool харчування = checkBox2.Checked;
                string санвузол = comboBox2.Text;
                decimal ціна = decimal.Parse(textBox4.Text);

                Room room = new Room(місця, площа, ліжка, видЛіжка, меблі, wifi, клімат, харчування, санвузол, ціна);
                rooms.Add(room);
                dataGridView1.Rows.Add(
                    room.Місця,
                    room.Площа,
                    room.КількістьЛіжок,
                    room.ВидЛіжка,
                    room.Меблі,
                    room.WiFi ? "Є" : "Немає",
                    room.Клімат,
                    room.Харчування ? "Є" : "Немає",
                    room.Санвузол,
                    room.Ціна
                );

                MessageBox.Show("Кімната додана!");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                comboBox1.SelectedIndex = -1;
                comboBox2.SelectedIndex = -1;
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
                MessageBox.Show("Перевірте правильність введених даних!");
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
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "CSV файли (*.csv)|*.csv|Всі файли (*.*)|*.*";
            saveFileDialog.Title = "Зберегти таблицю";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(saveFileDialog.FileName))
                {
                    for (int i = 0; i < dataGridView1.Columns.Count; i++)
                    {
                        sw.Write(dataGridView1.Columns[i].HeaderText);
                        if (i < dataGridView1.Columns.Count - 1) sw.Write(";");
                    }
                    sw.WriteLine();
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            for (int i = 0; i < row.Cells.Count; i++)
                            {
                                sw.Write(row.Cells[i].Value);
                                if (i < row.Cells.Count - 1) sw.Write(";");
                            }
                            sw.WriteLine();
                        }
                    }
                }
            }
        }

        private void створитиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV файли (*.csv)|*.csv|Всі файли (*.*)|*.*";
            openFileDialog.Title = "Відкрити таблицю";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();
                rooms.Clear(); // 🔹 очистити старий список

                string[] lines = File.ReadAllLines(openFileDialog.FileName);

                if (lines.Length > 0)
                {
                    string[] headers = lines[0].Split(';');
                    foreach (string header in headers)
                    {
                        dataGridView1.Columns.Add(header, header);
                    }

                    for (int i = 1; i < lines.Length; i++)
                    {
                        string[] cells = lines[i].Split(';');
                        if (cells.Length < 10) continue; // перевірка щоб не зламалось

                        // 🔹 Додати рядок у таблицю
                        dataGridView1.Rows.Add(cells);

                        try
                        {
                            // 🔹 Створюємо об’єкт Room на основі CSV-рядка
                            int місця = int.Parse(cells[1]);
                            double площа = double.Parse(cells[2]);
                            int ліжка = int.Parse(cells[3]);
                            string видЛіжка = cells[4];
                            string меблі = cells[5];
                            bool wifi = cells[6].Contains("Є");
                            string клімат = cells[7];
                            bool харчування = cells[8].Contains("Є");
                            string санвузол = cells[9];
                            decimal ціна = decimal.Parse(cells[10]);

                            Room room = new Room(місця, площа, ліжка, видЛіжка, меблі, wifi, клімат, харчування, санвузол, ціна);

                            // Якщо є стовпець ID — оновлюємо його вручну
                            if (cells[0].All(char.IsDigit))
                                typeof(Room).GetProperty("ID")?.SetValue(room, int.Parse(cells[0]));

                            rooms.Add(room);
                        }
                        catch
                        {
                            // Якщо якісь дані пошкоджені — просто пропускаємо рядок
                            continue;
                        }
                    }

                    // 🔹 Виправляємо лічильник ID (щоб далі рахувало правильно)
                    if (rooms.Count > 0)
                    {
                        int maxId = rooms.Max(r => r.ID);
                        typeof(Room).GetField("nextId", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static)
                                    ?.SetValue(null, maxId + 1);
                    }

                    MessageBox.Show("Таблицю завантажено. Кімнати зчитано у програму!");
                }
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView2.Rows.Clear();

            if (!int.TryParse(textBox5.Text, out int критерій))
            {
                MessageBox.Show("Введіть кількість місць для пошуку!");
                return;
            }

            foreach (Room room in rooms)
            {
                if (room.Місця == критерій)
                {
                    dataGridView2.Rows.Add(
                        room.Місця,
                        room.Площа,
                        room.КількістьЛіжок,
                        room.ВидЛіжка,
                        room.Меблі,
                        room.WiFi ? "Є" : "Немає",
                        room.Клімат,
                        room.Харчування,
                        room.Санвузол,
                        room.Ціна
                    );
                }
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textBox6.Text, out int num1) ||
        !int.TryParse(textBox7.Text, out int num2))
            {
                MessageBox.Show("Введіть правильні номери кімнат!");
                return;
            }

            // Індекси починаються з 0, а користувач бачить з 1
            num1--;
            num2--;

            if (num1 < 0 || num1 >= rooms.Count || num2 < 0 || num2 >= rooms.Count)
            {
                MessageBox.Show("Номери виходять за межі списку кімнат!");
                return;
            }

            if (num1 == num2)
            {
                MessageBox.Show("Оберіть різні кімнати для порівняння!");
                return;
            }

            Room r1 = rooms[num1];
            Room r2 = rooms[num2];

            string result;
            if (r1 > r2)
                result = $"Кімната {num1 + 1} дорожча ({r1.Ціна} грн > {r2.Ціна} грн)";
            else if (r1 < r2)
                result = $"Кімната {num2 + 1} дорожча ({r2.Ціна} грн > {r1.Ціна} грн)";
            else
                result = $"Кімнати {num1 + 1} і {num2 + 1} мають однакову ціну ({r1.Ціна} грн).";

            MessageBox.Show(result, "Результат порівняння");
        }
    }
}