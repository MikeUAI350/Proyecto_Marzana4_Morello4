using BE;
using BLL;
using Servicios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AMARENT
{
    public partial class UI_Gestion_Usuarios_44MM : Form , I_Idioma
    {
        private BLL_Usuario_44MM bll = new BLL_Usuario_44MM();
        private List<BE_Usuario_44MM> lista_usuarios;
        private DataGridViewCell celda_actual;

        public UI_Gestion_Usuarios_44MM()
        {
            InitializeComponent();
            Actualizar_Grillas();
            Agregar_Form_Idioma();
        }

        #region Funciones Secundarias
        public void Actualizar_Grillas()
        {
            radioButton_todos.Checked = true;
            lista_usuarios = bll.Gestionar_Usuarios();
            Filtrar("Todos");
        }

        private BE_Usuario_44MM Obtener_Seleccionado()
        {
            if (celda_actual == null || celda_actual.RowIndex < 0 || celda_actual.ColumnIndex < 0)
            {
                MessageBox.Show(Gestion_Idioma_44MM.Instancia.Texto["SeleccioneUnUsuario"], "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            else
            {
                DataGridViewCell celda = dataGridView_lista.Rows[celda_actual.RowIndex].Cells["Login"];
                string login = (string)celda.Value;
                BE_Usuario_44MM be = lista_usuarios.Find(x => x.Login == login);
                return be;
            }
        }

        private void Filtrar(string filtro)
        {
            button_desbloquear.Enabled = false;
            button_desbloquear.Visible = false;
            switch (filtro)
            {
                case "Todos":
                    {
                        dataGridView_lista.DataSource = lista_usuarios;
                        break;
                    }
                case "Activos":
                    {
                        List<BE_Usuario_44MM> lista = lista_usuarios.Where(u => u.Activo == true).ToList();
                        dataGridView_lista.DataSource = lista;
                        break;
                    }
                case "Inactivos":
                    {
                        List<BE_Usuario_44MM> lista = lista_usuarios.Where(u => u.Activo == false).ToList();
                        dataGridView_lista.DataSource = lista;
                        break;
                    }
                case "Bloqueados":
                    {
                        List<BE_Usuario_44MM> lista = lista_usuarios.Where(u => u.Bloqueado == true).ToList();
                        dataGridView_lista.DataSource = lista;
                        button_desbloquear.Enabled = true;
                        button_desbloquear.Visible = true;
                        break;
                    }
                default:
                    {
                        break;
                    }
            }

            dataGridView_lista.Columns["Email"].Visible = false;
            dataGridView_lista.Columns["Bloqueado"].Visible = false;
            dataGridView_lista.Columns["Activo"].Visible = false;
            dataGridView_lista.Columns["Idioma"].Visible = false;
            dataGridView_lista.Columns["RCC"].Visible = false;
        }
        #endregion

        #region Funciones Principales
        private void Crear()
        {
            UI_Gestion_44MM ui = new UI_Gestion_44MM("Crear", null, this);
            this.MdiParent.Controls["menuStrip"].Enabled = false;
            ui.MdiParent = this.MdiParent;
            ui.Show();
        }

        private void Modificar(BE_Usuario_44MM be)
        {
            UI_Gestion_44MM ui = new UI_Gestion_44MM("Modificar", be, this);
            this.MdiParent.Controls["menuStrip"].Enabled = false;
            ui.MdiParent = this.MdiParent;
            ui.Show();
        }

        private void Activar(BE_Usuario_44MM be)
        {
            string login = be.Login;
            bool activo = be.Activo;

            bool activar = false;

            DialogResult resultado;

            if (activo == false)
            {
                resultado = MessageBox.Show($"{Gestion_Idioma_44MM.Instancia.Texto["DeseaActivarA"]} {login}?", "Activar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                activar = true;
            }
            else
            {
                resultado = MessageBox.Show($"{Gestion_Idioma_44MM.Instancia.Texto["DeseaDesactivarA"]} {login}?", "Desactivar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                activar = false;
            }

            if (resultado == DialogResult.Yes)
            {
                bool exito = false;
                string mensaje = string.Empty;

                (exito, mensaje) = bll.Activar_Usuario(login, activar);

                if (exito == false)
                {
                    MessageBox.Show(mensaje, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(Gestion_Idioma_44MM.Instancia.Texto[mensaje]);
                    Actualizar_Grillas();
                }
            }
        }

        private void Desbloquear(BE_Usuario_44MM be)
        {
            string login = be.Login;
            DialogResult resultado = MessageBox.Show($"{Gestion_Idioma_44MM.Instancia.Texto["DeseaDesbloquearA"]} {login}?", "Desbloquear", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                bool exito = false;
                string mensaje = string.Empty;

                (exito, mensaje) = bll.Desbloquear_Usuario(be);

                if (exito == false)
                {
                    MessageBox.Show(mensaje, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(Gestion_Idioma_44MM.Instancia.Texto[mensaje]);
                    Actualizar_Grillas();
                }
            }
        }
        #endregion

        #region Botones
        private void button_crear_Click(object sender, EventArgs e)
        {
            Crear();
        }

        private void dataGridView_lista_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                celda_actual = dataGridView_lista.Rows[e.RowIndex].Cells[e.ColumnIndex];
            }
        }

        private void button_desbloquear_Click(object sender, EventArgs e)
        {
            if (Obtener_Seleccionado() != null)
            {
                Desbloquear(Obtener_Seleccionado());
            }
        }

        private void button_actualizar_Click(object sender, EventArgs e)
        {
            Actualizar_Grillas();
        }

        private void button_modificar_Click(object sender, EventArgs e)
        {
            if (Obtener_Seleccionado() != null)
            {
                Modificar(Obtener_Seleccionado());
            }
        }

        private void button_activar_desactivar_Click(object sender, EventArgs e)
        {
            if (Obtener_Seleccionado() != null)
            {
                Activar(Obtener_Seleccionado());
            }
        }

        private void radioButton_todos_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_todos.Checked == true)
            {
                Filtrar("Todos");
            }
        }

        private void radioButton_activos_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_activos.Checked == true)
            {
                Filtrar("Activos");
            }
        }

        private void radioButton_inactivos_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_inactivos.Checked == true)
            {
                Filtrar("Inactivos");
            }
        }

        private void radioButton_bloqueados_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_bloqueados.Checked == true)
            {
                Filtrar("Bloqueados");
            }
        }

        private void UI_Gestion_Usuarios_44MM_Load(object sender, EventArgs e)
        {
            Actualizar_Grillas();
        }

        private void UI_Gestion_Usuarios_44MM_Shown(object sender, EventArgs e)
        {
            Actualizar_Grillas();
        }
        #endregion

        #region Idioma
        public void Agregar_Form_Idioma()
        {
            Gestion_Idioma_44MM.Instancia.Suscribir_Form(this);
        }

        public void Actualizar_Idioma(Dictionary<string, string> key_word)
        {
            this.Text = key_word["GestionUsuarios"];

            label_lista.Text = key_word["ListaUsuarios"];
            radioButton_bloqueados.Text = key_word["Bloqueados"];
            radioButton_inactivos.Text = key_word["Inactivos"];
            radioButton_activos.Text = key_word["Activos"];
            radioButton_todos.Text = key_word["Todos"];

            groupBox_controles.Text = key_word["Controles"];
            button_crear.Text = key_word["Crear"];
            button_modificar.Text = key_word["Modificar"];
            button_activar_desactivar.Text = key_word["ActDesact"];
            button_desbloquear.Text = key_word["Desbloquear"];
            button_actualizar.Text = key_word["Actualizar"];
        }
        #endregion
    }
}
