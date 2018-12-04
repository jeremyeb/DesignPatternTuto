using Newtonsoft.Json;
using ShapeDrawer.Common.Shape;
using System.Text;

namespace ShapeDrawer.Common.Message
{
    public class MessageEncoder
    {
        public byte[] Encode(IShape shape, EnumUiDrawer uiDrawer)
        {
            var message = Serialize(shape, uiDrawer) + System.Environment.NewLine;
            return Encoding.UTF8.GetBytes(message);
        }

        private string Serialize(IShape shape, EnumUiDrawer uiDrawer)
        {
            return Serialize(new Message(shape, uiDrawer));
        }

        private string Serialize(Message message)
        {
            return JsonConvert.SerializeObject(message, Formatting.None, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Objects });
        }
    }
}
