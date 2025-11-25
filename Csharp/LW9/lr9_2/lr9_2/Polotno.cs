using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace lr9_2
{
    public class Polotno : UserControl
    {
        private const int CellSize = 20;

        // Колір поточного малювання
        public Color ActiveColor { get; set; } = Color.Black;

        // Симетрія: 0 - none, 1 - vertical, 2 - horizontal, 3 - both, 4 - center
        public int symm { get; set; } = 0;

        // Режим заливки
        public bool IsFillMode { get; set; } = false;

        // Збережені пікселі
        private List<(Point pos, Color col)> pixels = new List<(Point, Color)>();

        public Polotno()
        {
            DoubleBuffered = true;
            BackColor = Color.White;
            MouseClick += Polotno_MouseClick;
        }

        // Малювання клітинок
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            foreach (var p in pixels)
            {
                using (SolidBrush br = new SolidBrush(p.col))
                {
                    e.Graphics.FillRectangle(br, p.pos.X * CellSize, p.pos.Y * CellSize, CellSize, CellSize);
                }

                e.Graphics.DrawRectangle(Pens.Gray, p.pos.X * CellSize, p.pos.Y * CellSize, CellSize, CellSize);
            }
        }

        private void Polotno_MouseClick(object? sender, MouseEventArgs e)
        {
            int x = e.X / CellSize;
            int y = e.Y / CellSize;

            AddPixel(x, y, ActiveColor);

            // симетрія
            ApplySymmetry(x, y);

            Invalidate();
        }

        private void AddPixel(int x, int y, Color c)
        {
            if (x < 0 || y < 0) return;

            // Уникаємо дублювання
            pixels.RemoveAll(p => p.pos.X == x && p.pos.Y == y);

            pixels.Add((new Point(x, y), c));
        }

        private void ApplySymmetry(int x, int y)
        {
            int maxX = Width / CellSize;
            int maxY = Height / CellSize;

            switch (symm)
            {
                case 1: // vertical
                    AddPixel(maxX - x - 1, y, ActiveColor);
                    break;

                case 2: // horizontal
                    AddPixel(x, maxY - y - 1, ActiveColor);
                    break;

                case 3: // both axes
                    AddPixel(maxX - x - 1, y, ActiveColor);
                    AddPixel(x, maxY - y - 1, ActiveColor);
                    AddPixel(maxX - x - 1, maxY - y - 1, ActiveColor);
                    break;

                case 4: // central
                    AddPixel(maxX - x - 1, maxY - y - 1, ActiveColor);
                    break;
            }
        }

        public void Clear()
        {
            pixels.Clear();
            Invalidate();
        }

        // Заглушки для повної сумісності (щоб не було помилок)
        public void SaveToFile(string path) { }
        public void LoadFromFile(string path) { }
        public void SaveAsImage(string path) { }
        public void PrintPattern() { }
    }
}