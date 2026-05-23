using Servicios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_Intentos_44MM
    {
        private string nombre_tabla = "Intentos";
        private SqlConnection conexion = Conexion_44MM.Instancia.Conexion;

        public DataTable tabla_datos;
        private string query;

        public DAL_Intentos_44MM()
        {
            Recuperar_Intentos();
        }

        public void Recuperar_Intentos()
        {
            query = Conexion_44MM.Instancia.Conectar(nombre_tabla);
            tabla_datos = Conexion_44MM.Instancia.Consultar(tabla_datos, nombre_tabla, query);
            DataColumn p = tabla_datos.Columns["Login"];
            tabla_datos.PrimaryKey = new DataColumn[] { p };
        }

        public void Registrar_Intento(string login, DateTime fecha)
        {
            conexion.Open();
            SqlTransaction transaction = conexion.BeginTransaction();
            try
            {
                string sql = $"INSERT INTO [{nombre_tabla}] (Login, Fecha) VALUES (@Login, @Fecha)";
                SqlCommand cmd = new SqlCommand(sql, conexion);
                cmd.Transaction = transaction;

                cmd.Parameters.AddWithValue("@Login", login);
                cmd.Parameters.AddWithValue("@Fecha", fecha);

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
