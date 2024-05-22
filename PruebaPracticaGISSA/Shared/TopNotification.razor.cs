using Microsoft.AspNetCore.Components;
using PruebaPracticaGISSA.Models;

namespace PruebaPracticaGISSA.Shared
{
    public partial class TopNotification
    {
        [Parameter]
        public string Message { get; set; }
        [Parameter]
        public NotificationType Type { get; set; }
        [Parameter]
        public bool IsVisible { get; set; }
        [Parameter]
        public EventCallback OnClose { get; set; }

        private string GetNotificationClass()
        {
            return Type switch
            {
                NotificationType.Success => "notification success",
                NotificationType.Error => "notification error",
                NotificationType.Warning => "notification warning",
                NotificationType.Info => "notification info",
                _ => "notification"
            };
        }

        private async Task HandleClose()
        {
            IsVisible = false;
            await OnClose.InvokeAsync(null);
        }
    }
}