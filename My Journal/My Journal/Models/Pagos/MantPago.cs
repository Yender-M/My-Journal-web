using Microsoft.Data.SqlClient;
using My_Journal.Models.Ofrenda;
using My_Journal.Properties;
using System.Data;

namespace My_Journal.Models.Pagos
{
    public class MantPago
    {
        public MantPago()
        {
        }
        public string Insertar(Pago pago)
        {
            string valstring = string.Empty;
            string cnn = Utilidad.getConexString();
            try
            {
                using (SqlConnection connection = new SqlConnection(cnn))
                {
                    using (SqlCommand sqlCommand = new SqlCommand("[IGLESIA].pcdSetPago", connection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddWithValue("@IdCategoria", pago.IdCategoria);
                        sqlCommand.Parameters.AddWithValue("@Descripcion", pago.Descripcion);
                        sqlCommand.Parameters.AddWithValue("@Cantidad", pago.Cantidad);
                        sqlCommand.Parameters.AddWithValue("@Fecha", pago.FechaPago);
                        sqlCommand.Parameters.AddWithValue("@IdDivisa", pago.Divisa);
                        sqlCommand.Parameters.AddWithValue("@TasaCambio", pago.TasaCambio);
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

        public List<PagosViewModel> GetListadoPagos(String desde, string hasta)
        {
            List<PagosViewModel> resultado = new List<PagosViewModel>();
            var cnn = Utilidad.getConexString();
            try
            {
                using (SqlConnection connection = new SqlConnection(cnn))
                {
                    using (SqlCommand sqlCommand = new SqlCommand("[IGLESIA].pcdGetListadosPagos", connection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddWithValue("@FechaIni", desde);
                        sqlCommand.Parameters.AddWithValue("@FechaFin", hasta);
                        connection.Open();
                        var dt = new DataTable();
                        dt.Load(sqlCommand.ExecuteReader());
                        resultado = (from DataRow dr in dt.Rows
                                     select new PagosViewModel()
                                     {
                                         Pagos = new Pago
                                         {
                                             IdPago = int.Parse(dr["IdPago"].ToString()),
                                             IdCategoria = int.Parse(dr["IdCategoria"].ToString()),
                                             Cantidad = double.Parse(dr["Cantidad"].ToString()),
                                             Descripcion = dr["Descripcion"].ToString(),
                                             FechaPago = DateTime.Parse(dr["FechaPago"].ToString()),
                                             Divisa = int.Parse(dr["Divisa"].ToString()),
                                             TasaCambio = double.Parse(dr["TasaCambio"].ToString()),
                                             Estado = int.Parse(dr["Estado"].ToString()),
                                         },
                                         PagosCategoria = new PagosCategoria.PagosCategoria
                                         {
                                             IdCategoria = int.Parse(dr["IdCategoria"].ToString()),
                                             Nombre = dr["CategoriaNombre"].ToString(),
                                             Descripcion = dr["CategoriaDescripcion"].ToString()
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

        public PagosViewModel GetPago(int id)
        {
            PagosViewModel resultado = null;
            var cnn = Utilidad.getConexString();
            try
            {
                using (SqlConnection connection = new SqlConnection(cnn))
                {
                    using (SqlCommand sqlCommand = new SqlCommand("[IGLESIA].pcdGetPagos", connection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddWithValue("@IdPago", id);
                        connection.Open();
                        var dt = new DataTable();
                        dt.Load(sqlCommand.ExecuteReader());
                        if (dt.Rows.Count > 0)
                        {
                            var dr = dt.Rows[0];
                            resultado = new PagosViewModel
                            {
                                Pagos = new Pago
                                {
                                    IdPago = int.Parse(dr["IdPago"].ToString()),
                                    IdCategoria = int.Parse(dr["IdCategoria"].ToString()),
                                    Cantidad = double.Parse(dr["Cantidad"].ToString()),
                                    Descripcion = dr["Descripcion"].ToString(),
                                    FechaPago = DateTime.Parse(dr["FechaPago"].ToString()),
                                    Divisa = int.Parse(dr["Divisa"].ToString()),
                                    TasaCambio = double.Parse(dr["TasaCambio"].ToString()),
                                    Estado = int.Parse(dr["Estado"].ToString()),
                                },
                                PagosCategoria = new PagosCategoria.PagosCategoria
                                {
                                    IdCategoria = int.Parse(dr["IdCategoria"].ToString()),
                                    Nombre = dr["CategoriaNombre"].ToString(),
                                    Descripcion = dr["CategoriaDescripcion"].ToString()
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

        public string Editar(PagosViewModel PagoViewModel)
        {
            string valstring = string.Empty;
            string cnn = Utilidad.getConexString();
            try
            {
                using (SqlConnection connection = new SqlConnection(cnn))
                {
                    using (SqlCommand sqlCommand = new SqlCommand("[IGLESIA].pcdSetPagoEdit", connection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddWithValue("@IdCategoria", PagoViewModel.PagosCategoria.IdCategoria);
                        sqlCommand.Parameters.AddWithValue("@Descripcion", PagoViewModel.Pagos.Descripcion);
                        sqlCommand.Parameters.AddWithValue("@Cantidad", PagoViewModel.Pagos.Cantidad);
                        sqlCommand.Parameters.AddWithValue("@Fecha", PagoViewModel.Pagos.FechaPago);
                        sqlCommand.Parameters.AddWithValue("@IdDivisa", PagoViewModel.Divisa.IdDivisa);
                        sqlCommand.Parameters.AddWithValue("@TasaCambio", PagoViewModel.Pagos.TasaCambio);
                        sqlCommand.Parameters.AddWithValue("@Estado", 1);
                        sqlCommand.Parameters.AddWithValue("@IdUsuario", 1);
                        sqlCommand.Parameters.AddWithValue("@IdPago", PagoViewModel.Pagos.IdPago);

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

        public String AnularPago(int id)
        {
            string valstring = string.Empty;
            string cnn = Utilidad.getConexString();
            try
            {
                using (SqlConnection connection = new SqlConnection(cnn))
                {
                    using (SqlCommand sqlCommand = new SqlCommand("[IGLESIA].pcdGetAnularPago", connection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddWithValue("@IdPago", id);
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
