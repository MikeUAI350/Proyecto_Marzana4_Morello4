using BE;
using DAL;
using Digito_Verificador_IS;
using Servicios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static iTextSharp.text.pdf.AcroFields;

namespace BLL
{
    public class BLL_Perfil_44MM
    {
        private DAL_Perfil_44MM dal_perfil = new DAL_Perfil_44MM();
        private BLL_Bitacora_44MM bll_bitacora = new BLL_Bitacora_44MM();

        private DataTable_Converter_44MM<BE_Perfil_44MM> datatable_converter_perfil = new DataTable_Converter_44MM<BE_Perfil_44MM>();
        private DataTable_Converter_44MM<BE_Familia_44MM> datatable_converter_familia = new DataTable_Converter_44MM<BE_Familia_44MM>();
        private DataTable_Converter_44MM<BE_Permiso_44MM> datatable_converter_permiso = new DataTable_Converter_44MM<BE_Permiso_44MM>();

        public List<BE_Perfil_44MM> lista_perfiles;
        public List<BE_Familia_44MM> lista_familias;
        public List<BE_Permiso_44MM> lista_permisos;

        public List<BE_Perfil_44MM> lista_total = new List<BE_Perfil_44MM>();

        public BLL_Perfil_44MM()
        {
            Recuperar_Todo();
        }

        #region Setup
        public void Recuperar_Todo()
        {
            //Tablas
            dal_perfil.Recuperar_Todo();
            DataTable tabla_perfiles = dal_perfil.tabla_datos_perfil;
            DataTable tabla_familias = dal_perfil.tabla_datos_familia;
            DataTable tabla_permisos = dal_perfil.tabla_datos_permiso;

            DataTable tabla_perfiles_familias = dal_perfil.tabla_datos_perfil_familia;
            DataTable tabla_perfiles_permisos = dal_perfil.tabla_datos_perfil_permiso;
            DataTable tabla_familias_familias = dal_perfil.tabla_datos_familia_familia;
            DataTable tabla_familias_permisos = dal_perfil.tabla_datos_familia_permiso;

            //Conversion a lista
            lista_perfiles = datatable_converter_perfil.DataTable_Class(tabla_perfiles, typeof(BE_Perfil_44MM));
            lista_familias = datatable_converter_familia.DataTable_Class(tabla_familias, typeof(BE_Familia_44MM));
            lista_permisos = datatable_converter_permiso.DataTable_Class(tabla_permisos, typeof(BE_Permiso_44MM));

            //Agrega los permisos
            foreach (BE_Permiso_44MM permiso in lista_permisos)
            {
                lista_total.Add(permiso);
            }

            //Agrega las familias
            foreach (BE_Familia_44MM familia in lista_familias)
            {
                foreach (DataRow row in tabla_familias_familias.Rows)
                {
                    //Verifica si es familia padre de familia
                    if (familia.Cod_Familia == (string)row["Cod_Familia_Padre"])
                    {
                        //Busca, verifica y agrega a la familia hijo
                        BE_Familia_44MM familia_hijo = lista_familias.Where(x => x.Cod_Familia == (string)row["Cod_Familia_Hijo"]).FirstOrDefault();
                        if (familia_hijo != null)
                        {
                            familia.Agregar_Hijo(familia_hijo);
                        }
                    }
                }
                foreach (DataRow row in tabla_familias_permisos.Rows)
                {
                    //Verifica si es familia padre de permiso
                    if (familia.Cod_Familia == (string)row["Cod_Familia"])
                    {
                        //Busca, verifica y agrega al permiso hijo
                        BE_Permiso_44MM permiso_hijo = lista_permisos.Where(x => x.Cod_Permiso == (string)row["Cod_Permiso"]).FirstOrDefault();
                        if (permiso_hijo != null)
                        {
                            familia.Agregar_Hijo(permiso_hijo);
                        }
                    }
                }

                lista_total.Add(familia);
            }

            //Agrega los perfiles
            foreach (BE_Perfil_44MM perfil in lista_perfiles)
            {
                //Verifica si es perfil padre de familia
                foreach (DataRow row in tabla_perfiles_familias.Rows)
                {
                    if (perfil.Cod_Perfil == (string)row["Cod_Perfil"])
                    {
                        //Busca, verifica y agrega a la familia hijo
                        BE_Familia_44MM familia_hijo = lista_familias.Where(x => x.Cod_Familia == (string)row["Cod_Familia"]).FirstOrDefault();
                        if (familia_hijo != null)
                        {
                            perfil.Agregar_Hijo(familia_hijo);
                        }
                    }
                }
                foreach (DataRow row in tabla_perfiles_permisos.Rows)
                {
                    //Verifica si es perfil padre de permiso
                    if (perfil.Cod_Perfil == (string)row["Cod_Perfil"])
                    {
                        //Busca, verifica y agrega al permiso hijo
                        BE_Permiso_44MM permiso_hijo = lista_permisos.Where(x => x.Cod_Permiso == (string)row["Cod_Permiso"]).FirstOrDefault();
                        if (permiso_hijo != null)
                        {
                            perfil.Agregar_Hijo(permiso_hijo);
                        }
                    }
                }
                lista_total.Add(perfil);
            }
        }

