using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class Usuario
    {
        //Devuelve : si el pin coincide
        public bool Verificar_Sesion(string pin, string dni)
        {
            //Recupera datos de la base de datos
            string pin_rec = "123";

            //Compara si el pin guardado es el mismo que tiene actualmente
            if (pin == pin_rec)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Devuelve : pin / dni / si la sesion se mantiene / mensaje
        public (string, string, bool, string) Iniciar_Sesion(string correo, string contra, bool ms)
        {
            //Recupera datos de la base de datos
            string correo_rec = "123";
            string contra_rec = "123";
            bool bloqueado_rec = false;
            bool inactividad_rec = false;

            //Compara datos ingresados con datos de la base de datos
            if (correo != correo_rec)
            {
                return ("", "", false, "");
            }
            else if (contra != contra_rec)
            {
                return ("", "", false, "");
            }
            else if (bloqueado_rec == true)
            {
                return ("", "", false, "");
            }
            else if (inactividad_rec == true)
            {
                return ("", "", false, "");
            }
            else
            {
                //Crea pin si se quiere mantener la sesion
                string pin = "";
                string dni = "";
                if (ms == true)
                {
                    pin = "123";
                    dni = "123";
                }
                return (pin, dni, true, "");
            }
        }

        //Devuelve : pin blanco / dni blanco
        public (string, string) Cerrar_Sesion()
        {
            string pin = "";
            string dni = "";

            return (pin, dni);
        }


        public void Registrar_Usuario(string correo, string contra)
        {
            string correo_rec = "123";
            if (correo_rec != string.Empty)
            {

            }
        }
    }
}