using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public sealed class Gestion_Intentos_44MM
    {
        public Gestion_Intentos_44MM() { }

		private static Gestion_Intentos_44MM _instancia;

		public static Gestion_Intentos_44MM Instancia
		{
			get 
			{ 
				if (_instancia == null)
				{
					_instancia = new Gestion_Intentos_44MM();
				}
				return _instancia; 
			}
		}

		private static List<Intento_44MM> _lista_intentos = new List<Intento_44MM>();

		public static List<Intento_44MM> Lista_Intentos
		{
			get { return _lista_intentos; }
			set { _lista_intentos = value; }
		}

		public int Agregar_Intento(string login)
		{
			Intento_44MM intento;
			if (Lista_Intentos.Count == 0)
			{
                intento = new Intento_44MM(login);
				Lista_Intentos.Add(intento);
                intento.Intentos_Restantes -= 1;
            }
			else
			{
                intento = Lista_Intentos.FindLast(x => x.Login == login);
                if (intento == null)
                {
                    intento = new Intento_44MM(login);
					Lista_Intentos.Add(intento);
                    intento.Intentos_Restantes -= 1;
                }
                else
                {
                    intento.Intentos_Restantes -= 1;
                }
            }
			return intento.Intentos_Restantes;
		}
	}
}