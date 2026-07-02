using BLL;
using Servicios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_Intento_44MM
    {
        private string nombre_tabla = "Intentos";
        private SqlConnection conexion = DAL_44MM.Instancia.Nueva_Conexion();

        public DataTable tabla_datos;
        private string query;

        public DAL_Intento_44MM()
        {
            Recuperar_Intentos();
        }

        public void Recuperar_Intentos()
        {
            query = DAL_44MM.Instancia.Conectar(nombre_tabla);
            tabla_datos = DAL_44MM.Instancia.Consultar(tabla_datos, nombre_tabla, query);
            DataColumn p = tabla_datos.Columns["Login"];
            tabla_datos.PrimaryKey = new DataColumn[] { p };
        }

        public void Modificar_Intentos(string login, DateTime fecha, int intentos)
        {
            conexion.Open();
            DataRow fila = tabla_datos.Rows.Find(login);
            if (fila != null)
            {
                SqlTransaction transaction = conexion.BeginTransaction();
                try
                {
                    string sql = $"UPDATE {nombre_tabla} SET Fecha = @Fecha, Intentos = @Intentos WHERE Login = @Login";
                    SqlCommand cmd = new SqlCommand(sql, conexion, transaction);
                    cmd.Parameters.AddWithValue("@Fecha", fecha);
                    cmd.Parameters.AddWithValue("@Intentos", intentos);
                    cmd.Parameters.AddWithValue("@Login", login);

                    cmd.ExecuteNonQuery();
                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                }
            }
            else
            {
                SqlTransaction transaction = conexion.BeginTransaction();
                try
                {
                    string sql = $"INSERT INTO [{nombre_tabla}] (Login, Fecha, Intentos) VALUES (@Login, @Fecha, @Intentos)";
                    SqlCommand cmd = new SqlCommand(sql, conexion, transaction);
                    cmd.Parameters.AddWithValue("@Fecha", fecha);
                    cmd.Parameters.AddWithValue("@Intentos", intentos);
                    cmd.Parameters.AddWithValue("@Login", login);

                    cmd.ExecuteNonQuery();
                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                }
            }
            conexion.Close();
        }

        public void Actualizar_Intentos(DataTable tabla)
        {
            conexion.Open();
            foreach (DataRow row in tabla.Rows)
            {
                DataRow fila = tabla_datos.Rows.Find((string)row["Login"]);
                if (fila != null)
                {
                    SqlTransaction transaction = conexion.BeginTransaction();
                    try
                    {
                        string sql = $"UPDATE {nombre_tabla} SET Fecha = @Fecha, Intentos = @Intentos WHERE Login = @Login";
                        SqlCommand cmd = new SqlCommand(sql, conexion, transaction);
                        cmd.Parameters.AddWithValue("@Fecha", (DateTime)row["Fecha"]);
                        cmd.Parameters.AddWithValue("@Intentos", (int)row["Intentos"]);
                        cmd.Parameters.AddWithValue("@Login", (string)row["Login"]);

                        cmd.ExecuteNonQuery();
                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                    }
                }
                else
                {
                    SqlTransaction transaction = conexion.BeginTransaction();
                    try
                    {
                        string sql = $"INSERT INTO [{nombre_tabla}] (Login, Fecha, Intentos) VALUES (@Fecha, @Intentos, @Login)";
                        SqlCommand cmd = new SqlCommand(sql, conexion, transaction);
                        cmd.Parameters.AddWithValue("@Fecha", (DateTime)row["Fecha"]);
                        cmd.Parameters.AddWithValue("@Intentos", (int)row["Intentos"]);
                        cmd.Parameters.AddWithValue("@Login", (string)row["Login"]);

                        cmd.ExecuteNonQuery();
                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                    }
                }
            }

            conexion.Close();
        }
    }
}