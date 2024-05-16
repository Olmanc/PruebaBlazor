using Microsoft.AspNetCore.Components;
using PruebaPracticaGISSA.Models;
using static PruebaPracticaGISSA.Shared.MessageWindow;
using System.Text.RegularExpressions;
using Microsoft.IdentityModel.Tokens;

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
                if (User.Habilidades.Contains(h.Id))
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

                if (User.Telefonos.Contains(Telefono))
                {
                    MessageWindowModel msg = new MessageWindowModel("Valdación", "El teléfono ya se encuentra agregado.", "", MessageType.Warning);
                    await OnShowMessage.InvokeAsync(msg);
                    return;
                }

                User.Telefonos.Add(Telefono);
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
                    User.Habilidades.Add(habilidadId);
                }
                else
                {
                    User.Habilidades.Remove(habilidadId);
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
                if (User.Telefonos.Contains(Telefono))
                {
                    User.Telefonos.Remove(Telefono);
                }
            }catch(Exception ex)
            {
                MessageWindowModel msg = new MessageWindowModel("Error", "Error eliminando el teléfono, " + ex.Message, "", MessageType.Error);
                await OnShowMessage.InvokeAsync(msg);
            }
        }

        private async void SubmitForm()
        {
            //if (!ValidateFields())
            //{
            //    return;
            //}
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

        public async Task<bool> ValidateFields()
        {
            try
            {
                if(User.IdTipoIdentificacion == 0)
                {
                    MessageWindowModel msg = new MessageWindowModel("Validacion", "", "", MessageType.Error);
                    await OnShowMessage.InvokeAsync(msg);
                    return false;
                }
                if (User.NumeroIdentificacion.IsNullOrEmpty())
                {
                    MessageWindowModel msg = new MessageWindowModel("Validacion", "", "", MessageType.Error);
                    await OnShowMessage.InvokeAsync(msg);
                    return false;
                }
                if(User.Nombre.IsNullOrEmpty() || User.PrimerApellido.IsNullOrEmpty() || User.SegundoApellido.IsNullOrEmpty())
                {
                    MessageWindowModel msg = new MessageWindowModel("Validacion", "", "", MessageType.Error);
                    await OnShowMessage.InvokeAsync(msg);
                    return false;
                }
                if(User.IdTipoUsuario == 0)
                {
                    MessageWindowModel msg = new MessageWindowModel("Validacion", "", "", MessageType.Error);
                    await OnShowMessage.InvokeAsync(msg);
                    return false;
                }
                if(User.Usuario.IsNullOrEmpty() || User.Clave.IsNullOrEmpty())
                {
                    MessageWindowModel msg = new MessageWindowModel("Validacion", "", "", MessageType.Error);
                    await OnShowMessage.InvokeAsync(msg);
                    return false;
                }
                if (User.Correo.IsNullOrEmpty())
                {
                    MessageWindowModel msg = new MessageWindowModel("Validacion", "Debe ingresar un correo válido.", "", MessageType.Error);
                    await OnShowMessage.InvokeAsync(msg);
                    return false;
                }
                if(User.Habilidades.Count < 3)
                {
                    MessageWindowModel msg = new MessageWindowModel("Validacion", "Debe seleccionar al menos 3 habilidades.", "", MessageType.Error);
                    await OnShowMessage.InvokeAsync(msg);
                    return false;
                }
                return true;
            }catch(Exception ex) { 
                return false;
            }
        }
    }
}