using My_Journal.Models.Ofrenda;
using My_Journal.Models.Pagos;
using My_Journal.Properties;
using System.Data;
using System.Data.SqlClient;

namespace My_Journal.Models.Usuario
{
    public class MantUsuario
    {
        public string Insertar(Usuario usuario)
        {
            string valstring = string.Empty;
            string cnn = Utilidad.getConexString();
            try
            {
                using (SqlConnection connection = new SqlConnection(cnn))
                {
                    using (SqlCommand sqlCommand = new SqlCommand("[IGLESIA].pcdSetUsuario", connection))
                    {
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddWithValue("@IdUsuario", usuario.IdUsuario);
                        sqlCommand.Parameters.AddWithValue("@Nombres", usuario.Nombres);
                        sqlCommand.Parameters.AddWithValue("@Apellidos", usuario.Apellidos);
                        sqlCommand.Parameters.AddWithValue("@Telefono", usuario.Telefono);
                        sqlCommand.Parameters.AddWithValue("@Direccion", usuario.Direccion);
                        sqlCommand.Parameters.AddWithValue("@Usuario", usuario.Usuario1);
                        sqlCommand.Parameters.AddWithValue("@Clave", usuario.Clave);
                        sqlCommand.Parameters.AddWithValue("@Estado", usuario.Estado);

                        connection.Open();
                        sqlCommand.ExecuteNonQuery();
                        connection.Close();
                        //if (Cod.Value.ToString() != string.Empty)
                        //{
                        //    var _resource = new ResourceManager(typeof(strings));
                        //    string res = _resource.GetString(Cod.Value.ToString());
                        //    valstring = res;
                        //}
                    }
                }
            }
            catch (Exception ex)
            {
                valstring = "ERROR";
                //Utilidad.Ubicacion = clase + System.Reflection.MethodBase.GetCurrentMethod().Name;
                //Utilidad.GuardarLog(ex.Message, Utilidad.objectToString(registro));
            }
            return valstring;
        }
        public List<Usuario> GetListadoUsuarios()
        {
            List<Usuario> resultado = new List<Usuario>();
            var cnn = Utilidad.getConexString();
            try
            {
                using (SqlConnection connection = new SqlConnection(cnn))
                {
                    using (SqlCommand sqlCommand = new SqlCommand("[IGLESIA].pcdGetListadoUsuarios", connection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        connection.Open();
                        var dt = new DataTable();
                        dt.Load(sqlCommand.ExecuteReader());
                        resultado = (from DataRow dr in dt.Rows
                                     select new Usuario()
                                     {
                                        IdUsuario = int.Parse(dr["IdUsuario"].ToString()),
                                        Nombres = dr["Nombres"].ToString(),
                                        Apellidos = dr["Apellidos"].ToString(),
                                        Telefono = dr["Telefono"].ToString(),
                                        Direccion = dr["Direccion"].ToString(),
                                        Usuario1 = dr["Usuario"].ToString(),
                                        Estado = bool.Parse(dr["Estado"].ToString()),
                                        Clave = dr["Clave"].ToString()

                                     }).ToList();
                        connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejar la excepción según sea necesario
            }
            return resultado;
        }
        public Usuario GetUsuario(int id)
        {
            Usuario resultado = null;
            var cnn = Utilidad.getConexString();
            try
            {
                using (SqlConnection connection = new SqlConnection(cnn))
                {
                    using (SqlCommand sqlCommand = new SqlCommand("[IGLESIA].pcdGetUsuario", connection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddWithValue("@IdUsuario", id);
                        connection.Open();
                        var dt = new DataTable();
                        dt.Load(sqlCommand.ExecuteReader());
                        if (dt.Rows.Count > 0)
                        {
                            var dr = dt.Rows[0];
                            resultado = new Usuario
                            {

                                IdUsuario = int.Parse(dr["IdUsuario"].ToString()),
                                Nombres = dr["Nombres"].ToString(),
                                Apellidos = dr["Apellidos"].ToString(),
                                Telefono = dr["Telefono"].ToString(),
                                Direccion = dr["Direccion"].ToString(),
                                Usuario1 = dr["Usuario"].ToString(),
                                Estado = bool.Parse(dr["Estado"].ToString()),
                                Clave = dr["Clave"].ToString(),
                                UsuarioCreacion = dr["UsuarioCreacion"] != DBNull.Value ? int.Parse(dr["UsuarioCreacion"].ToString()) : (int?)null,
                                FechaCreacion = dr["FechaCreacion"] != DBNull.Value ? DateTime.Parse(dr["FechaCreacion"].ToString()) : (DateTime?)null,
                                UsuarioModifica = dr["UsuarioModifica"] != DBNull.Value ? int.Parse(dr["UsuarioModifica"].ToString()) : (int?)null,
                                FechaModifica = dr["FechaModifica"] != DBNull.Value ? DateTime.Parse(dr["FechaModifica"].ToString()) : (DateTime?)null,


                            };
                        }
                        connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejar la excepción según sea necesario
            }
            return resultado;
        }

    }
}
