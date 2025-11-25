using lr9_3;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lr9_3
{
    public class Game : UserControl
    {
        public Play Logic = new Play(); // твоїй логіці
        public event Action<string>? OnFinished;

        private const int cell = 100;
        private (Point start, Point end)? WinLine = null;

        public Game()
        {
            this.Size = new Size(3 * cell, 3 * cell);
            this.MouseClick += Game_MouseClick;
            DoubleBuffered = true;
        }

        private async void Game_MouseClick(object? sender, MouseEventArgs e)
        {
            int r = e.Y / cell;
            int c = e.X / cell;
            if (r < 0 || r > 2 || c < 0 || c > 2) return;

            // Спроба зробити хід
            if (!Logic.MakeMove(r, c)) return;

            // перемалювати поле (щоб новий хід відобразився)
            Invalidate();

            // Перевірка на перемогу
            string winner = Logic.CheckWinner();

            if (winner != null)
            {
                // обчислити координати лінії і примусово перемалювати СИНХРОННО
                CalculateWinLine();
                Refresh();                 // ОДРАЗУ промалює WinLine у OnPaint

                // зачекаємо трохи, щоб користувач побачив лінію
                await Task.Delay(300);

                // тільки після цього повідомляємо про перемогу
                OnFinished?.Invoke(winner);
                return;
            }

            // Якщо немає перемоги — змінити гравця і перемалювати
            Logic.CurrentPlayer = Logic.CurrentPlayer == "X" ? "O" : "X";
            Invalidate();
        }

        private void CalculateWinLine()
        {
            WinLine = null;

            // рядки
            for (int i = 0; i < 3; i++)
            {
                if (Logic.Board[i, 0] != null &&
                    Logic.Board[i, 0] == Logic.Board[i, 1] &&
                    Logic.Board[i, 1] == Logic.Board[i, 2])
                {
                    int y = i * cell + cell / 2;
                    WinLine = (new Point(10, y), new Point(3 * cell - 10, y));
                    return;
                }
            }

            // стовпці
            for (int i = 0; i < 3; i++)
            {
                if (Logic.Board[0, i] != null &&
                    Logic.Board[0, i] == Logic.Board[1, i] &&
                    Logic.Board[1, i] == Logic.Board[2, i])
                {
                    int x = i * cell + cell / 2;
                    WinLine = (new Point(x, 10), new Point(x, 3 * cell - 10));
                    return;
                }
            }

            // головна діагональ
            if (Logic.Board[0, 0] != null &&
                Logic.Board[0, 0] == Logic.Board[1, 1] &&
                Logic.Board[1, 1] == Logic.Board[2, 2])
            {
                WinLine = (new Point(10, 10), new Point(3 * cell - 10, 3 * cell - 10));
                return;
            }

            // побічна діагональ
            if (Logic.Board[0, 2] != null &&
                Logic.Board[0, 2] == Logic.Board[1, 1] &&
                Logic.Board[1, 1] == Logic.Board[2, 0])
            {
                WinLine = (new Point(3 * cell - 10, 10), new Point(10, 3 * cell - 10));
                return;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var g = e.Graphics;

            // Малюємо сітку
            g.DrawLine(Pens.Black, cell, 0, cell, 3 * cell);
            g.DrawLine(Pens.Black, 2 * cell, 0, 2 * cell, 3 * cell);
            g.DrawLine(Pens.Black, 0, cell, 3 * cell, cell);
            g.DrawLine(Pens.Black, 0, 2 * cell, 3 * cell, 2 * cell);

            // Малюємо X/O
            for (int r = 0; r < 3; r++)
            {
                for (int c = 0; c < 3; c++)
                {
                    var s = Logic.Board[r, c];
                    if (s == "X")
                    {
                        g.DrawLine(Pens.Red, c * cell + 20, r * cell + 20, c * cell + 80, r * cell + 80);
                        g.DrawLine(Pens.Red, c * cell + 80, r * cell + 20, c * cell + 20, r * cell + 80);
                    }
                    else if (s == "O")
                    {
                        g.DrawEllipse(Pens.Blue, c * cell + 20, r * cell + 20, 60, 60);
                    }
                }
            }

            // Малюємо переможну лінію (якщо є)
            if (WinLine != null)
            {
                using (var pen = new Pen(Color.Green, 6))
                {
                    g.DrawLine(pen, WinLine.Value.start, WinLine.Value.end);
                }
            }
        }

        public void Restart()
        {
            Logic.Reset();
            WinLine = null;
            Invalidate();
        }
    }
}