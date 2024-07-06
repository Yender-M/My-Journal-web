using Microsoft.Data.SqlClient;
using My_Journal.Models.IngresosCategoria;
using My_Journal.Properties;
using System.Data;

namespace My_Journal.Models.EgresosCategoria
{
    public class MantEgresoCategotia
    {
        public MantEgresoCategotia()
        {
        }
        public List<EgresoCategoria> Getlistado()
        {
            List<EgresoCategoria> resultado = new List<EgresoCategoria>();
            var cnn = Utilidad.getConexString();
            try
            {
                using (SqlConnection connection = new SqlConnection(cnn))
                {
                    using (SqlCommand sqlCommand = new SqlCommand("[IGLESIA].pcdGetCategoriaEgreso", connection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        connection.Open();
                        var dt = new DataTable();
                        dt.Load(sqlCommand.ExecuteReader());
                        resultado = (from DataRow dr in dt.Rows
                                     select new EgresoCategoria()
                                     {
                                         IdCatEgreso = int.Parse(dr["IdCatEgreso"].ToString()),
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

        public EgresoCategoria GetEgresoCategoria(int id)
        {
            EgresoCategoria resultado = new EgresoCategoria();
            var cnn = Utilidad.getConexString();
            try
            {
                using (SqlConnection connection = new SqlConnection(cnn))
                {
                    using (SqlCommand sqlCommand = new SqlCommand("[IGLESIA].pcdGetEgresoCat", connection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddWithValue("@IdEgresoCat", id);
                        connection.Open();
                        var dt = new DataTable();
                        dt.Load(sqlCommand.ExecuteReader());
                        resultado = (from DataRow dr in dt.Rows
                                     select new EgresoCategoria()
                                     {
                                         IdCatEgreso = int.Parse(dr["IdCatEgreso"].ToString()),
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

        public string Insertar(EgresoCategoria egresocat)
        {
            string valstring = string.Empty;
            string cnn = Utilidad.getConexString();
            try
            {
                using (SqlConnection connection = new SqlConnection(cnn))
                {
                    using (SqlCommand sqlCommand = new SqlCommand("[IGLESIA].pcdSetEgresoCat", connection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddWithValue("@Nombre", egresocat.Nombre);
                        sqlCommand.Parameters.AddWithValue("@Descripcion", egresocat.Descripcion);
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

        public string Editar(EgresoCategoria EgresoCat)
        {
            string valstring = string.Empty;
            string cnn = Utilidad.getConexString();
            try
            {
                using (SqlConnection connection = new SqlConnection(cnn))
                {
                    using (SqlCommand sqlCommand = new SqlCommand("[IGLESIA].pcdSetEgresoCatEdit", connection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddWithValue("@IdCatEgreso", EgresoCat.IdCatEgreso);
                        sqlCommand.Parameters.AddWithValue("@Nombre", EgresoCat.Nombre);
                        sqlCommand.Parameters.AddWithValue("@Descripcion", EgresoCat.Descripcion);
                        sqlCommand.Parameters.AddWithValue("@Estado", EgresoCat.Estado);
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
