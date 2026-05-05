using Servicios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_Bitacora_44MM
    {
        private string nombre_tabla = "Bitacora";
        private SqlConnection conexion = Conexion_44MM.Instancia.Conexion;

        public DataTable tabla_datos;
        private string query;

        public DAL_Bitacora_44MM()
        {
            query = Conexion_44MM.Instancia.Conectar(nombre_tabla);
        }

        public void Registrar_Evento(string login, DateTime fecha, string modulo, string evento, int criticidad)
        {
            conexion.Open();
            SqlTransaction transaction = conexion.BeginTransaction();
            try
            {
                string sql = $"INSERT INTO [{nombre_tabla}] (Login, Fecha, Modulo, Evento, Criticidad) VALUES (@Login, @Fecha, @Modulo, @Evento, @Criticidad)";
                SqlCommand cmd = new SqlCommand(sql, conexion);
                cmd.Transaction = transaction;

                cmd.Parameters.AddWithValue("@Login", login);
                cmd.Parameters.AddWithValue("@Fecha", fecha);
                cmd.Parameters.AddWithValue("@Modulo", modulo);
                cmd.Parameters.AddWithValue("@Evento", evento);
                cmd.Parameters.AddWithValue("@Criticidad", criticidad);

                cmd.ExecuteNonQuery();
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
            }
            conexion.Close();
        }
    }
}
