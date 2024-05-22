using System.ComponentModel.DataAnnotations;

namespace PruebaPracticaGISSA.Models
{
    public class UserModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int IdTipoUsuario { get; set; }
        public string TipoUsuario { get; set; }
        [Required]
        public int IdTipoIdentificacion { get; set; }
        [Required]
        public string NumeroIdentificacion { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string PrimerApellido { get; set; }
        [Required]
        public string SegundoApellido { get; set; }
        [Required]
        public string Usuario { get; set; }
        [Required]
        public string Clave { get; set; }
        [Required, EmailAddress]
        public string Correo { get; set; }
        [Required]
        public List<string> Telefonos { get; set; } = new List<string>();
        [Required]
        public List<int> Habilidades { get; set; } = new List<int>();
        public string imageUrl { get; set; }

        public string TelefonosString{
            get {
                return String.Join(",", Telefonos);
            }
        }

        public string HabilidadesString
        {
            get
            {
                return String.Join(",", Habilidades);
            }
        }
    }
}
