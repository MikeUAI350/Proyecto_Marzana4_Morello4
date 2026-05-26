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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace AMARENT
{
    public partial class UI_Menu_44MM : Form , I_Idioma
    {
        private BLL_Usuario_44MM bll = new BLL_Usuario_44MM();
        public UI_Menu_44MM()
        {
            InitializeComponent();
            Abrir_Login();
            Total_Pantallas();
            Agregar_Form_Idioma();
        }

        #region Usuarios
        private void Abrir_Login()
        {
            UI_Login_44MM ui = new UI_Login_44MM(this);
            ui.MdiParent = this;
            ui.Show();

            if (Pantalla_Actual != null)
            {
                Pantalla_Actual.Enabled = false;
            }
        }

        private void Abrir_Cambiar_Idioma(string idioma)
        {
            Gestion_Idioma_44MM.Instancia.Notificar_Cambio_Idioma(idioma);
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
                UI_Cambiar_Clave_44MM ui = new UI_Cambiar_Clave_44MM(this);
                ui.MdiParent = this;
                ui.Show();

                if (Pantalla_Actual != null)
                {
                    Pantalla_Actual.Enabled = false;
                }
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
                    Activar_Menus("");
                    MessageBox.Show("Sesion cerrada");
                    foreach (Form pantalla in pantallas)
                    {
                        pantalla.Visible = false;
                    }
                    Application.Restart();
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

        public Form Pantalla_Actual;
        private void Gestion_Pantalla(Form f)
        {
            foreach (Form pantalla in pantallas)
            {
                pantalla.Visible = false;
            }

            f.Visible = true;
            Pantalla_Actual = f;
        }

        public void Activar_Menus(string rol)
        {
            switch (rol)
            {
                case "Admin":
                    {
                        adminToolStripMenuItem.Visible = true;
                        reporteToolStripMenuItem.Visible = true;
                        ayudaToolStripMenuItem.Visible = true;

                        adminToolStripMenuItem.Enabled = true;
                        reporteToolStripMenuItem.Enabled = true;
                        ayudaToolStripMenuItem.Enabled = true;

                        break;
                    }
                case "Base":
                    {
                        pN1ToolStripMenuItem.Visible = true;
                        pN2ToolStripMenuItem.Visible = true;

                        pN1ToolStripMenuItem.Enabled = true;
                        pN2ToolStripMenuItem.Enabled = true;

                        break;
                    }
                default:
                    {
                        adminToolStripMenuItem.Visible = false;
                        maestroToolStripMenuItem.Visible = false;
                        pN1ToolStripMenuItem.Visible = false;
                        pN2ToolStripMenuItem.Visible = false;
                        reporteToolStripMenuItem.Visible = false;
                        ayudaToolStripMenuItem.Visible = false;

                        adminToolStripMenuItem.Enabled = false;
                        maestroToolStripMenuItem.Enabled = false;
                        pN1ToolStripMenuItem.Enabled = false;
                        pN2ToolStripMenuItem.Enabled = false;
                        reporteToolStripMenuItem.Enabled = false;
                        ayudaToolStripMenuItem.Enabled = false;

                        break;
                    }
            }
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

        private void españolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Abrir_Cambiar_Idioma("es");
        }

        private void inglesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Abrir_Cambiar_Idioma("en");
        }

        private void UI_Menu_44MM_FormClosing(object sender, FormClosingEventArgs e)
        {
            BE_Usuario_44MM be = Sesion_Manager_44MM.Get();
            if (be != null)
            {
                bll.Cerrar_Sesion();
            }
            foreach (Form pantalla in pantallas)
            {
                pantalla.Visible = false;
            }
            GC.Collect();
        }

        private Keys key0;
        private Keys key1;
        private Keys key2;
        private Keys key3;
        private Keys key4;
        private Keys key5;
        private Keys key6;
        private Keys key7;
        private Keys key8;
        private Keys key9;
        private void UI_Menu_44MM_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                if (
                key0 == Keys.Up &&
                key1 == Keys.Up &&
                key2 == Keys.Down &&
                key3 == Keys.Down &&
                key4 == Keys.Left &&
                key5 == Keys.Right &&
                key6 == Keys.Left &&
                key7 == Keys.Right &&
                key8 == Keys.B &&
                key9 == Keys.A
                )
                {
                    Abrir_Gestion_Usuarios();
                }
            }
            key0 = key1;
            key1 = key2;
            key2 = key3;
            key3 = key4;
            key4 = key5;
            key5 = key6;
            key6 = key7;
            key7 = key8;
            key8 = key9;
            key9 = e.KeyCode;
        }
        #endregion

        #region Idioma
        public void Agregar_Form_Idioma()
        {
            Gestion_Idioma_44MM.Instancia.Agregar_Form_Idioma(this);
        }
        #endregion
    }
}