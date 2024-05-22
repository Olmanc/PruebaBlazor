using PruebaPracticaGISSA.Models;
using PruebaPracticaGISSA.Shared;
using System.Text.RegularExpressions;
using static PruebaPracticaGISSA.Shared.MessageWindow;

namespace PruebaPracticaGISSA.Pages
{
    public partial class CreateUser2
    {
        public UserModel User { get; set; } = new UserModel();

        protected UserForm userForm;

        private bool messageShown = false;
        private string messageTitle = string.Empty;
        private string messageBody = string.Empty;
        private string messageImage = string.Empty;
        private MessageWindow.MessageType messageType;

        private void showMessage(string title, string message, string imgUrl, MessageWindow.MessageType type)
        {
            messageTitle = title;
            messageBody = message;
            messageType = type;
            messageShown = true;
            messageImage = imgUrl;
        }

        private void HandleShowMessage(MessageWindowModel message)
        {
            showMessage(message.Title, message.Message, message.ImageUrl, message.MessageType);
        }

        private void hideMessage()
        {
            messageShown = false;
        }

        private async void OnCreateUser(UserModel User)
        {
            try
            {
                if (DbService.CreateUser(User))
                {
                    UpdateComponent();
                    showMessage("Crear Usuario", "Usuario creado correctamente.", "", MessageType.Success);
                    
                }
                else
                {
                    showMessage("Crear Usuario", "hubo un problema al crear el usuario. Por favor intente más tarde.", "", MessageType.Warning);
                }
            }catch (Exception ex) {
                showMessage("Error", "Error al crear usuario. " + ex.Message, "", MessageType.Error);
            }
        }

        private void UpdateComponent()
        {
            User = new UserModel();
            messageShown = false;
            userForm.EmptyFields();
            StateHasChanged();
        }
    }
}