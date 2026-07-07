using AMARENT;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Digito_Verificador_IS
{
    public partial class UI_Digito_Verificador_44MM : Form , I_Idioma
    {
        BLL_Digito_Verificador_44MM bll_dv = new BLL_Digito_Verificador_44MM();
        public UI_Digito_Verificador_44MM(UI_Menu_44MM menu)
        {
            InitializeComponent();
            menu.Controls["menuStrip"].Enabled = false;
            MenuStrip menustrip = (MenuStrip)menu.Controls["menuStrip"];
            menustrip.Items.Clear();
            Agregar_Form_Idioma();
        }

        private void Mostar_Errores()
        {
            bool exito = false;
            string mensaje = string.Empty;
            List<string> nombres_tablas;

            (exito, nombres_tablas) = bll_dv.Recalcular_Todo();

            foreach (string item in nombres_tablas)
            {
                mensaje += $"{item}\n\r";
            }
            MessageBox.Show(mensaje, Gestion_Idioma_44MM.Instancia.Texto["TablasAfectadas"], MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Restock()
        {
            UI_Respaldo_44MM ui = new UI_Respaldo_44MM();
            ui.MdiParent = this.MdiParent;
            ui.Show();
            this.Close();
        }

        private void Recalcular()
        {
            bll_dv.Guardar_Calculo();
            MessageBox.Show(Gestion_Idioma_44MM.Instancia.Texto["Recalculado"]);
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
            DialogResult r = MessageBox.Show(Gestion_Idioma_44MM.Instancia.Texto["EstaSeguroQueDeseaRecalcularYMantenerLosPosiblesErrores"], Gestion_Idioma_44MM.Instancia.Texto["Advertencia"], MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (r == DialogResult.OK)
            {
                Recalcular();
            }
        }

        private void button_salir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion

        #region Idioma
        public void Agregar_Form_Idioma()
        {
            Gestion_Idioma_44MM.Instancia.Suscribir_Form(this);
        }

        public void Actualizar_Idioma(Dictionary<string, string> key_word)
        {
            this.Text = Gestion_Idioma_44MM.Instancia.Texto["InconsistenciaEnLaBaseDeDatos"];
            button_mostrar_errores.Text = Gestion_Idioma_44MM.Instancia.Texto["MostrarErrores"];
            button_restock.Text = Gestion_Idioma_44MM.Instancia.Texto["Restaurar"];
            button_recalcular.Text = Gestion_Idioma_44MM.Instancia.Texto["Recalcular"];
            button_salir.Text = Gestion_Idioma_44MM.Instancia.Texto["Salir"];
        }
        #endregion
    }
}
