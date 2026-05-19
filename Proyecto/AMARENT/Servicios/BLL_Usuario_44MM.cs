using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class BLL_Usuario_44MM
    {
        private DAL_Usuario_44MM dal_usuarios = new DAL_Usuario_44MM();

        #region Usuario
        //Devuelve : exito / numero de operacion
        public (bool, int) Iniciar_Sesion(string login, string contra)
        {
            DataRow info;
            int cod_op = 0;

            //Valida si hay una cuenta logueada
            bool login_rec = Sesion_Manager_44MM.Validar_Cuenta();
            if (login_rec == true)
            {
                cod_op = 7;
                //Ya hay una cuenta logueada
                return (false, cod_op);
            }
            else
            {
                //Encripta la contraseña y verifica la informacion de Login
                string contra_enc = Encriptador_44MM.Computar(contra);
                DataTable tabla_datos = dal_usuarios.Verificar_Cuenta(login);

                if (tabla_datos.Rows.Count != 1)
                {
                    if (tabla_datos.Rows.Count != 0)
                    {
                        cod_op = 6;
                        //Inconsistencia en la base de datos
                        return (false, cod_op);
                    }
                    else
                    {
                        cod_op = 5;
                        //Usuario no existe
                        return (false, cod_op);
                    }
                }
                else
                {
                    //Como es la unica fila, se recupera la informacion del usuario
                    info = tabla_datos.Rows[0];
                    string contra_rec = (string)info["Password"];
                    bool bloqueado_rec = (bool)info["Bloqueado"];
                    bool activo_rec = (bool)info["Activo"];

                    if (bloqueado_rec == true)
                    {
                        cod_op = 4;
                        //Usuario bloqueado
                        return (false, cod_op);
                    }
                    else if (activo_rec == false)
                    {
                        cod_op = 3;
                        //Usuario inactivo
                        return (false, cod_op);
                    }
                    else if (contra_enc != contra_rec)
                    {
                        cod_op = 2;

                        //Agrega un intento fallido
                        int intentos = Gestion_Intentos_44MM.Instancia.Agregar_Intento(login);

                        //Si se alcanzan los 3 intentos, bloquea el usuario
                        if (intentos <= 0)
                        {
                            dal_usuarios.Bloquear_Usuario(login);
                            Bitacora_44MM.Registrar_Evento(login, DateTime.Now, "Usuarios", "Bloqueo", 1);
                        }
                        //Contraseña incorrecta
                        return (false, cod_op);
                    }
                    else
                    {
                        //Crea la sesion del usuario, lo coloca en el Sesion Manager y registra el evento en la bitacora
                        cod_op = 1;
                        BE_Usuario_44MM usuario = new BE_Usuario_44MM(info);
                        Sesion_Manager_44MM.Set(usuario);
                        Bitacora_44MM.Registrar_Evento(login, DateTime.Now, "Usuarios", "Login", 1);
                        //Sesion iniciada
                        return (true, cod_op);
                    }
                }
            }
        }

        public (bool, string) Cambiar_Clave(string contra, string nueva_contra)
        {
            bool exito = false;
            string mensaje = string.Empty;
            DataRow info;

            // Recupera el login, encripta la contraseña y verifica la informacion de Login
            BE_Usuario_44MM usuario = Sesion_Manager_44MM.Get();
            string login = usuario.Login;
            string contra_enc = Encriptador_44MM.Computar(contra);
            DataTable tabla_datos = dal_usuarios.Verificar_Cuenta(login);

            info = tabla_datos.Rows[0];
            string contra_rec = (string)info["Password"];

            //Compara la contraseña ingresada con la contraseña recuperada
            if (contra_enc != contra_rec)
            {
                mensaje = "Contraseña Actual Incorrecta";
                return (false, mensaje);
            }
            else
            {
                //Encripta la nueva contraseña y la actualiza en la base de datos
                string nueva_contra_enc = Encriptador_44MM.Computar(nueva_contra);
                (exito, mensaje) = dal_usuarios.Cambiar_Clave(login, nueva_contra_enc);
                if (exito == false)
                {
                    return (false, mensaje);
                }
                else
                {
                    //Registra el evento en la bitacora
                    mensaje = "Contraseña Actualizada";
                    Bitacora_44MM.Registrar_Evento(login, DateTime.Now, "Usuarios", "Cambiar Clave", 1);
                    return (true, mensaje);
                }
            }
        }

        //Devuelve : pin blanco / dni blanco
        public void Cerrar_Sesion()
        {
            //Obtiene el login del usuario actual, lo quita del Sesion Manager y registra el evento en la bitacora
            string login = Sesion_Manager_44MM.Get().Login;
            Sesion_Manager_44MM.Quitar_Cuenta();
            Bitacora_44MM.Registrar_Evento(login, DateTime.Now, "Usuarios", "Logout", 1);
        }
        #endregion
        #region Gestion
        //Devuelve : tabla completa / tabla deactivos / tabla bloqueados
        public (DataTable, DataTable, DataTable) Gestionar_Usuarios()
        {
            //Recupera la tabla de usuarios
            dal_usuarios.Recuperar_Usuarios();
            DataTable tabla_usuarios = dal_usuarios.tabla_datos;

            //Filtra los activos y bloqueados
            DataTable tabla_activos = DataTable_Filter_44MM.Filtrar_Tabla(tabla_usuarios, "Activo", true.ToString());
            DataTable tabla_bloqueados = DataTable_Filter_44MM.Filtrar_Tabla(tabla_usuarios, "Bloqueado", true.ToString());

            return (tabla_usuarios, tabla_activos, tabla_bloqueados);
        }

        public (bool, string) Crear_Usuario(string dni, string nombre, string apellido, string email, string rol)
        {
            bool exito = false;
            string mensaje;

            //Crea el login por defecto (nombre + dni)
            string login = nombre + dni;

            //Obtiene el login si es que existe
            (exito, mensaje) = dal_usuarios.Verificar_Login(login);

            //Verifica que el login generado no exista en la base de datos
            if (exito == true)
            {
                //Crea y encripta la contraseña por defecto (apellido + dni)
                string password = Encriptador_44MM.Computar(apellido + dni);

                //Valores por defecto
                bool bloqueado = false;
                bool activo = true;

                //Crea el nuevo usuario a la base de datos
                (exito, mensaje) = dal_usuarios.Crear_Usuario(dni, nombre, apellido, login, email, password, rol, bloqueado, activo);

                if (exito == true)
                {
                    string login_sesion = Sesion_Manager_44MM.Get().Login;
                    //Registra el evento en la bitacora
                    Bitacora_44MM.Registrar_Evento(login_sesion, DateTime.Now, "Usuarios", "Crear Usuario " + login, 1);
                    return (true, mensaje);
                }
                else
                {
                    return (false, mensaje);
                }
            }
            else
            {
                return (false, mensaje);
            }
        }

        public (bool, string) Modificar_Usuario(string login, string email, string rol)
        {
            bool exito = false;
            string mensaje = string.Empty;

            //Modifica el email y rol del usuario seleccionado
            (exito, mensaje) = dal_usuarios.Modificar_Usuario(login, email, rol);
            if (exito == true)
            {
                string login_sesion = Sesion_Manager_44MM.Get().Login;
                //Registra el evento en la bitacora
                Bitacora_44MM.Registrar_Evento(login_sesion, DateTime.Now, "Usuarios", "Modificar Usuario " + login, 1);
                return (true, mensaje);
            }
            else
            {
                return (false, mensaje);
            }
        }

        public (bool, string) Activar_Usuario(string login, bool activo)
        {
            bool exito = false;
            string mensaje = string.Empty;

            //Modifica el estado "Activo" del usuario seleccionado
            (exito, mensaje) = dal_usuarios.Activar_Usuario(login, activo);
            if (exito == true)
            {
                string login_sesion = Sesion_Manager_44MM.Get().Login;
                //Registra el evento en la bitacora
                Bitacora_44MM.Registrar_Evento(login_sesion, DateTime.Now, "Usuarios", "Activar Usuario " + login, 1);
                return (true, mensaje);
            }
            else
            {
                return (false, mensaje);
            }
        }

        public (bool, string) Desbloquear_Usuario(DataRow fila)
        {
            bool exito = false;
            string mensaje = string.Empty;

            //Obtiene el login, apellido y dni del usuario seleccionado
            string login = (string)fila["Login"];
            string apellido = (string)fila["Apellido"];
            string dni = (string)fila["DNI"];

            //Encripta la contraseña por defecto (apellido + dni)
            string password = Encriptador_44MM.Computar(apellido + dni);

            //Modifica el estado "Bloqueado" del usuario seleccionado
            (exito, mensaje) = dal_usuarios.Desbloquear_Usuario(login, password);
            if (exito == true)
            {
                string login_sesion = Sesion_Manager_44MM.Get().Login;
                //Registra el evento en la bitacora
                Bitacora_44MM.Registrar_Evento(login_sesion, DateTime.Now, "Usuarios", "Desbloquear Usuario " + login, 1);
                return (true, mensaje);
            }
            else
            {
                return (false, mensaje);
            }
        }
        #endregion
    }
}
