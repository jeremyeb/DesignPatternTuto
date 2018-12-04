using Newtonsoft.Json;
using System;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace ShapeDrawer.Common.Message
{
    public class MessageDecoder
    {
        public Message Decode(NetworkStream stream)
        {
            //Should not dispose it
            var textStream = new StreamReader(stream, Encoding.UTF8);
            var message = textStream.ReadLine();
            //Console.WriteLine(message); //TODO remove
            return Decode(message);
        }

        public Message Decode(string jsonMessage)
        {
            return JsonConvert.DeserializeObject<Message>(jsonMessage, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Objects });
        }

    }
}
