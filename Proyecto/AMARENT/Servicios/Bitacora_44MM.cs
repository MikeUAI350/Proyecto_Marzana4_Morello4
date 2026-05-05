using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public sealed class Bitacora_44MM
    {
        private static readonly object _candado = new object();

        private Bitacora_44MM() {}
        private static Bitacora_44MM _Instancia;

        public static Bitacora_44MM Instancia
        {
            get
            {
                if (_Instancia == null)
                {
                    lock (_candado)
                    {
                        if (_Instancia == null)
                        {
                            _Instancia = new Bitacora_44MM();
                        }
                    }
                }
                return _Instancia;
            }
        }

        private static DAL_Bitacora_44MM _dal = new DAL_Bitacora_44MM();
        public static DAL_Bitacora_44MM Dal
        {
            get { return _dal; }
            set { _dal = value; }
        }

        public static void Registrar_Evento(string login, DateTime fecha, string modulo, string evento, int criticidad)
        {
            Dal.Registrar_Evento(login, fecha, modulo, evento, criticidad);
        }
    }
}
