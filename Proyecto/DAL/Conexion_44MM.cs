using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public sealed class Conexion_44MM
    {
        private static readonly object _candado = new object();

        private Conexion_44MM() { }

        private static Conexion_44MM _Instancia;

        public static Conexion_44MM Instancia
        {
            get
            {
                if (_Instancia == null)
                {
                    lock (_candado)
                    {
                        if (_Instancia == null)
                        {
                            _Instancia = new Conexion_44MM();
                        }
                    }
                }
                return _Instancia;
            }
        }

        private SqlConnection _conexion = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Proyecto IS2026;Integrated Security=True");
        //private SqlConnection _conexion = new SqlConnection("Data Source=.;Initial Catalog=Proyecto IS2026;Integrated Security=True");
        public SqlConnection Conexion
        {
            get { return _conexion; }
            set { _conexion = value; }
        }

        public string Conectar(string nombre_tabla)
        {
            return ($"SELECT * FROM {nombre_tabla}");
        }

        public DataTable Seleccionar(string nombre_tabla, string propiedad, string valor)
        {
            Conexion.Open();

            //string query = "SELECT * FROM " + nombre_tabla + " WHERE " + propiedad + " = '" + valor + "'";
            string query = $"SELECT * FROM {nombre_tabla} WHERE {propiedad} = '{valor}'";
            SqlDataAdapter adapter = new SqlDataAdapter(query, Conexion);
            DataTable tabla = new DataTable();
            adapter.Fill(tabla);

            Conexion.Close();
            return tabla;
        }

        public DataTable Consultar(DataTable tabla, string nombre_tabla, string query)
        {
            if (tabla == null)
            {
                tabla = new DataTable();
                tabla.TableName = nombre_tabla;
            }
            else
            {
                tabla.Clear();
            }

            Conexion.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(query, Conexion);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            adapter.Fill(tabla);
            Conexion.Close();

            return tabla;
        }

        public (bool, string) Modificar(string valor1, string propiedad1, string valor2, string propiedad2, string nombre_tabla)
        {
            string mensaje = string.Empty;
            bool exito = false;
            Conexion.Open();
            SqlTransaction transaction = Conexion.BeginTransaction();
            try
            {
                string command = "UPDATE " + nombre_tabla + " SET " + propiedad2 + " = '" + valor2 + "' WHERE " + propiedad1 +" = '" + valor1 + "'";
                SqlCommand cmd = new SqlCommand(command, Conexion);
                cmd.Transaction = transaction;

                cmd.ExecuteNonQuery();
                transaction.Commit();
                exito = true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                mensaje = ex.Message;
            }
            Conexion.Close();
            return (exito, mensaje);
        }
    }
}