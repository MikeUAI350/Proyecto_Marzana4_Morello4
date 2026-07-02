using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Digito_Verificador_IS
{
    public partial class UI_Digito_Verificador_44MM : Form
    {
        BLL_Digito_Verificador_44MM bll_dv = new BLL_Digito_Verificador_44MM();
        public UI_Digito_Verificador_44MM()
        {
            InitializeComponent();
        }

        private void Mostar_Errores()
        {
            bool exito = false;
            List<string> nombres_tablas;

            (exito, nombres_tablas) = bll_dv.Recalcular_Todo();

            foreach (string item in nombres_tablas)
            {
                MessageBox.Show(item);
            }
        }

        private void Restock()
        {
            // Implementar la lógica de restock aquí
        }

        private void Recalcular()
        {
            bll_dv.Guardar_Calculo();
            Application.Restart();
        }

        #region Botones
        private void button_mostrar_errores_Click(object sender, EventArgs e)
        {
            Mostar_Errores();
        }

        private void button_restock_Click(object sender, EventArgs e)
        {
            Restock();
        }

        private void button_recalcular_Click(object sender, EventArgs e)
        {
            Recalcular();
        }

        private void button_salir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion
    }
}
