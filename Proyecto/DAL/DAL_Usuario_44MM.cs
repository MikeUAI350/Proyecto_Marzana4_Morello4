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
        private SqlConnection conexion = DAL_44MM.Instancia.Nueva_Conexion();

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

            tabla_datos = DAL_44MM.Instancia.Seleccionar(nombre_tabla, propiedad, valor);
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
        }

        public (bool, string) Cambiar_Clave(string login, string contra)
        {
            bool exito = true;
            string mensaje = "ContraActualizada";

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
            return (exito, mensaje);
        }

        public void Cambiar_Idioma(string login, string idioma)
        {
            conexion.Open();
            SqlTransaction transaction = conexion.BeginTransaction();
            try
            {
                string sql = $"UPDATE {nombre_tabla} SET Idioma = @Idioma WHERE Login = @Login";
                SqlCommand cmd = new SqlCommand(sql, conexion, transaction);
                cmd.Parameters.AddWithValue("@Idioma", idioma);
                cmd.Parameters.AddWithValue("@Login", login);
                cmd.ExecuteNonQuery();
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
            }
            conexion.Close();
        }
        #endregion

        #region Gestion

        public void Recuperar_Usuarios()
        {
            query = DAL_44MM.Instancia.Conectar(nombre_tabla);
            tabla_datos = DAL_44MM.Instancia.Consultar(tabla_datos, nombre_tabla, query);
            DataColumn p = tabla_datos.Columns["Login"];
            tabla_datos.PrimaryKey = new DataColumn[] { p };
        }

        public (bool, string) Verificar_DNI(string dni)
        {
            string propiedad = "DNI";
            string valor = dni;

            string mensaje = "UsuarioYaExiste";

            tabla_datos = DAL_44MM.Instancia.Seleccionar(nombre_tabla, propiedad, valor);
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
            string mensaje = "UsuarioCreadoExitosamente";

            conexion.Open();
            SqlTransaction transaction = conexion.BeginTransaction();
            try
            {
                string sql = $"INSERT INTO {nombre_tabla} (DNI, Nombre, Apellido, Login, Email, Password, Rol) VALUES (@DNI, @Nombre, @Apellido, @Login, @Email, @Password, @Rol)";
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
            string mensaje = "UsuarioModificadoExitosamente";

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
        }

        public (bool, string) Activar_Usuario(string login, bool activo)
        {
            bool exito = true;
            string mensaje = string.Empty;

            if (activo == false)
            {
                mensaje = "UsuarioActivadoExitosamente";
            }
            else
            {
                mensaje = "UsuarioDesactivadoExitosamente";
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
        }

        public (bool, string) Desbloquear_Usuario(string login, string password)
        {
            bool exito = true;
            string mensaje = "UsuarioDesbloqueadoExitosamente";

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
        }
        #endregion
    }
}