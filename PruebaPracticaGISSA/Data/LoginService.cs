using PruebaPracticaGISSA.Models;
using System.Text.Json;
using System.Text;

namespace PruebaPracticaGISSA.Data
{
    public interface ILoginService
    {
        Task<LoginResult> Login(LoginModel user);
    }
    public class LoginService : ILoginService
    {
        private readonly HttpClient _client;

        public LoginService(HttpClient client)
        {
            this._client = client;
        }

        public async Task<LoginResult> Login(LoginModel user)
        {
            try
            {
                var result = new LoginResult();
                result.message = "OK";
                result.statusCode = 200;
                return result;


                //_client.DefaultRequestHeaders.Add("x-api-key", "prueba_E5QvNRSiLI_N3KNebWz97_E1NzQgGuaM0P8_Q1n6sujAPfDeydsmsTee_Cw7a2f9rNcCntJLVI_yQxrQELDKJw==");
                //var response = await _client.PostAsync("api/Login/GISSA", new StringContent(JsonSerializer.Serialize(new { user = user.user, pass = user.pass }), Encoding.UTF8, "application/json"));



                //if (response.IsSuccessStatusCode)
                //{
                //    var content = await response.Content.ReadAsStringAsync();
                //    var loginResponse = JsonSerializer.Deserialize<LoginResult>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                //    return loginResponse;
                //}
                //else
                //{
                //    return new LoginResult { statusCode = -1, message = response.ReasonPhrase.ToString() };
                //}
            }
            catch (Exception ex)
            {
                return new LoginResult { statusCode = -1, message = ex.Message };
            }

        }
    }
}
