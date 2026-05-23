using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Intento_44MM
    {
        public Intento_44MM(string l)
        {
            Login = l;
            Fecha = DateTime.Now;
            Intentos_Restantes = 3;
        }

        private string _login;
        public string Login
        {
            get { return _login; }
            set { _login = value; }
        }

        private DateTime _fecha;
        public DateTime Fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }

        private int _intentos_restantes;
        public int Intentos_Restantes
        {
            get { return _intentos_restantes; }
            set { _intentos_restantes = value; }
        }
    }
}
