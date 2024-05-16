namespace PruebaPracticaGISSA.Models
{
    public class HabilidadModel
    {
        public int Id { get; set; }
        public string Detalle { get; set; }
        public bool Seleccionado { get; set; }

        public HabilidadModel() { 
            Seleccionado = false;
        }
    }
}
