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
        private BLL_Usuario_44MM usuario = new BLL_Usuario_44MM();
        public UI_Login_44MM()
        {
            InitializeComponent();
        }

        private void Iniciar_Sesion()
        {
            string login = textBox_login.Text;
            string contra = textBox_contra.Text;

            bool exito;
            int cod_op = 0;

            (exito, cod_op) = usuario.Iniciar_Sesion(login, contra);
            if (exito != true)
            {
                label_mensaje.Text = "Error Codigo: " + cod_op.ToString();
            }
            else
            {
                MessageBox.Show("Inicio de Sesion Exitoso");
                this.Close();
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
    }
}