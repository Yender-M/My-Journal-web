using My_Journal.Properties;
using System.Data.SqlClient;

namespace My_Journal.Models.MinisteriosDetalle
{
    public class MantMinisteriosDetalle
    {
        public string Insertar(MinisteriosDetalle ministeriosdetalle)
        {
            string valstring = string.Empty;
            string cnn = Utilidad.getConexString();
            try
            {
                using (SqlConnection connection = new SqlConnection(cnn))
                {
                    using (SqlCommand sqlCommand = new SqlCommand("[IGLESIA].pcdSetMinisteriosDetalle", connection))
                    {
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddWithValue("@IdMinisterio", ministeriosdetalle.IdMinisterio);
                        sqlCommand.Parameters.AddWithValue("@Ver", ministeriosdetalle.Ver);
                        sqlCommand.Parameters.AddWithValue("@Crear", ministeriosdetalle.Crear);
                        sqlCommand.Parameters.AddWithValue("@Editar", ministeriosdetalle.Editar);
                        sqlCommand.Parameters.AddWithValue("@Anular", ministeriosdetalle.Anular);
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

    }
}
