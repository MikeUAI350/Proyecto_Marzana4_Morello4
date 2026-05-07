using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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
                    Instancia.Recuperar_Intentos();

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

        private DataTable _tabla_intentos;

        public DataTable Tabla_Intentos
        {
            get { return _tabla_intentos; }
            set { _tabla_intentos = value; }
        }

        private void Recuperar_Intentos()
        {
            FileStream fs = new FileStream("Intentos_44MM.txt", FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            DataTable dt = new DataTable();
            dt.Columns.Add("Login");
            dt.Columns.Add("Fecha");
            dt.Columns.Add("Intentos");
            dt.Columns["Login"].DataType = typeof(string);
            dt.Columns["Fecha"].DataType = typeof(DateTime);
            dt.Columns["Intentos"].DataType = typeof(int);
            while (!sr.EndOfStream)
            {
                string linea = sr.ReadLine();
                string[] valores = linea.Split(';');
                dt.Rows.Add(valores);
            }
            Tabla_Intentos = dt;

            foreach (DataRow row in dt.Rows)
            {
                Intento_44MM intento = new Intento_44MM(row["Login"].ToString());
                intento.Fecha = Convert.ToDateTime(row["Fecha"]);
                intento.Intentos_Restantes = Convert.ToInt32(row["Intentos"]);
                Lista_Intentos.Add(intento);
            }

            sr.Dispose();
            sr.DiscardBufferedData();
            sr.Close();

            fs.Dispose();
            fs.Flush();
            fs.Close();
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
                    TimeSpan diferencia = DateTime.Now - intento.Fecha;
                    if (diferencia.TotalDays >= 1)
                    {
                        intento.Fecha = DateTime.Now;
                        intento.Intentos_Restantes = 3;
                    }
                    intento.Intentos_Restantes -= 1;
                }
            }
            return intento.Intentos_Restantes;
        }

        public void Guardar_Intentos()
        {
            FileStream fs = new FileStream("Intentos_44MM.txt", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            foreach (Intento_44MM intento in Lista_Intentos)
            {
                string linea = $"{intento.Login};{intento.Fecha};{intento.Intentos_Restantes}";
                sw.WriteLine(linea);
            }
            sw.Dispose();
            sw.Flush();
            sw.Close();
        }
    }
}