using DAL;
using Digito_Verificador_IS;
using Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLL_Respaldo_44MM
    {
        private DAL_Respaldo_44MM dal_respaldo = new DAL_Respaldo_44MM();
        private BLL_Bitacora_44MM bll_bitacora = new BLL_Bitacora_44MM();
        private BLL_Digito_Verificador_44MM bll_dv = new BLL_Digito_Verificador_44MM();

        public (bool, string) Hacer_BackUp(string ruta_BK)
        {
            //Bitacora
            (bool exito, string mensaje) = dal_respaldo.Hacer_BackUp(ruta_BK);
            if (exito == true)
            {
                string login = Sesion_Manager_44MM.Instancia.Get().Login;
                //Bitacora
                bll_bitacora.Registrar_Evento(login, DateTime.Now, "BackUp-Restore", "BackUp", 5);
                //Digito verificador
                bll_dv.Guardar_Calculo();
            }    
            return (exito, mensaje);
        }

        public (bool, string) Hacer_Restore(string ruta_RT)
        {
            //Bitacora
            (bool exito, string mensaje) = dal_respaldo.Hacer_Restore(ruta_RT);
            if (exito == true)
            {
                string login = Sesion_Manager_44MM.Instancia.Get().Login;
                //Bitacora
                bll_bitacora.Registrar_Evento(login, DateTime.Now, "BackUp-Restore", "Restore", 5);
                //Digito verificador
                bll_dv.Guardar_Calculo();
            }
            return (exito, mensaje);
        }
    }
}