using Microsoft.Data.SqlClient;
using My_Journal.Properties;
using System.Data;

namespace My_Journal.Models.IngresosCategoria
{
    public class MantIngresoCategoria
    {
        public MantIngresoCategoria()
        {
        }
        public List<IngresoCategoria> Getlistado()
        {
            List<IngresoCategoria> resultado = new List<IngresoCategoria>();
            var cnn = Utilidad.getConexString();
            try
            {
                using (SqlConnection connection = new SqlConnection(cnn))
                {
                    using (SqlCommand sqlCommand = new SqlCommand("[IGLESIA].pcdGetCategoriaIngreso", connection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        connection.Open();
                        var dt = new DataTable();
                        dt.Load(sqlCommand.ExecuteReader());
                        resultado = (from DataRow dr in dt.Rows
                                     select new IngresoCategoria()
                                     {
                                         IdCatIngreso = int.Parse(dr["IdCatIngreso"].ToString()),
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

        public IngresoCategoria GetOIngresoCategoria(int id)
        {
            IngresoCategoria resultado = new IngresoCategoria();
            var cnn = Utilidad.getConexString();
            try
            {
                using (SqlConnection connection = new SqlConnection(cnn))
                {
                    using (SqlCommand sqlCommand = new SqlCommand("[IGLESIA].pcdGetIngresoCat", connection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddWithValue("@IdIngresoCat", id);
                        connection.Open();
                        var dt = new DataTable();
                        dt.Load(sqlCommand.ExecuteReader());
                        resultado = (from DataRow dr in dt.Rows
                                     select new IngresoCategoria()
                                     {
                                         IdCatIngreso = int.Parse(dr["IdCatIngreso"].ToString()),
                                         Nombre = dr["Nombre"].ToString(),
                                         Descripcion = dr["Descripcion"].ToString(),
                                         Estado = int.Parse(dr["Estado"].ToString())
                                     }).Single();
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

        public string Insertar(IngresoCategoria ingresocat)
        {
            string valstring = string.Empty;
            string cnn = Utilidad.getConexString();
            try
            {
                using (SqlConnection connection = new SqlConnection(cnn))
                {
                    using (SqlCommand sqlCommand = new SqlCommand("[IGLESIA].pcdSetIngresoCat", connection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddWithValue("@Nombre", ingresocat.Nombre);
                        sqlCommand.Parameters.AddWithValue("@Descripcion", ingresocat.Descripcion);
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

        public string Editar(IngresoCategoria IngresoCat)
        {
            string valstring = string.Empty;
            string cnn = Utilidad.getConexString();
            try
            {
                using (SqlConnection connection = new SqlConnection(cnn))
                {
                    using (SqlCommand sqlCommand = new SqlCommand("[IGLESIA].pcdSetIngresoCatEdit", connection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddWithValue("@IdCatIngreso", IngresoCat.IdCatIngreso);
                        sqlCommand.Parameters.AddWithValue("@Nombre", IngresoCat.Nombre);
                        sqlCommand.Parameters.AddWithValue("@Descripcion", IngresoCat.Descripcion);
                        sqlCommand.Parameters.AddWithValue("@Estado", IngresoCat.Estado);
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
