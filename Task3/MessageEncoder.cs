using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public static class MessageEncoder
    {
        public static string UpdateMessage(string message, Tuple<int, int, char> move)
        {
            return message.Substring(0, message.Length - 1) + ",  [\"x\",  "+ move.Item1 + ",  \"y\",  "+ move.Item2 +  ",  \"v\", \"" + move.Item3 + "\"]]";
        }
    }
}
