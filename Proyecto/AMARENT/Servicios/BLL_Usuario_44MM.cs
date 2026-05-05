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
                        int intentos = Gestion_Intentos_44MM.Instancia.Agregar_Intento(login);
                        if (intentos <= 0)
                        {
                            dal_usuarios.Bloquear_Usuario(login);
                        }
                        //Contraseña incorrecta
                        return (false, cod_op);
                    }
                    else
                    {
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

            if (contra_enc != contra_rec)
            {
                mensaje = "Contraseña Actual Incorrecta";
                return (false, mensaje);
            }
            else
            {
                string nueva_contra_enc = Encriptador_44MM.Computar(nueva_contra);
                (exito, mensaje) = dal_usuarios.Cambiar_Clave(login, nueva_contra_enc);
                if (exito == false)
                {
                    return (false, mensaje);
                }
                else
                {
                    mensaje = "Contraseña Actualizada";
                    Bitacora_44MM.Registrar_Evento(login, DateTime.Now, "Usuarios", "Cambiar Clave", 1);
                    return (true, mensaje);
                }
            }
        }

        //Devuelve : pin blanco / dni blanco
        public void Cerrar_Sesion()
        {
            string login = Sesion_Manager_44MM.Get().Login;
            Sesion_Manager_44MM.Quitar_Cuenta();
            Bitacora_44MM.Registrar_Evento(login, DateTime.Now, "Usuarios", "Logout", 1);
        }
    }
}
