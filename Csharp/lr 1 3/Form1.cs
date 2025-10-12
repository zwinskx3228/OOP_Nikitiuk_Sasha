using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace lr_1_3
{
    public partial class Form1 : Form
    {
        public class Room
        {
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
        }
        private List<Room> rooms = new List<Room>();
        public Form1()
        {
            InitializeComponent();
            panel1.Hide();
            label28.Hide();
            dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView2.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
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
                        dataGridView1.Rows.Add(cells);
                    }
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
    }
}