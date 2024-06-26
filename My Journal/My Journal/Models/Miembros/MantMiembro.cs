using Microsoft.Data.SqlClient;
using My_Journal.Properties;
using System.Data;

namespace My_Journal.Models.Miembros
{
    public class MantMiembro
    {
        public MantMiembro()
        {
        }
        public List<Miembro> GetListadoMiembros(String desde, string hasta)
        {
            List<Miembro> resultado = new List<Miembro>();
            var cnn = Utilidad.getConexString();
            try
            {
                using (SqlConnection connection = new SqlConnection(cnn))
                {
                    using (SqlCommand sqlCommand = new SqlCommand("[IGLESIA].pcdGetListadoMiembros", connection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddWithValue("@FechaIni", desde);
                        sqlCommand.Parameters.AddWithValue("@FechaFin", hasta);
                        connection.Open();
                        var dt = new DataTable();
                        dt.Load(sqlCommand.ExecuteReader());
                        resultado = (from DataRow dr in dt.Rows
                                     select new Miembro()
                                     {
                                            IdMiembro = int.Parse(dr["IdMiembro"].ToString()),
                                            Nombre = dr["Nombre"].ToString(),
                                            Apellido = dr["Apellido"].ToString(),
                                            Direccion = dr["Direccion"].ToString(),
                                            Telefono = dr["Telefono"].ToString(),
                                            FechaNacimiento = DateTime.Parse(dr["FechaNacimiento"].ToString()),
                                            FechaBautismo = DateTime.Parse(dr["FechaBautismo"].ToString()),
                                            Estado = int.Parse(dr["Estado"].ToString()),
                                         
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
