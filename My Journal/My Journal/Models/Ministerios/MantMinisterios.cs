using My_Journal.Models.IngresosCategoria;
using My_Journal.Models.Ofrenda;
using My_Journal.Properties;
using System.Data;
using System.Data.SqlClient;

namespace My_Journal.Models.Ministerios
{
    public class MantMinisterios
    {
        public string Insertar(Ministerios ministerios)
        {
            string valstring = string.Empty;
            string cnn = Utilidad.getConexString();
            try
            {
                using (SqlConnection connection = new SqlConnection(cnn))
                {
                    using (SqlCommand sqlCommand = new SqlCommand("[IGLESIA].pcdSetMinisterios", connection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddWithValue("@IdMinisterio", ministerios.IdMinisterio);
                        sqlCommand.Parameters.AddWithValue("@Nombre", ministerios.Nombre);
                        sqlCommand.Parameters.AddWithValue("@Descripcion", ministerios.Descripcion);
                        sqlCommand.Parameters.AddWithValue("@Estado", 1);
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
        public List<MinisteriosViewModel> GetListadoMinisterios(String desde, string hasta)
        {
            List<MinisteriosViewModel> resultado = new List<MinisteriosViewModel>();
            var cnn = Utilidad.getConexString();
            try
            {
                using (SqlConnection connection = new SqlConnection(cnn))
                {
                    using (SqlCommand sqlCommand = new SqlCommand("[IGLESIA].pcdGetListadoMinisterios", connection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddWithValue("@FechaIni", desde);
                        sqlCommand.Parameters.AddWithValue("@FechaFin", hasta);
                        connection.Open();
                        var dt = new DataTable();
                        dt.Load(sqlCommand.ExecuteReader());
                        resultado = (from DataRow dr in dt.Rows
                                     select new MinisteriosViewModel()
                                     {
                                         Ministerios = new Ministerios
                                         {
                                             IdMinisterio = int.Parse(dr["IdMinisterio"].ToString()),
                                             //IdDetalle = int.Parse(dr["IdCatOfrenda"].ToString()),
                                             Nombre = dr["Nombre"].ToString(),
                                             Descripcion = dr["Descripcion"].ToString(),
                                             UsuarioCreacion = dr["UsuarioCreacion"] != DBNull.Value ? int.Parse(dr["UsuarioCreacion"].ToString()) : (int?)null,
                                             FechaCreacion = dr["FechaCreacion"] != DBNull.Value ? DateTime.Parse(dr["FechaCreacion"].ToString()) : (DateTime?)null,
                                             UsuarioModifica = dr["UsuarioModifica"] != DBNull.Value ? int.Parse(dr["UsuarioModifica"].ToString()) : (int?)null,
                                             FechaModifica = dr["FechaModifica"] != DBNull.Value ? DateTime.Parse(dr["FechaModifica"].ToString()) : (DateTime?)null,
                                             Estado = int.Parse(dr["Estado"].ToString()),
                                         },
                                         MinisteriosDetalle = new MinisteriosDetalle.MinisteriosDetalle
                                         {
                                             IdDetalle = int.Parse(dr["IdDetalle"].ToString()),
                                             IdMinisterio = int.Parse(dr["IdMinisterio"].ToString()),
                                             IdUsuario = int.Parse(dr["IdUsuario"].ToString()),
                                             Ver = int.Parse(dr["Ver"].ToString()),
                                             Crear = int.Parse(dr["Crear"].ToString()),
                                             Editar = int.Parse(dr["Editar"].ToString()),
                                             Anular = int.Parse(dr["Anular"].ToString())
                                         },
                            
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
        public MinisteriosViewModel GetMinisterios(int id)
        {
            MinisteriosViewModel resultado = null;
            var cnn = Utilidad.getConexString();
            try
            {
                using (SqlConnection connection = new SqlConnection(cnn))
                {
                    using (SqlCommand sqlCommand = new SqlCommand("[IGLESIA].pcdGetMinisterios", connection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddWithValue("@IdMinisterio", id);
                        connection.Open();
                        var dt = new DataTable();
                        dt.Load(sqlCommand.ExecuteReader());
                        if (dt.Rows.Count > 0)
                        {
                            var dr = dt.Rows[0];
                            resultado = new MinisteriosViewModel
                            {
                                Ministerios = new Ministerios
                                {
                                    IdMinisterio = int.Parse(dr["IdMinisterio"].ToString()),
                                    //IdDetalle = int.Parse(dr["IdCatOfrenda"].ToString()),
                                    Nombre = dr["Nombre"].ToString(),
                                    Descripcion = dr["Descripcion"].ToString(),
                                    UsuarioCreacion = dr["UsuarioCreacion"] != DBNull.Value ? int.Parse(dr["UsuarioCreacion"].ToString()) : (int?)null,
                                    FechaCreacion = dr["FechaCreacion"] != DBNull.Value ? DateTime.Parse(dr["FechaCreacion"].ToString()) : (DateTime?)null,
                                    UsuarioModifica = dr["UsuarioModifica"] != DBNull.Value ? int.Parse(dr["UsuarioModifica"].ToString()) : (int?)null,
                                    FechaModifica = dr["FechaModifica"] != DBNull.Value ? DateTime.Parse(dr["FechaModifica"].ToString()) : (DateTime?)null,
                                    Estado = int.Parse(dr["Estado"].ToString()),
                                },
                                MinisteriosDetalle = new MinisteriosDetalle.MinisteriosDetalle
                                {
                                    IdDetalle = int.Parse(dr["IdDetalle"].ToString()),
                                    IdMinisterio = int.Parse(dr["IdMinisterio"].ToString()),
                                    IdUsuario = int.Parse(dr["IdUsuario"].ToString()),
                                    Ver = int.Parse(dr["Ver"].ToString()),
                                    Crear = int.Parse(dr["Crear"].ToString()),
                                    Editar = int.Parse(dr["Editar"].ToString()),
                                    Anular = int.Parse(dr["Anular"].ToString())
                                },
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

        public List<Ministerios> Getlistado()
        {
            List<Ministerios> resultado = new List<Ministerios>();
            var cnn = Utilidad.getConexString();
            try
            {
                using (SqlConnection connection = new SqlConnection(cnn))
                {
                    using (SqlCommand sqlCommand = new SqlCommand("[IGLESIA].pcdGetMinisteriosLista", connection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        connection.Open();
                        var dt = new DataTable();
                        dt.Load(sqlCommand.ExecuteReader());
                        resultado = (from DataRow dr in dt.Rows
                                     select new Ministerios()
                                     {
                                         IdMinisterio = int.Parse(dr["IdMinisterio"].ToString()),
                                         Nombre = dr["Nombre"].ToString(),
                                         Descripcion = dr["Descripcion"].ToString(),
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
        //public string Editar(MinisteriosViewModel ministeriosViewModel)
        //{
        //    string valstring = string.Empty;
        //    string cnn = Utilidad.getConexString();
        //    try
        //    {
        //        using (SqlConnection connection = new SqlConnection(cnn))
        //        {
        //            using (SqlCommand sqlCommand = new SqlCommand("[IGLESIA].pcdSetMinisteriosEdit", connection))
        //            {
        //                sqlCommand.CommandType = CommandType.StoredProcedure;
        //                sqlCommand.Parameters.AddWithValue("@IdCategoria", ofrendaViewModel.OfrendaCategoria.IdCatOfrenda);
        //                sqlCommand.Parameters.AddWithValue("@Descripcion", ofrendaViewModel.Ofrenda.Descripcion);
        //                sqlCommand.Parameters.AddWithValue("@Cantidad", ofrendaViewModel.Ofrenda.Cantidad);
        //                sqlCommand.Parameters.AddWithValue("@Fecha", ofrendaViewModel.Ofrenda.Fecha);
        //                sqlCommand.Parameters.AddWithValue("@IdDivisa", ofrendaViewModel.Divisa.IdDivisa);
        //                sqlCommand.Parameters.AddWithValue("@TasaCambio", ofrendaViewModel.Ofrenda.TasaCambio);
        //                sqlCommand.Parameters.AddWithValue("@Estado", 1);
        //                sqlCommand.Parameters.AddWithValue("@IdUsuario", 1);
        //                sqlCommand.Parameters.AddWithValue("@IdOfrenda", ofrendaViewModel.Ofrenda.IdOfrenda);

        //                connection.Open();
        //                sqlCommand.ExecuteNonQuery();
        //                connection.Close();
        //                //if (Cod.Value.ToString() != string.Empty)
        //                //{
        //                //    var _resource = new ResourceManager(typeof(strings));
        //                //    string res = _resource.GetString(Cod.Value.ToString());
        //                //    valstring = res;
        //                //}
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        valstring = "ERROR";
        //        //Utilidad.Ubicacion = clase + System.Reflection.MethodBase.GetCurrentMethod().Name;
        //        //Utilidad.GuardarLog(ex.Message, Utilidad.objectToString(registro));
        //    }
        //    return valstring;
        //}


    }
}
