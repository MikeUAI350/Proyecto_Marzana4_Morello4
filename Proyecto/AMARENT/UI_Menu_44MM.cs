using BE;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace AMARENT
{
    public partial class UI_Menu_44MM : Form
    {
        private BLL_Usuario_44MM bll = new BLL_Usuario_44MM();
        public UI_Menu_44MM()
        {
            InitializeComponent();
            Abrir_Login();
            Total_Pantallas();
            Sesion_Manager_44MM.Instancia.PropiedadCambiada += Activar_Menus;
        }

        #region Usuarios
        private void Abrir_Login()
        {
            UI_Login_44MM ui = new UI_Login_44MM();
            ui.MdiParent = this;
            ui.Show();
        }

        private void Abrir_Cambiar_Idioma(string idioma)
        {

        }

        private void Abrir_Cambiar_Clave()
        {
            BE_Usuario_44MM usuario = Sesion_Manager_44MM.Get();
            if (usuario == null)
            {
                MessageBox.Show("Sesion no Iniciada", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                UI_Cambiar_Clave_44MM ui = new UI_Cambiar_Clave_44MM();
                ui.MdiParent = this;
                ui.Show();
            }
        }

        private void Abrir_Logout()
        {
            BE_Usuario_44MM usuario = Sesion_Manager_44MM.Get();
            if (usuario == null)
            {
                MessageBox.Show("Sesion no Iniciada", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult resultado = MessageBox.Show("Desea cerrar sesion?", "Cerrar Sesion?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado == DialogResult.Yes)
                {
                    bll.Cerrar_Sesion();
                    MessageBox.Show("Sesion cerrada");
                    foreach (Form pantalla in pantallas)
                    {
                        pantalla.Visible = false;
                    }
                }
            }
        }

        private void Abrir_Gestion_Usuarios()
        {
            Gestion_Pantalla(ui_gestion_usuarios);
        }

        private void Abrir_Bitacora_Eventos()
        {
            Gestion_Pantalla(ui_bitacora_eventos);
        }
        #endregion

        #region Pantallas
        private UI_Bitacora_Eventos_44MM ui_bitacora_eventos = new UI_Bitacora_Eventos_44MM();
        private UI_Gestion_Usuarios_44MM ui_gestion_usuarios = new UI_Gestion_Usuarios_44MM();
        private List<Form> pantallas = new List<Form>();

        private void Total_Pantallas()
        {
            pantallas.Add(ui_gestion_usuarios);
            pantallas.Add(ui_bitacora_eventos);

            foreach (Form pantalla in pantallas)
            {
                pantalla.MdiParent = this;
                pantalla.Show();
                pantalla.Visible = false;
            }
        }

        private void Gestion_Pantalla(Form f)
        {
            foreach (Form pantalla in pantallas)
            {
                pantalla.Visible = false;
            }

            f.Visible = true;
        }

        private void Activar_Menus(bool act)
        {
            adminToolStripMenuItem.Visible = true;
            maestroToolStripMenuItem.Visible = true;
            pN1ToolStripMenuItem.Visible = true;
            pN2ToolStripMenuItem.Visible = true;
            reporteToolStripMenuItem.Visible = true;
            ayudaToolStripMenuItem.Visible = true;

            adminToolStripMenuItem.Enabled = true;
            maestroToolStripMenuItem.Enabled = true;
            pN1ToolStripMenuItem.Enabled = true;
            pN2ToolStripMenuItem.Enabled = true;
            reporteToolStripMenuItem.Enabled = true;
            ayudaToolStripMenuItem.Enabled = true;
        }
        #endregion

        #region Botones
        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Abrir_Login();
        }

        private void cambiarClaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Abrir_Cambiar_Clave();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Abrir_Logout();
        }

        private void gestionDeUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Abrir_Gestion_Usuarios();
        }

        private void bitacoraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Abrir_Bitacora_Eventos();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Abrir_Gestion_Usuarios();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Abrir_Bitacora_Eventos();
        }

        private void españolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Abrir_Cambiar_Idioma("es");
        }

        private void inglesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Abrir_Cambiar_Idioma("en");
        }
        #endregion

        private void UI_Menu_44MM_FormClosing(object sender, FormClosingEventArgs e)
        {
            Gestion_Intentos_44MM.Instancia.Guardar_Intentos();
        }
    }
}