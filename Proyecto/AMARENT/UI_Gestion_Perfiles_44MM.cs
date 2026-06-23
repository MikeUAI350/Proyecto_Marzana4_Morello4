using BLL;
using Servicios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AMARENT
{
    public partial class UI_Gestion_Perfiles_44MM : Form, I_Idioma
    {
        private BLL_Perfil_44MM bll_perfil = new BLL_Perfil_44MM();
        private BindingList<BE_Perfil_44MM> lista_familias_permisos = new BindingList<BE_Perfil_44MM>();
        private BindingList<BE_Perfil_44MM> lista_seleccionados = new BindingList<BE_Perfil_44MM>();

        private DataGridViewCell celda_actual;
        private DataGridViewCell celda_actual_lista;

        public UI_Gestion_Perfiles_44MM()
        {
            InitializeComponent();
            Actualizar();
            Agregar_Form_Idioma();
        }

        #region Actualizacion
        private void Actualizar()
        {
            lista_familias_permisos.Clear();
            lista_seleccionados.Clear();

            bll_perfil.Recuperar_Todo();
            lista_familias_permisos = bll_perfil.Recuperar_Familias_Permisos();
            Actualizar_Arbol();

            dataGridView_lista.DataSource = lista_familias_permisos;
            dataGridView_composicion.DataSource = lista_seleccionados;
        }

        private void Actualizar_Arbol()
        {
            treeView_arbol.Nodes.Clear();

            //Crea los perfiles
            foreach (BE_Perfil_44MM perfil in bll_perfil.lista_perfiles)
            {
                TreeNode nodo = new TreeNode(perfil.Nombre);
                nodo.Tag = perfil;
                treeView_arbol.Nodes.Add(nodo);
                Crear_Ramas(perfil, nodo);
            }

            //Nodo extra para las familias sin perfiles
            TreeNode nodo_familias = new TreeNode(Gestion_Idioma_44MM.Instancia.Texto["FamiliasSinPerfiles"]);
            nodo_familias.Tag = Gestion_Idioma_44MM.Instancia.Texto["FamiliasSinPerfiles"];
            treeView_arbol.Nodes.Add(nodo_familias);

            //Crea la lista de familias extra
            foreach (BE_Familia_44MM perfil in bll_perfil.lista_familias)
            {
                if (perfil.Es_Tope == true)
                {
                    TreeNode nodo = new TreeNode(perfil.Nombre);
                    nodo.Tag = perfil;
                    nodo_familias.Nodes.Add(nodo);
                    Crear_Ramas(perfil, nodo);
                }
            }

            treeView_arbol.ExpandAll();
        }

        private void Crear_Ramas(BE_Perfil_44MM perfil, TreeNode nodo_perfil)
        {
            //Obtiene los hijos y si es familia repite el ciclo
            foreach (BE_Perfil_44MM item in perfil.Obtener_Hijos())
            {
                TreeNode nodo = new TreeNode(item.Nombre);
                nodo.Tag = item;
                nodo_perfil.Nodes.Add(nodo);
                if (item.Tipo == "Familia")
                {
                    Crear_Ramas(item, nodo);
                }
            }
        }
        #endregion

        #region Obtener Seleccionados
        private BE_Perfil_44MM Obtener_Seleccionado()
        {
            if (celda_actual == null || celda_actual.RowIndex < 0 || celda_actual.ColumnIndex < 0)
            {
                MessageBox.Show(Gestion_Idioma_44MM.Instancia.Texto["SeleccioneUnaFamilioOPermiso"], "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            else
            {
                DataGridViewCell celda = dataGridView_lista.Rows[celda_actual.RowIndex].Cells["Cod_Perfil"];
                string codigo = (string)celda.Value;
                BE_Perfil_44MM be = lista_familias_permisos.FirstOrDefault(x => x.Cod_Perfil == codigo);
                return be;
            }
        }

        private BE_Perfil_44MM Obtener_Seleccionado_Lista()
        {
            if (celda_actual_lista == null || celda_actual_lista.RowIndex < 0 || celda_actual_lista.ColumnIndex < 0)
            {
                MessageBox.Show(Gestion_Idioma_44MM.Instancia.Texto["SeleccioneUnaFamilioOPermiso"], "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            else
            {
                DataGridViewCell celda = dataGridView_composicion.Rows[celda_actual_lista.RowIndex].Cells["Cod_Perfil"];
                string codigo = (string)celda.Value;
                BE_Perfil_44MM be = lista_seleccionados.FirstOrDefault(x => x.Cod_Perfil == codigo);
                return be;
            }
        }

        private BE_Perfil_44MM Obtener_Seleccionado_Arbol()
        {
            if (treeView_arbol.SelectedNode == null || treeView_arbol.SelectedNode.Tag == null || treeView_arbol.SelectedNode.Tag.ToString() == Gestion_Idioma_44MM.Instancia.Texto["FamiliasSinPerfiles"])
            {
                if (treeView_arbol.SelectedNode.Tag.ToString() != Gestion_Idioma_44MM.Instancia.Texto["FamiliasSinPerfiles"])
                {
                    MessageBox.Show(Gestion_Idioma_44MM.Instancia.Texto["SeleccioneUnPerfilOFamilia"], "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return null;
            }
            else
            {
                BE_Perfil_44MM be = (BE_Perfil_44MM)treeView_arbol.SelectedNode.Tag;
                return be;
            }
        }
        #endregion

        #region Funciones Secundarias
        private void Limpiar_Elementos()
        {
            //Mueve todo lo de la lista seleccionados a la lista de familias y permisos
            List<BE_Perfil_44MM> lista_copia = new List<BE_Perfil_44MM>();
            foreach (BE_Perfil_44MM perfil in lista_seleccionados)
            {
                lista_copia.Add(perfil);
            }

            foreach (BE_Perfil_44MM perfil in lista_copia)
            {
                lista_familias_permisos.Add(perfil);
                lista_seleccionados.Remove(perfil);
            }
        }

        private void Agregar_Elemento(BE_Perfil_44MM perfil)
        {
            //Verifica si hay duplicados
            List<BE_Perfil_44MM> lista = new List<BE_Perfil_44MM>(lista_seleccionados);
            (List<BE_Permiso_44MM> permisos, List<BE_Permiso_44MM> duplicados) = bll_perfil.Obtener_Permisos(lista);
            if (duplicados.Count <= 0)
            {
                lista_seleccionados.Add(perfil);
                lista_familias_permisos.Remove(perfil);
            }
            else
            {
                //Muestra todos los duplicados
                string mensaje = Gestion_Idioma_44MM.Instancia.Texto["PermisosDuplicados"];
                foreach (BE_Permiso_44MM item in duplicados)
                {
                    mensaje += "\n\r" + item.Nombre_Permiso;
                }

                MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Quitar_Elemento(BE_Perfil_44MM perfil)
        {
            lista_familias_permisos.Add(perfil);
            lista_seleccionados.Remove(perfil);
        }

        private void Cargar_Elementos(BE_Perfil_44MM perfil)
        {
            Limpiar_Elementos();

            //Si no es un permiso, va a agregar todos los hijos del perfil a la lista de seleccionados
            if (perfil.Tipo != "Permiso")
            {
                foreach (BE_Perfil_44MM item in perfil.Obtener_Hijos())
                {
                    BE_Perfil_44MM item_copia = lista_familias_permisos.FirstOrDefault(x => x.Cod_Perfil == item.Cod_Perfil);
                    if (item_copia != null)
                    {
                        lista_seleccionados.Add(item);
                        lista_familias_permisos.Remove(item);
                    }
                }
                textBox_codigo.Text = perfil.Cod_Perfil;
                textBox_nombre.Text = perfil.Nombre;
            }
        }
        #endregion

        #region Funciones Principales
        private void Crear_Perfil()
        {
            bool exito = false;
            string mensaje = string.Empty;
            bool existe = true;

            string codigo = textBox_codigo.Text;
            string nombre = textBox_nombre.Text;

            //Verifica formato
            Match ER_codigo = Regex.Match(codigo, "^(?=.{1,50}$)+$");
            Match ER_nombre = Regex.Match(nombre, "^(?=.{1,50}$)[A-Za-z]+$");

            if (ER_codigo.Success == true && ER_codigo.Success == true)
            {
                //Obtiene el seleccionado
                if (radioButton_perfil.Checked == true)
                {
                    //Verifica si existe un perfil con ese codigo o nombre
                    existe = bll_perfil.Verificar_Existencia_Perfil(codigo, nombre);
                    if (existe == false)
                    {
                        (exito, mensaje) = bll_perfil.Agregar_Perfil(codigo, nombre, lista_seleccionados);
                    }
                    else
                    {
                        mensaje = $"Perfil {Gestion_Idioma_44MM.Instancia.Texto["YaExistente"]}";
                    }
                }
                else if (radioButton_familia.Checked == true)
                {
                    //Verifica si existe una familia con ese codigo o nombre
                    existe = bll_perfil.Verificar_Existencia_Familia(codigo, nombre);
                    if (existe == false)
                    {
                        (exito, mensaje) = bll_perfil.Agregar_Familia(codigo, nombre, lista_seleccionados);
                    }
                    else
                    {
                        mensaje = $"Familia {Gestion_Idioma_44MM.Instancia.Texto["YaExistente"]}";
                    }
                }
                else
                {
                    MessageBox.Show("?", "?", MessageBoxButtons.OK,MessageBoxIcon.Question);
                }
            }
            else
            {
                mensaje = Gestion_Idioma_44MM.Instancia.Texto[""];
            }

            if (exito == true)
            {
                MessageBox.Show(Gestion_Idioma_44MM.Instancia.Texto[mensaje]);
                Actualizar();
            }
            else
            {
                MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Modificar_Perfil(BE_Perfil_44MM perfil)
        {
            bool exito = false;
            string mensaje = string.Empty;
            bool existe = false;

            //Verifica el tipo
            if (perfil.Tipo == "Perfil")
            {
                //Verifica si existe una familia con ese codigo o nombre y si las cajas de texto son las mismas
                existe = bll_perfil.Verificar_Existencia_Perfil(perfil.Cod_Perfil, perfil.Nombre);
                if (textBox_codigo.Text == perfil.Cod_Perfil && textBox_nombre.Text == perfil.Nombre && existe == true)
                {
                    //Pregunta de seguridad
                    DialogResult resultado = MessageBox.Show($"{Gestion_Idioma_44MM.Instancia.Texto["EstaSeguroDeModificar"]} {perfil.Tipo} '{perfil.Nombre}'?", Gestion_Idioma_44MM.Instancia.Texto["ConfirmarModificacion"], MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                    if (resultado == DialogResult.Yes)
                    {
                        (exito, mensaje) = bll_perfil.Modificar_Perfil(perfil, lista_seleccionados.ToList());
                        if (exito == true)
                        {
                            MessageBox.Show(Gestion_Idioma_44MM.Instancia.Texto[mensaje]);
                            Actualizar();
                        }
                        else
                        {
                            MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else if (resultado == DialogResult.No)
                    {
                        Actualizar();
                    }
                }
                else
                {
                    //No existe, pregunta si quiere crearlo
                    DialogResult resultado = MessageBox.Show($"{Gestion_Idioma_44MM.Instancia.Texto["DeseaCrear"]} {perfil.Tipo} : {perfil.Nombre}?", $"{perfil.Tipo} {Gestion_Idioma_44MM.Instancia.Texto["NoExistente"]}", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (resultado == DialogResult.Yes)
                    {
                        radioButton_perfil.Checked = true;
                        Crear_Perfil();
                    }
                }
            }
            else if (perfil.Tipo == "Familia")
            {
                //Verifica si existe una familia con ese codigo o nombre y si las cajas de texto son las mismas
                existe = bll_perfil.Verificar_Existencia_Familia(perfil.Cod_Perfil, perfil.Nombre);
                if (textBox_codigo.Text == perfil.Cod_Perfil && textBox_nombre.Text == perfil.Nombre && existe == true)
                {
                    //Pregunta de seguridad
                    DialogResult resultado = MessageBox.Show($"{Gestion_Idioma_44MM.Instancia.Texto["EstaSeguroDeModificar"]} {perfil.Tipo} '{perfil.Nombre}'?", Gestion_Idioma_44MM.Instancia.Texto["ConfirmarModificacion"], MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                    if (resultado == DialogResult.Yes)
                    {
                        (exito, mensaje) = bll_perfil.Modificar_Familia(perfil, lista_seleccionados.ToList());
                        if (exito == true)
                        {
                            MessageBox.Show(Gestion_Idioma_44MM.Instancia.Texto[mensaje]);
                            Actualizar();
                        }
                        else
                        {
                            MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else if (resultado == DialogResult.No)
                    {
                        Actualizar();
                    }
                }
                else
                {
                    //No existe, pregunta si quiere crearlo
                    DialogResult resultado = MessageBox.Show($"{Gestion_Idioma_44MM.Instancia.Texto["DeseaCrear"]} {perfil.Tipo} : {perfil.Nombre}?", $"{perfil.Tipo} {Gestion_Idioma_44MM.Instancia.Texto["NoExistente"]}", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (resultado == DialogResult.Yes)
                    {
                        radioButton_familia.Checked = true;
                        Crear_Perfil();
                    }
                }
            }
            else
            {
                MessageBox.Show($"{Gestion_Idioma_44MM.Instancia.Texto["NoSePuedeModificar"]} {perfil.Tipo} '{perfil.Nombre}'");
            }
        }

        private void Eliminar_Perfil(BE_Perfil_44MM perfil)
        {
            bool exito = false;
            string mensaje = string.Empty;
            bool existe = false;

            if (perfil.Tipo == "Perfil")
            {
                //Verifica si existe
                existe = bll_perfil.Verificar_Existencia_Perfil(perfil.Cod_Perfil, perfil.Nombre);
                if (existe == true)
                {
                    //Pregunta de seguridad
                    DialogResult resultado = MessageBox.Show($"{Gestion_Idioma_44MM.Instancia.Texto["EstaSeguroDeEliminar"]} {perfil.Tipo} '{perfil.Nombre}'?", Gestion_Idioma_44MM.Instancia.Texto["ConfirmarEliminacion"], MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (resultado == DialogResult.Yes)
                    {
                        (exito, mensaje) = bll_perfil.Eliminar_Perfil(perfil);
                        if (exito == true)
                        {
                            MessageBox.Show(Gestion_Idioma_44MM.Instancia.Texto[mensaje]);
                            Actualizar();
                        }
                        else
                        {
                            MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show($"{perfil.Tipo} {Gestion_Idioma_44MM.Instancia.Texto["NoExistente"]}");
                }
            }
            else if (perfil.Tipo == "Familia")
            {
                //Verifica si existe
                existe = bll_perfil.Verificar_Existencia_Familia(perfil.Cod_Perfil, perfil.Nombre);
                if (existe == true)
                {
                    //Pregunta de seguridad
                    DialogResult resultado = MessageBox.Show($"{Gestion_Idioma_44MM.Instancia.Texto["EstaSeguroDeEliminar"]} {perfil.Tipo} '{perfil.Nombre}'?", Gestion_Idioma_44MM.Instancia.Texto["ConfirmarEliminacion"], MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (resultado == DialogResult.Yes)
                    {
                        (exito, mensaje) = bll_perfil.Eliminar_Familia(perfil);
                        if (exito == true)
                        {
                            MessageBox.Show(Gestion_Idioma_44MM.Instancia.Texto[mensaje]);
                            Actualizar();
                        }
                        else
                        {
                            MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show($"{perfil.Tipo} {Gestion_Idioma_44MM.Instancia.Texto["NoExistente"]}");
                }
            }
            else
            {
                MessageBox.Show($"{Gestion_Idioma_44MM.Instancia.Texto["NoSePuedeEliminar"]} {perfil.Tipo} '{perfil.Nombre}'");
            }
        }
        #endregion

        #region Botones
        private void button_actualizar_Click(object sender, EventArgs e)
        {
            Actualizar();
        }

        private void button_limpiar_Click(object sender, EventArgs e)
        {
            Limpiar_Elementos();
        }

        private void button_agregar_Click(object sender, EventArgs e)
        {
            if (Obtener_Seleccionado() != null)
            {
                Agregar_Elemento(Obtener_Seleccionado());
            }
        }

        private void button_quitar_Click(object sender, EventArgs e)
        {
            if (Obtener_Seleccionado_Lista() != null)
            {
                Quitar_Elemento(Obtener_Seleccionado_Lista());
            }
        }

        private void button_crear_Click(object sender, EventArgs e)
        {
            Crear_Perfil();
        }

        private void button_modificar_Click(object sender, EventArgs e)
        {
            if (Obtener_Seleccionado_Arbol() != null)
            {
                Modificar_Perfil(Obtener_Seleccionado_Arbol());
            }
            else
            {
                MessageBox.Show(Gestion_Idioma_44MM.Instancia.Texto["SeleccioneUnPerfilOFamilia"], "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_eliminar_Click(object sender, EventArgs e)
        {
            if (Obtener_Seleccionado_Arbol() != null)
            {
                Eliminar_Perfil(Obtener_Seleccionado_Arbol());
            }
            else
            {
                MessageBox.Show(Gestion_Idioma_44MM.Instancia.Texto["SeleccioneUnPerfilOFamilia"], "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView_lista_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                celda_actual = dataGridView_lista.Rows[e.RowIndex].Cells[e.ColumnIndex];
            }
        }

        private void dataGridView_composicion_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                celda_actual_lista = dataGridView_composicion.Rows[e.RowIndex].Cells[e.ColumnIndex];
            }
        }

        private void treeView_arbol_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (Obtener_Seleccionado_Arbol() != null)
            {
                Cargar_Elementos(Obtener_Seleccionado_Arbol());
            }
        }
        #endregion

        #region Idioma
        public void Agregar_Form_Idioma()
        {
            Gestion_Idioma_44MM.Instancia.Suscribir_Form(this);
        }

        public void Actualizar_Idioma(Dictionary<string, string> key_word)
        {
            this.Text = key_word["GestionPerfiles"];

            label_composicion.Text = key_word["FamilasPermisosOtorgar"];
            label_lista.Text = key_word["FamiliasPermisosDisponibles"];

            radioButton_perfil.Text = key_word["CrearPerfil"];
            radioButton_familia.Text = key_word["CrearFamilia"];

            label_codigo.Text = key_word["Codigo"];
            label_nombre.Text = key_word["Nombre"];

            button_crear.Text = key_word["Crear"];
            button_agregar.Text = key_word["Agregar"];
            button_quitar.Text = key_word["Quitar"];
            button_limpiar.Text = key_word["Limpiar"];
            button_eliminar.Text = key_word["Eliminar"];
            button_actualizar.Text = key_word["Actualizar"];

            Actualizar_Arbol();
        }
        #endregion
    }
}