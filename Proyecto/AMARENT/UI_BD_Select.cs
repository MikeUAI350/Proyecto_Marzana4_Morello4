using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
using System.Diagnostics;

namespace AMARENT
{
    public partial class UI_BD_Select : Form
    {
        public UI_BD_Select()
        {
            InitializeComponent();
        }

        private void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                DialogResult resultado = MessageBox.Show($"Seguro que este es nombre del Servidor?\n\r{textBox.Text}", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado == DialogResult.Yes)
                {
                    FileStream fs = new FileStream("Content\\Data\\DataBase", FileMode.Create, FileAccess.Write);
                    StreamWriter sw = new StreamWriter(fs);
                    sw.Write(textBox.Text);
                    sw.Dispose();
                    sw.Close();
                    fs.Dispose();
                    fs.Close();
                    this.Close();
                    Application.Restart();
                }
            }
        }
    }
}
