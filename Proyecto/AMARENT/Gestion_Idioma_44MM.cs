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

        private List<I_Idioma> lista_form = new List<I_Idioma>();
        public Dictionary<string, string> Texto = new Dictionary<string, string>();

        public void Suscribir_Form(I_Idioma form)
        {
            if (lista_form.Contains(form) == false)
            {
                lista_form.Add(form);
                form.Actualizar_Idioma(Texto);
            }
            else
            {
                lista_form.Remove(form);
                lista_form.Add(form);
                form.Actualizar_Idioma(Texto);
            }
        }

        public void Cambiar_Idioma(string idioma)
        {
            Texto = Obtener_Idioma_Json(idioma);
            foreach (I_Idioma form in lista_form)
            {
                form.Actualizar_Idioma(Texto);
            }
        }

        public Dictionary<string, string> Obtener_Idioma_Json(string idioma)
        {
            string Ruta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"Content\\Idiomas\\{idioma}.json");
            string Js = File.ReadAllText(Ruta);
            return JsonSerializer.Deserialize<Dictionary<string, string>>(Js);
        }


        #region Antiguo
        //      private List<I_Idioma> _lista_form_idioma = new List<I_Idioma>();

        //      public List<I_Idioma> Lista_Form_Idioma
        //{
        //	get { return _lista_form_idioma; }
        //	set { _lista_form_idioma = value; }
        //}

        //      private static string _idioma = "es";

        //      private static Dictionary<string, Dictionary<string, string>> _traducciones;

        //      public void Agregar_Form_Idioma(I_Idioma form_idioma)
        //{
        //	_lista_form_idioma.Add(form_idioma);
        //          Cargar_Idioma(form_idioma);
        //      }

        //      public void Eliminar_Form_Idioma(I_Idioma form_idioma)
        //      {
        //          _lista_form_idioma.Remove(form_idioma);
        //      }

        //      private void Cargar_Idioma(I_Idioma form_idioma)
        //      {
        //          string ruta = $"Content\\Idiomas\\{_idioma}_{(form_idioma as Control).Name}.json";
        //          Cargar_Idioma(ruta);
        //          Aplicar_Idioma(form_idioma as Control);
        //      }

        //      public void Notificar_Cambio_Idioma(string idioma)
        //{
        //          _idioma = idioma;
        //          foreach (I_Idioma form in Lista_Form_Idioma)
        //          {
        //              string ruta = $"Content\\Idiomas\\{idioma}_{(form as Control).Name}.json";
        //              Cargar_Idioma(ruta);
        //              Aplicar_Idioma(form as Control);
        //          }
        //      }

        //      private static void Cargar_Idioma(string ruta)
        //      {
        //          string json = File.ReadAllText(ruta);

        //          _traducciones = JsonSerializer.Deserialize<
        //              Dictionary<string, Dictionary<string, string>>
        //          >(json);
        //      }

        //      private static void Aplicar_Idioma(Control parent)
        //      {
        //          Aplicar_Control(parent);

        //          foreach (Control control in parent.Controls)
        //          {
        //              Aplicar_Idioma(control);
        //          }
        //          if (parent is Form form)
        //          {
        //              foreach (Control c in form.Controls)
        //              {
        //                  if (c is MenuStrip menu)
        //                  {
        //                      Aplicar_Menu(menu.Items);
        //                  }
        //              }
        //          }
        //      }

        //      private static void Aplicar_Control(Control control)
        //      {
        //          string nombre_control = control.Name;

        //          if (_traducciones.ContainsKey(nombre_control))
        //          {
        //              var propiedades = _traducciones[nombre_control];

        //              if (propiedades.ContainsKey("Text"))
        //                  control.Text = propiedades["Text"];
        //          }
        //      }

        //      private static void Aplicar_Menu(ToolStripItemCollection items)
        //      {
        //          foreach (ToolStripItem item in items)
        //          {
        //              if (_traducciones.ContainsKey(item.Name))
        //              {
        //                  var propiedades = _traducciones[item.Name];

        //                  if (propiedades.ContainsKey("Text"))
        //                  {
        //                      item.Text = propiedades["Text"];
        //                  }
        //              }

        //              // Submenús
        //              if (item is ToolStripMenuItem menuItem)
        //              {
        //                  Aplicar_Menu(menuItem.DropDownItems);
        //              }
        //          }
        //      }

        //      public static string Obtener_Mensajes(string key)
        //      {
        //          if (_traducciones.ContainsKey("Messages"))
        //          {
        //              var messages = _traducciones["Messages"];
        //              if (messages.ContainsKey(key))
        //              {
        //                  return messages[key];
        //              }
        //          }
        //          return key;
        //      }
        #endregion
    }
}