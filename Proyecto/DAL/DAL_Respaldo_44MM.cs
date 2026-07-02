using Servicios;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace DAL
{
    public class DAL_Respaldo_44MM
    {
        private SqlConnection conexion = DAL_44MM.Instancia.Nueva_Conexion();
        public (bool, string) Hacer_BackUp(string ruta_BK)
        {
            bool exito = true;
            string mensaje = "BackupExitoso";
            string nombre_archivo = $"Proyecto IS2026.BCK_{DateTime.Now:ddMMyy_HHmm}.bak";
            string ruta_completa = ruta_BK += nombre_archivo;
            //string ruta_completa = Path.Combine(ruta_BK, nombre_archivo);

            string comando_backup = $"BACKUP DATABASE [Proyecto IS2026] TO DISK = '{ruta_completa}'";

            conexion.Open();
            try
            {
                using (SqlCommand cmd = new SqlCommand(comando_backup, conexion))
                {
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                exito = false;
                mensaje = ex.Message;
            }
            conexion.Close();
            return (exito, mensaje);
        }

        public (bool, string) Hacer_Restore(string ruta_RT)
        {
            bool exito = true;
            string mensaje = "RestoreExitoso";
            string comandoRestore = @"
            USE master;
            ALTER DATABASE [Proyecto IS2026] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
            RESTORE DATABASE [Proyecto IS2026] 
            FROM DISK = @RutaCompleta WITH REPLACE;
            ALTER DATABASE [Proyecto IS2026] SET MULTI_USER;";

            conexion.Open();
            try
            {

                using (SqlCommand cmd = new SqlCommand(comandoRestore, conexion))
                {
                    cmd.Parameters.AddWithValue("@RutaCompleta", ruta_RT);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                exito = false;
                mensaje = ex.Message;
            }
            conexion.Close();
            return (exito, mensaje);
        }
    }
}
