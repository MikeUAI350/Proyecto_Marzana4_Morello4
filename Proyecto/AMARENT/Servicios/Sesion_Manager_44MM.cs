using BE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public sealed class Sesion_Manager_44MM
    {
        private static readonly object _candado = new object();

        private Sesion_Manager_44MM() { }

        private static Sesion_Manager_44MM _Instancia;

        public static Sesion_Manager_44MM Instancia
        {
            get
            {
                if (_Instancia == null)
                {
                    lock (_candado)
                    {
                        if (_Instancia == null)
                        {
                            _Instancia = new Sesion_Manager_44MM();
                        }
                    }
                }
                return _Instancia;
            }
        }

        public bool Validar_Cuenta()
        {
            if (Usuario != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Quitar_Cuenta()
        {
            Usuario = null;
        }

        public void Set(BE_Usuario_44MM cuenta)
        {
            Usuario = cuenta;
        }

        public BE_Usuario_44MM Get()
        {
            return Usuario;
        }

        private BE_Usuario_44MM _usuario;

        public BE_Usuario_44MM Usuario
        {
            get { return _usuario; }
            set { _usuario = value; }
        }
    }
}