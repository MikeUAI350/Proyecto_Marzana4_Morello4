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

        public static bool Validar_Cuenta()
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

        public static void Quitar_Cuenta()
        {
            Usuario = null;
            Instancia.Iniciado = false;
        }

        public static void Set(BE_Usuario_44MM cuenta)
        {
            Usuario = cuenta;
            Instancia.Iniciado = true;
        }

        public static BE_Usuario_44MM Get()
        {
            return Usuario;
        }

        private static BE_Usuario_44MM _usuario;

        public static BE_Usuario_44MM Usuario
        {
            get { return _usuario; }
            set { _usuario = value; }
        }

        private bool _iniciado = false;

        public bool Iniciado
        {
            get { return _iniciado; }
            set {
                if (_iniciado != value)
                {
                    _iniciado = value;
                    OnPropiedadCambiada();
                }
            }
        }


        public event Action<bool> PropiedadCambiada;

        public void OnPropiedadCambiada()
        {
            PropiedadCambiada?.Invoke(true);
        }
    }
}
