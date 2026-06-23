using BE;
using BLL;
using Servicios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AMARENT
{
    public partial class UI_Gestion_44MM : Form, I_Idioma
    {
        private BLL_Usuario_44MM bll_usuario = new BLL_Usuario_44MM();
        private List<BE_Perfil_44MM> lista_perfiles;
        private string finalidad;
        private BE_Usuario_44MM informacion;
        private UI_Gestion_Usuarios_44MM ui;
        public UI_Gestion_44MM(string fin, BE_Usuario_44MM be, UI_Gestion_Usuarios_44MM form)
        {
            InitializeComponent();
            finalidad = fin;
            informacion = be;
            ui = form;
            ui.Visible = false;
            Definir_Objetivo(be);
            Agregar_Form_Idioma();
        }

        private void Definir_Objetivo(BE_Usuario_44MM be)
        {
            lista_perfiles = bll_usuario.Recuperar_Perfiles();
            foreach (BE_Perfil_44MM item in lista_perfiles)
            {
                comboBox_rol.Items.Add(item.Cod_Perfil);
            }
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

                        button_anular.Enabled = false;

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

                        textBox_email.Text = be.Email;
                        comboBox_rol.Text = be.Rol;
                        textBox_login.Text = be.Login;

                        break;
                    }
                default:
                    {
                        MessageBox.Show(Gestion_Idioma_44MM.Instancia.Texto["ErrorAlCargarLaInterfaz"], "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Close();
                        break;
                    }
            }
        }

        private void Nombre_Perfil(string cod)
        {
            BE_Perfil_44MM perfil = lista_perfiles.FirstOrDefault(x => x.Cod_Perfil == cod);
            if (perfil != null)
            {
                textBox_perfil.Text = perfil.Nombre;
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
            int exito = 0;

            switch (finalidad)
            {
                case "Crear":
                    {
                        Match ER_dni = Regex.Match( dni, "^[0-9]{1,10}$");
                        Match ER_nombre = Regex.Match(nombre, "^[A-Z][a-zA-Z]{0,49}$");
                        Match ER_apellido = Regex.Match(apellido, "^[A-Z][a-zA-Z]{0,49}$");
                        Match ER_email = Regex.Match(email, "^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,49}$");
                        if (ER_dni.Success != true || ER_nombre.Success != true || ER_apellido.Success != true || ER_email.Success != true)
                        {
                            mensaje = Gestion_Idioma_44MM.Instancia.Texto["FormatoInvalido"];
                            //if (ER_dni.Success != true)
                            //{
                            //    mensaje += $"\n\r{Gestion_Idioma_44MM.Instancia.Texto[""]}";
                            //}
                            //if (ER_nombre.Success != true)
                            //{
                            //    mensaje += $"\n\r{Gestion_Idioma_44MM.Instancia.Texto[""]}";
                            //}
                            //if (ER_apellido.Success != true)
                            //{
                            //    mensaje += $"\n\r{Gestion_Idioma_44MM.Instancia.Texto[""]}";
                            //}
                            //if (ER_email.Success != true)
                            //{
                            //    mensaje += $"\n\r{Gestion_Idioma_44MM.Instancia.Texto[""]}";
                            //}
                        }
                        else
                        {
                            (exito, mensaje) = bll_usuario.Crear_Usuario(dni, nombre, apellido, email, rol);
                        }
                        break;
                    }
                case "Modificar":
                    {
                        Match ER_email = Regex.Match(email, "^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,49}$");
                        if (ER_email.Success == true)
                        {
                            (exito, mensaje) = bll_usuario.Modificar_Usuario(login, email, rol);
                        }
                        else
                        {
                            mensaje = Gestion_Idioma_44MM.Instancia.Texto[""];
                        }
                        break;
                    }
                default:
                    {
                        MessageBox.Show(Gestion_Idioma_44MM.Instancia.Texto["ErrorAlCargarLaInterfaz"], "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Close();
                        break;
                    }
            }
            if (exito == 0)
            {
                MessageBox.Show(Gestion_Idioma_44MM.Instancia.Texto[mensaje], "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (exito == 1)
            {
                MessageBox.Show(Gestion_Idioma_44MM.Instancia.Texto[mensaje]);
                this.Close();
            }
            else
            {
                MessageBox.Show(mensaje, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Anular()
        {
            textBox_dni.Text = informacion.DNI;
            textBox_nombre.Text = informacion.Nombre;
            textBox_apellido.Text = informacion.Apellido;
            textBox_email.Text = informacion.Email;
            comboBox_rol.Text = informacion.Rol;
            textBox_login.Text = informacion.Login;
        }

        #region Botones
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

        private void comboBox_rol_SelectedIndexChanged(object sender, EventArgs e)
        {
            Nombre_Perfil(comboBox_rol.Text);
        }

        private void UI_Gestion_44MM_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.MdiParent.Controls["menuStrip"].Enabled = true;
            ui.Visible = true;
            ui.Actualizar_Grillas();
        }
        #endregion

        #region Idioma
        public void Agregar_Form_Idioma()
        {
            Gestion_Idioma_44MM.Instancia.Suscribir_Form(this);
        }

        public void Actualizar_Idioma(Dictionary<string, string> key_word)
        {
            this.Text = key_word["Gestion"];

            label_dni.Text = key_word["DNI"];
            label_nombre.Text = key_word["Nombre"];
            label_apellido.Text = key_word["Apellido"];
            label_email.Text = key_word["Email"];
            label_rol.Text = key_word["Rol"];
            label_login.Text = key_word["Usuario"];

            button_confirmar.Text = key_word["Confirmar"];
            button_anular.Text = key_word["Anular"];
            button_salir.Text = key_word["Salir"];
        }
        #endregion
    }
}