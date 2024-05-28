using Microsoft.AspNetCore.Components;
using PruebaPracticaGISSA.Models;
using static PruebaPracticaGISSA.Shared.MessageWindow;
using System.Text.RegularExpressions;
using Microsoft.IdentityModel.Tokens;
using PruebaPracticaGISSA.Data;
using Radzen;

namespace PruebaPracticaGISSA.Shared
{
    public partial class UserForm
    {
        [Parameter]
        public UserModel User { get; set; }
        [Parameter]
        public EventCallback<UserModel> OnAction { get; set; }
        [Parameter]
        public EventCallback<MessageWindowModel> OnShowMessage { get; set; }


        [Parameter]
        public string Telefono { get; set; }

        public List<string> ListaHabilidades { get; set; }= new List<string>();

        private bool showNotification = false;
        public string NotificationMessage { get; set; }
        public NotificationType NotificationType { get; set; }

        public void ResetUser()
        {
            User = new UserModel();
            StateHasChanged();
        }


        public List<HabilidadModel> catalogoHabilidades { get; set; }
        public List<TipoIdentificcionModel> catalogoTipoIdentificacion { get; set; }
        public List<TipoUsuarioModel> catalogoTipoUsuario { get; set; }

        protected override void OnParametersSet()
        {
            catalogoHabilidades = DbService.GetSkills();
            catalogoTipoIdentificacion = DbService.GetIdentificationTypes();
            catalogoTipoUsuario = DbService.GetUserTypes();
            
            foreach(var h in catalogoHabilidades)
            {
                if (User.Habilidades.Select(x => x.IdHabilidad).Contains(h.Id))
                {
                    h.Seleccionado = true;
                }
            }
        }

        private async void AddPhone()
        {
            try
            {
                if (Telefono.Trim().Length != 8 || !Regex.IsMatch(Telefono, @"\d{8}"))
                {
                    MessageWindowModel msg = new MessageWindowModel("Valdación", "El teléfono solo puede tener 8 caracteres numéricos.", "", MessageType.Warning);
                    await OnShowMessage.InvokeAsync(msg);
                    return;
                }

                if (User.Telefonos.Select(x => x.Telefono).Contains(Telefono))
                {
                    MessageWindowModel msg = new MessageWindowModel("Valdación", "El teléfono ya se encuentra agregado.", "", MessageType.Warning);
                    await OnShowMessage.InvokeAsync(msg);
                    return;
                }

                User.Telefonos.Add(new TelefonoClass(Telefono));
                Telefono = string.Empty;
                
            }
            catch (Exception ex)
            {
                MessageWindowModel msg = new MessageWindowModel("Error", "Error agregando el teléfono, " + ex.Message, "", MessageType.Error);
                await OnShowMessage.InvokeAsync(msg);
            }
        }

        private async void ToggleHabilidad(int habilidadId, string checkboxValue)
        {
            try
            {
                if (Convert.ToBoolean(checkboxValue))
                {
                    User.Habilidades.Add(new HabilidadClass(habilidadId));
                }
                else
                {
                    var habilidadToRemove = User.Habilidades.FirstOrDefault(h => h.IdHabilidad == habilidadId);
                    User.Habilidades.Remove(habilidadToRemove);
                }
            }
            catch(Exception ex)
            {
                MessageWindowModel msg = new MessageWindowModel("Error", "Error marcando/desmarcando habilidad, " + ex.Message, "", MessageType.Error);
                await OnShowMessage.InvokeAsync(msg);
            }
        }

        private async void DeletePhone(string Telefono)
        {
            try
            {
                //if (User.Telefonos.Select(x => x.Telefono).Contains(Telefono))
                //{
                //    User.Telefonos.Remove(new TelefonoClass(Telefono)));
                //}
                var telefonoToRemove = User.Telefonos.FirstOrDefault(t => t.Telefono == Telefono);
                if (telefonoToRemove != null)
                {
                    User.Telefonos.Remove(telefonoToRemove);
                }
            }
            catch(Exception ex)
            {
                MessageWindowModel msg = new MessageWindowModel("Error", "Error eliminando el teléfono, " + ex.Message, "", MessageType.Error);
                await OnShowMessage.InvokeAsync(msg);
            }
        }

        private async void SubmitForm()
        {
            //ShowNotification("Prueba", NotificationType.Warning);
            if (!ValidateFields())
            {
                return;
            }
            showNotification = false;
            await OnAction.InvokeAsync(User);            
        }

        public void EmptyFields()
        {
            foreach(HabilidadModel h in catalogoHabilidades)
            {
                h.Seleccionado = false;
            }
            Telefono = "";
        }

        public bool ValidateFields()
        {
            try
            {
                if(User.IdTipoIdentificacion == 0)
                {
                    ShowNotification("Debe indicar el Tipo de Identificación.", NotificationType.Warning);
                    return false;
                }
                if (User.NumeroIdentificacion.IsNullOrEmpty())
                {
                    ShowNotification("Debe indicar el Número de Identificación.", NotificationType.Warning);
                    return false;
                }
                if(User.IdTipoIdentificacion == 1 && User.NumeroIdentificacion.Trim().Length != 9)
                {
                    ShowNotification("El Número de Identificación debe tener 9 dígitos si es Nacional.", NotificationType.Warning);
                    return false;
                }
                if(User.Nombre.IsNullOrEmpty() || User.PrimerApellido.IsNullOrEmpty() || User.SegundoApellido.IsNullOrEmpty())
                {
                    ShowNotification("Debe indicar el Nombre Completo.", NotificationType.Warning);
                    return false;
                }
                if(User.IdTipoUsuario == 0)
                {
                    ShowNotification("Debe indicar el Tipo de Usuario.", NotificationType.Warning);
                    return false;
                }
                if(User.Usuario.IsNullOrEmpty() || User.Clave.IsNullOrEmpty())
                {
                    ShowNotification("Debe indicar un Usuario y una Clave.", NotificationType.Warning);
                    return false;
                }
                if (!Regex.IsMatch(User.Clave, @"^[a-zA-Z0-9]{6,}$"))
                {
                    ShowNotification("La Clave debe tener un mínimo de 6 characteres alphanumericos.", NotificationType.Warning);
                    return false;
                }
                if (User.Correo.IsNullOrEmpty())
                {
                    ShowNotification("Debe indicar un Correo.", NotificationType.Warning);
                    return false;
                }
                if (!Regex.IsMatch(User.Correo, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
                {
                    ShowNotification("Debe indicar un Correo válido.", NotificationType.Warning);
                    return false;
                }
                if(User.Telefonos.Count <= 1)
                {
                    ShowNotification("Debe indicar más de un Teléfono.", NotificationType.Warning);
                    return false;
                }
                if(User.Habilidades.Count < 3)
                {
                    ShowNotification("Debe indicar al menos 3 Habilidades.", NotificationType.Warning);
                    return false;
                }
                return true;
            }catch(Exception ex) { 
                return false;
            }
        }

        private void HandleNotificationClose()
        {
            showNotification = false;
        }

        private void ShowNotification(string message, NotificationType type)
        {
            NotificationMessage = message;
            NotificationType = type;
            showNotification = true;
        }
    }
}