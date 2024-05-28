using PruebaPracticaGISSA.Data;
using PruebaPracticaGISSA.Models;
using PruebaPracticaGISSA.Shared;
using static PruebaPracticaGISSA.Shared.MessageWindow;

namespace PruebaPracticaGISSA.Pages
{
    public partial class UsersList
    {
        public List<UserModel> Users { get; set; }
        public UserModel? SelectedUser { get; set; }
        public bool ShowUserList { get; set; } = true;
        public bool ShowUserForm { get; set; } = false;



        private bool messageShown = false;
        private string messageTitle = string.Empty;
        private string messageBody = string.Empty;
        private string messageImage = string.Empty;
        private MessageWindow.MessageType messageType;
        protected override void OnInitialized()
        {
            //UserModel user1 = new UserModel();
            //user1.IdTipoIdentificacion = "1";
            //user1.IdTipoUsuario = "1";
            //user1.TipoUsuario = "Tipo1";
            //user1.NumeroIdentificacion = "402270879";
            //user1.Nombre = "Olman1";
            //user1.PrimerApellido = "Cheng1";
            //user1.SegundoApellido = "Lam1";
            //user1.Usuario = "ocheng1";
            //user1.Clave = "ocheng1";
            //user1.Correo = "ocheng1@correo.com";

            //UserModel user2 = new UserModel();
            //user2.IdTipoIdentificacion = "2";
            //user2.IdTipoUsuario = "2";
            //user2.TipoUsuario = "Tipo2";
            //user2.NumeroIdentificacion = "402270879";
            //user2.Nombre = "Olman2";
            //user2.PrimerApellido = "Cheng2";
            //user2.SegundoApellido = "Lam2";
            //user2.Usuario = "ocheng2";
            //user2.Clave = "ocheng2";
            //user2.Correo = "ocheng2@correo.com";

            //UserModel user3 = new UserModel();
            //user3.IdTipoIdentificacion = "3";
            //user3.IdTipoUsuario = "3";
            //user3.TipoUsuario = "Tipo3";
            //user3.NumeroIdentificacion = "402270879";
            //user3.Nombre = "Olman3";
            //user3.PrimerApellido = "Cheng3";
            //user3.SegundoApellido = "Lam3";
            //user3.Usuario = "ocheng3";
            //user3.Clave = "ocheng3";
            //user3.Correo = "ocheng3@correo.com";

            //Users = new List<UserModel>();
            //Users.Add(user1);
            //Users.Add(user2);
            //Users.Add(user3);

            Users = DbService.GetAllUsersJson();
        }

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

        private void OnUpdateUser()
        {
            try
            {
                if (DbService.UpdateUser(SelectedUser))
                {
                    showMessage("Actualizar Usuario", "Usuario actualizado correctamente.", "", MessageType.Success);
                    UpdateComponent();
                }
                else
                {
                    showMessage("Actualizar Usuario", "hubo un problema al actualizar el usuario. Por favor intente más tarde.", "", MessageType.Warning);
                }
            }
            catch (Exception ex)
            {
                showMessage("Error", "Error al actualizar usuario. " + ex.Message, "", MessageType.Error);
            }
        }

        private void HandleCardSelected(UserModel user)
        {
            SelectedUser = user;
            ShowUserForm = true;
            ShowUserList = true;
        }

        private void UpdateComponent()
        {
            Users = DbService.GetAllUsersJson();
            ShowUserForm = false;
            messageShown = false;
            StateHasChanged();
        }
    }
}