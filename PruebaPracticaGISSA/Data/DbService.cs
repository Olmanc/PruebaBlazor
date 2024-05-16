using Microsoft.Data.SqlClient;
using PruebaPracticaGISSA.Models;
using System.Data;


namespace PruebaPracticaGISSA.Data
{
    public interface IDbService
    {
        DataTable ExecuteQuery(string spName, List<SqlParameter> parameters);
        int ExecuteCommand(string spName, List<SqlParameter> parameters);
        string ExecuteProcedure(string spName, List<SqlParameter> parameters);
    }
    public class DbService: IDbService
    {
        private readonly IConfiguration _configuration;
        private string _serverId;
        public DbService(IConfiguration config, string servderId)
        {
            _configuration = config;
            _serverId = servderId;
        }

        public DataTable ExecuteQuery(string spName, List<SqlParameter> parameters)
        {
            var connectionString = _configuration.GetConnectionString(_serverId);

            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand(spName, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddRange(parameters.ToArray());

                    connection.Open();

                    var table = new DataTable();
                    table.Load(command.ExecuteReader());

                    return table;
                }
            }
        }

        public int ExecuteCommand(string spName, List<SqlParameter> parameters)
        {
            var connectionString = _configuration.GetConnectionString(_serverId);

            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand(spName, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddRange(parameters.ToArray());

                    connection.Open();

                    return command.ExecuteNonQuery();
                }
            }
        }

        public string ExecuteProcedure(string spName, List<SqlParameter> parameters)
        {
            var connectionString = _configuration.GetConnectionString(_serverId);
            var jsonResult = "";

            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand(spName, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddRange(parameters.ToArray());

                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            jsonResult += reader[0].ToString();
                        }
                    }
                }
            }

            return jsonResult;
        }
        public List<TipoIdentificcionModel> GetIdentificationTypes() {
            try
            {
                DataTable types = ExecuteQuery("test_ObtenerTiposIdentificacion", new List<SqlParameter>());
                return types.ConvertDataTable<TipoIdentificcionModel>();
            }catch(Exception ex)
            {
                throw ex;
            }
        }
        public List<TipoUsuarioModel> GetUserTypes() {
            try
            {
                DataTable types = ExecuteQuery("test_ObtenerTiposUsuario", new List<SqlParameter>());
                return types.ConvertDataTable<TipoUsuarioModel>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<HabilidadModel> GetSkills() {
            try
            {
                DataTable types = ExecuteQuery("test_ObtenerHabilidades", new List<SqlParameter>());
                return types.ConvertDataTable<HabilidadModel>();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool ValidateUserLogin(LoginModel login)
        {
            try
            {
                DataTable userFound = ExecuteQuery("test_ValidarLoginUsuario", new List<SqlParameter>()
                {
                    new SqlParameter("@usuario", login.user),
                    new SqlParameter("@clave", login.pass)
                });

                return userFound.Rows.Count > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool CreateUser(UserModel user)
        {
            try
            {
                int i = ExecuteCommand("test_CrearUsuario", new List<SqlParameter>()
                {
                    new SqlParameter("@IdTipoIdentificacion", user.IdTipoIdentificacion),
                    new SqlParameter("@NumeroIdentificacion", user.NumeroIdentificacion),
                    new SqlParameter("@Nombre", user.Nombre),
                    new SqlParameter("@PrimerApellido", user.PrimerApellido),
                    new SqlParameter("@SegundoApellido", user.SegundoApellido),
                    new SqlParameter("@Usuario", user.Usuario),
                    new SqlParameter("@Clave", user.Clave),
                    new SqlParameter("@IdTipoUsuario", user.IdTipoUsuario),
                    new SqlParameter("@Correo", user.Correo),
                    new SqlParameter("@Telefonos", user.TelefonosString),
                    new SqlParameter("@Habilidades", user.HabilidadesString)
                });

                return i > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool UpdateUser(UserModel user)
        {
            try
            {
                int i = ExecuteCommand("test_ActualizarUsuario", new List<SqlParameter>()
                {
                    new SqlParameter("@IdUsuario", user.Id),
                    new SqlParameter("@IdTipoIdentificacion", user.IdTipoIdentificacion),
                    new SqlParameter("@NumeroIdentificacion", user.NumeroIdentificacion),
                    new SqlParameter("@Nombre", user.Nombre),
                    new SqlParameter("@PrimerApellido", user.PrimerApellido),
                    new SqlParameter("@SegundoApellido", user.SegundoApellido),
                    new SqlParameter("@Usuario", user.Usuario),
                    new SqlParameter("@Clave", user.Clave),
                    new SqlParameter("@IdTipoUsuario", user.IdTipoUsuario),
                    new SqlParameter("@Correo", user.Correo),
                    new SqlParameter("@Telefonos", user.TelefonosString),
                    new SqlParameter("@Habilidades", user.HabilidadesString)
                });

                return i > 0;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool DeleteUser(int userId)
        {
            try
            {
                int i = ExecuteCommand("test_EliminarUsuario", new List<SqlParameter>()
                {
                    new SqlParameter("@IdUsuario", userId)
                });

                return i > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<UserModel> GetAllUsers()
        {
            try
            {
                DataTable users = ExecuteQuery("test_ObtenerUsuarios", new List<SqlParameter>());
                return users.ConvertDataTable<UserModel>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public UserModel GetUserData(int userId)
        {
            try
            {
                DataTable user = ExecuteQuery("test_ObtenerDatosUsuario", new List<SqlParameter>()
                {
                    new SqlParameter("@idUsuario", userId)
                });
                
                UserModel userData = new UserModel();

                if(user.Rows.Count > 0)
                {
                    userData.Id = Convert.ToInt32(user.Rows[0]["Id"].ToString());
                    userData.IdTipoUsuario = Convert.ToInt32(user.Rows[0]["IdTipoUsuario"].ToString());
                    userData.TipoUsuario = user.Rows[0]["TipoUsuario"].ToString();
                    userData.IdTipoIdentificacion = Convert.ToInt32(user.Rows[0]["IdTipoIdentificacion"].ToString());
                    userData.NumeroIdentificacion = user.Rows[0]["NumeroIdentificacion"].ToString();
                    userData.Nombre = user.Rows[0]["Nombre"].ToString();
                    userData.PrimerApellido = user.Rows[0]["PrimerApellido"].ToString();
                    userData.SegundoApellido = user.Rows[0]["SegundoApellido"].ToString();
                    userData.Usuario = user.Rows[0]["Usuario"].ToString();
                    userData.Clave = user.Rows[0]["Clave"].ToString();
                    userData.Correo = user.Rows[0]["Correo"].ToString();
                    //userData.Telefonos = Convert.ToInt32(user.Rows[0][""].ToString());
                    //userData.Habilidades = Convert.ToInt32(user.Rows[0][""].ToString());
                    userData.imageUrl = "";
                }

                return userData;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<string> GetUserPhones(int userId)
        {
            try
            {
                DataTable phones = ExecuteQuery("test_ObtenerTelefonosXUsuario", new List<SqlParameter>()
                {
                    new SqlParameter("@idUsuario", userId)
                });

                List<string> lista = new List<string>();
                foreach(DataRow p in phones.Rows)
                {
                    lista.Add(p["Telefono"].ToString());
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<int> GetUserSkills(int userId)
        {
            try
            {
                DataTable skills = ExecuteQuery("test_ObtenerHabilidadesXUsuario", new List<SqlParameter>()
                {
                    new SqlParameter("@idUsuario", userId)
                });

                List<int> lista = new List<int>();
                foreach (DataRow p in skills.Rows)
                {
                    lista.Add(Convert.ToInt32(p["IdHabilidad"].ToString()));
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
