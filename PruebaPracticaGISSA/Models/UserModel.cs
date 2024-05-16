namespace PruebaPracticaGISSA.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public int IdTipoUsuario { get; set; }
        public string TipoUsuario { get; set; }
        public int IdTipoIdentificacion { get; set; }
        public string NumeroIdentificacion { get; set; }
        public string Nombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Usuario { get; set; }
        public string Clave { get; set; }
        public string Correo { get; set; }
        public List<string> Telefonos { get; set; } = new List<string>();
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
