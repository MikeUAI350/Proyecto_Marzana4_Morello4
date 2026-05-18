using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json;
using System.IO;

namespace Servicios
{
    public sealed class Gestion_Idioma_44MM
    {
		private static Gestion_Idioma_44MM _instancia;

		public static Gestion_Idioma_44MM Instancia
		{
			get 
			{
				if (_instancia == null)
				{
					_instancia = new Gestion_Idioma_44MM();
				}
				return _instancia;
            }
		}

		private List<I_Idioma> _lista_form_idioma = new List<I_Idioma>();

        public List<I_Idioma> Lista_Form_Idioma
		{
			get { return _lista_form_idioma; }
			set { _lista_form_idioma = value; }
		}

        private static Dictionary<string, Dictionary<string, string>> _traducciones;

        public void Agregar_Form_Idioma(I_Idioma form_idioma)
		{
			_lista_form_idioma.Add(form_idioma);
        }

		public void Notificar_Cambio_Idioma(string idioma, string nombre_form)
		{
            string ruta = $"Content\\Idiomas\\{idioma}_{nombre_form}.json";
            foreach (I_Idioma form in Lista_Form_Idioma)
            {
                Cargar_Idioma(ruta);
                Aplicar_Control(form as Control);
            }
        }

        private static void Cargar_Idioma(string ruta)
        {
            string json = File.ReadAllText(ruta);

            _traducciones = JsonSerializer.Deserialize<
                Dictionary<string, Dictionary<string, string>>
            >(json);
        }

        private static void Aplicar_Idioma(Control parent)
        {
            Aplicar_Control(parent);

            foreach (Control control in parent.Controls)
            {
                Aplicar_Idioma(control);
            }
        }

        private static void Aplicar_Control(Control control)
        {
            string nombre_control = control.Name;

            if (_traducciones.ContainsKey(nombre_control))
            {
                var propiedades = _traducciones[nombre_control];

                if (propiedades.ContainsKey("Text"))
                    control.Text = propiedades["Text"];
            }
        }
    }
}