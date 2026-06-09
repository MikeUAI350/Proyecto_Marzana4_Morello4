using BE;
using DAL;
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
            DataTable tabla_perfiles = dal_perfil.tabla_datos_perfil;
            DataTable tabla_familias = dal_perfil.tabla_datos_familia;
            DataTable tabla_permisos = dal_perfil.tabla_datos_permiso;

            DataTable tabla_perfiles_familias = dal_perfil.tabla_datos_perfil_familia;
            DataTable tabla_perfiles_permisos = dal_perfil.tabla_datos_perfil_permiso;
            DataTable tabla_familias_familias = dal_perfil.tabla_datos_familia_familia;
            DataTable tabla_familias_permisos = dal_perfil.tabla_datos_familia_permiso;

            lista_perfiles = datatable_converter_perfil.DataTable_Class(tabla_perfiles, typeof(BE_Perfil_44MM));
            lista_familias = datatable_converter_familia.DataTable_Class(tabla_familias, typeof(BE_Familia_44MM));
            lista_permisos = datatable_converter_permiso.DataTable_Class(tabla_permisos, typeof(BE_Permiso_44MM));

            foreach (BE_Permiso_44MM permiso in lista_permisos)
            {
                lista_total.Add(permiso);
            }

            foreach (BE_Familia_44MM familia in lista_familias)
            {
                foreach (DataRow row in tabla_familias_familias.Rows)
                {
                    if (familia.Cod_Familia == (string)row["Cod_Familia_Padre"])
                    {
                        BE_Familia_44MM familia_hijo = lista_familias.Where(x => x.Cod_Familia == (string)row["Cod_Familia_Hijo"]).FirstOrDefault();
                        if (familia_hijo != null)
                        {
                            familia.Agregar_Hijo(familia_hijo);
                        }
                    }
                }
                foreach (DataRow row in tabla_familias_permisos.Rows)
                {
                    if (familia.Cod_Familia == (string)row["Cod_Familia"])
                    {
                        BE_Permiso_44MM permiso_hijo = lista_permisos.Where(x => x.Cod_Permiso == (string)row["Cod_Permiso"]).FirstOrDefault();
                        if (permiso_hijo != null)
                        {
                            familia.Agregar_Hijo(permiso_hijo);
                        }
                    }
                }

                lista_total.Add(familia);
            }

            foreach (BE_Perfil_44MM perfil in lista_perfiles)
            {
                foreach (DataRow row in tabla_perfiles_familias.Rows)
                {
                    if (perfil.Cod_Perfil == (string)row["Cod_Perfil"])
                    {
                        BE_Familia_44MM familia_hijo = lista_familias.Where(x => x.Cod_Familia == (string)row["Cod_Familia"]).FirstOrDefault();
                        if (familia_hijo != null)
                        {
                            perfil.Agregar_Hijo(familia_hijo);
                        }
                    }
                }
                foreach (DataRow row in tabla_perfiles_permisos.Rows)
                {
                    if (perfil.Cod_Perfil == (string)row["Cod_Perfil"])
                    {
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
                    (List<BE_Permiso_44MM> permisos, List<BE_Permiso_44MM> duplicados) = Obtener_Permisos(item.Obtener_Hijos());
                    foreach (BE_Permiso_44MM permiso in permisos)
                    {
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

        #region Creacion
        public (bool, string) Agregar_Perfil(string codigo, string nombre, BindingList<BE_Perfil_44MM> lista)
        {
            bool exito = false;
            string mensaje = string.Empty;

            List<string> lista_nombres_familias = new List<string>();
            List<string> lista_nombres_permisos = new List<string>();
            (lista_nombres_familias, lista_nombres_permisos) = Listar_Familias_Permisos(lista.ToList());

            (exito, mensaje) = dal_perfil.Agregar_Perfil(codigo, nombre, lista_nombres_familias, lista_nombres_permisos);

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
            return (exito, mensaje);
        }
        #endregion

        #region Modificacion

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
            return (exito, mensaje);
        }
        #endregion
    }
}