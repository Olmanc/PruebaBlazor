namespace PruebaPracticaGISSA.Models
{
    public class LoginModel
    {
        public string user { get; set; }
        public string pass { get; set; }

        public LoginModel()
        {
            user = string.Empty;
            pass = string.Empty;
        }
    }
}
