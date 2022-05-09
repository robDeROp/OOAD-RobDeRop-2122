using System;
using System.Collections.Generic;
using System.Text;

namespace WpfEscapeGame
{
    class RandomMessageGenerator
    {
        private static string[] ErrorMessage = {"That doesn't seem to work","Hmm, this didn't work","Dam, it doesn't work" };
        private static string[] FoundMessage = {"Look, I found a ","Great, I have found a ","Oh, I have found a " };
        private static string[] PickupMessage = {"I have picked up the ","I took the ","I have grabbed the " };
        public enum MessageType { error, found, pickup }

        public static string GetRandomMessage(MessageType IntMessageType)
        {
            Random rnd = new Random();
            string message = "";
            if(IntMessageType == MessageType.error)
            {
                message = ErrorMessage[rnd.Next(0, ErrorMessage.Length)];
            }
            else if(IntMessageType == MessageType.found)
            {
                message = FoundMessage[rnd.Next(0, FoundMessage.Length)];
            }
            else if(IntMessageType == MessageType.pickup)
            {
                message = PickupMessage[rnd.Next(0, PickupMessage.Length)];
            }
            else
            {
                message = "Internal error: Message Type was not found";
            }
            return message;
        }
    }
}
