using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class BE_Perfil_44MM
    {
        private string _cod_perfil;
        public string Cod_Perfil
        {
            get { return _cod_perfil; }
            set { _cod_perfil = value; }
        }

        private string _nombre;
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        private string _tipo = "Perfil";
        public string Tipo
        {
            get { return _tipo; }
            set { _tipo = value; }
        }


        private List<BE_Perfil_44MM> Hijos = new List<BE_Perfil_44MM>();
        public BE_Perfil_44MM(string codigo, string nombre)
        {
            Cod_Perfil = codigo;
            Nombre = nombre;
        }

        public BE_Perfil_44MM(DataRow row)
        {
            Cod_Perfil = (string)row["Cod_Perfil"];
            Nombre = (string)row["Nombre"];
        }

        public BE_Perfil_44MM(DataRow row, string tipo)
        {
            switch (tipo)
            {
                case "Familia":
                    {
                        Cod_Perfil = (string)row["Cod_Familia"];
                        Nombre = (string)row["Nombre"];
                        break;
                    }
                case "Permiso":
                    {
                        Cod_Perfil = (string)row["Cod_Permiso"];
                        Nombre = (string)row["Nombre"];
                        break;
                    }
                default:
                    {
                        throw new ArgumentException("Tipo de perfil no válido");
                    }
            }
        }

        public virtual void Agregar_Hijo(BE_Perfil_44MM hijo)
        {
            Hijos.Add(hijo);
        }

        public virtual void Eliminar_Hijo(BE_Perfil_44MM hijo)
        {
            Hijos.Remove(hijo);
        }

        public virtual List<BE_Perfil_44MM> Obtener_Hijos()
        {
            return Hijos;
        }
    }
}