        public BindingList<BE_Perfil_44MM> Recuperar_Familias_Permisos()
        {
            BindingList<BE_Perfil_44MM> lista = new BindingList<BE_Perfil_44MM>();
            foreach (BE_Familia_44MM familia in lista_familias)
            {
                lista.Add(familia);
            }
            foreach (BE_Permiso_44MM permiso in lista_permisos)
            {
                lista.Add(permiso);
            }
            return lista;
        }

        public (List<BE_Permiso_44MM>, List<BE_Permiso_44MM>) Obtener_Permisos(List<BE_Perfil_44MM> hijos)
        {
            List<BE_Permiso_44MM> lista_permisos_seleccionados = new List<BE_Permiso_44MM>();
            List<BE_Permiso_44MM> lista_permisos_duplicados = new List<BE_Permiso_44MM>();
            foreach (BE_Perfil_44MM item in hijos)
            {
                if (item.Tipo == "Familia")
                {
                    //Vuelve a busca dentro de los hijos de la familia
                    (List<BE_Permiso_44MM> permisos, List<BE_Permiso_44MM> duplicados) = Obtener_Permisos(item.Obtener_Hijos());
                    foreach (BE_Permiso_44MM permiso in permisos)
                    {
                        //Agrega el permiso o lo agrega en duplicados
                        if (lista_permisos_seleccionados.Contains(permiso))
                        {
                            lista_permisos_duplicados.Add(permiso);
                        }
                        else
                        {
                            lista_permisos_seleccionados.Add(permiso);
                        }
                    }
                }
                else if (item.Tipo == "Permiso")
                {
                    //Verifica si tiene permisos repetidos
                    if (lista_permisos_seleccionados.Contains((BE_Permiso_44MM)item))
                    {
                        lista_permisos_duplicados.Add((BE_Permiso_44MM)item);
                    }
                    else
                    {
                        lista_permisos_seleccionados.Add((BE_Permiso_44MM)item);
                    }
                }
            }
            return (lista_permisos_seleccionados, lista_permisos_duplicados);
        }

        public List<BE_Permiso_44MM> Asignar_Permisos_Perfil(string codigo)
        {
            BE_Perfil_44MM perfil = lista_perfiles.FirstOrDefault(x => x.Cod_Perfil == codigo);
            List<BE_Permiso_44MM> lista_permisos_seleccionados = new List<BE_Permiso_44MM>();
            List<BE_Permiso_44MM> lista_permisos_duplicados = new List<BE_Permiso_44MM>();
            (lista_permisos_seleccionados, lista_permisos_duplicados) = Obtener_Permisos(perfil.Obtener_Hijos());

            if (lista_permisos_duplicados.Count > 0)
            {
                return null;
            }
            else
            {
                return lista_permisos_seleccionados;
            }
        }

        public List<BE_Perfil_44MM> Recuperar_Perfiles()
        {
            return lista_perfiles;
        }
        #endregion

        #region Privado
        private (List<string>, List<string>) Listar_Familias_Permisos(List<BE_Perfil_44MM> lista)
        {
            List<string> lista_nombres_familias = new List<string>();
            List<string> lista_nombres_permisos = new List<string>();

            foreach (BE_Perfil_44MM be in lista)
            {
                if (be.Tipo == "Familia")
                {
                    lista_nombres_familias.Add(be.Cod_Perfil);
                }
                else if (be.Tipo == "Permiso")
                {
                    lista_nombres_permisos.Add(be.Cod_Perfil);
                }
            }
            return (lista_nombres_familias, lista_nombres_permisos);
        }
        #endregion

        #region Verificacion
        public bool Verificar_Existencia_Perfil(string codigo, string nombre)
        {
            bool existe = dal_perfil.Verificar_Existencia_Perfil(codigo, nombre);
            return existe;
        }

        public bool Verificar_Existencia_Familia(string codigo, string nombre)
        {
            bool existe = dal_perfil.Verificar_Existencia_Familia(codigo, nombre);
            return existe;
        }

        public bool Verificar_Ultimo_Elemento(string codigo)
        {
            bool es_ultimo = dal_perfil.Verificar_Ultimo_Elemento(codigo);
            return es_ultimo;
        }

