using Servicios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_Perfil_44MM
    {
        //public DataSet dataSet = new DataSet();

        private string nombre_tabla_perfil = "Perfil";
        public DataTable tabla_datos_perfil;
        private string query_perfil;

        private string nombre_tabla_familia = "Familia";
        public DataTable tabla_datos_familia;
        private string query_familia;

        private string nombre_tabla_permiso = "Permiso";
        public DataTable tabla_datos_permiso;
        private string query_permiso;

        private string nombre_tabla_perfil_familia = "Perfil_Familia";
        public DataTable tabla_datos_perfil_familia;
        private string query_perfil_familia;

        private string nombre_tabla_perfil_permiso = "Perfil_Permiso";
        public DataTable tabla_datos_perfil_permiso;
        private string query_perfil_permiso;

        private string nombre_tabla_familia_familia = "Familia_Familia";
        public DataTable tabla_datos_familia_familia;
        private string query_familia_familia;

        private string nombre_tabla_familia_permiso = "Familia_Permiso";
        public DataTable tabla_datos_familia_permiso;
        private string query_familia_permiso;


        private SqlConnection conexion = DAL_44MM.Instancia.Conexion;

        public DAL_Perfil_44MM()
        {
            Recuperar_Todo();
        }

        #region Recuperacion
        public void Recuperar_Todo()
        {
            Recuperar_Perfiles();
            Recuperar_Familias();
            Recuperar_Permisos();
            Recuperar_Perfil_Familias();
            Recuperar_Perfil_Permisos();
            Recuperar_Familia_Familias();
            Recuperar_Familia_Permisos();
        }

        private void Recuperar_Perfiles()
        {
            query_perfil = DAL_44MM.Instancia.Conectar(nombre_tabla_perfil);
            tabla_datos_perfil = DAL_44MM.Instancia.Consultar(tabla_datos_perfil, nombre_tabla_perfil, query_perfil);
            DataColumn p = tabla_datos_perfil.Columns["Cod_Perfil"];
            tabla_datos_perfil.PrimaryKey = new DataColumn[] { p };
            //dataSet.Tables.Add(tabla_datos_perfil);
        }

        private void Recuperar_Familias()
        {
            query_familia = DAL_44MM.Instancia.Conectar(nombre_tabla_familia);
            tabla_datos_familia = DAL_44MM.Instancia.Consultar(tabla_datos_familia, nombre_tabla_familia, query_familia);
            DataColumn p = tabla_datos_familia.Columns["Cod_Familia"];
            tabla_datos_familia.PrimaryKey = new DataColumn[] { p };
            //dataSet.Tables.Add(tabla_datos_familia);
        }

        private void Recuperar_Permisos()
        {
            query_permiso = DAL_44MM.Instancia.Conectar(nombre_tabla_permiso);
            tabla_datos_permiso = DAL_44MM.Instancia.Consultar(tabla_datos_permiso, nombre_tabla_permiso, query_permiso);
            DataColumn p = tabla_datos_permiso.Columns["Cod_Permiso"];
            tabla_datos_permiso.PrimaryKey = new DataColumn[] { p };
            //dataSet.Tables.Add(tabla_datos_permiso);
        }

        private void Recuperar_Perfil_Familias()
        {
            query_perfil_familia = DAL_44MM.Instancia.Conectar(nombre_tabla_perfil_familia);
            tabla_datos_perfil_familia = DAL_44MM.Instancia.Consultar(tabla_datos_perfil_familia, nombre_tabla_perfil_familia, query_perfil_familia);
            //dataSet.Tables.Add(tabla_datos_perfil_familia);
            //DataRelation relacion_superior = new DataRelation(nombre_tabla_perfil_familia + "_Padre", tabla_datos_perfil.Columns["Cod_Perfil"], tabla_datos_perfil_familia.Columns["Cod_Perfil"]);
            //DataRelation relacion_inferior = new DataRelation(nombre_tabla_perfil_familia + "_Hijo", tabla_datos_familia.Columns["Cod_Familia"], tabla_datos_perfil_familia.Columns["Cod_Familia"]);
            //dataSet.Relations.Add(relacion_superior);
            //dataSet.Relations.Add(relacion_inferior);
        }

        private void Recuperar_Perfil_Permisos()
        {
            query_perfil_permiso = DAL_44MM.Instancia.Conectar(nombre_tabla_perfil_permiso);
            tabla_datos_perfil_permiso = DAL_44MM.Instancia.Consultar(tabla_datos_perfil_permiso, nombre_tabla_perfil_permiso, query_perfil_permiso);
            //dataSet.Tables.Add(tabla_datos_perfil_permiso);
            //DataRelation relacion_superior = new DataRelation(nombre_tabla_perfil_permiso + "_Padre", tabla_datos_perfil.Columns["Cod_Perfil"], tabla_datos_perfil_permiso.Columns["Cod_Perfil"]);
            //DataRelation relacion_inferior = new DataRelation(nombre_tabla_perfil_permiso + "_Hijo", tabla_datos_permiso.Columns["Cod_Permiso"], tabla_datos_perfil_permiso.Columns["Cod_Permiso"]);
            //dataSet.Relations.Add(relacion_superior);
            //dataSet.Relations.Add(relacion_inferior);
        }

        private void Recuperar_Familia_Familias()
        {
            query_familia_familia = DAL_44MM.Instancia.Conectar(nombre_tabla_familia_familia);
            tabla_datos_familia_familia = DAL_44MM.Instancia.Consultar(tabla_datos_familia_familia, nombre_tabla_familia_familia, query_familia_familia);
            //dataSet.Tables.Add(tabla_datos_familia_familia);
            //DataRelation relacion_superior = new DataRelation(nombre_tabla_familia_familia + "_Padre", tabla_datos_familia.Columns["Cod_Familia"], tabla_datos_familia_familia.Columns["Cod_Familia_Padre"]);
            //DataRelation relacion_inferior = new DataRelation(nombre_tabla_familia_familia + "_Hijo", tabla_datos_familia.Columns["Cod_Familia"], tabla_datos_familia_familia.Columns["Cod_Familia_Hijo"]);
            //dataSet.Relations.Add(relacion_superior);
            //dataSet.Relations.Add(relacion_inferior);
        }

        private void Recuperar_Familia_Permisos()
        {
            query_familia_permiso = DAL_44MM.Instancia.Conectar(nombre_tabla_familia_permiso);
            tabla_datos_familia_permiso = DAL_44MM.Instancia.Consultar(tabla_datos_familia_permiso, nombre_tabla_familia_permiso, query_familia_permiso);
            //dataSet.Tables.Add(tabla_datos_familia_permiso);
            //DataRelation relacion_superior = new DataRelation(nombre_tabla_familia_permiso + "_Padre", tabla_datos_familia.Columns["Cod_Familia"], tabla_datos_familia_permiso.Columns["Cod_Familia"]);
            //DataRelation relacion_inferior = new DataRelation(nombre_tabla_familia_permiso + "_Hijo", tabla_datos_permiso.Columns["Cod_Permiso"], tabla_datos_familia_permiso.Columns["Cod_Permiso"]);
            //dataSet.Relations.Add(relacion_superior);
            //dataSet.Relations.Add(relacion_inferior);
        }
        #endregion

        #region Creacion
        public (bool, string) Agregar_Perfil(string cod_perfil, string nombre, List<string> lista_nombres_familias, List<string> lista_nombres_permisos)
        {
            bool exito = true;
            string mensaje = "PerfilCreadoExitosamente";

            conexion.Open();
            SqlTransaction transaction = conexion.BeginTransaction();
            try
            {
                string sql = $"INSERT INTO {nombre_tabla_perfil} (Cod_Perfil, Nombre) VALUES (@Cod_Perfil, @Nombre)";
                SqlCommand cmd = new SqlCommand(sql, conexion);
                cmd.Transaction = transaction;

                cmd.Parameters.AddWithValue("@Cod_Perfil", cod_perfil);
                cmd.Parameters.AddWithValue("@Nombre", nombre);

                cmd.ExecuteNonQuery();

                foreach (string cod_familia in lista_nombres_familias)
                {
                    string sql_f = $"INSERT INTO {nombre_tabla_perfil_familia} (Cod_Perfil, Cod_Familia) VALUES (@Cod_Perfil, @Cod_Familia)";
                    SqlCommand cmd_f = new SqlCommand(sql_f, conexion);
                    cmd_f.Transaction = transaction;

                    cmd_f.Parameters.AddWithValue("@Cod_Perfil", cod_perfil);
                    cmd_f.Parameters.AddWithValue("@Cod_Familia", cod_familia);
                    cmd_f.ExecuteNonQuery();

                    string sql_ft = $"UPDATE {nombre_tabla_familia} SET Es_Tope = @Es_Tope WHERE Cod_Familia = @Cod_Familia";
                    SqlCommand cmd_ft = new SqlCommand(sql_ft, conexion);
                    cmd_ft.Transaction = transaction;

                    cmd_ft.Parameters.AddWithValue("@Es_Tope", false);
                    cmd_ft.Parameters.AddWithValue("@Cod_Familia", cod_familia);
                    cmd_ft.ExecuteNonQuery();
                }

                foreach (string cod_permiso in lista_nombres_permisos)
                {
                    string sql_p = $"INSERT INTO {nombre_tabla_perfil_permiso} (Cod_Perfil, Cod_Permiso) VALUES (@Cod_Perfil, @Cod_Permiso)";
                    SqlCommand cmd_p = new SqlCommand(sql_p, conexion);
                    cmd_p.Transaction = transaction;

                    cmd_p.Parameters.AddWithValue("@Cod_Perfil", cod_perfil);
                    cmd_p.Parameters.AddWithValue("@Cod_Permiso", cod_permiso);

                    cmd_p.ExecuteNonQuery();
                }

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

        public (bool, string) Agregar_Familia(string cod_familia, string nombre, List<string> lista_nombres_familias, List<string> lista_nombres_permisos)
        {
            bool exito = true;
            string mensaje = "FamiliaCreadoExitosamente";

            conexion.Open();
            SqlTransaction transaction = conexion.BeginTransaction();
            try
            {
                string sql = $"INSERT INTO {nombre_tabla_familia} (Cod_Familia, Nombre) VALUES (@Cod_Familia, @Nombre)";
                SqlCommand cmd = new SqlCommand(sql, conexion);
                cmd.Transaction = transaction;

                cmd.Parameters.AddWithValue("@Cod_Familia", cod_familia);
                cmd.Parameters.AddWithValue("@Nombre", nombre);

                cmd.ExecuteNonQuery();

                foreach (string cod_familia_hijo in lista_nombres_familias)
                {
                    string sql_f = $"INSERT INTO {nombre_tabla_familia_familia} (Cod_Familia_Padre, Cod_Familia_Hijo) VALUES (@Cod_Familia_Padre, @Cod_Familia_Hijo)";
                    SqlCommand cmd_f = new SqlCommand(sql_f, conexion);
                    cmd_f.Transaction = transaction;

                    cmd_f.Parameters.AddWithValue("@Cod_Familia_Padre", cod_familia);
                    cmd_f.Parameters.AddWithValue("@Cod_Familia_Hijo", cod_familia_hijo);
                    cmd_f.ExecuteNonQuery();

                    string sql_ft = $"UPDATE {nombre_tabla_familia} SET Es_Tope = @Es_Tope WHERE Cod_Familia = @Cod_Familia";
                    SqlCommand cmd_ft = new SqlCommand(sql_ft, conexion);
                    cmd_ft.Transaction = transaction;

                    cmd_ft.Parameters.AddWithValue("@Es_Tope", false);
                    cmd_ft.Parameters.AddWithValue("@Cod_Familia", cod_familia_hijo);
                    cmd_ft.ExecuteNonQuery();
                }

                foreach (string cod_permiso in lista_nombres_permisos)
                {
                    string sql_p = $"INSERT INTO {nombre_tabla_familia_permiso} (Cod_Familia, Cod_Permiso) VALUES (@Cod_Familia, @Cod_Permiso)";
                    SqlCommand cmd_p = new SqlCommand(sql_p, conexion);
                    cmd_p.Transaction = transaction;

                    cmd_p.Parameters.AddWithValue("@Cod_Familia", cod_familia);
                    cmd_p.Parameters.AddWithValue("@Cod_Permiso", cod_permiso);

                    cmd_p.ExecuteNonQuery();
                }

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
        #endregion

        #region Modificacion
        public (bool, string) Modificar_Perfil(string cod_perfil, List<string> lista_nombres_familias, List<string> lista_nombres_permisos)
        {
            bool exito = true;
            string mensaje = "PerfilModificadoExitosamente";

            conexion.Open();
            SqlTransaction transaction = conexion.BeginTransaction();
            try
            {
                DataTable tabla = DAL_44MM.Instancia.Seleccionar(nombre_tabla_perfil_familia, "Cod_Perfil", cod_perfil);

                string sql_p = $"DELETE FROM {nombre_tabla_perfil_permiso} WHERE Cod_Perfil = @Cod_Perfil";
                SqlCommand cmd_p = new SqlCommand(sql_p, conexion);
                cmd_p.Transaction = transaction;
                cmd_p.Parameters.AddWithValue("@Cod_Perfil", cod_perfil);
                cmd_p.ExecuteNonQuery();

                foreach (DataRow row in tabla.Rows)
                {
                    string cod_familia = (string)row["Cod_Familia"];
                    bool se_libera = Verificar_Ultimo(cod_familia);
                    if (se_libera == true)
                    {
                        string sql_ft = $"UPDATE {nombre_tabla_familia} SET Es_Tope = @Es_Tope WHERE Cod_Familia = @Cod_Familia";
                        SqlCommand cmd_ft = new SqlCommand(sql_ft, conexion);
                        cmd_ft.Transaction = transaction;
                        cmd_ft.Parameters.AddWithValue("@Es_Tope", true);
                        cmd_ft.Parameters.AddWithValue("@Cod_Familia", cod_familia);
                        cmd_ft.ExecuteNonQuery();
                    }
                }

                string sql_f = $"DELETE FROM {nombre_tabla_perfil_familia} WHERE Cod_Perfil = @Cod_Perfil";
                SqlCommand cmd_f = new SqlCommand(sql_f, conexion);
                cmd_f.Transaction = transaction;
                cmd_f.Parameters.AddWithValue("@Cod_Perfil", cod_perfil);
                cmd_f.ExecuteNonQuery();

                foreach (string cod_familia in lista_nombres_familias)
                {
                    string sql_ff = $"INSERT INTO {nombre_tabla_perfil_familia} (Cod_Perfil, Cod_Familia) VALUES (@Cod_Perfil, @Cod_Familia)";
                    SqlCommand cmd_ff = new SqlCommand(sql_ff, conexion);
                    cmd_ff.Transaction = transaction;

                    cmd_ff.Parameters.AddWithValue("@Cod_Perfil", cod_perfil);
                    cmd_ff.Parameters.AddWithValue("@Cod_Familia", cod_familia);
                    cmd_ff.ExecuteNonQuery();

                    string sql_ft = $"UPDATE {nombre_tabla_familia} SET Es_Tope = @Es_Tope WHERE Cod_Familia = @Cod_Familia";
                    SqlCommand cmd_ft = new SqlCommand(sql_ft, conexion);
                    cmd_ft.Transaction = transaction;

                    cmd_ft.Parameters.AddWithValue("@Es_Tope", false);
                    cmd_ft.Parameters.AddWithValue("@Cod_Familia", cod_familia);
                    cmd_ft.ExecuteNonQuery();
                }

                foreach (string cod_permiso in lista_nombres_permisos)
                {
                    string sql_pp = $"INSERT INTO {nombre_tabla_perfil_permiso} (Cod_Perfil, Cod_Permiso) VALUES (@Cod_Perfil, @Cod_Permiso)";
                    SqlCommand cmd_pp = new SqlCommand(sql_pp, conexion);
                    cmd_pp.Transaction = transaction;

                    cmd_pp.Parameters.AddWithValue("@Cod_Perfil", cod_perfil);
                    cmd_pp.Parameters.AddWithValue("@Cod_Permiso", cod_permiso);

                    cmd_pp.ExecuteNonQuery();
                }

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

        public (bool, string) Modificar_Familia(string cod_familia, List<string> lista_nombres_familias, List<string> lista_nombres_permisos)
        {
            bool exito = true;
            string mensaje = "FamiliaModificadoExitosamente";

            conexion.Open();
            SqlTransaction transaction = conexion.BeginTransaction();
            try
            {
                DataTable tabla = DAL_44MM.Instancia.Seleccionar(nombre_tabla_familia_familia, "Cod_Familia_Padre", cod_familia);

                string sql_p = $"DELETE FROM {nombre_tabla_familia_permiso} WHERE Cod_Familia = @Cod_Familia";
                SqlCommand cmd_p = new SqlCommand(sql_p, conexion);
                cmd_p.Transaction = transaction;
                cmd_p.Parameters.AddWithValue("@Cod_Familia", cod_familia);
                cmd_p.ExecuteNonQuery();

                foreach (DataRow row in tabla.Rows)
                {
                    string cod_familia_hijo = (string)row["Cod_Familia_Hijo"];
                    bool se_libera = Verificar_Ultimo(cod_familia_hijo);
                    if (se_libera == true)
                    {
                        string sql_ft = $"UPDATE {nombre_tabla_familia} SET Es_Tope = @Es_Tope WHERE Cod_Familia = @Cod_Familia";
                        SqlCommand cmd_ft = new SqlCommand(sql_ft, conexion);
                        cmd_ft.Transaction = transaction;
                        cmd_ft.Parameters.AddWithValue("@Es_Tope", true);
                        cmd_ft.Parameters.AddWithValue("@Cod_Familia", cod_familia_hijo);
                        cmd_ft.ExecuteNonQuery();
                    }
                }

                string sql_f = $"DELETE FROM {nombre_tabla_familia_familia} WHERE Cod_Familia_Padre = @Cod_Familia_Padre";
                SqlCommand cmd_f = new SqlCommand(sql_f, conexion);
                cmd_f.Transaction = transaction;
                cmd_f.Parameters.AddWithValue("@Cod_Familia_Padre", cod_familia);
                cmd_f.ExecuteNonQuery();

                foreach (string cod_familia_hijo in lista_nombres_familias)
                {
                    string sql_ff = $"INSERT INTO {nombre_tabla_familia_familia} (Cod_Familia_Padre, Cod_Familia_Hijo) VALUES (@Cod_Familia_Padre, @Cod_Familia_Hijo)";
                    SqlCommand cmd_ff = new SqlCommand(sql_ff, conexion);
                    cmd_ff.Transaction = transaction;

                    cmd_ff.Parameters.AddWithValue("@Cod_Familia_Padre", cod_familia);
                    cmd_ff.Parameters.AddWithValue("@Cod_Familia_Hijo", cod_familia_hijo);
                    cmd_ff.ExecuteNonQuery();

                    string sql_ft = $"UPDATE {nombre_tabla_familia} SET Es_Tope = @Es_Tope WHERE Cod_Familia = @Cod_Familia";
                    SqlCommand cmd_ft = new SqlCommand(sql_ft, conexion);
                    cmd_ft.Transaction = transaction;

                    cmd_ft.Parameters.AddWithValue("@Es_Tope", false);
                    cmd_ft.Parameters.AddWithValue("@Cod_Familia", cod_familia_hijo);
                    cmd_ft.ExecuteNonQuery();
                }

                foreach (string cod_permiso in lista_nombres_permisos)
                {
                    string sql_pp = $"INSERT INTO {nombre_tabla_familia_permiso} (Cod_Familia, Cod_Permiso) VALUES (@Cod_Familia, @Cod_Permiso)";
                    SqlCommand cmd_pp = new SqlCommand(sql_pp, conexion);
                    cmd_pp.Transaction = transaction;

                    cmd_pp.Parameters.AddWithValue("@Cod_Familia", cod_familia);
                    cmd_pp.Parameters.AddWithValue("@Cod_Permiso", cod_permiso);

                    cmd_pp.ExecuteNonQuery();
                }

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
        #endregion

        #region Eliminacion
        public (bool, string) Eliminar_Perfil(string cod_perfil, List<string> lista_nombres_familias)
        {
            bool exito = true;
            string mensaje = "PerfilEliminadoExitosamente";

            conexion.Open();
            SqlTransaction transaction = conexion.BeginTransaction();
            try
            {
                string sql_p = $"DELETE FROM {nombre_tabla_perfil_permiso} WHERE Cod_Perfil = @Cod_Perfil";
                SqlCommand cmd_p = new SqlCommand(sql_p, conexion);
                cmd_p.Transaction = transaction;
                cmd_p.Parameters.AddWithValue("@Cod_Perfil", cod_perfil);
                cmd_p.ExecuteNonQuery();

                foreach (string cod_familia in lista_nombres_familias)
                {
                    bool se_libera = Verificar_Ultimo(cod_familia);
                    if (se_libera == true)
                    {
                        string sql_ft = $"UPDATE {nombre_tabla_familia} SET Es_Tope = @Es_Tope WHERE Cod_Familia = @Cod_Familia";
                        SqlCommand cmd_ft = new SqlCommand(sql_ft, conexion);
                        cmd_ft.Transaction = transaction;
                        cmd_ft.Parameters.AddWithValue("@Es_Tope", true);
                        cmd_ft.Parameters.AddWithValue("@Cod_Familia", cod_familia);
                        cmd_ft.ExecuteNonQuery();
                    }
                }

                string sql_f = $"DELETE FROM {nombre_tabla_perfil_familia} WHERE Cod_Perfil = @Cod_Perfil";
                SqlCommand cmd_f = new SqlCommand(sql_f, conexion);
                cmd_f.Transaction = transaction;
                cmd_f.Parameters.AddWithValue("@Cod_Perfil", cod_perfil);
                cmd_f.ExecuteNonQuery();

                string sql = $"DELETE FROM {nombre_tabla_perfil} WHERE Cod_Perfil = @Cod_Perfil";
                SqlCommand cmd = new SqlCommand(sql, conexion);
                cmd.Transaction = transaction;
                cmd.Parameters.AddWithValue("@Cod_Perfil", cod_perfil);
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

        public (bool, string) Eliminar_Familia(string cod_familia, List<string> lista_nombres_familias)
        {
            bool exito = true;
            string mensaje = "FamiliaEliminadoExitosamente";

            conexion.Open();
            SqlTransaction transaction = conexion.BeginTransaction();
            try
            {
                string sql_p = $"DELETE FROM {nombre_tabla_familia_permiso} WHERE Cod_Familia = @Cod_Familia";
                SqlCommand cmd_p = new SqlCommand(sql_p, conexion);
                cmd_p.Transaction = transaction;
                cmd_p.Parameters.AddWithValue("@Cod_Familia", cod_familia);
                cmd_p.ExecuteNonQuery();

                foreach (string cod_familia_hijo in lista_nombres_familias)
                {
                    bool se_libera = Verificar_Ultimo(cod_familia_hijo);
                    if (se_libera == true)
                    {
                        string sql_ft = $"UPDATE {nombre_tabla_familia} SET Es_Tope = @Es_Tope WHERE Cod_Familia = @Cod_Familia";
                        SqlCommand cmd_ft = new SqlCommand(sql_ft, conexion);
                        cmd_ft.Transaction = transaction;
                        cmd_ft.Parameters.AddWithValue("@Es_Tope", true);
                        cmd_ft.Parameters.AddWithValue("@Cod_Familia", cod_familia_hijo);
                        cmd_ft.ExecuteNonQuery();
                    }
                }

                string sql_f = $"DELETE FROM {nombre_tabla_familia_familia} WHERE Cod_Familia_Padre = @Cod_Familia_Padre";
                SqlCommand cmd_f = new SqlCommand(sql_f, conexion);
                cmd_f.Transaction = transaction;
                cmd_f.Parameters.AddWithValue("@Cod_Familia_Padre", cod_familia);
                cmd_f.ExecuteNonQuery();

                string sql = $"DELETE FROM {nombre_tabla_familia} WHERE Cod_Familia = @Cod_Familia";
                SqlCommand cmd = new SqlCommand(sql, conexion);
                cmd.Transaction = transaction;
                cmd.Parameters.AddWithValue("@Cod_Familia", cod_familia);
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
        #endregion

        #region Otros
        private bool Verificar_Ultimo(string codigo)
        {
            DataTable tabla_perfiles_ocupantes = DAL_44MM.Instancia.Seleccionar(nombre_tabla_perfil_familia, "Cod_Familia", codigo);
            DataTable tabla_familias_ocupantes = DAL_44MM.Instancia.Seleccionar(nombre_tabla_familia_familia, "Cod_Familia_Hijo", codigo);

            if (tabla_perfiles_ocupantes.Rows.Count + tabla_familias_ocupantes.Rows.Count <= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
    }
}
