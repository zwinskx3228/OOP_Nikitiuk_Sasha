using lr9_3;
using System;
using System.Windows.Forms;

namespace lr9_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            game1.OnFinished += GameFinished;
        }

        private void GameFinished(string winner)
        {
            // тут буде викликано після await Task.Delay(...) в Game
            MessageBox.Show(this, $"Переможець: {winner}", "Гра", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            game1.Restart();
        }
    }
}