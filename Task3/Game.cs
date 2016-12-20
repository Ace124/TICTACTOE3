using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public static class Game
    {
        public static string Play(string gameId)
        {
            var message = GameHttpClient.Get(gameId);

            var decodedMessage = MessageDecoder.ParseMoves(message);

            if (Validation.ValidateMoves(decodedMessage)) return "Game is over";

            if (MoveFinder.tryToWin(decodedMessage).isNothing)
            {
                var newMove = MoveFinder.findMove(decodedMessage);
                var newMessage = MessageEncoder.UpdateMessage(message, newMove);
                GameHttpClient.Post(gameId, newMessage);
            }
            else
            {
                var newMove = MoveFinder.tryToWin(decodedMessage);
                var newMessage = MessageEncoder.UpdateMessage(message, newMove);
                GameHttpClient.Post(gameId, newMessage);
                return "I win";
            }
            return Play(gameId);
        }  
 }
}
