using My_Journal.Models.IngresosVarios;
using My_Journal.Properties;
using System.Data;
using System.Data.SqlClient;

namespace My_Journal.Models.EgresosVarios
{
    public class MantEgresosVarios
    {
        public MantEgresosVarios()
        {
        }
        public string Insertar(EgresosVario egresos)
        {
            string valstring = string.Empty;
            string cnn = Utilidad.getConexString();
            try
            {
                using (SqlConnection connection = new SqlConnection(cnn))
                {
                    using (SqlCommand sqlCommand = new SqlCommand("[IGLESIA].pcdSetEgresosVarios", connection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddWithValue("@IdCatEgreso", egresos.IdCatEgreso);
                        sqlCommand.Parameters.AddWithValue("@IdMinisterio", egresos.IdMinisterio);
                        sqlCommand.Parameters.AddWithValue("@Descripcion", egresos.Descripcion);
                        sqlCommand.Parameters.AddWithValue("@Cantidad", egresos.Cantidad);
                        sqlCommand.Parameters.AddWithValue("@FechaEgreso", egresos.FechaEgreso);
                        sqlCommand.Parameters.AddWithValue("@IdDivisa", egresos.Divisa);
                        sqlCommand.Parameters.AddWithValue("@TasaCambio", egresos.TasaCambio);
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

        public EgresosVariosViewModel GetEgresos(int id)
        {
            EgresosVariosViewModel resultado = null;
            var cnn = Utilidad.getConexString();
            try
            {
                using (SqlConnection connection = new SqlConnection(cnn))
                {
                    using (SqlCommand sqlCommand = new SqlCommand("[IGLESIA].pcdGetEgreso", connection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddWithValue("@IdEgreVarios", id);
                        connection.Open();
                        var dt = new DataTable();
                        dt.Load(sqlCommand.ExecuteReader());
                        if (dt.Rows.Count > 0)
                        {
                            var dr = dt.Rows[0];
                            resultado = new EgresosVariosViewModel
                            {
                               EgresosVario = new EgresosVario
                                {
                                    IdEgreVarios = int.Parse(dr["IdEgreVarios"].ToString()),
                                    IdCatEgreso = int.Parse(dr["IdCatEgreso"].ToString()),
                                    IdMinisterio = int.Parse(dr["IdMinisterio"].ToString()),
                                    Cantidad = double.Parse(dr["Cantidad"].ToString()),
                                    Descripcion = dr["Descripcion"].ToString(),
                                    FechaEgreso = DateTime.Parse(dr["FechaEgreso"].ToString()),
                                    Divisa = int.Parse(dr["Divisa"].ToString()),
                                    TasaCambio = double.Parse(dr["TasaCambio"].ToString()),
                                    Estado = int.Parse(dr["Estado"].ToString()),
                                },
                                EgresoCategoria = new EgresosCategoria.EgresoCategoria
                                {
                                    IdCatEgreso = int.Parse(dr["IdCatEgreso"].ToString()),
                                    Nombre = dr["CategoriaNombre"].ToString(),
                                    Descripcion = dr["CategoriaDescripcion"].ToString()
                                },
                                Ministerios = new Ministerios.Ministerios
                                {
                                    IdMinisterio = int.Parse(dr["IdMinisterio"].ToString()),
                                    Nombre = dr["MinisterioNombre"].ToString(),
                                    Descripcion = dr["MinisterioDescripcion"].ToString()
                                },
                                Divisa = new Divisa.Divisa
                                {
                                    IdDivisa = int.Parse(dr["IdDivisa"].ToString()),
                                    CodDivisa = dr["CodDivisa"].ToString(),
                                    Descripcion = dr["Divisa"].ToString()
                                }
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

        public string Editar(EgresosVariosViewModel egresosVariosViewModel)
        {
            string valstring = string.Empty;
            string cnn = Utilidad.getConexString();
            try
            {
                using (SqlConnection connection = new SqlConnection(cnn))
                {
                    using (SqlCommand sqlCommand = new SqlCommand("[IGLESIA].pcdSetEgresoVariosEdit", connection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddWithValue("@IdCatEgreso", egresosVariosViewModel.EgresoCategoria.IdCatEgreso);
                        sqlCommand.Parameters.AddWithValue("@IdMinisterio", egresosVariosViewModel.Ministerios.IdMinisterio);
                        sqlCommand.Parameters.AddWithValue("@Descripcion", egresosVariosViewModel.EgresosVario.Descripcion);
                        sqlCommand.Parameters.AddWithValue("@Cantidad", egresosVariosViewModel.EgresosVario.Cantidad);
                        sqlCommand.Parameters.AddWithValue("@FechaEgreso", egresosVariosViewModel.EgresosVario.FechaEgreso);
                        sqlCommand.Parameters.AddWithValue("@IdDivisa", egresosVariosViewModel.Divisa.IdDivisa);
                        sqlCommand.Parameters.AddWithValue("@TasaCambio", egresosVariosViewModel.EgresosVario.TasaCambio);
                        sqlCommand.Parameters.AddWithValue("@Estado", 1);
                        sqlCommand.Parameters.AddWithValue("@IdUsuario", 1);
                        sqlCommand.Parameters.AddWithValue("@IdEgreVarios", egresosVariosViewModel.EgresosVario.IdEgreVarios);

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

        public String AnularEgreVarios(int id)
        {
            string valstring = string.Empty;
            string cnn = Utilidad.getConexString();
            try
            {
                using (SqlConnection connection = new SqlConnection(cnn))
                {
                    using (SqlCommand sqlCommand = new SqlCommand("[IGLESIA].pcdGetAnularEgreVarios", connection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddWithValue("@IdEgreVarios", id);
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

        public List<EgresosVariosViewModel> GetListadoEgresosVarios(String desde, string hasta)
        {
            List<EgresosVariosViewModel> resultado = new List<EgresosVariosViewModel>();
            var cnn = Utilidad.getConexString();
            try
            {
                using (SqlConnection connection = new SqlConnection(cnn))
                {
                    using (SqlCommand sqlCommand = new SqlCommand("[IGLESIA].pcdGetListadoEgresosVarios", connection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddWithValue("@FechaIni", desde);
                        sqlCommand.Parameters.AddWithValue("@FechaFin", hasta);
                        connection.Open();
                        var dt = new DataTable();
                        dt.Load(sqlCommand.ExecuteReader());
                        resultado = (from DataRow dr in dt.Rows
                                     select new EgresosVariosViewModel()
                                     {
                                        EgresosVario = new EgresosVario
                                         {
                                             IdEgreVarios = int.Parse(dr["IdEgreVarios"].ToString()),
                                             IdCatEgreso = int.Parse(dr["IdCatEgreso"].ToString()),
                                             IdMinisterio = int.Parse(dr["IdMinisterio"].ToString()),
                                             Cantidad = double.Parse(dr["Cantidad"].ToString()),
                                             Descripcion = dr["Descripcion"].ToString(),
                                             FechaEgreso = DateTime.Parse(dr["FechaEgreso"].ToString()),
                                             Divisa = int.Parse(dr["Divisa"].ToString()),
                                             TasaCambio = double.Parse(dr["TasaCambio"].ToString()),
                                             Estado = int.Parse(dr["Estado"].ToString()),
                                         },
                                        EgresoCategoria = new EgresosCategoria.EgresoCategoria
                                         {
                                             IdCatEgreso = int.Parse(dr["IdCatEgreso"].ToString()),
                                             Nombre = dr["CategoriaNombre"].ToString(),
                                             Descripcion = dr["CategoriaDescripcion"].ToString()
                                         },
                                         Ministerios = new Ministerios.Ministerios
                                         {
                                             IdMinisterio = int.Parse(dr["IdMinisterio"].ToString()),
                                             Nombre = dr["MinisterioNombre"].ToString(),
                                             Descripcion = dr["MinisterioDescripcion"].ToString()
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
    }
}
