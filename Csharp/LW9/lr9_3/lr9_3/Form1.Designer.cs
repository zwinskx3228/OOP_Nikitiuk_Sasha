using lr9_3;

namespace lr9_3
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private Game game1;
        private Button btnStart;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            game1 = new Game();
            btnStart = new Button();
            SuspendLayout();
            // 
            // game1
            // 
            game1.BackColor = Color.White;
            game1.Location = new Point(10, 10);
            game1.Name = "game1";
            game1.Size = new Size(300, 300);
            game1.TabIndex = 1;
            // 
            // btnStart
            // 
            btnStart.Location = new Point(10, 320);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(75, 23);
            btnStart.TabIndex = 0;
            btnStart.Text = "Reset";
            btnStart.Click += btnStart_Click;
            // 
            // Form1
            // 
            ClientSize = new Size(330, 360);
            Controls.Add(btnStart);
            Controls.Add(game1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }
    }
}