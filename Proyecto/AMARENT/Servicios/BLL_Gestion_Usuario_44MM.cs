using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class BLL_Gestion_Usuario_44MM
    {
        private DAL_Gestion_Usuarios_44MM dal_gestion_usuarios = new DAL_Gestion_Usuarios_44MM();

        public (DataTable, DataTable, DataTable) Gestionar_Usuarios()
        {
            dal_gestion_usuarios.Recuperar_Usuarios();
            DataTable tabla_usuarios = dal_gestion_usuarios.tabla_datos;
            DataTable tabla_activos = DataTable_Filter_44MM.Filtrar_Tabla(tabla_usuarios, "Activo", true.ToString());
            DataTable tabla_bloqueados = DataTable_Filter_44MM.Filtrar_Tabla(tabla_usuarios, "Bloqueado", true.ToString());

            return (tabla_usuarios, tabla_activos, tabla_bloqueados);
        }

        public (bool, string) Crear_Usuario(string dni, string nombre, string apellido, string email, string rol)
        {
            string login = nombre + dni;
            bool exito = false;
            string mensaje;

            (exito, mensaje) = dal_gestion_usuarios.Verificar_Login(login);

            if (exito == true)
            {
                string password = Encriptador_44MM.Computar(apellido + dni);
                bool bloqueado = false;
                bool activo = true;
                (exito, mensaje) = dal_gestion_usuarios.Agregar_Usuario(dni, nombre, apellido, login, email, password, rol, bloqueado, activo);
            }
            return (exito, mensaje);
        }

        public (bool, string) Modificar_Usuario(string login, string email, string rol)
        {
            bool exito = false;
            string mensaje = string.Empty;

            (exito, mensaje) = dal_gestion_usuarios.Modificar_Usuario(login, email, rol);

            return (exito, mensaje);
        }

        public (bool, string) Activar_Usuario(string login, bool activo)
        {
            bool exito = false;
            string mensaje = string.Empty;

            (exito, mensaje) = dal_gestion_usuarios.Activar_Usuario(login, activo);
            return (exito, mensaje);
        }

        public (bool, string) Desbloquear_Usuario(DataRow fila)
        {
            bool exito = false;
            string mensaje = string.Empty;

            string login = (string)fila["Login"];
            string apellido = (string)fila["Apellido"];
            string dni = (string)fila["DNI"];
            string password = Encriptador_44MM.Computar(apellido + dni);

            (exito, mensaje) = dal_gestion_usuarios.Desbloquear_Usuario(login, password);
            return (exito, mensaje);
        }
    }
}
