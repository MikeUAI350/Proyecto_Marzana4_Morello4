using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class BE_Familia_44MM : BE_Perfil_44MM
    {
        private string _cod_familia;
        public string Cod_Familia
        {
            get { return _cod_familia; }
            set { _cod_familia = value; }
        }

        private string _nombre_familia;
        public string Nombre_Familia
        {
            get { return _nombre_familia; }
            set { _nombre_familia = value; }
        }

        private bool _es_tope;
        public bool Es_Tope
        {
            get { return _es_tope; }
            set { _es_tope = value; }
        }


        private List<BE_Perfil_44MM> Hijos = new List<BE_Perfil_44MM>();
        public BE_Familia_44MM(string codigo, string nombre, bool es_tope) : base(codigo, nombre)
        {
            Cod_Familia = codigo;
            Nombre_Familia = nombre;
            Es_Tope = es_tope;
            Tipo = "Familia";
        }

        public BE_Familia_44MM(DataRow row) : base(row, "Familia")
        {
            Cod_Familia = (string)row["Cod_Familia"];
            Nombre_Familia = (string)row["Nombre"];
            Es_Tope = (bool)row["Es_Tope"];
            Tipo = "Familia";
        }

        public override void Agregar_Hijo(BE_Perfil_44MM hijo)
        {
            Hijos.Add(hijo);
        }

        public override void Eliminar_Hijo(BE_Perfil_44MM hijo)
        {
            Hijos.Remove(hijo);
        }

        public override List<BE_Perfil_44MM> Obtener_Hijos()
        {
            return Hijos;
        }
    }
}
