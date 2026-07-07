using BLL;
using Digito_Verificador_IS;
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
    public partial class UI_Login_44MM : Form, I_Idioma
    {
        private BLL_Usuario_44MM bll_usuario = new BLL_Usuario_44MM();
        public UI_Login_44MM(UI_Menu_44MM menu)
        {
            InitializeComponent();
            menu.Controls["menuStrip"].Enabled = false;
            Agregar_Form_Idioma();
        }

        private void Iniciar_Sesion()
        {
            string login = textBox_login.Text;
            string contra = textBox_contra.Text;

            int exito;
            string mensaje = string.Empty;

            //Verifica si no esta en blanco
            if (login == string.Empty || contra == string.Empty || login == null || contra == null || login == "" || contra == "")
            {
                MessageBox.Show(Gestion_Idioma_44MM.Instancia.Texto["NoDebeHaberEspaciosEnBlanco"], "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                (exito, mensaje) = bll_usuario.Iniciar_Sesion(login, contra);

                switch (exito)
                {
                    //Error de Inicio
                    case 0:
                        {
                            MessageBox.Show(Gestion_Idioma_44MM.Instancia.Texto[mensaje], "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        }
                    //Inicio de Sesion Exitoso
                    case 1:
                        {
                            //Cambia el idioma
                            Gestion_Idioma_44MM.Instancia.Cambiar_Idioma(Sesion_Manager_44MM.Instancia.Get().Idioma);
                            //Mensaje
                            MessageBox.Show(Gestion_Idioma_44MM.Instancia.Texto[mensaje]);

                            UI_Menu_44MM menu = (UI_Menu_44MM)this.MdiParent;
                            MenuStrip menustrip = (MenuStrip)menu.Controls["menuStrip"];
                            menustrip.Enabled = true;

                            ToolStripMenuItem menu_usuario = (ToolStripMenuItem)menustrip.Items["usuariotoolStripMenuItem"];
                            menu_usuario.DropDownItems["loginToolStripMenuItem"].Visible = false;
                            menu_usuario.DropDownItems["loginToolStripMenuItem"].Enabled = false;
                            menu_usuario.DropDownItems["cambiarIdiomaToolStripMenuItem"].Visible = false;
                            menu_usuario.DropDownItems["cambiarIdiomaToolStripMenuItem"].Enabled = false;
                            menu_usuario.DropDownItems["cambiarClaveToolStripMenuItem"].Visible = false;
                            menu_usuario.DropDownItems["cambiarClaveToolStripMenuItem"].Enabled = false;
                            menu_usuario.DropDownItems["logoutToolStripMenuItem"].Visible = false;
                            menu_usuario.DropDownItems["logoutToolStripMenuItem"].Enabled = false;

                            List<BE_Permiso_44MM> lista_permisos = bll_usuario.Recuperar_Permisos(Sesion_Manager_44MM.Instancia.Get().Rol);
                            if (lista_permisos != null)
                            {
                                foreach (BE_Permiso_44MM permiso in lista_permisos)
                                {
                                    menu.Activar_Menus(permiso.Cod_Permiso);
                                    menu.Activar_Menus(permiso.Nombre);
                                }
                            }

                            this.Close();
                            break;
                        }
                    //Requiere de cambio de contraseña
                    case 2:
                        {
                            //Cambia el idioma
                            Gestion_Idioma_44MM.Instancia.Cambiar_Idioma(Sesion_Manager_44MM.Instancia.Get().Idioma);
                            //Mensaje
                            MessageBox.Show(Gestion_Idioma_44MM.Instancia.Texto[mensaje], "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            UI_Cambiar_Clave_44MM ui = new UI_Cambiar_Clave_44MM((UI_Menu_44MM)this.MdiParent);
                            ui.Controls["button_salir"].Enabled = false;
                            ui.MdiParent = this.MdiParent;
                            ui.Show();

                            this.Close();
                            break;
                        }
                    //Inconsistencia de Datos
                    case 3:
                        {
                            //Cambia el idioma
                            Gestion_Idioma_44MM.Instancia.Cambiar_Idioma(Sesion_Manager_44MM.Instancia.Get().Idioma);
                            //Mensaje
                            MessageBox.Show(Gestion_Idioma_44MM.Instancia.Texto[mensaje], "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            //Digito verificador
                            UI_Digito_Verificador_44MM ui_dv = new UI_Digito_Verificador_44MM((UI_Menu_44MM)this.MdiParent);
                            ui_dv.MdiParent = this.MdiParent;
                            ui_dv.Show();

                            this.Close();
                            break;
                        }
                }
            }
        }

        #region Botones
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
            if ((this.MdiParent as UI_Menu_44MM).Pantalla_Actual != null)
            {
                (this.MdiParent as UI_Menu_44MM).Pantalla_Actual.Enabled = true;
            }
        }
        #endregion

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

        #region Idioma
        public void Agregar_Form_Idioma()
        {
            Gestion_Idioma_44MM.Instancia.Suscribir_Form(this);
        }

        public void Actualizar_Idioma(Dictionary<string, string> key_word)
        {
            this.Text = key_word["Login"];

            label_login.Text = key_word["Usuario"];
            label_contra.Text = key_word["Contra"];
            button_login.Text = key_word["Login"];
            button_salir.Text = key_word["Salir"];
        }
        #endregion
    }
}