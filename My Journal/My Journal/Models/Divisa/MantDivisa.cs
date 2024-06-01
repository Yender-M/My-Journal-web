using Microsoft.Data.SqlClient;
using My_Journal.Models.OfrendaCategoria;
using My_Journal.Properties;
using System.Data;

namespace My_Journal.Models.Divisa
{
    public class MantDivisa
    { 
        public List<Divisa> Getlistado()
        {
            List<Divisa> resultado = new List<Divisa>();
            var cnn = Utilidad.getConexString();
            try
            {
                using (SqlConnection connection = new SqlConnection(cnn))
                {
                    using (SqlCommand sqlCommand = new SqlCommand("[IGLESIA].pcdGetDivisas", connection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        connection.Open();
                        var dt = new DataTable();
                        dt.Load(sqlCommand.ExecuteReader());
                        resultado = (from DataRow dr in dt.Rows
                                     select new Divisa()
                                     {
                                         IdDivisa = int.Parse(dr["IdDivisa"].ToString()),
                                         CodDivisa = dr["CodDivisa"].ToString(),
                                         Descripcion = dr["Descripcion"].ToString(),
                                         Simbolo = dr["Simbolo"].ToString()
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
