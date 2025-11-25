namespace lr9_2
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            polotno1 = new Polotno();
            buttonColor = new Button();
            buttonClear = new Button();
            panel1 = new Panel();
            rbNone = new RadioButton();
            rbCenter = new RadioButton();
            rbBoth = new RadioButton();
            rbVert = new RadioButton();
            rbHoriz = new RadioButton();
            label1 = new Label();
            btnSave = new Button();
            btnLoad = new Button();
            btnImage = new Button();
            colorDialog1 = new ColorDialog();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // polotno1
            // 
            polotno1.ActiveColor = Color.Black;
            polotno1.BackColor = Color.White;
            polotno1.IsFillMode = false;
            polotno1.Location = new Point(12, 12);
            polotno1.Name = "polotno1";
            polotno1.Size = new Size(620, 426);
            polotno1.symm = 0;
            polotno1.TabIndex = 0;
            // 
            // buttonColor
            // 
            buttonColor.Location = new Point(685, 21);
            buttonColor.Name = "buttonColor";
            buttonColor.Size = new Size(90, 23);
            buttonColor.TabIndex = 1;
            buttonColor.Text = "Колір";
            buttonColor.UseVisualStyleBackColor = true;
            buttonColor.Click += buttonColor_Click;
            // 
            // buttonClear
            // 
            buttonClear.Location = new Point(687, 436);
            buttonClear.Name = "buttonClear";
            buttonClear.Size = new Size(90, 23);
            buttonClear.TabIndex = 2;
            buttonClear.Text = "Очистити";
            buttonClear.Click += buttonClear_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(rbNone);
            panel1.Controls.Add(rbCenter);
            panel1.Controls.Add(rbBoth);
            panel1.Controls.Add(rbVert);
            panel1.Controls.Add(rbHoriz);
            panel1.Location = new Point(665, 100);
            panel1.Name = "panel1";
            panel1.Size = new Size(128, 196);
            panel1.TabIndex = 5;
            // 
            // rbNone
            // 
            rbNone.Location = new Point(3, 141);
            rbNone.Name = "rbNone";
            rbNone.Size = new Size(104, 24);
            rbNone.TabIndex = 2;
            rbNone.Text = "Без симетрії";
            rbNone.CheckedChanged += rbNone_CheckedChanged;
            // 
            // rbCenter
            // 
            rbCenter.Location = new Point(6, 111);
            rbCenter.Name = "rbCenter";
            rbCenter.Size = new Size(104, 24);
            rbCenter.TabIndex = 3;
            rbCenter.Text = "Центральна";
            rbCenter.CheckedChanged += rbCenter_CheckedChanged;
            // 
            // rbBoth
            // 
            rbBoth.Location = new Point(6, 78);
            rbBoth.Name = "rbBoth";
            rbBoth.Size = new Size(104, 24);
            rbBoth.TabIndex = 4;
            rbBoth.Text = "Дві осі";
            rbBoth.CheckedChanged += rbBoth_CheckedChanged;
            // 
            // rbVert
            // 
            rbVert.Location = new Point(6, 47);
            rbVert.Name = "rbVert";
            rbVert.Size = new Size(104, 24);
            rbVert.TabIndex = 5;
            rbVert.Text = "Вертикальна";
            rbVert.CheckedChanged += rbVert_CheckedChanged;
            // 
            // rbHoriz
            // 
            rbHoriz.Location = new Point(6, 17);
            rbHoriz.Name = "rbHoriz";
            rbHoriz.Size = new Size(104, 24);
            rbHoriz.TabIndex = 6;
            rbHoriz.Text = "Горизонтальна";
            rbHoriz.CheckedChanged += rbHoriz_CheckedChanged;
            // 
            // label1
            // 
            label1.Location = new Point(668, 74);
            label1.Name = "label1";
            label1.Size = new Size(100, 23);
            label1.TabIndex = 4;
            label1.Text = "Симетрія";
            // 
            // btnSave
            // 
            btnSave.Location = new Point(671, 335);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(122, 23);
            btnSave.TabIndex = 3;
            btnSave.Text = "Зберегти";
            btnSave.Click += btnSave_Click;
            // 
            // btnLoad
            // 
            btnLoad.Location = new Point(671, 393);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(122, 23);
            btnLoad.TabIndex = 2;
            btnLoad.Text = "Завантажити";
            btnLoad.Click += btnLoad_Click;
            // 
            // btnImage
            // 
            btnImage.Location = new Point(671, 364);
            btnImage.Name = "btnImage";
            btnImage.Size = new Size(122, 23);
            btnImage.TabIndex = 1;
            btnImage.Text = "Зображення";
            btnImage.Click += btnImage_Click;
            // 
            // Form1
            // 
            ClientSize = new Size(820, 471);
            Controls.Add(btnImage);
            Controls.Add(btnLoad);
            Controls.Add(btnSave);
            Controls.Add(label1);
            Controls.Add(panel1);
            Controls.Add(buttonClear);
            Controls.Add(buttonColor);
            Controls.Add(polotno1);
            Name = "Form1";
            Text = "Редактор візерунків (Form1)";
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button buttonColor;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnImage;

        private System.Windows.Forms.RadioButton rbHoriz;
        private System.Windows.Forms.RadioButton rbVert;
        private System.Windows.Forms.RadioButton rbBoth;
        private System.Windows.Forms.RadioButton rbCenter;
        private System.Windows.Forms.RadioButton rbNone;

        private System.Windows.Forms.Label label1;

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private Polotno polotno1;
    }
}