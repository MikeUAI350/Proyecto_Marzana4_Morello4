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
    public partial class UI_Cambiar_Clave_44MM : Form
    {
        private BLL_Usuario_44MM bll = new BLL_Usuario_44MM();
        public UI_Cambiar_Clave_44MM()
        {
            InitializeComponent();
        }

        private void Verificar_Coincidencia(string contra_a, string contra1, string contra2)
        {
            bool exito = false;
            string mensaje = string.Empty;
            if (contra1 != contra2)
            {
                MessageBox.Show("Las Contraseñas no Coinciden", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                (exito, mensaje) = bll.Cambiar_Clave(contra_a, contra1);
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
    }
}
