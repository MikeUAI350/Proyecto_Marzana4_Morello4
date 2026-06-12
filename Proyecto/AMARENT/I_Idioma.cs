using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public interface I_Idioma
    {
        void Agregar_Form_Idioma();
        void Actualizar_Idioma(Dictionary<string, string> key_word);
    }
}