        public bool Verificar_Mismo_Perfil(string codigo)
        {
            BE_Usuario_44MM usuario = Sesion_Manager_44MM.Instancia.Get();
            if (usuario != null && usuario.Rol == codigo)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region Creacion
        public (bool, string) Agregar_Perfil(string codigo, string nombre, BindingList<BE_Perfil_44MM> lista)
        {
            bool exito = false;
            string mensaje = string.Empty;

            List<string> lista_nombres_familias = new List<string>();
            List<string> lista_nombres_permisos = new List<string>();
            (lista_nombres_familias, lista_nombres_permisos) = Listar_Familias_Permisos(lista.ToList());

            (exito, mensaje) = dal_perfil.Agregar_Perfil(codigo, nombre, lista_nombres_familias, lista_nombres_permisos);
            if (exito == true)
            {
                string login = Sesion_Manager_44MM.Instancia.Get().Login;
                //Bitacora
                bll_bitacora.Registrar_Evento(login, DateTime.Now, "Perfiles", "Crear Perfil", 1);
            }
            return (exito, mensaje);
        }

        public (bool, string) Agregar_Familia(string codigo, string nombre, BindingList<BE_Perfil_44MM> lista)
        {
            bool exito = false;
            string mensaje = string.Empty;

            List<string> lista_nombres_familias = new List<string>();
            List<string> lista_nombres_permisos = new List<string>();
            (lista_nombres_familias, lista_nombres_permisos) = Listar_Familias_Permisos(lista.ToList());

            (exito, mensaje) = dal_perfil.Agregar_Familia(codigo, nombre, lista_nombres_familias, lista_nombres_permisos);
            if (exito == true)
            {
                string login = Sesion_Manager_44MM.Instancia.Get().Login;
                //Bitacora
                bll_bitacora.Registrar_Evento(login, DateTime.Now, "Perfiles", "Crear Familia", 1);
            }
            return (exito, mensaje);
        }
        #endregion

        #region Modificacion
        public (bool, string) Modificar_Perfil(BE_Perfil_44MM perfil, List<BE_Perfil_44MM> lista)
        {
            bool exito = false;
            string mensaje = string.Empty;

            List<string> lista_nombres_familias = new List<string>();
            List<string> lista_nombres_permisos = new List<string>();
            (lista_nombres_familias, lista_nombres_permisos) = Listar_Familias_Permisos(lista);

            (exito, mensaje) = dal_perfil.Modificar_Perfil(perfil.Cod_Perfil, lista_nombres_familias, lista_nombres_permisos);
            if (exito == true)
            {
                string login = Sesion_Manager_44MM.Instancia.Get().Login;
                //Bitacora
                bll_bitacora.Registrar_Evento(login, DateTime.Now, "Perfiles", "Modificar Perfil", 1);
            }
            return (exito, mensaje);
        }

        public (bool, string) Modificar_Familia(BE_Perfil_44MM perfil, List<BE_Perfil_44MM> lista)
        {
            bool exito = false;
            string mensaje = string.Empty;

            List<string> lista_nombres_familias = new List<string>();
            List<string> lista_nombres_permisos = new List<string>();
            (lista_nombres_familias, lista_nombres_permisos) = Listar_Familias_Permisos(lista);

            (exito, mensaje) = dal_perfil.Modificar_Familia(perfil.Cod_Perfil, lista_nombres_familias, lista_nombres_permisos);
            if (exito == true)
            {
                string login = Sesion_Manager_44MM.Instancia.Get().Login;
                //Bitacora
                bll_bitacora.Registrar_Evento(login, DateTime.Now, "Perfiles", "Modificar Familia", 1);
            }
            return (exito, mensaje);
        }
        #endregion

        #region Eliminacion
        public (bool, string) Eliminar_Perfil(BE_Perfil_44MM perfil)
        {
            bool exito = false;
            string mensaje = string.Empty;

            List<string> lista_nombres_familias = new List<string>();
            List<string> lista_nombres_permisos = new List<string>();
            (lista_nombres_familias, lista_nombres_permisos) = Listar_Familias_Permisos(perfil.Obtener_Hijos());

            (exito, mensaje) = dal_perfil.Eliminar_Perfil(perfil.Cod_Perfil, lista_nombres_familias);
            if (exito == true)
            {
                string login = Sesion_Manager_44MM.Instancia.Get().Login;
                //Bitacora
                bll_bitacora.Registrar_Evento(login, DateTime.Now, "Perfiles", "Eliminar Perfil", 1);
            }
            return (exito, mensaje);
        }

        public (bool, string) Eliminar_Familia(BE_Perfil_44MM perfil)
        {
            bool exito = false;
            string mensaje = string.Empty;

            List<string> lista_nombres_familias = new List<string>();
            List<string> lista_nombres_permisos = new List<string>();
            (lista_nombres_familias, lista_nombres_permisos) = Listar_Familias_Permisos(perfil.Obtener_Hijos());

            (exito, mensaje) = dal_perfil.Eliminar_Familia(perfil.Cod_Perfil, lista_nombres_familias);
            if (exito == true)
            {
                string login = Sesion_Manager_44MM.Instancia.Get().Login;
                //Bitacora
                bll_bitacora.Registrar_Evento(login, DateTime.Now, "Perfiles", "Eliminar Familia", 1);
            }
            return (exito, mensaje);
        }
        #endregion
    }
}