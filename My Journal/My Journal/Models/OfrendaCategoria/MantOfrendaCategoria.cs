using Microsoft.Data.SqlClient;
using My_Journal.Models.Miembros;
using My_Journal.Properties;
using System.Data;

namespace My_Journal.Models.OfrendaCategoria
{
    public class MantOfrendaCategoria
    {
        public MantOfrendaCategoria()
        {
        }
        public List<OfrendasCategoria> Getlistado()
        {
            List<OfrendasCategoria> resultado = new List<OfrendasCategoria>();
            var cnn = Utilidad.getConexString();
            try
            {
                using (SqlConnection connection = new SqlConnection(cnn))
                {
                    using (SqlCommand sqlCommand = new SqlCommand("[IGLESIA].pcdGetCategoriaOfrenda", connection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        connection.Open();
                        var dt = new DataTable();
                        dt.Load(sqlCommand.ExecuteReader());
                        resultado = (from DataRow dr in dt.Rows
                                     select new OfrendasCategoria()
                                     {
                                         IdCatOfrenda = int.Parse(dr["IdCatOfrenda"].ToString()),
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

        public OfrendasCategoria GetOfrendaCategoria(int id)
        {
            OfrendasCategoria resultado = new OfrendasCategoria();
            var cnn = Utilidad.getConexString();
            try
            {
                using (SqlConnection connection = new SqlConnection(cnn))
                {
                    using (SqlCommand sqlCommand = new SqlCommand("[IGLESIA].pcdGetOfrendaCat", connection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddWithValue("@IdOfrendaCat", id);
                        connection.Open();
                        var dt = new DataTable();
                        dt.Load(sqlCommand.ExecuteReader());
                        resultado = (from DataRow dr in dt.Rows
                                     select new OfrendasCategoria()
                                     {
                                         IdCatOfrenda = int.Parse(dr["IdCatOfrenda"].ToString()),
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

        public string Insertar(OfrendasCategoria OfrendaCat)
        {
            string valstring = string.Empty;
            string cnn = Utilidad.getConexString();
            try
            {
                using (SqlConnection connection = new SqlConnection(cnn))
                {
                    using (SqlCommand sqlCommand = new SqlCommand("[IGLESIA].pcdSetOfrendaCat", connection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddWithValue("@Nombre", OfrendaCat.Nombre);
                        sqlCommand.Parameters.AddWithValue("@Descripcion", OfrendaCat.Descripcion);
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

        public string Editar(OfrendasCategoria OfrenfaCat)
        {
            string valstring = string.Empty;
            string cnn = Utilidad.getConexString();
            try
            {
                using (SqlConnection connection = new SqlConnection(cnn))
                {
                    using (SqlCommand sqlCommand = new SqlCommand("[IGLESIA].pcdSetOfrendaCatEdit", connection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddWithValue("@IdCatOfrenda", OfrenfaCat.IdCatOfrenda);
                        sqlCommand.Parameters.AddWithValue("@Nombre", OfrenfaCat.Nombre);
                        sqlCommand.Parameters.AddWithValue("@Descripcion", OfrenfaCat.Descripcion);
                        sqlCommand.Parameters.AddWithValue("@Estado", OfrenfaCat.Estado);
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
