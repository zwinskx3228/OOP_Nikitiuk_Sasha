using System;

namespace lr9_3
{
    public class Play
    {
        public string[,] Board = new string[3, 3];
        public string CurrentPlayer = "X";

        public void Reset()
        {
            Board = new string[3, 3];
            CurrentPlayer = "X";
        }

        public bool MakeMove(int r, int c)
        {
            if (Board[r, c] != null) return false;

            Board[r, c] = CurrentPlayer;
            return true;
        }

        public string CheckWinner()
        {
            // rows + columns
            for (int i = 0; i < 3; i++)
            {
                if (Board[i, 0] != null &&
                    Board[i, 0] == Board[i, 1] &&
                    Board[i, 1] == Board[i, 2])
                    return Board[i, 0];

                if (Board[0, i] != null &&
                    Board[0, i] == Board[1, i] &&
                    Board[1, i] == Board[2, i])
                    return Board[0, i];
            }

            // diagonals
            if (Board[0, 0] != null &&
                Board[0, 0] == Board[1, 1] &&
                Board[1, 1] == Board[2, 2])
                return Board[0, 0];

            if (Board[0, 2] != null &&
                Board[0, 2] == Board[1, 1] &&
                Board[1, 1] == Board[2, 0])
                return Board[0, 2];

            return null;
        }
    }
}