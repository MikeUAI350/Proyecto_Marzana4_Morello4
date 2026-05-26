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
    public class DAL_Usuario_44MM
    {
        private string nombre_tabla = "Usuario";
        private SqlConnection conexion = Conexion_44MM.Instancia.Conexion;

        public DataTable tabla_datos;
        private string query;

        public DAL_Usuario_44MM()
        {
            Recuperar_Usuarios();
        }

        #region Usuario
        public DataTable Verificar_Login(string login)
        {
            string propiedad = "Login";
            string valor = login;

            tabla_datos = Conexion_44MM.Instancia.Seleccionar(nombre_tabla, propiedad, valor);
            return tabla_datos;
        }

        public void Bloquear_Usuario(string login)
        {
            conexion.Open();
            SqlTransaction transaction = conexion.BeginTransaction();
            try
            {
                string sql = $"UPDATE {nombre_tabla} SET Bloqueado = @Bloqueado WHERE Login = @Login";
                SqlCommand cmd = new SqlCommand(sql, conexion, transaction);
                cmd.Parameters.AddWithValue("@Bloqueado", true);
                cmd.Parameters.AddWithValue("@Login", login);
                cmd.ExecuteNonQuery();
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
            }
            conexion.Close();
            /*string propiedad1 = "Login";
            string propiedad2 = "Bloqueado";
            string valor2 = true.ToString();

            Conexion_44MM.Instancia.Modificar(login, propiedad1, valor2, propiedad2, nombre_tabla);*/
        }

        public (bool, string) Cambiar_Clave(string login, string contra)
        {
            bool exito = true;
            string mensaje = string.Empty;

            conexion.Open();
            SqlTransaction transaction = conexion.BeginTransaction();
            try
            {
                string sql = $"UPDATE {nombre_tabla} SET Password = @Password, RCC = @RCC WHERE Login = @Login";
                SqlCommand cmd = new SqlCommand(sql, conexion, transaction);
                cmd.Parameters.AddWithValue("@Password", contra);
                cmd.Parameters.AddWithValue("@RCC", false);
                cmd.Parameters.AddWithValue("@Login", login);
                cmd.ExecuteNonQuery();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                exito = false;
                mensaje = ex.Message;
            }
            conexion.Close();

            /*string propiedad1 = "Login";
            string propiedad2 = "Password";

            (exito, mensaje) = Conexion_44MM.Instancia.Modificar(login, propiedad1, contra, propiedad2, nombre_tabla);
            if (exito == false)
            {
                return (false, mensaje);
            }
            else
            {
                propiedad2 = "RCC";
                string valor2 = false.ToString();
                (exito, mensaje) = Conexion_44MM.Instancia.Modificar(login, propiedad1, valor2, propiedad2, nombre_tabla);
            }*/
            return (exito, mensaje);
        }
        #endregion

        #region Gestion

        public void Recuperar_Usuarios()
        {
            query = Conexion_44MM.Instancia.Conectar(nombre_tabla);
            tabla_datos = Conexion_44MM.Instancia.Consultar(tabla_datos, nombre_tabla, query);
            DataColumn p = tabla_datos.Columns["Login"];
            tabla_datos.PrimaryKey = new DataColumn[] { p };
        }

        public (bool, string) Verificar_DNI(string dni)
        {
            string propiedad = "DNI";
            string valor = dni;

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

        public (bool, string) Crear_Usuario(string dni, string nombre, string apellido, string login, string email, string password, string rol)
        {
            bool exito = true;
            string mensaje = "Usuario Creado Exitosamente";

            conexion.Open();
            SqlTransaction transaction = conexion.BeginTransaction();
            try
            {
                string sql = $"INSERT INTO [{nombre_tabla}] (DNI, Nombre, Apellido, Login, Email, Password, Rol) VALUES (@DNI, @Nombre, @Apellido, @Login, @Email, @Password, @Rol)";
                SqlCommand cmd = new SqlCommand(sql, conexion);
                cmd.Transaction = transaction;

                cmd.Parameters.AddWithValue("@DNI", dni);
                cmd.Parameters.AddWithValue("@Nombre", nombre);
                cmd.Parameters.AddWithValue("@Apellido", apellido);
                cmd.Parameters.AddWithValue("@Login", login);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Password", password);
                cmd.Parameters.AddWithValue("@Rol", rol);

                cmd.ExecuteNonQuery();
                transaction.Commit();
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
            bool exito = true;
            string mensaje = "Usuario Modificado Exitosamente";

            conexion.Open();
            SqlTransaction transaction = conexion.BeginTransaction();
            try
            {
                string sql = $"UPDATE {nombre_tabla} SET Email = @Email, Rol = @Rol WHERE Login = @Login";
                SqlCommand cmd = new SqlCommand(sql, conexion, transaction);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Rol", rol);
                cmd.Parameters.AddWithValue("@Login", login);
                cmd.ExecuteNonQuery();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                exito = false;
                mensaje = ex.Message;
            }
            conexion.Close();
            return (exito, mensaje);
            /* string propiedad1 = "Login";
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
                     return (false, mensaje);
                 }
                 else
                 {
                     return (true, mensaje);
                 }
             }*/
        }

        public (bool, string) Activar_Usuario(string login, bool activo)
        {
            bool exito = true;
            string mensaje = string.Empty;

            if (activo == false)
            {
                mensaje = "Usuario Activado Exitosamente";
            }
            else
            {
                mensaje = "Usuario Desactivado Exitosamente";
            }

            conexion.Open();
            SqlTransaction transaction = conexion.BeginTransaction();
            try
            {
                string sql = $"UPDATE {nombre_tabla} SET Activo = @Activo WHERE Login = @Login";
                SqlCommand cmd = new SqlCommand(sql, conexion, transaction);
                cmd.Parameters.AddWithValue("@Activo", activo);
                cmd.Parameters.AddWithValue("@Login", login);
                cmd.ExecuteNonQuery();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                exito = false;
                mensaje = ex.Message;
            }
            conexion.Close();
            return (exito, mensaje);
            /*if (activo == false)
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
            }*/
        }

        public (bool, string) Desbloquear_Usuario(string login, string password)
        {
            bool exito = true;
            string mensaje = "Usuario Desbloqueado Exitosamente";

            conexion.Open();
            SqlTransaction transaction = conexion.BeginTransaction();
            try
            {
                string sql = $"UPDATE {nombre_tabla} SET Bloqueado = @Bloqueado, Password = @Password, RCC = @RCC WHERE Login = @Login";
                SqlCommand cmd = new SqlCommand(sql, conexion, transaction);
                cmd.Parameters.AddWithValue("@Bloqueado", false);
                cmd.Parameters.AddWithValue("@Password", password);
                cmd.Parameters.AddWithValue("@RCC", true);
                cmd.Parameters.AddWithValue("@Login", login);
                cmd.ExecuteNonQuery();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                exito = false;
                mensaje = ex.Message;
            }
            conexion.Close();
            return (exito, mensaje);
            /*string propiedad1 = "Login";
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
                (exito, mensaje) = Conexion_44MM.Instancia.Modificar(login, propiedad1, password, propiedad2, nombre_tabla);
                if (exito == false)
                {
                    return (false, mensaje);
                }
                else
                {
                    propiedad2 = "RCC";
                    (exito, mensaje) = Conexion_44MM.Instancia.Modificar(login, propiedad1, true.ToString(), propiedad2, nombre_tabla);
                    if (exito == false)
                    {
                        return (false, mensaje);
                    }
                    else
                    {
                        return (true, mensaje);
                    }
                }
            }*/
        }
        #endregion
    }
}