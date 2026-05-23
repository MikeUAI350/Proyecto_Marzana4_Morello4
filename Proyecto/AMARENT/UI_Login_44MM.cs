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
    public partial class UI_Login_44MM : Form
    {
        private BLL_Usuario_44MM bll_usuario = new BLL_Usuario_44MM();
        public UI_Login_44MM(UI_Menu_44MM menu)
        {
            InitializeComponent();
            menu.Controls["menuStrip"].Enabled = false;
        }

        private void Iniciar_Sesion()
        {
            string login = textBox_login.Text;
            string contra = textBox_contra.Text;

            int exito;
            string mensaje = string.Empty;

            if (login == string.Empty || contra == string.Empty || login == null || contra == null || login == "" || contra == "")
            {
                MessageBox.Show("No debe haber Espacios en Blanco", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                (exito, mensaje) = bll_usuario.Iniciar_Sesion(login, contra);

                switch (exito)
                {
                    case -1:
                        {
                            MessageBox.Show(mensaje, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            UI_Cambiar_Clave_44MM ui = new UI_Cambiar_Clave_44MM((UI_Menu_44MM)this.MdiParent);
                            ui.Controls["button_salir"].Enabled = false;
                            ui.MdiParent = this.MdiParent;
                            ui.Show();
                            this.Close();
                            break;
                        }
                    case 0:
                        {
                            MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        }
                    case 1:
                        {
                            MessageBox.Show(mensaje);
                            UI_Menu_44MM menu = (UI_Menu_44MM)this.MdiParent;
                            this.MdiParent.Controls["menuStrip"].Enabled = true;
                            menu.Activar_Menus(Sesion_Manager_44MM.Get().Rol);
                            this.Close();
                            break;
                        }
                }
            }
        }

        private void button_login_Click(object sender, EventArgs e)
        {
            Iniciar_Sesion();
        }

        private void button_salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UI_Login_44MM_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.MdiParent.Controls["menuStrip"].Enabled = true;
        }

        #region Visiblilidad Contraseña
        private void Mostrar_TextBox(TextBox tb)
        {
            tb.UseSystemPasswordChar = false;
        }
        private void Ocultar_TextBox(TextBox tb)
        {
            tb.UseSystemPasswordChar = true;
        }

        private void textBox_contra_MouseEnter(object sender, EventArgs e)
        {
            Mostrar_TextBox(textBox_contra);
        }

        private void textBox_contra_MouseLeave(object sender, EventArgs e)
        {
            Ocultar_TextBox(textBox_contra);
        }
        #endregion
    }
}