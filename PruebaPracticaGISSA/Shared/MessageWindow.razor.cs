using Microsoft.AspNetCore.Components;

namespace PruebaPracticaGISSA.Shared
{
    public partial class MessageWindow
    {
        [Parameter]
        public string title { get; set; }
        [Parameter]
        public string message { get; set; }
        [Parameter]
        public string imageUrl { get; set; }
        [Parameter]
        public MessageType type { get; set; }
        [Parameter]
        public EventCallback OnClose { get; set; }

        private string GetStyle()
        {
            switch (type)
            {
                case MessageType.Success: return "success";
                case MessageType.Info: return "info";
                case MessageType.Warning: return "warning";
                case MessageType.Error: return "error";
                default: return string.Empty;
            }
        }

        public enum MessageType
        {
            Success,
            Info,
            Warning,
            Error
        }
    }
}