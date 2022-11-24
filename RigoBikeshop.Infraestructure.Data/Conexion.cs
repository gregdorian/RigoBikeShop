using System.Configuration;
using System.Data;
using Microsoft.Data.SqlClient;

namespace RigoBikeshop.Infraestructure.Data
{
    internal class Conexion
    {

        private static readonly string cadenaConexion = ConfigurationManager.ConnectionStrings["sqlConexionApp"].ConnectionString;
        private static SqlConnection conexion = new SqlConnection(cadenaConexion);

        public static Int32 IdEscalar;

        public static bool Conectar()
        {
            try
            {
                conexion.Open();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public static void Desconectar()
        {
            conexion.Close();
        }

        /// <summary>
        ///   Operacion Conectada para realizar consultas, llamando Stored Procedures  
        /// No retorna ningun objeto
        /// </summary>
        /// <param name="cadenaComando"></param>
        /// <param name="listaparametros"></param>
        /// <param name="tipoComando"></param>
        public static void EjecutarOperacion(string cadenaComando, List<SqlParameter> listaparametros, CommandType tipoComando)
        {
            if (Conectar())
            {
                SqlCommand comando = new SqlCommand
                {
                    CommandText = cadenaComando,
                    CommandType = tipoComando,
                    Connection = conexion
                };


                foreach (SqlParameter parametro in listaparametros)
                {
                    comando.Parameters.Add(parametro);
                }
                comando.ExecuteNonQuery();
                Desconectar();
            }
            else
            {
                throw new Exception("No se pudo establecer conexion");
            }


        }

        /// <summary>
        ///   Operacion de consulta que retorna un DataTable en Terminos desconectados
        ///   consulta por medio de stored Procedures, Retorna El Objeto DataTable
        /// </summary>
        /// <param name="sentencia"></param>
        /// <param name="listaparametro"></param>
        /// <param name="tipocomando"></param>
        /// <returns></returns>
        public static DataTable EjecutarConsulta(string sentencia, List<SqlParameter> listaparametro, CommandType tipocomando)
        {
            SqlDataAdapter adaptador = new SqlDataAdapter
            {
                SelectCommand = new SqlCommand(sentencia, conexion)
            };
            adaptador.SelectCommand.CommandType = tipocomando;
            foreach (SqlParameter parametro in listaparametro)
            {
                adaptador.SelectCommand.Parameters.Add(parametro);
            }
            DataSet resultado = new DataSet();
            adaptador.Fill(resultado);

            return resultado.Tables[0];
        }

        /// <summary>
        ///  Metodo conectado que retorna DataTable y realiza consulta por medio de stored Procedures
        /// </summary>
        /// <param name="cadenaComando"></param>
        /// <param name="tipocomando"></param>
        /// <returns></returns>
        public static DataTable EjecutarConsulta(string cadenaComando, CommandType tipocomando)
        {
            DataTable dtResult = new DataTable();
            using (SqlCommand cmd = new SqlCommand(cadenaComando, conexion))
            {
                Conectar();

                using (SqlDataAdapter Adapter = new SqlDataAdapter(cmd))
                {
                    Adapter.Fill(dtResult);
                    Desconectar();
                }

            }
            return dtResult;
        }

    }
}
