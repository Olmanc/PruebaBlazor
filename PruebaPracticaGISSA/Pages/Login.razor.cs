using Microsoft.AspNetCore.Components;
using PruebaPracticaGISSA.Models;

namespace PruebaPracticaGISSA.Pages
{
    public partial class Login
    {
        //public  string[] elementos {  get; set; }
        //public TestService TestService { get; set; }
        [Parameter]
        public EventCallback<bool> OnLoginResult { get; set; }

        [Parameter]
        public EventCallback OnForgotPassword { get; set; }

        [Parameter]
        public EventCallback OnCreateAccount { get; set; }
        private LoginModel user { get; set; } = new LoginModel();

        private async Task validateUser()
        {
            var loginResult = DbService.ValidateUserLogin(user);//await loginService.Login(user);
            await OnLoginResult.InvokeAsync(loginResult);
        }

        private async Task HandleForgotPassword()
        {
            await OnForgotPassword.InvokeAsync();
        }

        private void HandleCreateAccount()
        {
            //await OnCreateAccount.InvokeAsync();
            Navigation.NavigateTo("create");
        }
    }
}