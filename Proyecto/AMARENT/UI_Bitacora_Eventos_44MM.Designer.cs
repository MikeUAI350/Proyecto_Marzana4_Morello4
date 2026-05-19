namespace AMARENT
{
    partial class UI_Bitacora_Eventos_44MM
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView_lista = new System.Windows.Forms.DataGridView();
            this.textBox_modulo = new System.Windows.Forms.TextBox();
            this.dateTimePicker_fecha_final = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_fecha_inicial = new System.Windows.Forms.DateTimePicker();
            this.textBox_login = new System.Windows.Forms.TextBox();
            this.textBox_evento = new System.Windows.Forms.TextBox();
            this.numericUpDown_criticidad = new System.Windows.Forms.NumericUpDown();
            this.groupBox_filtro = new System.Windows.Forms.GroupBox();
            this.checkBox_usar_fechas = new System.Windows.Forms.CheckBox();
            this.label_criticidad = new System.Windows.Forms.Label();
            this.label_fecha_final = new System.Windows.Forms.Label();
            this.label_fecha_inicial = new System.Windows.Forms.Label();
            this.label_evento = new System.Windows.Forms.Label();
            this.label_modulo = new System.Windows.Forms.Label();
            this.label_login = new System.Windows.Forms.Label();
            this.button_imprimir = new System.Windows.Forms.Button();
            this.button_aplicar = new System.Windows.Forms.Button();
            this.button_limpiar = new System.Windows.Forms.Button();
            this.saveFileDialog_tabla_bitacora = new System.Windows.Forms.SaveFileDialog();
            this.textBox_apellido = new System.Windows.Forms.TextBox();
            this.textBox_nombre = new System.Windows.Forms.TextBox();
            this.label_apellido = new System.Windows.Forms.Label();
            this.label_nombre = new System.Windows.Forms.Label();
            this.button_actualizar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_lista)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_criticidad)).BeginInit();
            this.groupBox_filtro.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView_lista
            // 
            this.dataGridView_lista.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_lista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_lista.Dock = System.Windows.Forms.DockStyle.Right;
            this.dataGridView_lista.Location = new System.Drawing.Point(230, 0);
            this.dataGridView_lista.Name = "dataGridView_lista";
            this.dataGridView_lista.RowHeadersVisible = false;
            this.dataGridView_lista.RowHeadersWidth = 51;
            this.dataGridView_lista.RowTemplate.Height = 24;
            this.dataGridView_lista.Size = new System.Drawing.Size(570, 450);
            this.dataGridView_lista.TabIndex = 0;
            this.dataGridView_lista.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_lista_CellClick);
            // 
            // textBox_modulo
            // 
            this.textBox_modulo.Location = new System.Drawing.Point(6, 81);
            this.textBox_modulo.Name = "textBox_modulo";
            this.textBox_modulo.Size = new System.Drawing.Size(200, 22);
            this.textBox_modulo.TabIndex = 1;
            // 
            // dateTimePicker_fecha_final
            // 
            this.dateTimePicker_fecha_final.Location = new System.Drawing.Point(6, 213);
            this.dateTimePicker_fecha_final.Name = "dateTimePicker_fecha_final";
            this.dateTimePicker_fecha_final.Size = new System.Drawing.Size(200, 22);
            this.dateTimePicker_fecha_final.TabIndex = 2;
            // 
            // dateTimePicker_fecha_inicial
            // 
            this.dateTimePicker_fecha_inicial.Location = new System.Drawing.Point(6, 169);
            this.dateTimePicker_fecha_inicial.Name = "dateTimePicker_fecha_inicial";
            this.dateTimePicker_fecha_inicial.Size = new System.Drawing.Size(200, 22);
            this.dateTimePicker_fecha_inicial.TabIndex = 3;
            // 
            // textBox_login
            // 
            this.textBox_login.Location = new System.Drawing.Point(6, 37);
            this.textBox_login.Name = "textBox_login";
            this.textBox_login.Size = new System.Drawing.Size(200, 22);
            this.textBox_login.TabIndex = 4;
            // 
            // textBox_evento
            // 
            this.textBox_evento.Location = new System.Drawing.Point(6, 125);
            this.textBox_evento.Name = "textBox_evento";
            this.textBox_evento.Size = new System.Drawing.Size(200, 22);
            this.textBox_evento.TabIndex = 5;
            // 
            // numericUpDown_criticidad
            // 
            this.numericUpDown_criticidad.Location = new System.Drawing.Point(6, 283);
            this.numericUpDown_criticidad.Name = "numericUpDown_criticidad";
            this.numericUpDown_criticidad.Size = new System.Drawing.Size(200, 22);
            this.numericUpDown_criticidad.TabIndex = 6;
            // 
            // groupBox_filtro
            // 
            this.groupBox_filtro.AutoSize = true;
            this.groupBox_filtro.Controls.Add(this.checkBox_usar_fechas);
            this.groupBox_filtro.Controls.Add(this.label_criticidad);
            this.groupBox_filtro.Controls.Add(this.numericUpDown_criticidad);
            this.groupBox_filtro.Controls.Add(this.label_fecha_final);
            this.groupBox_filtro.Controls.Add(this.label_fecha_inicial);
            this.groupBox_filtro.Controls.Add(this.dateTimePicker_fecha_final);
            this.groupBox_filtro.Controls.Add(this.label_evento);
            this.groupBox_filtro.Controls.Add(this.dateTimePicker_fecha_inicial);
            this.groupBox_filtro.Controls.Add(this.label_modulo);
            this.groupBox_filtro.Controls.Add(this.textBox_evento);
            this.groupBox_filtro.Controls.Add(this.label_login);
            this.groupBox_filtro.Controls.Add(this.textBox_login);
            this.groupBox_filtro.Controls.Add(this.textBox_modulo);
            this.groupBox_filtro.Location = new System.Drawing.Point(12, 1);
            this.groupBox_filtro.Name = "groupBox_filtro";
            this.groupBox_filtro.Size = new System.Drawing.Size(212, 326);
            this.groupBox_filtro.TabIndex = 7;
            this.groupBox_filtro.TabStop = false;
            this.groupBox_filtro.Text = "Filtros";
            // 
            // checkBox_usar_fechas
            // 
            this.checkBox_usar_fechas.AutoSize = true;
            this.checkBox_usar_fechas.Location = new System.Drawing.Point(6, 241);
            this.checkBox_usar_fechas.Name = "checkBox_usar_fechas";
            this.checkBox_usar_fechas.Size = new System.Drawing.Size(110, 20);
            this.checkBox_usar_fechas.TabIndex = 10;
            this.checkBox_usar_fechas.Text = "Usar_Fechas";
            this.checkBox_usar_fechas.UseVisualStyleBackColor = true;
            // 
            // label_criticidad
            // 
            this.label_criticidad.AutoSize = true;
            this.label_criticidad.Location = new System.Drawing.Point(6, 264);
            this.label_criticidad.Name = "label_criticidad";
            this.label_criticidad.Size = new System.Drawing.Size(63, 16);
            this.label_criticidad.TabIndex = 9;
            this.label_criticidad.Text = "Criticidad";
            // 
            // label_fecha_final
            // 
            this.label_fecha_final.AutoSize = true;
            this.label_fecha_final.Location = new System.Drawing.Point(6, 194);
            this.label_fecha_final.Name = "label_fecha_final";
            this.label_fecha_final.Size = new System.Drawing.Size(77, 16);
            this.label_fecha_final.TabIndex = 8;
            this.label_fecha_final.Text = "Fecha Final";
            // 
            // label_fecha_inicial
            // 
            this.label_fecha_inicial.AutoSize = true;
            this.label_fecha_inicial.Location = new System.Drawing.Point(6, 150);
            this.label_fecha_inicial.Name = "label_fecha_inicial";
            this.label_fecha_inicial.Size = new System.Drawing.Size(86, 16);
            this.label_fecha_inicial.TabIndex = 7;
            this.label_fecha_inicial.Text = "Fecha_Inicial";
            // 
            // label_evento
            // 
            this.label_evento.AutoSize = true;
            this.label_evento.Location = new System.Drawing.Point(6, 106);
            this.label_evento.Name = "label_evento";
            this.label_evento.Size = new System.Drawing.Size(49, 16);
            this.label_evento.TabIndex = 6;
            this.label_evento.Text = "Evento";
            // 
            // label_modulo
            // 
            this.label_modulo.AutoSize = true;
            this.label_modulo.Location = new System.Drawing.Point(6, 62);
            this.label_modulo.Name = "label_modulo";
            this.label_modulo.Size = new System.Drawing.Size(52, 16);
            this.label_modulo.TabIndex = 5;
            this.label_modulo.Text = "Modulo";
            // 
            // label_login
            // 
            this.label_login.AutoSize = true;
            this.label_login.Location = new System.Drawing.Point(6, 18);
            this.label_login.Name = "label_login";
            this.label_login.Size = new System.Drawing.Size(40, 16);
            this.label_login.TabIndex = 0;
            this.label_login.Text = "Login";
            // 
            // button_imprimir
            // 
            this.button_imprimir.Location = new System.Drawing.Point(12, 391);
            this.button_imprimir.Name = "button_imprimir";
            this.button_imprimir.Size = new System.Drawing.Size(75, 23);
            this.button_imprimir.TabIndex = 10;
            this.button_imprimir.Text = "Imprimir";
            this.button_imprimir.UseVisualStyleBackColor = true;
            this.button_imprimir.Click += new System.EventHandler(this.button_imprimir_Click);
            // 
            // button_aplicar
            // 
            this.button_aplicar.Location = new System.Drawing.Point(12, 362);
            this.button_aplicar.Name = "button_aplicar";
            this.button_aplicar.Size = new System.Drawing.Size(75, 23);
            this.button_aplicar.TabIndex = 11;
            this.button_aplicar.Text = "Aplicar";
            this.button_aplicar.UseVisualStyleBackColor = true;
            this.button_aplicar.Click += new System.EventHandler(this.button_aplicar_Click);
            // 
            // button_limpiar
            // 
            this.button_limpiar.Location = new System.Drawing.Point(12, 333);
            this.button_limpiar.Name = "button_limpiar";
            this.button_limpiar.Size = new System.Drawing.Size(75, 23);
            this.button_limpiar.TabIndex = 12;
            this.button_limpiar.Text = "Limpiar";
            this.button_limpiar.UseVisualStyleBackColor = true;
            this.button_limpiar.Click += new System.EventHandler(this.button_limpiar_Click);
            // 
            // saveFileDialog_tabla_bitacora
            // 
            this.saveFileDialog_tabla_bitacora.DefaultExt = "pdf";
            this.saveFileDialog_tabla_bitacora.RestoreDirectory = true;
            // 
            // textBox_apellido
            // 
            this.textBox_apellido.Location = new System.Drawing.Point(105, 416);
            this.textBox_apellido.Name = "textBox_apellido";
            this.textBox_apellido.ReadOnly = true;
            this.textBox_apellido.Size = new System.Drawing.Size(100, 22);
            this.textBox_apellido.TabIndex = 15;
            // 
            // textBox_nombre
            // 
            this.textBox_nombre.Location = new System.Drawing.Point(105, 372);
            this.textBox_nombre.Name = "textBox_nombre";
            this.textBox_nombre.ReadOnly = true;
            this.textBox_nombre.Size = new System.Drawing.Size(100, 22);
            this.textBox_nombre.TabIndex = 16;
            // 
            // label_apellido
            // 
            this.label_apellido.AutoSize = true;
            this.label_apellido.Location = new System.Drawing.Point(105, 397);
            this.label_apellido.Name = "label_apellido";
            this.label_apellido.Size = new System.Drawing.Size(57, 16);
            this.label_apellido.TabIndex = 17;
            this.label_apellido.Text = "Apellido";
            // 
            // label_nombre
            // 
            this.label_nombre.AutoSize = true;
            this.label_nombre.Location = new System.Drawing.Point(105, 353);
            this.label_nombre.Name = "label_nombre";
            this.label_nombre.Size = new System.Drawing.Size(56, 16);
            this.label_nombre.TabIndex = 18;
            this.label_nombre.Text = "Nombre";
            // 
            // button_actualizar
            // 
            this.button_actualizar.Location = new System.Drawing.Point(12, 420);
            this.button_actualizar.Name = "button_actualizar";
            this.button_actualizar.Size = new System.Drawing.Size(75, 23);
            this.button_actualizar.TabIndex = 19;
            this.button_actualizar.Text = "Actualizar";
            this.button_actualizar.UseVisualStyleBackColor = true;
            this.button_actualizar.Click += new System.EventHandler(this.button_actualizar_Click);
            // 
            // UI_Bitacora_Eventos_44MM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ControlBox = false;
            this.Controls.Add(this.button_limpiar);
            this.Controls.Add(this.button_actualizar);
            this.Controls.Add(this.button_imprimir);
            this.Controls.Add(this.button_aplicar);
            this.Controls.Add(this.label_nombre);
            this.Controls.Add(this.label_apellido);
            this.Controls.Add(this.textBox_nombre);
            this.Controls.Add(this.textBox_apellido);
            this.Controls.Add(this.groupBox_filtro);
            this.Controls.Add(this.dataGridView_lista);
            this.Name = "UI_Bitacora_Eventos_44MM";
            this.Text = "UI_Gestion_Bitacora_44MM";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_lista)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_criticidad)).EndInit();
            this.groupBox_filtro.ResumeLayout(false);
            this.groupBox_filtro.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_lista;
        private System.Windows.Forms.TextBox textBox_modulo;
        private System.Windows.Forms.DateTimePicker dateTimePicker_fecha_final;
        private System.Windows.Forms.DateTimePicker dateTimePicker_fecha_inicial;
        private System.Windows.Forms.TextBox textBox_login;
        private System.Windows.Forms.TextBox textBox_evento;
        private System.Windows.Forms.NumericUpDown numericUpDown_criticidad;
        private System.Windows.Forms.GroupBox groupBox_filtro;
        private System.Windows.Forms.Label label_criticidad;
        private System.Windows.Forms.Label label_fecha_final;
        private System.Windows.Forms.Label label_fecha_inicial;
        private System.Windows.Forms.Label label_evento;
        private System.Windows.Forms.Label label_modulo;
        private System.Windows.Forms.Label label_login;
        private System.Windows.Forms.Button button_limpiar;
        private System.Windows.Forms.Button button_aplicar;
        private System.Windows.Forms.Button button_imprimir;
        private System.Windows.Forms.CheckBox checkBox_usar_fechas;
        private System.Windows.Forms.SaveFileDialog saveFileDialog_tabla_bitacora;
        private System.Windows.Forms.TextBox textBox_apellido;
        private System.Windows.Forms.TextBox textBox_nombre;
        private System.Windows.Forms.Label label_apellido;
        private System.Windows.Forms.Label label_nombre;
        private System.Windows.Forms.Button button_actualizar;
    }
}