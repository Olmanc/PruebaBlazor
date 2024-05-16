
using PruebaPracticaGISSA.Shared;

namespace PruebaPracticaGISSA.Models
{
    public class MessageWindowModel
    {
        public string Title { get; set; }
        public string Message { get; set; }
        public string ImageUrl { get; set; }
        public MessageWindow.MessageType MessageType { get; set; }
        public bool MessageShown { get; set; }

        public MessageWindowModel(string title, string message, string image, MessageWindow.MessageType type) {
            Title = title;
            Message = message;
            ImageUrl = image;
            MessageType = type;
        }
    }
}
