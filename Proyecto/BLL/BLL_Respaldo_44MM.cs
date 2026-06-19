using DAL;
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
        private DAL_Bitacora_44MM dal_bitacora = new DAL_Bitacora_44MM();

        public void Hacer_BackUp(string ruta_BK)
        {
            string login = Sesion_Manager_44MM.Instancia.Get().Login;
            //Bitacora
            dal_respaldo.Hacer_BackUp(ruta_BK);
            dal_bitacora.Registrar_Evento(login, DateTime.Now, "BackUp-Restore", "BackUp", 5);
        }

        public void Hacer_Restore(string ruta_RT)
        {
            string login = Sesion_Manager_44MM.Instancia.Get().Login;
            //Bitacora
            dal_respaldo.Hacer_Restore(ruta_RT);
            dal_bitacora.Registrar_Evento(login, DateTime.Now, "BackUp-Restore", "Restore", 5);
        }
    }
}