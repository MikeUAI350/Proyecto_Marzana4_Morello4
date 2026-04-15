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
    public partial class UI_Login : Form
    {
        public UI_Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string correo = textBox_correo.Text;
            string contra = textBox_contra.Text;
            bool mantener_sesion = checkBox_ms.Checked;

            Usuario usuario = new Usuario();
            string pin;
            string dni;
            bool exito;
            string mensaje;
            (pin, dni, exito, mensaje) = usuario.Iniciar_Sesion(correo, contra, mantener_sesion);

            if (exito == true)
            {
                MessageBox.Show(mensaje);
                this.Close();
            }
            else
            {
                label_mensaje.Text = mensaje;
            }
        }
    }
}
