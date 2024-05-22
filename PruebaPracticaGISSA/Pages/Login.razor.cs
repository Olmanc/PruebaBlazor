using Microsoft.AspNetCore.Components;
using PruebaPracticaGISSA.Authentication;
using PruebaPracticaGISSA.Data;
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
            if (loginResult.Rows.Count > 0)
            {
                var customAuthStateProvider = (CustomAuthenticationProvider)authStateProvider;
                await customAuthStateProvider.UpdateAuthenticationState(new UserSession
                {
                    Usuario = loginResult.Rows[0]["Usuario"].ToString(),
                    TipoUsuario = loginResult.Rows[0]["IdTipoUsuario"].ToString()
                });
            }
            await OnLoginResult.InvokeAsync(loginResult.Rows.Count > 0);
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