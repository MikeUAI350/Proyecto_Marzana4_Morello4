using BE;
using DAL;
using Digito_Verificador_IS;
using Servicios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLL_Usuario_44MM
    {
        private DAL_Usuario_44MM dal_usuarios = new DAL_Usuario_44MM();
        private BLL_Bitacora_44MM bll_bitacora = new BLL_Bitacora_44MM();
        private BLL_Perfil_44MM bll_perfil = new BLL_Perfil_44MM();
        private BLL_Digito_Verificador_44MM bll_dv = new BLL_Digito_Verificador_44MM();

        private DataTable_Converter_44MM<BE_Usuario_44MM> datatable_converter = new DataTable_Converter_44MM<BE_Usuario_44MM>();

        #region Usuario
        //Devuelve : exito (0 : no ; 1 : si ; -1 : requiere cambio de clave) / numero de operacion
        public (int, string) Iniciar_Sesion(string login, string contra)
        {
            DataRow info;

            //Valida si hay una cuenta logueada
            bool login_rec = Sesion_Manager_44MM.Instancia.Validar_Cuenta();
            if (login_rec == true)
            {
                //Ya hay una cuenta logueada
                return (0, "SesionYaIniciada");
            }
            else
            {
                //Encripta la contraseña y verifica la informacion de Login
                string contra_enc = Encriptador_44MM.Instancia.Computar(contra);
                DataTable tabla_datos = dal_usuarios.Verificar_Login(login);

                if (tabla_datos.Rows.Count != 1)
                {
                    if (tabla_datos.Rows.Count != 0)
                    {
                        //Inconsistencia en la base de datos
                        return (0, "AccesoDenegado");
                    }
                    else
                    {
                        //Usuario no existe
                        return (0, "UsuarioInexistente");
                    }
                }
                else
                {
                    //Como es la unica fila, se recupera la informacion del usuario
                    info = tabla_datos.Rows[0];
                    string email = (string)info["Email"];
                    string contra_rec = (string)info["Password"];
                    bool bloqueado_rec = (bool)info["Bloqueado"];
                    bool activo_rec = (bool)info["Activo"];
                    bool rcc = (bool)info["RCC"];
                    string rol = (string)info["Rol"];

                    if (bloqueado_rec == true)
                    {
                        //Usuario bloqueado
                        return (0, "UsuarioBloqueado");
                    }
                    else if (activo_rec == false)
                    {
                        return (0, "UsuarioInactivo");
                    }
                    else if (contra_enc != contra_rec)
                    {
                        //Agrega un intento fallido
                        return (2, "");
                    }
                    else if (rcc == true)
                    {
                        //Usuario requiere cambio de contraseña
                        BE_Usuario_44MM usuario = new BE_Usuario_44MM(info);
                        Sesion_Manager_44MM.Instancia.Set(usuario);
                        return (-1, "RequiereCambioDeContra");
                    }
                    else
                    {
                        ////Cambiar el rol a Base si es que el actual fue eliminado
                        //List<BE_Perfil_44MM> lista = Recuperar_Perfiles();
                        //BE_Perfil_44MM perfil = lista.FirstOrDefault(x => x.Cod_Perfil == rol);
                        //if (perfil == null)
                        //{
                        //    dal_usuarios.Modificar_Usuario(login, email, "Base");
                        //    info["Rol"] = "Base";
                        //}

                        //Crea la sesion del usuario, lo coloca en el Sesion Manager
                        BE_Usuario_44MM usuario = new BE_Usuario_44MM(info);
                        Sesion_Manager_44MM.Instancia.Set(usuario);
                        ////Sesion iniciada
                        return (1, "InicioDeSesionExitoso");
                    }
                }
            }
        }

        //Devuelve : exito (0 : contraseña incorrecta ; -1 : inconsistencia de datos ; 1 : exito
        public (int, string) Cambiar_Clave(string contra, string nueva_contra)
        {
            bool exito = false;
            string mensaje = string.Empty;
            DataRow info;

            // Recupera el login, encripta la contraseña y verifica la informacion de Login
            BE_Usuario_44MM usuario = Sesion_Manager_44MM.Instancia.Get();
            string login = usuario.Login;
            string contra_enc = Encriptador_44MM.Instancia.Computar(contra);
            DataTable tabla_datos = dal_usuarios.Verificar_Login(login);

            info = tabla_datos.Rows[0];
            string contra_rec = (string)info["Password"];

            //Compara la contraseña ingresada con la contraseña recuperada
            if (contra_enc != contra_rec)
            {
                mensaje = "ContraActualIncorrecta";
                return (0, mensaje);
            }
            else
            {
                //Encripta la nueva contraseña y la actualiza en la base de datos
                string nueva_contra_enc = Encriptador_44MM.Instancia.Computar(nueva_contra);
                (exito, mensaje) = dal_usuarios.Cambiar_Clave(login, nueva_contra_enc);
                if (exito == false)
                {
                    return (-1, mensaje);
                }
                else
                {
                    //Reinicia Intentos
                    BLL_Intento_44MM.Instancia.Resetear_Intentos(login);
                    //Registra el evento en la bitacora
                    bll_bitacora.Registrar_Evento(login, DateTime.Now, "Usuarios", "Cambiar Clave", 1);
                    return (1, mensaje);
                }
            }
        }

        public List<BE_Permiso_44MM> Recuperar_Permisos(string codigo)
        {
            List<BE_Permiso_44MM> lista_permisos = bll_perfil.Asignar_Permisos_Perfil(codigo);
            return lista_permisos;
        }

        public string Agregar_Intento(string login)
        {
            //Agrega un intento fallido
            int intentos = BLL_Intento_44MM.Instancia.Agregar_Intento(login);

            //Si se alcanzan los 3 intentos, bloquea el usuario
            if (intentos <= 0)
            {
                dal_usuarios.Bloquear_Usuario(login);
                //Bitacora
                bll_bitacora.Registrar_Evento(login, DateTime.Now, "Usuarios", "Bloqueo", 1);
                return "UsuarioFueBloqueado";
            }
            else
            {
                //Digito verificador
                bll_dv.Guardar_Calculo();
                //Contraseña incorrecta
                return "ContraIncorrecta";
            }
        }

        public void Cambiar_Idioma(string idioma)
        {
            string login = Sesion_Manager_44MM.Instancia.Get().Login;
            dal_usuarios.Cambiar_Idioma(login, idioma);
            //Bitacora
            bll_bitacora.Registrar_Evento(login, DateTime.Now, "Usuarios", $"Cambiar Idioma: {idioma}", 1);
        }

        //Devuelve : pin blanco / dni blanco
        public void Cerrar_Sesion()
        {
            //Obtiene el login del usuario actual, lo quita del Sesion Manager y registra el evento en la bitacora
            string login = Sesion_Manager_44MM.Instancia.Get().Login;
            string idioma = Sesion_Manager_44MM.Instancia.Get().Idioma;
            dal_usuarios.Cambiar_Idioma(login, idioma);
            Sesion_Manager_44MM.Instancia.Quitar_Cuenta();
            //Bitacora
            bll_bitacora.Registrar_Evento(login, DateTime.Now, "Usuarios", "Logout", 1);
        }
        #endregion

        #region Gestion
        //Devuelve : tabla completa / tabla deactivos / tabla bloqueados
        public List<BE_Usuario_44MM> Gestionar_Usuarios()
        {
            //Recupera la tabla de usuarios
            dal_usuarios.Recuperar_Usuarios();
            DataTable tabla_usuarios = dal_usuarios.tabla_datos;
            List<BE_Usuario_44MM> lista_usuarios = datatable_converter.DataTable_Class(tabla_usuarios, typeof(BE_Usuario_44MM));
            return lista_usuarios;
        }

        public List<BE_Perfil_44MM> Recuperar_Perfiles()
        {
            return bll_perfil.Recuperar_Perfiles();
        }

        public (int, string) Crear_Usuario(string dni, string nombre, string apellido, string email, string rol)
        {
            bool exito = false;
            string mensaje;

            //Obtiene el login si es que existe
            (exito, mensaje) = dal_usuarios.Verificar_DNI(dni);

            //Verifica que el login generado no exista en la base de datos
            if (exito == true)
            {
                //Crea el login por defecto (nombre + dni)
                string login = nombre + dni;

                //Crea y encripta la contraseña por defecto (apellido + dni)
                string password = Encriptador_44MM.Instancia.Computar(apellido + dni);

                //Crea el nuevo usuario a la base de datos
                (exito, mensaje) = dal_usuarios.Crear_Usuario(dni, nombre, apellido, login, email, password, rol);

                if (exito == true)
                {
                    string login_sesion = Sesion_Manager_44MM.Instancia.Get().Login;
                    //Registra el evento en la bitacora
                    bll_bitacora.Registrar_Evento(login_sesion, DateTime.Now, "Usuarios", "Crear Usuario " + login, 1);
                    return (1, mensaje);
                }
                else
                {
                    return (-1, mensaje);
                }
            }
            else
            {
                return (0, mensaje);
            }
        }

        public (int, string) Modificar_Usuario(string login, string email, string rol)
        {
            bool exito = false;
            string mensaje = string.Empty;

            //Modifica el email y rol del usuario seleccionado
            (exito, mensaje) = dal_usuarios.Modificar_Usuario(login, email, rol);
            if (exito == true)
            {
                string login_sesion = Sesion_Manager_44MM.Instancia.Get().Login;
                //Registra el evento en la bitacora
                bll_bitacora.Registrar_Evento(login_sesion, DateTime.Now, "Usuarios", "Modificar Usuario " + login, 1);
                return (1, mensaje);
            }
            else
            {
                return (-1, mensaje);
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
                string login_sesion = Sesion_Manager_44MM.Instancia.Get().Login;
                //Registra el evento en la bitacora
                bll_bitacora.Registrar_Evento(login_sesion, DateTime.Now, "Usuarios", "Activar Usuario " + login, 1);
                return (true, mensaje);
            }
            else
            {
                return (false, mensaje);
            }
        }

        public (bool, string) Desbloquear_Usuario(BE_Usuario_44MM be)
        {
            bool exito = false;
            string mensaje = string.Empty;

            //Obtiene el login, apellido y dni del usuario seleccionado
            string login = be.Login;
            string apellido = be.Apellido;
            string dni = be.DNI;

            //Encripta la contraseña por defecto (apellido + dni)
            string password = Encriptador_44MM.Instancia.Computar(apellido + dni);

            //Modifica el estado "Bloqueado" del usuario seleccionado
            (exito, mensaje) = dal_usuarios.Desbloquear_Usuario(login, password);
            if (exito == true)
            {
                string login_sesion = Sesion_Manager_44MM.Instancia.Get().Login;
                //Reinicia Intentos para el Login Desbloqueado
                BLL_Intento_44MM.Instancia.Resetear_Intentos(login);
                //Registra el evento en la bitacora
                bll_bitacora.Registrar_Evento(login_sesion, DateTime.Now, "Usuarios", "Desbloquear Usuario " + login, 1);
                return (true, mensaje);
            }
            else
            {
                return (false, mensaje);
            }
        }
        #endregion

        #region Con DataTable
        /*#region Gestion
        //Devuelve : tabla completa / tabla deactivos / tabla bloqueados
        public (DataTable, DataTable, DataTable) Gestionar_Usuarios()
        {
            //Recupera la tabla de usuarios
            dal_usuarios.Recuperar_Usuarios();
            DataTable tabla_usuarios = dal_usuarios.tabla_datos;

            //Filtra los activos y bloqueados
            DataTable tabla_activos = DataTable_Filter_44MM.Filtrar_Tabla(tabla_usuarios, "Activo", true.ToString());
            DataTable tabla_bloqueados = DataTable_Filter_44MM.Filtrar_Tabla(tabla_usuarios, "Bloqueado", true.ToString());

            List<BE_Usuario_44MM> lista_usuarios = datatable_converter.DataTable_Class(tabla_usuarios, typeof(BE_Usuario_44MM));

            return (tabla_usuarios, tabla_activos, tabla_bloqueados);
        }

        public (bool, string) Crear_Usuario(string dni, string nombre, string apellido, string email, string rol)
        {
            bool exito = false;
            string mensaje;

            //Obtiene el login si es que existe
            (exito, mensaje) = dal_usuarios.Verificar_DNI(dni);

            //Verifica que el login generado no exista en la base de datos
            if (exito == true)
            {
                //Crea el login por defecto (nombre + dni)
                string login = nombre + dni;

                //Crea y encripta la contraseña por defecto (apellido + dni)
                string password = Encriptador_44MM.Computar(apellido + dni);

                //Crea el nuevo usuario a la base de datos
                (exito, mensaje) = dal_usuarios.Crear_Usuario(dni, nombre, apellido, login, email, password, rol);

                if (exito == true)
                {
                    string login_sesion = Sesion_Manager_44MM.Get().Login;
                    //Registra el evento en la bitacora
                    bll_bitacora.Registrar_Evento(login_sesion, DateTime.Now, "Usuarios", "Crear Usuario " + login, 1);
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
                bll_bitacora.Registrar_Evento(login_sesion, DateTime.Now, "Usuarios", "Modificar Usuario " + login, 1);
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
                bll_bitacora.Registrar_Evento(login_sesion, DateTime.Now, "Usuarios", "Activar Usuario " + login, 1);
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
                bll_bitacora.Registrar_Evento(login_sesion, DateTime.Now, "Usuarios", "Desbloquear Usuario " + login, 1);
                //Reinicia Intentos para el Login Desbloqueado
                Gestion_Intentos_44MM.Instancia.Resetear_Intentos(login);
                return (true, mensaje);
            }
            else
            {
                return (false, mensaje);
            }
        }
        #endregion*/
        #endregion
    }
}