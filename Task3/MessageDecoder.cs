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
            
            List<int> xCoord = ParseCoordinates(xCoordinates);
            List<int> yCoord = ParseCoordinates(yCoordinates);
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
            List<String> newString = message.Trim('[').Trim(']').Replace(" ", "").Replace("]", "").Replace("[", "").Replace("\"", "").Split(',').ToList();
            List<String> odds = newString.Where((item, index) => index % 2 != 0).ToList();
            return odds;
        }
        //public static List<int> ParseCoordinate(List<string> coordinates)
        //{
        //    List<int> Coord = new List<int>();
        //    foreach (var v in coordinates)
        //    {
        //        switch (v)
        //        {
        //            case "0":
        //                Coord.Add(0);
        //                break;
        //            case "1":
        //                Coord.Add(1);
        //                break;
        //            case "2":
        //                Coord.Add(2);
        //                break;
        //            default:
        //                Console.WriteLine("Parsing error while parsing coordinate");
        //                break;
        //        }
        //    }
        //    return Coord;
        //}
        public static int ParseCoordinate(string coordinate)
        {              
           switch (coordinate)
           {
                    case "0":
                        return 0;
                    case "1":
                        return 1;
                    case "2":
                        return 2;
                    default:
                        Console.WriteLine("Parsing error while parsing coordinate");
                    return 3;
            }
        }

        public static List<int> ParseCoordinates(List<string> val)
        {
            List<int> empty = new List<int>();
            switch (val.Count)
            {

                case 1:
                    List<int> moveVal1 = new List<int>
                        {
                            ParseCoordinate(val[0])
                        };
                    return moveVal1;
                case 2:
                    List<int> moveVal2 = new List<int>
                        {
                            ParseCoordinate(val[0]) ,
                            ParseCoordinate(val[1])
                        };
                    return moveVal2;
                case 3:
                    List<int> moveVal3 = new List<int>
                        {
                            ParseCoordinate(val[0]) ,
                            ParseCoordinate(val[1]) ,
                            ParseCoordinate(val[2])
                        };
                    return moveVal3;
                case 4:
                    List<int> moveVal4 = new List<int>
                        {
                            ParseCoordinate(val[0]) ,
                            ParseCoordinate(val[1]) ,
                            ParseCoordinate(val[2]) ,
                            ParseCoordinate(val[3]) ,
                        };
                    return moveVal4;
                case 5:
                    List<int> moveVal5 = new List<int>
                        {
                            ParseCoordinate(val[0]) ,
                            ParseCoordinate(val[1]) ,
                            ParseCoordinate(val[2]) ,
                            ParseCoordinate(val[3]) ,
                            ParseCoordinate(val[4])
                        };
                    return moveVal5;
                case 6:
                    List<int> moveVal6 = new List<int>
                        {
                            ParseCoordinate(val[0]) ,
                            ParseCoordinate(val[1]) ,
                            ParseCoordinate(val[2]) ,
                            ParseCoordinate(val[3]) ,
                            ParseCoordinate(val[4]) ,
                            ParseCoordinate(val[5])
                        };
                    return moveVal6;
                case 7:
                    List<int> moveVal7 = new List<int>
                        {
                           ParseCoordinate(val[0]) ,
                           ParseCoordinate(val[1]) ,
                           ParseCoordinate(val[2]) ,
                           ParseCoordinate(val[3]) ,
                           ParseCoordinate(val[4]) ,
                           ParseCoordinate(val[5]) ,
                           ParseCoordinate(val[6])
                        };
                    return moveVal7;
                case 8:
                    List<int> moveVal8 = new List<int>
                        {
                           ParseCoordinate(val[0]) ,
                           ParseCoordinate(val[1]) ,
                           ParseCoordinate(val[2]) ,
                           ParseCoordinate(val[3]) ,
                           ParseCoordinate(val[4]) ,
                           ParseCoordinate(val[5]) ,
                           ParseCoordinate(val[6]) ,
                           ParseCoordinate(val[7])
                        };
                    return moveVal8;
                case 9:
                    List<int> moveVal9 = new List<int>
                        {
                           ParseCoordinate(val[0]) ,
                           ParseCoordinate(val[1]) ,
                           ParseCoordinate(val[2]) ,
                           ParseCoordinate(val[3]) ,
                           ParseCoordinate(val[4]) ,
                           ParseCoordinate(val[5]) ,
                           ParseCoordinate(val[6]) ,
                           ParseCoordinate(val[7]) ,
                           ParseCoordinate(val[8])
                        };
                    return moveVal9;
                default:
                    Console.WriteLine("Parsing error while parsing move value");
                    return empty;
            }
        }

        //public static List<char> ParseMoveValue(List<string> val)
        //{
        //    List<char> moveVal = new List<char>();
        //    foreach (var v in val)
        //    {
        //        switch (v.Length)
        //        {
        //            case 1:
        //                moveVal.Add(Convert.ToChar(v));
        //                break;
        //            default:
        //                Console.WriteLine("Parsing error while parsing move value");
        //                break;
        //        }

        //        return moveVal;
        //    }
        //}

        public static List<char> ParseMoveValue(List<string> val)
        {
            List<char> empty = new List<char>();
            switch (val.Count)
                {

                    case 1:
                        List<char> moveVal1 = new List<char>
                        {
                            Convert.ToChar(val[0])
                        };
                        return moveVal1;
                    case 2:
                        List<char> moveVal2 = new List<char>
                        {
                            Convert.ToChar(val[0]) ,
                            Convert.ToChar(val[1])
                        };
                        return moveVal2;
                    case 3:
                        List<char> moveVal3 = new List<char>
                        {
                            Convert.ToChar(val[0]) ,
                            Convert.ToChar(val[1]) ,
                            Convert.ToChar(val[2])
                        };
                        return moveVal3;
                    case 4:
                        List<char> moveVal4 = new List<char>
                        {
                            Convert.ToChar(val[0]) ,
                            Convert.ToChar(val[1]) ,
                            Convert.ToChar(val[2]) ,
                            Convert.ToChar(val[3]) ,
                        };
                        return moveVal4;
                    case 5:
                        List<char> moveVal5 = new List<char>
                        {
                            Convert.ToChar(val[0]) ,
                            Convert.ToChar(val[1]) ,
                            Convert.ToChar(val[2]) ,
                            Convert.ToChar(val[3]) ,
                            Convert.ToChar(val[4]) 
                        };
                        return moveVal5;
                 case 6:
                        List<char> moveVal6 = new List<char>
                        {
                            Convert.ToChar(val[0]) ,
                            Convert.ToChar(val[1]) ,
                            Convert.ToChar(val[2]) ,
                            Convert.ToChar(val[3]) ,
                            Convert.ToChar(val[4]) ,
                            Convert.ToChar(val[5])
                        };
                        return moveVal6;
                case 7:
                        List<char> moveVal7 = new List<char>
                        {
                            Convert.ToChar(val[0]) ,
                            Convert.ToChar(val[1]) ,
                            Convert.ToChar(val[2]) ,
                            Convert.ToChar(val[3]) ,
                            Convert.ToChar(val[4]) ,
                            Convert.ToChar(val[5]) ,
                            Convert.ToChar(val[6])
                        };
                        return moveVal7;
                case 8:
                        List<char> moveVal8 = new List<char>
                        {
                            Convert.ToChar(val[0]) ,
                            Convert.ToChar(val[1]) ,
                            Convert.ToChar(val[2]) ,
                            Convert.ToChar(val[3]) ,
                            Convert.ToChar(val[4]) ,
                            Convert.ToChar(val[5]) ,
                            Convert.ToChar(val[6]) ,
                            Convert.ToChar(val[7]) 
                        };
                        return moveVal8;
                case 9:
                    List<char> moveVal9 = new List<char>
                        {
                            Convert.ToChar(val[0]) ,
                            Convert.ToChar(val[1]) ,
                            Convert.ToChar(val[2]) ,
                            Convert.ToChar(val[3]) ,
                            Convert.ToChar(val[4]) ,
                            Convert.ToChar(val[5]) ,
                            Convert.ToChar(val[6]) ,
                            Convert.ToChar(val[7]) ,
                            Convert.ToChar(val[8]) 
                        };
                    return moveVal9;
                default:
                        Console.WriteLine("Parsing error while parsing move value");
                        return empty;
                }
        }

        public static List<Move> BuildNewMoves(List<int> x, List<int> y, List<char> v)
        {
             List<Move> empty = new List<Move>();
                switch (v.Count)
                {
                    case 1:
                        List<Move> newMoves1 = new List<Move>
                        {
                            new Move(x[0], y[0], v[0])
                        };         
                        return newMoves1;
                    case 2:
                        List<Move> newMoves2 = new List<Move>
                        {
                            new Move(x[0], y[0], v[0]) ,
                            new Move(x[1], y[1], v[1])
                        };
                        return newMoves2;
                    case 3:
                        List<Move> newMoves3 = new List<Move>
                        {
                            new Move(x[0], y[0], v[0]) ,
                            new Move(x[1], y[1], v[1]) ,
                            new Move(x[2], y[2], v[2])
                        };
                        return newMoves3;
                    case 4:
                        List<Move> newMoves4 = new List<Move>
                        {
                            new Move(x[0], y[0], v[0]) ,
                            new Move(x[1], y[1], v[1]) ,
                            new Move(x[2], y[2], v[2]) ,
                            new Move(x[3], y[3], v[3])
                        };
                        return newMoves4;
                    case 5:
                        List<Move> newMoves5 = new List<Move>
                        {
                            new Move(x[0], y[0], v[0]) ,
                            new Move(x[1], y[1], v[1]) ,
                            new Move(x[2], y[2], v[2]) ,
                            new Move(x[3], y[3], v[3]) ,
                            new Move(x[4], y[4], v[4])
                        };
                        return newMoves5;
                    case 6:
                        List<Move> newMoves6 = new List<Move>
                        {
                            new Move(x[0], y[0], v[0]) ,
                            new Move(x[1], y[1], v[1]) ,
                            new Move(x[2], y[2], v[2]) ,
                            new Move(x[3], y[3], v[3]) ,
                            new Move(x[4], y[4], v[4]) ,
                            new Move(x[5], y[5], v[5])
                        };
                        return newMoves6;
                case 7:
                        List<Move> newMoves7 = new List<Move>
                        {
                            new Move(x[0], y[0], v[0]) ,
                            new Move(x[1], y[1], v[1]) ,
                            new Move(x[2], y[2], v[2]) ,
                            new Move(x[3], y[3], v[3]) ,
                            new Move(x[4], y[4], v[4]) ,
                            new Move(x[5], y[5], v[5]) ,
                            new Move(x[6], y[6], v[6])
                        };
                        return newMoves7;
                    case 8:
                        List<Move> newMoves8 = new List<Move>
                        {
                            new Move(x[0], y[0], v[0]) ,
                            new Move(x[1], y[1], v[1]) ,
                            new Move(x[2], y[2], v[2]) ,
                            new Move(x[3], y[3], v[3]) ,
                            new Move(x[4], y[4], v[4]) ,
                            new Move(x[5], y[5], v[5]) ,
                            new Move(x[6], y[6], v[6]) ,
                            new Move(x[7], y[7], v[7])
                        };
                        return newMoves8;
                case 9:
                        List<Move> newMoves9 = new List<Move>
                        {
                            new Move(x[0], y[0], v[0]) ,
                            new Move(x[1], y[1], v[1]) ,
                            new Move(x[2], y[2], v[2]) ,
                            new Move(x[3], y[3], v[3]) ,
                            new Move(x[4], y[4], v[4]) ,
                            new Move(x[5], y[5], v[5]) ,
                            new Move(x[6], y[6], v[6]) ,
                            new Move(x[7], y[7], v[7]) ,
                            new Move(x[8], y[8], v[8])
                        };
                        return newMoves9;
                default:
                        Console.WriteLine("There are no moves available");
                        return empty;
                }
        }
    }
}