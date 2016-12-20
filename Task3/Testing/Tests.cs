using System.Collections.Generic;
using FsCheck;
//using FsCheck.Xunit;
using NUnit.Framework;
using Task3;
using Task3.Testing;
using Xunit;

namespace FS3.Testing
{
    public class Tests
    {
        //[Fact]
        //public void MoveProperty()
        //{
        //    var property = Prop.ForAll(MovesArbitrary.Move(),
        //        move =>
        //        {
        //            var message =
        //    "[[\"x\", 2,  \"y\", 2,   \"v\",  \"x\"],  [\"x\", 1,   \"y\",  0,   \"v\",   \"o\"], [\"x\", 0,   \"y\", 0, \"v\",   \"x\"],  [\"x\",  1,  \"y\", 1, \"v\",   \"o\"], [\"x\", 2, \"y\",  0, \"v\", \"x\"]]";
        //            var dictionaryFromMsg = MessageDecoder.ParseMoves(message);

        //            var newMessage = MessageEncoder.UpdateMessage(message, move);
        //            var dictionaryFromNewMessage = MessageDecoder.ParseMoves(newMessage);

        //           /* dictionaryFromMsg.Add(dictionaryFromMsg.Count.ToString(), new Dictionary<string, string>()
        //            {
        //                {"v", "o"},
        //                {"x", move.Item1.ToString()},
        //                {"y", move.Item2.ToString()}
        //            });

        //            Assert.Equal(dictionaryFromMsg, dictionaryFromNewMessage);*/
        //        });

        //    property.QuickCheckThrowOnFailure();
        //}
    }
}