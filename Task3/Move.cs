using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public class Move : Tuple<int, int, char>
    {
        public Move(int item1, int item2, char item3) : base(item1, item2, item3) { }
    }
}
