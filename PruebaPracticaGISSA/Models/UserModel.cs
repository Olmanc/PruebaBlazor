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
        public List<TelefonoClass> Telefonos { get; set; } = new List<TelefonoClass>();
        [Required]
        public List<HabilidadClass> Habilidades { get; set; } = new List<HabilidadClass>();
        public string imageUrl { get; set; }

        public string TelefonosString{
            get {
                return String.Join(",", Telefonos.Select(x => x.Telefono));
            }
        }

        public string HabilidadesString
        {
            get
            {
                return String.Join(",", Habilidades.Select(x => x.IdHabilidad));
            }
        }
    }

    public class TelefonoClass
    {
        public string Telefono { get; set; }
        public TelefonoClass(string tel)
        {
            Telefono = tel;
        }
    }

    public class HabilidadClass
    {
        public int IdHabilidad { get; set; }
        public HabilidadClass(int idHabilidad)
        {
            IdHabilidad = idHabilidad;
        }
    }
}
