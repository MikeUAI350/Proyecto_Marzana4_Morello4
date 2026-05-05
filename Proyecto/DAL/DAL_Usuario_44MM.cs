using Servicios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_Usuario_44MM
    {
        private string nombre_tabla = "Usuario";
        private SqlConnection conexion = Conexion_44MM.Instancia.Conexion;

        public DataTable tabla_datos;
        private string query;

        public DAL_Usuario_44MM()
        {
            query = Conexion_44MM.Instancia.Conectar(nombre_tabla);
        }

        public DataTable Verificar_Cuenta(string login)
        {
            string propiedad = "Login";
            string valor = login;

            tabla_datos = Conexion_44MM.Instancia.Seleccionar(nombre_tabla, propiedad, valor);
            return tabla_datos;
        }

        public void Bloquear_Usuario(string login)
        {
            string propiedad1 = "Login";
            string propiedad2 = "Bloqueado";
            string valor2 = true.ToString();

            Conexion_44MM.Instancia.Modificar(login, propiedad1, valor2, propiedad2, nombre_tabla);
        }

        public (bool, string) Cambiar_Clave(string login, string contra)
        {
            bool exito = false;
            string mensaje = string.Empty;

            string propiedad1 = "Login";
            string propiedad2 = "Password";

            (exito, mensaje) = Conexion_44MM.Instancia.Modificar(login, propiedad1, contra, propiedad2, nombre_tabla);
            return (exito, mensaje);
        }
    }
}
