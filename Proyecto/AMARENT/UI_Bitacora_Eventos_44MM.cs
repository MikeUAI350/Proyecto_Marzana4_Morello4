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
    public partial class UI_Bitacora_Eventos_44MM : Form
    {
        private DataTable tabla_datos;
        private List<BE_Bitacora_44MM> lista_datos;
        private DataGridViewCell celda_actual;
        private BLL_Bitacora_44MM bll_bitacora = new BLL_Bitacora_44MM();

        public UI_Bitacora_Eventos_44MM()
        {
            InitializeComponent();
            Actualizar_Grillas();
        }

        private void Actualizar_Grillas()
        {
            (tabla_datos, lista_datos) = bll_bitacora.Gestionar_Bitacora();

            DateTime filtro = DateTime.Now.Subtract(TimeSpan.FromDays(3));
            DataTable tabla = DataTable_Filter_44MM.Filtrar_Entre_Fechas(tabla_datos, "Fecha", filtro, DateTime.Now);

            dataGridView_lista.DataSource = tabla;

            celda_actual = dataGridView_lista.Rows[0].Cells[0];
        }

        private DataRow Obtener_Seleccionado()
        {
            try
            {
                DataGridViewCell celda = dataGridView_lista.Rows[celda_actual.RowIndex].Cells["Cod_Operacion"];
                int cod_ope = (int)celda.Value;
                DataRow row = tabla_datos.Rows.Find(cod_ope);
                return row;
            }
            catch (Exception)
            {
                MessageBox.Show("Seleccione una Fila", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private void Filtrar_Contenido()
        {
            string login = textBox_login.Text;
            string modulo = comboBox_modulo.Text;
            string evento = textBox_evento.Text;
            DateTime fecha_inicial = dateTimePicker_fecha_inicial.Value;
            DateTime fecha_final = dateTimePicker_fecha_final.Value;
            bool usar_fechas = checkBox_usar_fechas.Checked;
            int criticidad = (int)numericUpDown_criticidad.Value;

            DataTable tabla = tabla_datos;

            //Verificacion de fechas
            if (fecha_inicial > fecha_final && usar_fechas == true || fecha_final > DateTime.Now && usar_fechas == true)
            {
                MessageBox.Show("Fechas Invalidas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                //Filtros
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

                //Filtro para fechas
                if (usar_fechas == true)
                {
                    tabla = DataTable_Filter_44MM.Filtrar_Entre_Fechas(tabla, "Fecha", fecha_inicial, fecha_final);
                }
                else
                {
                    tabla = DataTable_Filter_44MM.Filtrar_Entre_Fechas(tabla, "Fecha", DateTime.Now.Subtract(TimeSpan.FromDays(3)), DateTime.Now);
                }

                //Error si esta vacio
                if (tabla.Rows.Count <= 0)
                {
                    MessageBox.Show("No se encontraron resultados con los filtros aplicados", "Sin Resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    dataGridView_lista.DataSource = tabla;
                }
            }
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
                    (bool exito, string mensaje) = bll_bitacora.Imprimir_Bitacora(tabla, ruta);
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

        private void Obtener_Login(DataRow fila)
        {
            DataRow fila_rec = bll_bitacora.Obtener_Login((string)fila["Login"]);

            textBox_nombre.Text = (string)fila_rec["Nombre"];
            textBox_apellido.Text = (string)fila_rec["Apellido"];
        }

        private void Limpiar_Filtros()
        {
            textBox_login.Text = "";
            comboBox_modulo.Text = "";
            textBox_evento.Text = "";
            dateTimePicker_fecha_inicial.Value = DateTime.Now;
            dateTimePicker_fecha_final.Value = DateTime.Now;
            checkBox_usar_fechas.Checked = false;
            numericUpDown_criticidad.Value = 1;
            textBox_nombre.Text = "";
            textBox_apellido.Text = "";

            Actualizar_Grillas();
            Filtrar_Contenido();
        }

        private void button_aplicar_Click(object sender, EventArgs e)
        {
            Filtrar_Contenido();
        }

        private void button_imprimir_Click(object sender, EventArgs e)
        {
            Imprimir_Contenido();
        }

        private void button_limpiar_Click(object sender, EventArgs e)
        {
            Limpiar_Filtros();
        }

        private void button_actualizar_Click(object sender, EventArgs e)
        {
            Actualizar_Grillas();
        }

        private void dataGridView_lista_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                celda_actual = dataGridView_lista.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (Obtener_Seleccionado() != null)
                {
                    Obtener_Login(Obtener_Seleccionado());
                }
            }
        }

        private void UI_Bitacora_Eventos_44MM_Load(object sender, EventArgs e)
        {
            Actualizar_Grillas();
        }

        private void UI_Bitacora_Eventos_44MM_Shown(object sender, EventArgs e)
        {
            Actualizar_Grillas();
        }
    }
}