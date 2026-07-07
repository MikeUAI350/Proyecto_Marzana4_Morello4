using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public sealed class BLL_Intento_44MM
    {
        public BLL_Intento_44MM() { }

        private static BLL_Intento_44MM _instancia;

        public static BLL_Intento_44MM Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new BLL_Intento_44MM();
                    Instancia.Recuperar_Intentos();

                }
                return _instancia;
            }
        }

        private static List<BE_Intento_44MM> _lista_intentos = new List<BE_Intento_44MM>();

        public static List<BE_Intento_44MM> Lista_Intentos
        {
            get { return _lista_intentos; }
            set { _lista_intentos = value; }
        }

        private DataTable _tabla_intentos;

        public DataTable Tabla_Intentos
        {
            get { return _tabla_intentos; }
            set { _tabla_intentos = value; }
        }

        #region Funciones Principales
        private int Dias_Pasados = 1;
        public int Agregar_Intento(string login)
        {
            BE_Intento_44MM intento;
            if (Lista_Intentos.Count == 0)
            {
                intento = new BE_Intento_44MM(login);
                Lista_Intentos.Add(intento);
                intento.Intentos_Restantes -= 1;
            }
            else
            {
                intento = Lista_Intentos.FindLast(x => x.Login == login);
                if (intento == null)
                {
                    intento = new BE_Intento_44MM(login);
                    Lista_Intentos.Add(intento);
                    intento.Intentos_Restantes -= 1;
                }
                else
                {
                    TimeSpan diferencia = DateTime.Now - intento.Fecha;
                    if (diferencia.TotalDays >= Dias_Pasados)
                    {
                        intento.Fecha = DateTime.Now;
                        intento.Intentos_Restantes = 3;
                    }
                    intento.Intentos_Restantes -= 1;
                }
            }
            dal_intentos.Modificar_Intentos(intento.Login, intento.Fecha, intento.Intentos_Restantes);

            return intento.Intentos_Restantes;
        }

        public void Resetear_Intentos(string login)
        {
            BE_Intento_44MM intento;
            if (Lista_Intentos.Count == 0)
            {
                intento = new BE_Intento_44MM(login);
                Lista_Intentos.Add(intento);
                intento.Intentos_Restantes = 3;
            }
            else
            {
                intento = Lista_Intentos.FindLast(x => x.Login == login);
                if (intento != null)
                {
                    intento.Intentos_Restantes = 3;
                    intento.Fecha = DateTime.Now;
                }
                else
                {
                    intento = new BE_Intento_44MM(login);
                    Lista_Intentos.Add(intento);
                    intento.Intentos_Restantes = 3;
                }
            }
            dal_intentos.Modificar_Intentos(intento.Login, intento.Fecha, intento.Intentos_Restantes);
        }
        #endregion

        #region Base de Datos
        DAL_Intento_44MM dal_intentos = new DAL_Intento_44MM();

        public void Recuperar_Intentos()
        {
            Tabla_Intentos = dal_intentos.tabla_datos;
            foreach (DataRow row in Tabla_Intentos.Rows)
            {
                BE_Intento_44MM intento = new BE_Intento_44MM((string)row["Login"]);
                intento.Fecha = (DateTime)row["Fecha"];
                intento.Intentos_Restantes = (int)row["Intentos"];
                Lista_Intentos.Add(intento);
            }
        }
        #endregion
    }
}