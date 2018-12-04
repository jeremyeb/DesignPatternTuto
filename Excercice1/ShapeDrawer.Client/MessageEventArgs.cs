using System;
using ShapeDrawer.Common.Message;

namespace ShapeDrawer.Client
{
    public class MessageEventArgs : EventArgs
    {
        public Message Message { get; private set; }

        public MessageEventArgs(Message message)
        {
            Message = message ?? throw new ArgumentNullException(nameof(message));
        }
    }
}