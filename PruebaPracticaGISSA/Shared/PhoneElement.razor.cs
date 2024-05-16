using Microsoft.AspNetCore.Components;
using PruebaPracticaGISSA.Models;

namespace PruebaPracticaGISSA.Shared
{
    public partial class PhoneElement
    {
        [Parameter]
        public string Telefono { get; set; }

        [Parameter]
        public EventCallback<string> OnDelete { get; set; }

        private async void DeleteItem()
        {
            await OnDelete.InvokeAsync(Telefono);
        }
    }
}