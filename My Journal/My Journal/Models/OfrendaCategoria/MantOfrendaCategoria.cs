using Microsoft.Data.SqlClient;
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
    }
}
