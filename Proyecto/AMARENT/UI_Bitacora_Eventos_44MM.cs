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
    public partial class UI_Bitacora_Eventos_44MM : Form
    {
        private DataTable tabla_datos;
        private DataGridViewCell celda_actual;
        public UI_Bitacora_Eventos_44MM()
        {
            InitializeComponent();
            Iniciar_Grillas();
        }

        private void Iniciar_Grillas()
        {
            DataTable tabla_usuarios = Bitacora_44MM.Instancia.Gestionar_Bitacora();
            tabla_datos = tabla_usuarios;

            DateTime filtro = DateTime.Now.Subtract(TimeSpan.FromDays(3));
            DataTable tabla = DataTable_Filter_44MM.Filtrar_Entre_Fechas(tabla_usuarios, "Fecha", filtro, DateTime.Now);

            dataGridView_lista.DataSource = tabla;

            celda_actual = dataGridView_lista.Rows[0].Cells[0];
        }

        private void Filtrar_Contenido()
        {
            string login = textBox_login.Text;
            string modulo = textBox_modulo.Text;
            string evento = textBox_evento.Text;
            DateTime fecha_inicial = dateTimePicker_fecha_inicial.Value;
            DateTime fecha_final = dateTimePicker_fecha_final.Value;
            bool usar_fechas = checkBox_usar_fechas.Checked;
            int criticidad = (int)numericUpDown_criticidad.Value;

            DataTable tabla = tabla_datos;

            if (login != "" && login != null && login != string.Empty)
            {
                tabla = DataTable_Filter_44MM.Filtrar_Tabla(tabla_datos, "Login", login);
            }
            if (modulo != "" && modulo != null && modulo != string.Empty)
            {
                tabla = DataTable_Filter_44MM.Filtrar_Tabla(tabla, "Modulo", modulo);
            }
            if (evento != "" && evento != null && evento != string.Empty)
            {
                tabla = DataTable_Filter_44MM.Filtrar_Tabla(tabla, "Evento", evento);
            }
            if (criticidad > 0)
            {
                tabla = DataTable_Filter_44MM.Filtrar_Tabla(tabla, "Criticidad", criticidad.ToString());
            }
            if (usar_fechas == true)
            {
                tabla = DataTable_Filter_44MM.Filtrar_Entre_Fechas(tabla, "Fecha", fecha_inicial, fecha_final);
            }

            dataGridView_lista.DataSource = tabla;
        }

        private void Imprimir_Contenido()
        {
            DataTable tabla = (DataTable)dataGridView_lista.DataSource;
            DialogResult resultado = saveFileDialog_tabla_bitacora.ShowDialog();
            if (resultado == DialogResult.OK)
            {
                string ruta = saveFileDialog_tabla_bitacora.FileName;
                if (ruta != "" && ruta != null && ruta != string.Empty)
                {
                    (bool exito, string mensaje) = Bitacora_44MM.Instancia.Imprimir_Bitacora(tabla, ruta);
                    if (exito == true)
                    {
                        MessageBox.Show(mensaje);
                    }
                    else
                    {
                        MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void button_aplicar_Click(object sender, EventArgs e)
        {
            Filtrar_Contenido();
        }

        private void button_imprimir_Click(object sender, EventArgs e)
        {
            Imprimir_Contenido();
        }
    }
}
