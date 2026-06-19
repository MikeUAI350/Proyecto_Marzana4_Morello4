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
    public partial class UI_Respaldo_44MM : Form , I_Idioma
    {
        private BLL_Respaldo_44MM bll_respaldo = new BLL_Respaldo_44MM();
        public UI_Respaldo_44MM()
        {
            InitializeComponent();
        }

        #region Funciones Principales
        private void Direccion_Backup()
        {
            if (saveFileDialog_backup.ShowDialog() == DialogResult.OK)
            {
                textBox_backup.Text = saveFileDialog_backup.FileName;
            }
        }

        private void Direccion_Restore()
        {
            if (openFileDialog_restore.ShowDialog() == DialogResult.OK)
            {
                textBox_restore.Text = openFileDialog_restore.FileName;
            }
        }

        private void Backup()
        {
            if(!string.IsNullOrEmpty(textBox_backup.Text))
            {
                try
                {
                    bll_respaldo.Hacer_BackUp(textBox_backup.Text);
                    MessageBox.Show($"{Gestion_Idioma_44MM.Instancia.Texto["BackupExitoso"]}\n\r{textBox_backup.Text}");
                    textBox_backup.Text = "";
                }
                catch
                {
                    MessageBox.Show(Gestion_Idioma_44MM.Instancia.Texto["ErrorBackup"], "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show(Gestion_Idioma_44MM.Instancia.Texto["SeleccioneRutaDelBackup"], "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Direccion_Backup();
            }
        }

        private void Restore()
        {
            if (!string.IsNullOrEmpty(textBox_restore.Text))
            {
                try
                {
                    bll_respaldo.Hacer_Restore(textBox_restore.Text);
                    MessageBox.Show($"{Gestion_Idioma_44MM.Instancia.Texto["RestoreExitoso"]}\n\r{textBox_restore.Text}");
                    textBox_restore.Text = "";
                }
                catch
                {
                    MessageBox.Show(Gestion_Idioma_44MM.Instancia.Texto["ErrorRestore"], "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show(Gestion_Idioma_44MM.Instancia.Texto["SeleccioneRutaDelRestore"], "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Direccion_Restore();
            }
        }
        #endregion

        #region Botones
        private void button_direccion_backup_Click(object sender, EventArgs e)
        {
            Direccion_Backup();
        }

        private void button_backup_Click(object sender, EventArgs e)
        {
            Backup();
        }

        private void button_direccion_restore_Click(object sender, EventArgs e)
        {
            Direccion_Restore();
        }

        private void button_restore_Click(object sender, EventArgs e)
        {
            Restore();
        }
        #endregion

        #region Idioma
        public void Agregar_Form_Idioma()
        {
            Gestion_Idioma_44MM.Instancia.Suscribir_Form(this);
        }

        public void Actualizar_Idioma(Dictionary<string, string> key_word)
        {
            this.Text = Gestion_Idioma_44MM.Instancia.Texto["SeleccioneRutaDelRestore"];
            label_backup.Text = Gestion_Idioma_44MM.Instancia.Texto["Respaldar"];
            label_restore.Text = Gestion_Idioma_44MM.Instancia.Texto["Restaurar"];
            button_backup.Text = Gestion_Idioma_44MM.Instancia.Texto["Respaldar"];
            button_restore.Text = Gestion_Idioma_44MM.Instancia.Texto["Restaurar"];
        }
        #endregion
    }
}