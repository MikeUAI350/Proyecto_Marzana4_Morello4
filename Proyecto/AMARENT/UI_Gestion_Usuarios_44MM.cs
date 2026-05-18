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
    public partial class UI_Gestion_Usuarios_44MM : Form
    {
        private BLL_Usuario_44MM bll = new BLL_Usuario_44MM();
        private DataTable tabla_usuarios;
        private DataTable tabla_activos;
        private DataTable tabla_bloqueados;
        private DataGridViewCell celda_actual;

        public UI_Gestion_Usuarios_44MM()
        {
            InitializeComponent();
            Iniciar_Grillas();
        }

        private void Iniciar_Grillas()
        {
            (tabla_usuarios, tabla_activos, tabla_bloqueados) = bll.Gestionar_Usuarios();

            dataGridView_lista.DataSource = tabla_usuarios;

            dataGridView_lista.Columns["Password"].Visible = false;
            dataGridView_lista.Columns["Email"].Visible = false;
            dataGridView_lista.Columns["Bloqueado"].Visible = false;
            dataGridView_lista.Columns["Activo"].Visible = false;

            celda_actual = dataGridView_lista.Rows[0].Cells[0];
        }

        private DataRow Obtener_Seleccionado()
        {
            try
            {
                DataGridViewCell celda = dataGridView_lista.Rows[celda_actual.RowIndex].Cells["Login"];
                string login = (string)celda.Value;
                DataRow row = tabla_usuarios.Rows.Find(login);
                return row;
            }
            catch (Exception)
            {
                MessageBox.Show("Seleccione un Usuario", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
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
                        dataGridView_lista.DataSource = tabla_usuarios;
                        break;
                    }
                case "Activos":
                    {
                        dataGridView_lista.DataSource = tabla_activos;
                        break;
                    }
                case "Bloqueados":
                    {
                        dataGridView_lista.DataSource = tabla_bloqueados;
                        button_desbloquear.Enabled = true;
                        button_desbloquear.Visible = true;
                        break;
                    }
                default:
                    {
                        break;
                    }
            }

            dataGridView_lista.Columns["Password"].Visible = false;
            dataGridView_lista.Columns["Email"].Visible = false;
            dataGridView_lista.Columns["Bloqueado"].Visible = false;
            dataGridView_lista.Columns["Activo"].Visible = false;
        }

        private void Crear()
        {
            UI_Gestion_44MM ui = new UI_Gestion_44MM("Crear", null);
            this.MdiParent.Controls["menuStrip"].Enabled = false;
            ui.MdiParent = this.MdiParent;
            ui.Show();
        }

        private void Modificar(DataRow fila)
        {
            UI_Gestion_44MM ui = new UI_Gestion_44MM("Modificar", fila);
            this.MdiParent.Controls["menuStrip"].Enabled = false;
            ui.MdiParent = this.MdiParent;
            ui.Show();
        }

        private void Activar(DataRow fila)
        {
            string login = (string)fila["Login"];
            bool activo = (bool)fila["Activo"];

            bool activar = false;

            DialogResult resultado;

            if (activo == false)
            {
                resultado = MessageBox.Show("Desea Activar a " + login, "Activar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                activar = true;
            }
            else
            {
                resultado = MessageBox.Show("Desea Desactivar a " + login, "Desactivar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
                    MessageBox.Show(mensaje);
                }
            }
        }

        private void Desbloquear(DataRow fila)
        {
            string login = (string)fila["Login"];
            DialogResult resultado = MessageBox.Show("Desea Desbloquear a " + login, "Desbloquear", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                bool exito = false;
                string mensaje = string.Empty;

                (exito, mensaje) = bll.Desbloquear_Usuario(fila);

                if (exito == false)
                {
                    MessageBox.Show(mensaje, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(mensaje);
                }
            }
        }

        private void button_crear_Click(object sender, EventArgs e)
        {
            Crear();
        }

        private void dataGridView_lista_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            celda_actual = dataGridView_lista.Rows[e.RowIndex].Cells[e.ColumnIndex];
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
            radioButton_todos.Checked = true;
            Iniciar_Grillas();
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

        private void radioButton_bloqueados_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_bloqueados.Checked == true)
            {
                Filtrar("Bloqueados");
            }
        }
    }
}
