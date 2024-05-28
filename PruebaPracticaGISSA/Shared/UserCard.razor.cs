using Microsoft.AspNetCore.Components;
using PruebaPracticaGISSA.Models;

namespace PruebaPracticaGISSA.Shared
{
    public partial class UserCard
    {
        [Parameter]
        public UserModel User { get; set; }
        [Parameter]
        public EventCallback<UserModel> OnSelected { get; set; }
        [Parameter]
        public EventCallback<int> OnButtonClick { get; set; }

        private bool isButtonVisible = false;

        private void ShowButton()
        {
            isButtonVisible = true;
        }

        private void HideButton()
        {
            isButtonVisible = false;
        }

        async void OnUserCardClicked(int IdUsuario)
        {
            UserModel user = DbService.GetUserDataJson(IdUsuario);
            //user.Telefonos = DbService.GetUserPhones(user.Id);
            //user.Habilidades = DbService.GetUserSkills(user.Id);


            await OnSelected.InvokeAsync(user);
        }

        public async void DeleteUser(int IdUsuario)
        {
            await OnButtonClick.InvokeAsync(IdUsuario);

        }
    }
}