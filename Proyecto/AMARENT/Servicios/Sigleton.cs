using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public sealed class Sigleton
    {
        private static readonly object _candado = new object();

        private Sigleton() { }

        private static Sigleton _Instancia;

        private static int _propiedad;

        public static int Propiedad
        {
            get { return _propiedad; }
            set { _propiedad = value; }
        }

        public static Sigleton Instancia
        {
            get
            {
                if (_Instancia == null)
                {
                    lock (_candado)
                    {
                        if (_Instancia == null)
                        {
                            _Instancia = new Sigleton();
                        }
                    }
                }
                return _Instancia;
            }
        }
    }
}
