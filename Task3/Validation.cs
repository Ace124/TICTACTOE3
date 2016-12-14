using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Task3
{
    public static class Validation
    {
        public static bool ValidateMoves(List<Move> moves)
        {
            // Checks for last turn
            if (moves.Count == 9) return true;
            // Checks columns for winner 
            if (moves.Exists(item => item.Item1 == 0 && item.Item2 == 0 && item.Item3 == 'x') && moves.Exists(item => item.Item1 == 0 && item.Item2 == 1 && item.Item3 == 'x') && moves.Exists(item => item.Item1 == 0 && item.Item2 == 2 && item.Item3 == 'x')) return true;
            if (moves.Exists(item => item.Item1 == 1 && item.Item2 == 0 && item.Item3 == 'x') && moves.Exists(item => item.Item1 == 1 && item.Item2 == 1 && item.Item3 == 'x') && moves.Exists(item => item.Item1 == 1 && item.Item2 == 2 && item.Item3 == 'x')) return true;
            if (moves.Exists(item => item.Item1 == 2 && item.Item2 == 0 && item.Item3 == 'x') && moves.Exists(item => item.Item1 == 2 && item.Item2 == 1 && item.Item3 == 'x') && moves.Exists(item => item.Item1 == 2 && item.Item2 == 2 && item.Item3 == 'x')) return true;
            if (moves.Exists(item => item.Item1 == 0 && item.Item2 == 0 && item.Item3 == 'o') && moves.Exists(item => item.Item1 == 0 && item.Item2 == 1 && item.Item3 == 'o') && moves.Exists(item => item.Item1 == 0 && item.Item2 == 2 && item.Item3 == 'o')) return true;
            if (moves.Exists(item => item.Item1 == 1 && item.Item2 == 0 && item.Item3 == 'o') && moves.Exists(item => item.Item1 == 1 && item.Item2 == 1 && item.Item3 == 'o') && moves.Exists(item => item.Item1 == 1 && item.Item2 == 2 && item.Item3 == 'o')) return true;
            if (moves.Exists(item => item.Item1 == 2 && item.Item2 == 0 && item.Item3 == 'o') && moves.Exists(item => item.Item1 == 2 && item.Item2 == 1 && item.Item3 == 'o') && moves.Exists(item => item.Item1 == 2 && item.Item2 == 2 && item.Item3 == 'o')) return true;
            // Checks rows for winner
            if (moves.Exists(item => item.Item1 == 0 && item.Item2 == 0 && item.Item3 == 'x') && moves.Exists(item => item.Item1 == 1 && item.Item2 == 0 && item.Item3 == 'x') && moves.Exists(item => item.Item1 == 2 && item.Item2 == 0 && item.Item3 == 'x')) return true;
            if (moves.Exists(item => item.Item1 == 0 && item.Item2 == 1 && item.Item3 == 'x') && moves.Exists(item => item.Item1 == 1 && item.Item2 == 1 && item.Item3 == 'x') && moves.Exists(item => item.Item1 == 2 && item.Item2 == 1 && item.Item3 == 'x')) return true;
            if (moves.Exists(item => item.Item1 == 0 && item.Item2 == 2 && item.Item3 == 'x') && moves.Exists(item => item.Item1 == 1 && item.Item2 == 2 && item.Item3 == 'x') && moves.Exists(item => item.Item1 == 2 && item.Item2 == 2 && item.Item3 == 'x')) return true;
            if (moves.Exists(item => item.Item1 == 0 && item.Item2 == 0 && item.Item3 == 'o') && moves.Exists(item => item.Item1 == 1 && item.Item2 == 0 && item.Item3 == 'o') && moves.Exists(item => item.Item1 == 2 && item.Item2 == 0 && item.Item3 == 'o')) return true;
            if (moves.Exists(item => item.Item1 == 0 && item.Item2 == 1 && item.Item3 == 'o') && moves.Exists(item => item.Item1 == 1 && item.Item2 == 1 && item.Item3 == 'o') && moves.Exists(item => item.Item1 == 2 && item.Item2 == 1 && item.Item3 == 'o')) return true;
            if (moves.Exists(item => item.Item1 == 0 && item.Item2 == 2 && item.Item3 == 'o') && moves.Exists(item => item.Item1 == 1 && item.Item2 == 2 && item.Item3 == 'o') && moves.Exists(item => item.Item1 == 2 && item.Item2 == 2 && item.Item3 == 'o')) return true;
            // Checks diagonals for winner
            if (moves.Exists(item => item.Item1 == 0 && item.Item2 == 0 && item.Item3 == 'x') && moves.Exists(item => item.Item1 == 1 && item.Item2 == 1 && item.Item3 == 'x') && moves.Exists(item => item.Item1 == 2 && item.Item2 == 2 && item.Item3 == 'x')) return true;
            if (moves.Exists(item => item.Item1 == 2 && item.Item2 == 0 && item.Item3 == 'x') && moves.Exists(item => item.Item1 == 1 && item.Item2 == 1 && item.Item3 == 'x') && moves.Exists(item => item.Item1 == 0 && item.Item2 == 2 && item.Item3 == 'x')) return true;
            if (moves.Exists(item => item.Item1 == 0 && item.Item2 == 0 && item.Item3 == 'o') && moves.Exists(item => item.Item1 == 1 && item.Item2 == 1 && item.Item3 == 'o') && moves.Exists(item => item.Item1 == 2 && item.Item2 == 2 && item.Item3 == 'o')) return true;
            if (moves.Exists(item => item.Item1 == 2 && item.Item2 == 0 && item.Item3 == 'o') && moves.Exists(item => item.Item1 == 1 && item.Item2 == 1 && item.Item3 == 'o') && moves.Exists(item => item.Item1 == 0 && item.Item2 == 2 && item.Item3 == 'o')) return true;
            return false;
        }
    }
}
