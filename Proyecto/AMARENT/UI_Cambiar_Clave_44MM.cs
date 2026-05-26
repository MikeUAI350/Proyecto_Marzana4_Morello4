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
    public partial class UI_Cambiar_Clave_44MM : Form , I_Idioma
    {
        private BLL_Usuario_44MM bll_usuario = new BLL_Usuario_44MM();
        public UI_Cambiar_Clave_44MM(UI_Menu_44MM menu)
        {
            InitializeComponent();
            menu.Controls["menuStrip"].Enabled = false;
            Agregar_Form_Idioma();
        }

        private void Verificar_Coincidencia(string contra_a, string contra1, string contra2)
        {
            bool exito = false;
            string mensaje = string.Empty;
            if (contra_a == string.Empty || contra1 == string.Empty || contra2 == string.Empty || contra_a == null || contra1 == null || contra2 == null || contra_a == "" || contra1 == "" || contra2 == "")
            {
                MessageBox.Show("No debe haber Espacios en Blanco", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (contra1 != contra2)
            {
                MessageBox.Show("Las Contraseñas no Coinciden", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (contra_a == contra1 || contra_a == contra2)
            {
                MessageBox.Show("La Nueva Contraseña no puede ser igual a la Anterior", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                (exito, mensaje) = bll_usuario.Cambiar_Clave(contra_a, contra1);
                if (exito == false)
                {
                    MessageBox.Show(mensaje, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(mensaje);
                    Sesion_Manager_44MM.Quitar_Cuenta();
                    Application.Restart();
                }
            }
        }

        private void button_confirmar_Click(object sender, EventArgs e)
        {
            string contra_a = textBox_contra.Text;
            string contra1 = textBox_nueva_contra1.Text;
            string contra2 = textBox_nueva_contra2.Text;

            Verificar_Coincidencia(contra_a, contra1, contra2);
        }

        private void button_salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UI_Cambiar_Clave_44MM_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.MdiParent.Controls["menuStrip"].Enabled = true;
            if ((this.MdiParent as UI_Menu_44MM).Pantalla_Actual != null)
            {
                (this.MdiParent as UI_Menu_44MM).Pantalla_Actual.Enabled = true;
            }
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

        private void textBox_nueva_contra1_MouseEnter(object sender, EventArgs e)
        {
            Mostrar_TextBox(textBox_nueva_contra1);
        }

        private void textBox_nueva_contra2_MouseEnter(object sender, EventArgs e)
        {
            Mostrar_TextBox(textBox_nueva_contra2);
        }

        private void textBox_contra_MouseLeave(object sender, EventArgs e)
        {
            Ocultar_TextBox(textBox_contra);
        }

        private void textBox_nueva_contra1_MouseLeave(object sender, EventArgs e)
        {
            Ocultar_TextBox(textBox_nueva_contra1);
        }

        private void textBox_nueva_contra2_MouseLeave(object sender, EventArgs e)
        {
            Ocultar_TextBox(textBox_nueva_contra2);
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
