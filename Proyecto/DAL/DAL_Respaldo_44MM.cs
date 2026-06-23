using Servicios;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_Respaldo_44MM
    {
        private SqlConnection conexion = DAL_44MM.Instancia.Conexion;
        public void Hacer_BackUp(string ruta_BK)
        {
            string nombre_archivo = $"Proyecto IS2026.BCK_{DateTime.Now:ddMMyy_HHmm}.bak";
            string ruta_completa = System.IO.Path.Combine(ruta_BK, nombre_archivo);

            string comando_backup = $"BACKUP DATABASE [Proyecto IS2026] TO DISK = '{ruta_completa}'";

            conexion.Open();
            using (SqlCommand cmd = new SqlCommand(comando_backup))
            {
                cmd.ExecuteNonQuery();
            }
            conexion.Close();
        }

        public void Hacer_Restore(string ruta_RT)
        {
            string comandoRestore = @"
            USE master;
            ALTER DATABASE [Proyecto IS2026] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
            RESTORE DATABASE [Proyecto IS2026] 
            FROM DISK = @RutaCompleta WITH REPLACE;
            ALTER DATABASE [Proyecto IS2026] SET MULTI_USER;";

            conexion.Open();
            using (SqlCommand cmd = new SqlCommand(comandoRestore))
            {
                cmd.Parameters.AddWithValue("@RutaCompleta", ruta_RT);
                cmd.ExecuteNonQuery();
            }
            conexion.Close();
        }
    }
}
