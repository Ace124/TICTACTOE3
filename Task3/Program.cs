using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Program
    {
        private static string message =
            "[[\"x\", 2,  \"y\", 2,   \"v\",  \"x\"],  [\"x\", 1,   \"y\",  0,   \"v\",   \"o\"], [\"x\", 0,   \"y\", 0, \"v\",   \"x\"],  [\"x\",  1,  \"y\", 1, \"v\",   \"o\"], [\"x\", 2, \"y\",  0, \"v\", \"x\"]]";
        public static void Main()
        {
            Console.WriteLine(Game.Play(Console.ReadLine()));
            Console.ReadKey();
        }
    }
}
