using Microsoft.AspNetCore.Components;
using PruebaPracticaGISSA.Data;
using PruebaPracticaGISSA.Models;

namespace PruebaPracticaGISSA.Pages
{

    public partial class CardList
    {
        [Parameter]
        public List<UserModel> users { get; set; }
        [Parameter]
        public EventCallback<UserModel> OnSelectedCard { get; set; }

        [Parameter]
        public EventCallback OnComponentUpdate { get; set; }


        private async void HandleCardSelected(UserModel user)
        {
            await OnSelectedCard.InvokeAsync(user);
        }
        public async void OnCardSelected(UserModel user)
        {
            await OnSelectedCard.InvokeAsync(user);
        }

        public void HandleDeleteUser(int IdUsuario)
        {
            DbService.DeleteUser(IdUsuario);
            OnComponentUpdate.InvokeAsync();
        }
    }
}