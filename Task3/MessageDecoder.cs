using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public static class MessageDecoder
    {
        public static List<Move> ParseMoves(string message)
        {   
            List<String> newMessage = ClearTheNoise(message);
            List<String> xCoordinates = newMessage.Where((item, index) => index == 0 || index % 3 == 0).ToList();
            List<String> yCoordinates = newMessage.Where((item, index) => index == 1 || (index-1) % 3 == 0).ToList();
            List<String> moveValue = newMessage.Where((item, index) => index == 2 || (index - 2) % 3 == 0).ToList();

            //string[] xC = newMessage.Where((item, index) => index == 0 || index % 3 == 0).ToArray();
            //string[] yC = newMessage.Where((item, index) => index == 1 || (index - 1) % 3 == 0).ToArray();
            //string[] mV = newMessage.Where((item, index) => index == 2 || (index - 2) % 3 == 0).ToArray();

            //List<int> 

            //var qx = xCoordinates.Select((fruit, index) => new { index, str = xCoordinates.Substring(0, index) });

            //var qx = xCoord.Select((value, i) => new {i, value}).ToList();
            
            List<int> xCoord = ParseCoordinate(xCoordinates);
            List<int> yCoord = ParseCoordinate(yCoordinates);
            List<char> moveVal = ParseMoveValue(moveValue);
            List<Move> newMoves = BuildNewMoves(xCoord, yCoord, moveVal);

            // newMoves.AddRange(qx.Select(item => new  Move(xCoord[item.i]), yCoord[item.i], moveVal[item.i]))));

            /* foreach (var item in newMoves.Select((value, i) => new {i, value}))
             {
                 newMoves.Add(new Move(xCoord[item.i], yCoord[item.i], moveVal[item.i]));
             }*/
            //foreach (var item in newMoves)
            //{
            //    Console.Write(item.Item1.ToString() + " " + item.Item2.ToString() + " " + item.Item3.ToString());
            //}

            //foreach (var item in qx)
            //{
            //    Console.Write(item.i + " " + item.value);
            //}
            //foreach (var i in newMoves)
            //{
            //    Console.Write(i.Item1 + " " + i.Item2 + " " + i.Item3 + " ");
            //}
            return newMoves;
        }
        public static List<String> ClearTheNoise(string message)
        {
            const string space = " ";
            String nString = message.Trim().Trim('[').Trim(']');
            String neString = nString.Replace(" " , "").Replace("]", "").Replace("[", "").Replace("\"", "");
            List<String> newString = neString.Split(',').ToList();
            List<String> odds = newString.Where((item, index) => index % 2 != 0).ToList();
            return odds;
        }

        public static List<int> ParseCoordinate(List<string> coordinates)
        {
            List<int> Coord = new List<int>();
            foreach (var v in coordinates)
            {
                switch (v)
                {
                    case "0":
                        Coord.Add(0);
                        break;
                    case "1":
                        Coord.Add(1);
                        break;
                    case "2":
                        Coord.Add(2);
                        break;
                    default:
                        Console.WriteLine("Parsing error while parsing coordinate");
                        break;
                }
            }
            return Coord;
        }

        public static List<char> ParseMoveValue(List<string> val)
        {
            List<char> moveVal = new List<char>();
            foreach (var v in val)
            {
                switch (v.Length)
                {
                    case 1:
                        moveVal.Add(Convert.ToChar(v));
                        break;
                    default:
                        Console.WriteLine("Parsing error while parsing move value");
                        break;
                }
            }
            return moveVal;
        }

        public static List<Move> BuildNewMoves(List<int> x, List<int> y, List<char> v)
        {
            List<Move> newMoves = new List<Move>();
            switch (v.Count)
            {
                case 1:
                    newMoves.Add(new Move(x[0], y[0], v[0]));
                    break;
                case 2:
                    newMoves.Add(new Move(x[0], y[0], v[0]));
                    newMoves.Add(new Move(x[1], y[1], v[1]));
                    break;
                case 3:
                    newMoves.Add(new Move(x[0], y[0], v[0]));
                    newMoves.Add(new Move(x[1], y[1], v[1]));
                    newMoves.Add(new Move(x[2], y[2], v[2]));
                    break;
                case 4:
                    newMoves.Add(new Move(x[0], y[0], v[0]));
                    newMoves.Add(new Move(x[1], y[1], v[1]));
                    newMoves.Add(new Move(x[2], y[2], v[2]));
                    newMoves.Add(new Move(x[3], y[3], v[3]));
                    break;
                case 5:
                    newMoves.Add(new Move(x[0], y[0], v[0]));
                    newMoves.Add(new Move(x[1], y[1], v[1]));
                    newMoves.Add(new Move(x[2], y[2], v[2]));
                    newMoves.Add(new Move(x[3], y[3], v[3]));
                    newMoves.Add(new Move(x[4], y[4], v[4]));
                    break;
                case 6:
                    newMoves.Add(new Move(x[0], y[0], v[0]));
                    newMoves.Add(new Move(x[1], y[1], v[1]));
                    newMoves.Add(new Move(x[2], y[2], v[2]));
                    newMoves.Add(new Move(x[3], y[3], v[3]));
                    newMoves.Add(new Move(x[4], y[4], v[4]));
                    newMoves.Add(new Move(x[5], y[5], v[5]));
                    break;
                case 7:
                    newMoves.Add(new Move(x[0], y[0], v[0]));
                    newMoves.Add(new Move(x[1], y[1], v[1]));
                    newMoves.Add(new Move(x[2], y[2], v[2]));
                    newMoves.Add(new Move(x[3], y[3], v[3]));
                    newMoves.Add(new Move(x[4], y[4], v[4]));
                    newMoves.Add(new Move(x[5], y[5], v[5]));
                    newMoves.Add(new Move(x[6], y[6], v[6]));
                    break;
                case 8:
                    newMoves.Add(new Move(x[0], y[0], v[0]));
                    newMoves.Add(new Move(x[1], y[1], v[1]));
                    newMoves.Add(new Move(x[2], y[2], v[2]));
                    newMoves.Add(new Move(x[3], y[3], v[3]));
                    newMoves.Add(new Move(x[4], y[4], v[4]));
                    newMoves.Add(new Move(x[5], y[5], v[5]));
                    newMoves.Add(new Move(x[6], y[6], v[6]));
                    newMoves.Add(new Move(x[7], y[7], v[7]));
                    break;
                case 9:
                    newMoves.Add(new Move(x[0], y[0], v[0]));
                    newMoves.Add(new Move(x[1], y[1], v[1]));
                    newMoves.Add(new Move(x[2], y[2], v[2]));
                    newMoves.Add(new Move(x[3], y[3], v[3]));
                    newMoves.Add(new Move(x[4], y[4], v[4]));
                    newMoves.Add(new Move(x[5], y[5], v[5]));
                    newMoves.Add(new Move(x[6], y[6], v[6]));
                    newMoves.Add(new Move(x[7], y[7], v[7]));
                    newMoves.Add(new Move(x[8], y[8], v[8]));
                    break;
                default:
                    Console.WriteLine("There are no moves available");
                    break;
            }
            return newMoves;
        }
    }

}