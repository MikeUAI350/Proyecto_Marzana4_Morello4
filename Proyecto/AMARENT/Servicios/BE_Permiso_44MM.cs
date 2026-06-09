using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class BE_Permiso_44MM : BE_Perfil_44MM
    {
        private string _cod_permiso;
        public string Cod_Permiso
        {
            get { return _cod_permiso; }
            set { _cod_permiso = value; }
        }

        private string _nombre_permiso;
        public string Nombre_Permiso
        {
            get { return _nombre_permiso; }
            set { _nombre_permiso = value; }
        }

        public BE_Permiso_44MM(string codigo, string nombre) : base(codigo, nombre)
        {
            Cod_Permiso = codigo;
            Nombre_Permiso = nombre;
            Tipo = "Permiso";
        }

        public BE_Permiso_44MM(DataRow row) : base(row, "Permiso")
        {
            Cod_Permiso = (string)row["Cod_Permiso"];
            Nombre_Permiso = (string)row["Nombre"];
            Tipo = "Permiso";
        }

        public override void Agregar_Hijo(BE_Perfil_44MM hijo)
        {
            throw new InvalidOperationException("Permiso no puede tener hijos");
        }

        public override void Eliminar_Hijo(BE_Perfil_44MM hijo)
        {
            throw new InvalidOperationException("Permiso no puede tener hijos");
        }

        public override List<BE_Perfil_44MM> Obtener_Hijos()
        {
            return new List<BE_Perfil_44MM>(); // No tiene hijos
        }
    }
}
