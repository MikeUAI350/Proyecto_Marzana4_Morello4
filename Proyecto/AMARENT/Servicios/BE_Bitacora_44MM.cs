using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class BE_Bitacora_44MM
    {
        public BE_Bitacora_44MM(DataRow row)
        {
            Cod_Operacion = (int)row["Cod_Operacion"];
            Login = (string)row["Login"];
            Fecha = (DateTime)row["Fecha"];
            Modulo = (string)row["Modulo"];
            Evento = (string)row["Evento"];
            Criticidad = (int)row["Criticidad"];
        }

        private int _cod_operacion;

        public int Cod_Operacion
        {
            get { return _cod_operacion; }
            set { _cod_operacion = value; }
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

        private string _modulo;

        public string Modulo
        {
            get { return _modulo; }
            set { _modulo = value; }
        }

        private string _evento;

        public string Evento
        {
            get { return _evento; }
            set { _evento = value; }
        }

        private int _criticidad;

        public int Criticidad
        {
            get { return _criticidad; }
            set { _criticidad = value; }
        }
    }
}
