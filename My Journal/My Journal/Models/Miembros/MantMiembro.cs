using Microsoft.Data.SqlClient;
using My_Journal.Models.Ofrenda;
using My_Journal.Properties;
using System.Data;

namespace My_Journal.Models.Miembros
{
    public class MantMiembro
    {
        public MantMiembro()
        {
        }
        public List<Miembro> GetListadoMiembros(String desde, string hasta)
        {
            List<Miembro> resultado = new List<Miembro>();
            var cnn = Utilidad.getConexString();
            try
            {
                using (SqlConnection connection = new SqlConnection(cnn))
                {
                    using (SqlCommand sqlCommand = new SqlCommand("[IGLESIA].pcdGetListadoMiembros", connection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddWithValue("@FechaIni", desde);
                        sqlCommand.Parameters.AddWithValue("@FechaFin", hasta);
                        connection.Open();
                        var dt = new DataTable();
                        dt.Load(sqlCommand.ExecuteReader());
                        resultado = (from DataRow dr in dt.Rows
                                     select new Miembro()
                                     {
                                            IdMiembro = int.Parse(dr["IdMiembro"].ToString()),
                                            Nombre = dr["Nombre"].ToString(),
                                            Apellido = dr["Apellido"].ToString(),
                                            Direccion = dr["Direccion"].ToString(),
                                            Telefono = dr["Telefono"].ToString(),
                                            FechaNacimiento = DateTime.Parse(dr["FechaNacimiento"].ToString()),
                                            FechaBautismo = DateTime.Parse(dr["FechaBautismo"].ToString()),
                                            Estado = int.Parse(dr["Estado"].ToString()),
                                         
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

        public string Insertar(Miembro miembro)
        {
            string valstring = string.Empty;
            string cnn = Utilidad.getConexString();
            try
            {
                using (SqlConnection connection = new SqlConnection(cnn))
                {
                    using (SqlCommand sqlCommand = new SqlCommand("[IGLESIA].pcdSetMiembros", connection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddWithValue("@nombre", miembro.Nombre);
                        sqlCommand.Parameters.AddWithValue("@apellido", miembro.Apellido);
                        sqlCommand.Parameters.AddWithValue("@direccion", miembro.Direccion);
                        sqlCommand.Parameters.AddWithValue("@telefono", miembro.Telefono);
                        sqlCommand.Parameters.AddWithValue("@FechaNaci", miembro.FechaNacimiento);
                        sqlCommand.Parameters.AddWithValue("@FechaBauti", miembro.FechaBautismo);
                        sqlCommand.Parameters.AddWithValue("@IdUsuario", 1);

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

        public Miembro GetMiembro(int id)
        {
            Miembro resultado = null;
            var cnn = Utilidad.getConexString();
            try
            {
                using (SqlConnection connection = new SqlConnection(cnn))
                {
                    using (SqlCommand sqlCommand = new SqlCommand("[IGLESIA].pcdGetMiembro", connection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddWithValue("@IdMiembro", id);
                        connection.Open();
                        var dt = new DataTable();
                        dt.Load(sqlCommand.ExecuteReader());
                        resultado = (from DataRow dr in dt.Rows
                                     select new Miembro()
                                     {
                                         IdMiembro = int.Parse(dr["IdMiembro"].ToString()),
                                         Nombre = dr["Nombre"].ToString(),
                                         Apellido = dr["Apellido"].ToString(),
                                         Direccion = dr["Direccion"].ToString(),
                                         Telefono = dr["Telefono"].ToString(),
                                         FechaNacimiento = DateTime.Parse(dr["FechaNacimiento"].ToString()),
                                         FechaBautismo = DateTime.Parse(dr["FechaBautismo"].ToString()),
                                         Estado = int.Parse(dr["Estado"].ToString()),

                                     }).Single();
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

        public string Editar(Miembro miembro)
        {
            string valstring = string.Empty;
            string cnn = Utilidad.getConexString();
            try
            {
                using (SqlConnection connection = new SqlConnection(cnn))
                {
                    using (SqlCommand sqlCommand = new SqlCommand("[IGLESIA].pcdSetMiembroEdit", connection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddWithValue("@IdMiembro", miembro.IdMiembro);
                        sqlCommand.Parameters.AddWithValue("@nombre", miembro.Nombre);
                        sqlCommand.Parameters.AddWithValue("@apellido", miembro.Apellido);
                        sqlCommand.Parameters.AddWithValue("@direccion", miembro.Direccion);
                        sqlCommand.Parameters.AddWithValue("@telefono", miembro.Telefono);
                        sqlCommand.Parameters.AddWithValue("@FechaNaci", miembro.FechaNacimiento);
                        sqlCommand.Parameters.AddWithValue("@FechaBauti", miembro.FechaBautismo);
                        sqlCommand.Parameters.AddWithValue("@Estado", miembro.Estado);
                        sqlCommand.Parameters.AddWithValue("@IdUsuario", 1);

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

        public List<Miembro> Getlistado()
        {
            List<Miembro> resultado = new List<Miembro>();
            var cnn = Utilidad.getConexString();
            try
            {
                using (SqlConnection connection = new SqlConnection(cnn))
                {
                    using (SqlCommand sqlCommand = new SqlCommand("[IGLESIA].pcdGetMiembros", connection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        connection.Open();
                        var dt = new DataTable();
                        dt.Load(sqlCommand.ExecuteReader());
                        resultado = (from DataRow dr in dt.Rows
                                     select new Miembro()
                                     {
                                         IdMiembro = int.Parse(dr["IdMiembro"].ToString()),
                                         Nombre = dr["Nombre"].ToString(),
                                         Apellido = dr["Apellido"].ToString(),
                                         Estado = int.Parse(dr["Estado"].ToString())
                                     }).ToList();
                        connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                //Utilidad.Ubicacion = clase + System.Reflection.MethodBase.GetCurrentMethod().Name;
                //Utilidad.GuardarLog(ex.Message, string.Empty);
            }
            return resultado;
        }
    }
}
