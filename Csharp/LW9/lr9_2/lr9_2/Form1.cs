using System;
using System.Windows.Forms;

namespace lr9_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
                polotno1.ActiveColor = colorDialog1.Color;
        }

        private void rbHoriz_CheckedChanged(object sender, EventArgs e)
        {
            polotno1.symm = 2;
        }

        private void rbVert_CheckedChanged(object sender, EventArgs e)
        {
            polotno1.symm = 1;
        }

        private void rbBoth_CheckedChanged(object sender, EventArgs e)
        {
            polotno1.symm = 3;
        }

        private void rbCenter_CheckedChanged(object sender, EventArgs e)
        {
            polotno1.symm = 4;
        }

        private void rbNone_CheckedChanged(object sender, EventArgs e)
        {
            polotno1.symm = 0;
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            polotno1.Clear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Stitch Project|*.stitch";
            if (sfd.ShowDialog() == DialogResult.OK)
                polotno1.SaveToFile(sfd.FileName);
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Stitch Project|*.stitch";
            if (ofd.ShowDialog() == DialogResult.OK)
                polotno1.LoadFromFile(ofd.FileName);
        }

        private void btnImage_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "JPEG Image|*.jpg|PNG Image|*.png";
            if (sfd.ShowDialog() == DialogResult.OK)
                polotno1.SaveAsImage(sfd.FileName);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            polotno1.PrintPattern();
        }

        private void chkFill_CheckedChanged(object sender, EventArgs e)
        {
            polotno1.IsFillMode = chkFill.Checked;
        }

        private void rbPencil_CheckedChanged(object sender, EventArgs e)
        {
            if (rbPencil.Checked)
                polotno1.IsFillMode = false;
        }
    }
}