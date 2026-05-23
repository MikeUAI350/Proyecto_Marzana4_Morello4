using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BE_Usuario_44MM
    {
        public BE_Usuario_44MM(DataRow info)
        {
            DNI = (string)info["DNI"];
            Apellido = (string)info["Apellido"];
            Nombre = (string)info["Nombre"];
            Login = (string)info["Login"];
            Rol = (string)info["Rol"];
            Email = (string)info["Email"];
            Activo = (bool)info["Activo"];
        }

        private string _dni;
        public string DNI
        {
            get { return _dni; }
            set { _dni = value; }
        }

        private string _apellido;
        public string Apellido
        {
            get { return _apellido; }
            set { _apellido = value; }
        }

        private string _nombre;
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        private string _login;
        public string Login
        {
            get { return _login; }
            set { _login = value; }
        }

        private string _rol;
        public string Rol
        {
            get { return _rol; }
            set { _rol = value; }
        }

        private string _email;
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        private bool _activo;

        public bool Activo
        {
            get { return _activo; }
            set { _activo = value; }
        }
    }
}
