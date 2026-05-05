using Servicios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_Gestion_Usuarios_44MM
    {
        private string nombre_tabla = "Usuario";
        private SqlConnection conexion = Conexion_44MM.Instancia.Conexion;

        public DataTable tabla_datos;
        private string query;

        public DAL_Gestion_Usuarios_44MM()
        {
            Recuperar_Usuarios();
        }

        public void Recuperar_Usuarios()
        {
            query = Conexion_44MM.Instancia.Conectar(nombre_tabla);
            tabla_datos = Conexion_44MM.Instancia.Consultar(tabla_datos, nombre_tabla, query);
            DataColumn p = tabla_datos.Columns["Login"];
            tabla_datos.PrimaryKey = new DataColumn[] { p };
        }

        public (bool, string) Verificar_Login(string login)
        {
            string propiedad = "Login";
            string valor = login;

            string mensaje = "Usuario ya Existente";

            tabla_datos = Conexion_44MM.Instancia.Seleccionar(nombre_tabla, propiedad, valor);
            if (tabla_datos.Rows.Count == 0)
            {
                return (true, "");
            }
            else
            {
                return (false, mensaje);
            }
        }

        public (bool, string) Agregar_Usuario(string dni, string nombre, string apellido, string login, string email, string password, string rol, bool bloqueado, bool activo)
        {
            bool exito = false;
            string mensaje = "Usuario Creado Exitosamente";

            conexion.Open();
            SqlTransaction transaction = conexion.BeginTransaction();
            try
            {
                string sql = $"INSERT INTO [{nombre_tabla}] (DNI, Nombre, Apellido, Login, Email, Password, Rol, Bloqueado, Activo) VALUES (@DNI, @Nombre, @Apellido, @Login, @Email, @Password, @Rol, @Bloqueado, @Activo)";
                SqlCommand cmd = new SqlCommand(sql, conexion);
                cmd.Transaction = transaction;

                cmd.Parameters.AddWithValue("@DNI", dni);
                cmd.Parameters.AddWithValue("@Nombre", nombre);
                cmd.Parameters.AddWithValue("@Apellido", apellido);
                cmd.Parameters.AddWithValue("@Login", login);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Password", password);
                cmd.Parameters.AddWithValue("@Rol", rol);
                cmd.Parameters.AddWithValue("@Bloqueado", bloqueado);
                cmd.Parameters.AddWithValue("@Activo", activo);

                cmd.ExecuteNonQuery();
                transaction.Commit();
                exito = true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                mensaje = ex.Message;
                exito = false;
            }
            conexion.Close();
            return (exito, mensaje);
        }

        public (bool, string) Modificar_Usuario(string login, string email, string rol)
        {
            bool exito = false;
            string mensaje = "Usuario Modificado Exitosamente";

            string propiedad1 = "Login";
            string propiedad2 = "Email";

            (exito, mensaje) = Conexion_44MM.Instancia.Modificar(login, propiedad1, email, propiedad2, nombre_tabla);
            if (exito == false)
            {
                return (false, mensaje);
            }
            else
            {
                propiedad2 = "Rol";
                (exito, mensaje) = Conexion_44MM.Instancia.Modificar(login, propiedad1, rol, propiedad2, nombre_tabla);
                if (exito == false)
                {
                    return(false, mensaje);
                }
                else
                {
                    return (true, mensaje);
                }
            }
        }

        public (bool, string) Activar_Usuario(string login, bool activo)
        {
            bool exito = false;
            string mensaje = string.Empty;

            if (activo == false)
            {
                mensaje = "Usuario Activado Exitosamente";
            }
            else
            {
                mensaje = "Usuario Desactivado Exitosamente";
            }

            string propiedad1 = "Login";
            string propiedad2 = "Activo";

            (exito, mensaje) = Conexion_44MM.Instancia.Modificar(login, propiedad1, activo.ToString(), propiedad2, nombre_tabla);
            if (exito == false)
            {
                return (false, mensaje);
            }
            else
            {
                return (true, mensaje);
            }
        }

        public (bool, string) Desbloquear_Usuario(string login, string password)
        {
            bool exito = false;
            string mensaje = "Usuario Desbloqueado Exitosamente";

            string propiedad1 = "Login";
            string propiedad2 = "Bloqueado";
            string valor2 = false.ToString();

            (exito, mensaje) = Conexion_44MM.Instancia.Modificar(login, propiedad1, valor2, propiedad2, nombre_tabla);
            if (exito == false)
            {
                return (false, mensaje);
            }
            else
            {
                propiedad2 = "Password";
                (exito, mensaje) = Conexion_44MM.Instancia.Modificar(login, propiedad1, valor2, password, nombre_tabla);
                if (exito == false)
                {
                    return (false, mensaje);
                }
                else
                {
                    return (true, mensaje);
                }
            }
        }
    }
}