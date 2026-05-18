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
    public partial class UI_Gestion_44MM : Form
    {
        private BLL_Usuario_44MM gestion_usuario = new BLL_Usuario_44MM();
        private string finalidad;
        private DataRow informacion;
        public UI_Gestion_44MM(string fin, DataRow row)
        {
            InitializeComponent();
            finalidad = fin;
            informacion = row;
            Definir_Objetivo(row);
        }

        private void Definir_Objetivo(DataRow row)
        {
            switch (finalidad)
            {
                case "Crear":
                    {
                        label_dni.Visible = true;
                        textBox_dni.Visible = true;
                        label_nombre.Visible = true;
                        textBox_nombre.Visible = true;
                        label_apellido.Visible = true;
                        textBox_apellido.Visible = true;
                        label_email.Visible = true;
                        textBox_email.Visible = true;
                        label_rol.Visible = true;
                        comboBox_rol.Visible = true;

                        label_dni.Enabled = true;
                        textBox_dni.Enabled = true;
                        label_nombre.Enabled = true;
                        textBox_nombre.Enabled = true;
                        label_apellido.Enabled = true;
                        textBox_apellido.Enabled = true;
                        label_email.Enabled = true;
                        textBox_email.Enabled = true;
                        label_rol.Enabled = true;
                        comboBox_rol.Enabled = true;

                        break;
                    }
                case "Modificar":
                    {
                        label_email.Visible = true;
                        textBox_email.Visible = true;
                        label_rol.Visible = true;
                        comboBox_rol.Visible = true;
                        label_login.Visible = true;
                        textBox_login.Visible = true;

                        label_email.Enabled = true;
                        textBox_email.Enabled = true;
                        label_rol.Enabled = true;
                        comboBox_rol.Enabled = true;
                        label_login.Enabled = true;
                        textBox_login.Enabled = true;

                        textBox_login.ReadOnly = true;

                        textBox_email.Text = (string)row["Email"];
                        comboBox_rol.Text = (string)row["Rol"];
                        textBox_login.Text = (string)row["Login"];

                        break;
                    }
                default:
                    {
                        MessageBox.Show("Error al cargar la interfaz", "Error de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Close();
                        break;
                    }
            }
        }

        private void Confirmacion()
        {
            string dni = textBox_dni.Text;
            string nombre = textBox_nombre.Text;
            string apellido = textBox_apellido.Text;
            string email = textBox_email.Text;
            string rol = comboBox_rol.Text;
            string login = textBox_login.Text;

            string mensaje = string.Empty;
            bool exito = false;

            switch (finalidad)
            {
                case "Crear":
                    {
                        (exito, mensaje) = gestion_usuario.Crear_Usuario(dni, nombre, apellido, email, rol);
                        break;
                    }
                case "Modificar":
                    {
                        (exito, mensaje) = gestion_usuario.Modificar_Usuario(login, email, rol);
                        break;
                    }
                default:
                    {
                        MessageBox.Show("Error al cargar la interfaz", "Error de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Close();
                        break;
                    }
            }
            if (exito == false)
            {
                MessageBox.Show(mensaje, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show(mensaje);
                this.Close();
            }
        }

        private void Anular()
        {
            textBox_dni.Text = (string)informacion["DNI"];
            textBox_nombre.Text = (string)informacion["Nombre"];
            textBox_apellido.Text = (string)informacion["Apellido"];
            textBox_email.Text = (string)informacion["Email"];
            comboBox_rol.Text = (string)informacion["Rol"];
            textBox_login.Text = (string)informacion["Login"];
        }

        private void button_confirmar_Click(object sender, EventArgs e)
        {
            Confirmacion();
        }

        private void button_anular_Click(object sender, EventArgs e)
        {
            Anular();
        }

        private void button_salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
