using Servicios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digito_Verificador_IS
{
    public class DAL_Digito_Verificador_44MM
    {
        private string nombre_tabla = "Digito_Verificador";
        private SqlConnection conexion = DAL_44MM.Instancia.Nueva_Conexion();

        public DataTable tabla_datos;
        private string query;

        public DAL_Digito_Verificador_44MM()
        {
            Recuperar();
            Recuperar_Tablas();
        }

        private void Recuperar()
        {
            query = DAL_44MM.Instancia.Conectar(nombre_tabla);
            tabla_datos = DAL_44MM.Instancia.Consultar(tabla_datos, nombre_tabla, query);
            DataColumn p = tabla_datos.Columns["Nombre_Tabla"];
            tabla_datos.PrimaryKey = new DataColumn[] { p };
        }

        public DataSet Recuperar_Tablas()
        {
            DataSet tablas = new DataSet();
            foreach (DataRow row in tabla_datos.Rows)
            {
                string _nombre_tabla = (string)row["Nombre_Tabla"];
                string _query = DAL_44MM.Instancia.Conectar(_nombre_tabla);
                DataTable _tabla_datos = DAL_44MM.Instancia.Consultar(null, _nombre_tabla, _query);
                tablas.Tables.Add(_tabla_datos);
            }
            return tablas;
        }

        public void Guardar_Calculo(string nombre, string v, string h)
        {
            conexion.Open();
            string sql = $"UPDATE {nombre_tabla} SET Calculo_Vertical = @Calculo_Vertical, Calculo_Horizontal = @Calculo_Horizontal WHERE Nombre_Tabla = @Nombre_Tabla";
            SqlCommand cmd = new SqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@Calculo_Vertical", v);
            cmd.Parameters.AddWithValue("@Calculo_Horizontal", h);
            cmd.Parameters.AddWithValue("@Nombre_Tabla", nombre);
            cmd.ExecuteNonQuery();
            conexion.Close();
        }
    }
}