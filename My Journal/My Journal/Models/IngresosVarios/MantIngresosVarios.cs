using My_Journal.Properties;
using System.Data;
using System.Data.SqlClient;

namespace My_Journal.Models.IngresosVarios
{
    public class MantIngresosVarios
    {
        public MantIngresosVarios()
        {
        }
        public string Insertar(IngresosVario ingresos)
        {
            string valstring = string.Empty;
            string cnn = Utilidad.getConexString();
            try
            {
                using (SqlConnection connection = new SqlConnection(cnn))
                {
                    using (SqlCommand sqlCommand = new SqlCommand("[IGLESIA].pcdSetIngresosVarios", connection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddWithValue("@IdCatIngreso", ingresos.IdCatIngreso);
                        sqlCommand.Parameters.AddWithValue("@IdMinisterio", ingresos.IdMinisterio);
                        sqlCommand.Parameters.AddWithValue("@Descripcion", ingresos.Descripcion);
                        sqlCommand.Parameters.AddWithValue("@Cantidad", ingresos.Cantidad);
                        sqlCommand.Parameters.AddWithValue("@FechaIngreso", ingresos.FechaIngreso);
                        sqlCommand.Parameters.AddWithValue("@IdDivisa", ingresos.Divisa);
                        sqlCommand.Parameters.AddWithValue("@TasaCambio", ingresos.TasaCambio);
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

        public IngresosVariosViewModel GetIngresos(int id)
        {
            IngresosVariosViewModel resultado = null;
            var cnn = Utilidad.getConexString();
            try
            {
                using (SqlConnection connection = new SqlConnection(cnn))
                {
                    using (SqlCommand sqlCommand = new SqlCommand("[IGLESIA].pcdGetIngreso", connection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddWithValue("@IdIngreVarios", id);
                        connection.Open();
                        var dt = new DataTable();
                        dt.Load(sqlCommand.ExecuteReader());
                        if (dt.Rows.Count > 0)
                        {
                            var dr = dt.Rows[0];
                            resultado = new IngresosVariosViewModel
                            {
                                IngresosVario = new IngresosVario
                                {
                                    IdIngreVarios = int.Parse(dr["IdIngreVarios"].ToString()),
                                    IdCatIngreso = int.Parse(dr["IdCatIngreso"].ToString()),
                                    IdMinisterio = int.Parse(dr["IdMinisterio"].ToString()),
                                    Cantidad = double.Parse(dr["Cantidad"].ToString()),
                                    Descripcion = dr["Descripcion"].ToString(),
                                    FechaIngreso = DateTime.Parse(dr["FechaIngreso"].ToString()),
                                    Divisa = int.Parse(dr["Divisa"].ToString()),
                                    TasaCambio = double.Parse(dr["TasaCambio"].ToString()),
                                    Estado = int.Parse(dr["Estado"].ToString()),
                                },
                                IngresoCategoria = new IngresosCategoria.IngresoCategoria
                                {
                                    IdCatIngreso = int.Parse(dr["IdCatIngreso"].ToString()),
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

        public string Editar(IngresosVariosViewModel ingresosVariosViewModel)
        {
            string valstring = string.Empty;
            string cnn = Utilidad.getConexString();
            try
            {
                using (SqlConnection connection = new SqlConnection(cnn))
                {
                    using (SqlCommand sqlCommand = new SqlCommand("[IGLESIA].pcdSetIngresoVariosEdit", connection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddWithValue("@IdCatIngreso", ingresosVariosViewModel.IngresoCategoria.IdCatIngreso);
                        sqlCommand.Parameters.AddWithValue("@IdMinisterio", ingresosVariosViewModel.Ministerios.IdMinisterio);
                        sqlCommand.Parameters.AddWithValue("@Descripcion", ingresosVariosViewModel.IngresosVario.Descripcion);
                        sqlCommand.Parameters.AddWithValue("@Cantidad", ingresosVariosViewModel.IngresosVario.Cantidad);
                        sqlCommand.Parameters.AddWithValue("@FechaIngreso", ingresosVariosViewModel.IngresosVario.FechaIngreso);
                        sqlCommand.Parameters.AddWithValue("@IdDivisa", ingresosVariosViewModel.Divisa.IdDivisa);
                        sqlCommand.Parameters.AddWithValue("@TasaCambio", ingresosVariosViewModel.IngresosVario.TasaCambio);
                        sqlCommand.Parameters.AddWithValue("@Estado", 1);
                        sqlCommand.Parameters.AddWithValue("@IdUsuario", 1);
                        sqlCommand.Parameters.AddWithValue("@IdIngreVarios", ingresosVariosViewModel.IngresosVario.IdIngreVarios);

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

        public String AnularIngreVarios(int id)
        {
            string valstring = string.Empty;
            string cnn = Utilidad.getConexString();
            try
            {
                using (SqlConnection connection = new SqlConnection(cnn))
                {
                    using (SqlCommand sqlCommand = new SqlCommand("[IGLESIA].pcdGetAnularIngreVarios", connection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddWithValue("@IdIngreVarios", id);
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

        public List<IngresosVariosViewModel> GetListadoIngresosVarios(String desde, string hasta)
        {
            List<IngresosVariosViewModel> resultado = new List<IngresosVariosViewModel>();
            var cnn = Utilidad.getConexString();
            try
            {
                using (SqlConnection connection = new SqlConnection(cnn))
                {
                    using (SqlCommand sqlCommand = new SqlCommand("[IGLESIA].pcdGetListadoIngresosVarios", connection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddWithValue("@FechaIni", desde);
                        sqlCommand.Parameters.AddWithValue("@FechaFin", hasta);
                        connection.Open();
                        var dt = new DataTable();
                        dt.Load(sqlCommand.ExecuteReader());
                        resultado = (from DataRow dr in dt.Rows
                                     select new IngresosVariosViewModel()
                                     {
                                         IngresosVario = new IngresosVario
                                         {
                                             IdIngreVarios = int.Parse(dr["IdIngreVarios"].ToString()),
                                             IdCatIngreso = int.Parse(dr["IdCatIngreso"].ToString()),
                                             IdMinisterio = int.Parse(dr["IdMinisterio"].ToString()),
                                             Cantidad = double.Parse(dr["Cantidad"].ToString()),
                                             Descripcion = dr["Descripcion"].ToString(),
                                             FechaIngreso = DateTime.Parse(dr["FechaIngreso"].ToString()),
                                             Divisa = int.Parse(dr["Divisa"].ToString()),
                                             TasaCambio = double.Parse(dr["TasaCambio"].ToString()),
                                             Estado = int.Parse(dr["Estado"].ToString()),
                                         },
                                         IngresoCategoria = new IngresosCategoria.IngresoCategoria
                                         {
                                             IdCatIngreso = int.Parse(dr["IdCatIngreso"].ToString()),
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
