using Microsoft.Data.SqlClient;
using My_Journal.Models.Ofrenda;
using My_Journal.Properties;
using System.Data;

namespace My_Journal.Models.Diezmos
{
    public class MantDiezmo
    {
        public MantDiezmo() { }

        public List<DiezmoViewModel> GetListadoDiezmo(String desde, string hasta)
        {
            List<DiezmoViewModel> resultado = new List<DiezmoViewModel>();
            var cnn = Utilidad.getConexString();
            try
            {
                using (SqlConnection connection = new SqlConnection(cnn))
                {
                    using (SqlCommand sqlCommand = new SqlCommand("[IGLESIA].pcdGetListadoDiezmo", connection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddWithValue("@FechaIni", desde);
                        sqlCommand.Parameters.AddWithValue("@FechaFin", hasta);
                        connection.Open();
                        var dt = new DataTable();
                        dt.Load(sqlCommand.ExecuteReader());
                        resultado = (from DataRow dr in dt.Rows
                                     select new DiezmoViewModel()
                                     {
                                         Diezmo = new Diezmo
                                         {
                                             IdDiezmo = int.Parse(dr["IdDiezmo"].ToString()),
                                             IdMiembro = int.Parse(dr["IdMiembro"].ToString()),
                                             Cantidad = double.Parse(dr["Cantidad"].ToString()),
                                             Descripcion = dr["Descripcion"].ToString(),
                                             FechaDiezmo = DateTime.Parse(dr["FechaDiezmo"].ToString()),
                                             Divisa = int.Parse(dr["Divisa"].ToString()),
                                             TasaCambio = double.Parse(dr["TasaCambio"].ToString()),
                                             Estado = int.Parse(dr["Estado"].ToString()),
                                             Alias = dr["Alias"].ToString(),
                                         },
                                         Miembro = new Miembros.Miembro
                                         {
                                             IdMiembro = int.Parse(dr["IdMiembro"].ToString()),
                                             Nombre = dr["Nombre"].ToString(),
                                         },
                                         Divisa = new Divisa.Divisa
                                         {
                                             IdDivisa = int.Parse(dr["IdDivisa"].ToString()),
                                             CodDivisa = dr["CodDivisa"].ToString(),
                                             Descripcion = dr["Divisa"].ToString()
                                         }
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

        public string Insertar(Diezmo diezmo)
        {
            string valstring = string.Empty;
            string cnn = Utilidad.getConexString();
            try
            {
                using (SqlConnection connection = new SqlConnection(cnn))
                {
                    using (SqlCommand sqlCommand = new SqlCommand("[IGLESIA].pcdSetDiezmos", connection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddWithValue("@IdMiembro", diezmo.IdMiembro);
                        sqlCommand.Parameters.AddWithValue("@Alias", diezmo.Alias ?? (object)DBNull.Value);
                        sqlCommand.Parameters.AddWithValue("@Descripcion", diezmo.Descripcion ?? (object)DBNull.Value);
                        sqlCommand.Parameters.AddWithValue("@Cantidad", diezmo.Cantidad);
                        sqlCommand.Parameters.AddWithValue("@Fecha", diezmo.FechaDiezmo);
                        sqlCommand.Parameters.AddWithValue("@IdDivisa", diezmo.Divisa);
                        sqlCommand.Parameters.AddWithValue("@TasaCambio", diezmo.TasaCambio);
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

        public DiezmoViewModel GetDiezmo(int id)
        {
            DiezmoViewModel resultado = new DiezmoViewModel();
            var cnn = Utilidad.getConexString();
            try
            {
                using (SqlConnection connection = new SqlConnection(cnn))
                {
                    using (SqlCommand sqlCommand = new SqlCommand("[IGLESIA].pcdGetDiezmo", connection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddWithValue("@IdDiezmo", id);
                        connection.Open();
                        var dt = new DataTable();
                        dt.Load(sqlCommand.ExecuteReader());
                        resultado = (from DataRow dr in dt.Rows
                                     select new DiezmoViewModel()
                                     {
                                         Diezmo = new Diezmo
                                         {
                                             IdDiezmo = int.Parse(dr["IdDiezmo"].ToString()),
                                             IdMiembro = int.Parse(dr["IdMiembro"].ToString()),
                                             Cantidad = double.Parse(dr["Cantidad"].ToString()),
                                             Descripcion = dr["Descripcion"].ToString(),
                                             FechaDiezmo = DateTime.Parse(dr["FechaDiezmo"].ToString()),
                                             Divisa = int.Parse(dr["Divisa"].ToString()),
                                             TasaCambio = double.Parse(dr["TasaCambio"].ToString()),
                                             Estado = int.Parse(dr["Estado"].ToString()),
                                             Alias = dr["Alias"].ToString(),
                                         },
                                         Miembro = new Miembros.Miembro
                                         {
                                             IdMiembro = int.Parse(dr["IdMiembro"].ToString()),
                                             Nombre = dr["Nombre"].ToString(),
                                         },
                                         Divisa = new Divisa.Divisa
                                         {
                                             IdDivisa = int.Parse(dr["IdDivisa"].ToString()),
                                             CodDivisa = dr["CodDivisa"].ToString(),
                                             Descripcion = dr["Divisa"].ToString()
                                         }
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

        public string Editar(DiezmoViewModel diezmoViewModel)
        {
            string valstring = string.Empty;
            string cnn = Utilidad.getConexString();
            try
            {
                using (SqlConnection connection = new SqlConnection(cnn))
                {
                    using (SqlCommand sqlCommand = new SqlCommand("[IGLESIA].pcdSetDiezmoEdit", connection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddWithValue("@IdDiezmo", diezmoViewModel.Diezmo.IdDiezmo);
                        sqlCommand.Parameters.AddWithValue("@IdMiembro", diezmoViewModel.Miembro.IdMiembro);
                        sqlCommand.Parameters.AddWithValue("@Alias", diezmoViewModel.Diezmo.Alias ?? (object)DBNull.Value);
                        sqlCommand.Parameters.AddWithValue("@Descripcion", diezmoViewModel.Diezmo.Descripcion ?? (object)DBNull.Value);
                        sqlCommand.Parameters.AddWithValue("@Cantidad", diezmoViewModel.Diezmo.Cantidad);
                        sqlCommand.Parameters.AddWithValue("@Fecha", diezmoViewModel.Diezmo.FechaDiezmo);
                        sqlCommand.Parameters.AddWithValue("@IdDivisa", diezmoViewModel.Divisa.IdDivisa);
                        sqlCommand.Parameters.AddWithValue("@TasaCambio", diezmoViewModel.Diezmo.TasaCambio);
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

        public String AnularDiezmo(int id)
        {
            string valstring = string.Empty;
            string cnn = Utilidad.getConexString();
            try
            {
                using (SqlConnection connection = new SqlConnection(cnn))
                {
                    using (SqlCommand sqlCommand = new SqlCommand("[IGLESIA].pcdGetAnularDiezmo", connection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddWithValue("@IdDiezmo", id);
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
    }
}
