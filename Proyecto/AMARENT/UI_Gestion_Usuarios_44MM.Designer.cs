namespace AMARENT
{
    partial class UI_Gestion_Usuarios_44MM
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
            this.label_lista = new System.Windows.Forms.Label();
            this.groupBox_controles = new System.Windows.Forms.GroupBox();
            this.button_actualizar = new System.Windows.Forms.Button();
            this.button_activar_desactivar = new System.Windows.Forms.Button();
            this.button_modificar = new System.Windows.Forms.Button();
            this.button_desbloquear = new System.Windows.Forms.Button();
            this.button_crear = new System.Windows.Forms.Button();
            this.radioButton_todos = new System.Windows.Forms.RadioButton();
            this.radioButton_activos = new System.Windows.Forms.RadioButton();
            this.radioButton_bloqueados = new System.Windows.Forms.RadioButton();
            this.radioButton_inactivos = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_lista)).BeginInit();
            this.groupBox_controles.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView_lista
            // 
            this.dataGridView_lista.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_lista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_lista.Location = new System.Drawing.Point(12, 28);
            this.dataGridView_lista.Name = "dataGridView_lista";
            this.dataGridView_lista.ReadOnly = true;
            this.dataGridView_lista.RowHeadersVisible = false;
            this.dataGridView_lista.RowHeadersWidth = 51;
            this.dataGridView_lista.RowTemplate.Height = 24;
            this.dataGridView_lista.Size = new System.Drawing.Size(674, 410);
            this.dataGridView_lista.TabIndex = 0;
            this.dataGridView_lista.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_lista_CellClick);
            // 
            // label_lista
            // 
            this.label_lista.AutoSize = true;
            this.label_lista.Location = new System.Drawing.Point(12, 9);
            this.label_lista.Name = "label_lista";
            this.label_lista.Size = new System.Drawing.Size(111, 16);
            this.label_lista.TabIndex = 1;
            this.label_lista.Text = "Lista de Usuarios";
            // 
            // groupBox_controles
            // 
            this.groupBox_controles.AutoSize = true;
            this.groupBox_controles.Controls.Add(this.button_actualizar);
            this.groupBox_controles.Controls.Add(this.button_activar_desactivar);
            this.groupBox_controles.Controls.Add(this.button_modificar);
            this.groupBox_controles.Controls.Add(this.button_desbloquear);
            this.groupBox_controles.Controls.Add(this.button_crear);
            this.groupBox_controles.Location = new System.Drawing.Point(692, 0);
            this.groupBox_controles.Name = "groupBox_controles";
            this.groupBox_controles.Size = new System.Drawing.Size(108, 453);
            this.groupBox_controles.TabIndex = 2;
            this.groupBox_controles.TabStop = false;
            this.groupBox_controles.Text = "Controles";
            // 
            // button_actualizar
            // 
            this.button_actualizar.AutoSize = true;
            this.button_actualizar.Location = new System.Drawing.Point(6, 406);
            this.button_actualizar.Name = "button_actualizar";
            this.button_actualizar.Size = new System.Drawing.Size(96, 26);
            this.button_actualizar.TabIndex = 6;
            this.button_actualizar.Text = "Actualizar";
            this.button_actualizar.UseVisualStyleBackColor = true;
            this.button_actualizar.Click += new System.EventHandler(this.button_actualizar_Click);
            // 
            // button_activar_desactivar
            // 
            this.button_activar_desactivar.AutoSize = true;
            this.button_activar_desactivar.Location = new System.Drawing.Point(6, 85);
            this.button_activar_desactivar.Name = "button_activar_desactivar";
            this.button_activar_desactivar.Size = new System.Drawing.Size(96, 26);
            this.button_activar_desactivar.TabIndex = 3;
            this.button_activar_desactivar.Text = "Act / Desact";
            this.button_activar_desactivar.UseVisualStyleBackColor = true;
            this.button_activar_desactivar.Click += new System.EventHandler(this.button_activar_desactivar_Click);
            // 
            // button_modificar
            // 
            this.button_modificar.AutoSize = true;
            this.button_modificar.Location = new System.Drawing.Point(6, 53);
            this.button_modificar.Name = "button_modificar";
            this.button_modificar.Size = new System.Drawing.Size(96, 26);
            this.button_modificar.TabIndex = 2;
            this.button_modificar.Text = "Modificar";
            this.button_modificar.UseVisualStyleBackColor = true;
            this.button_modificar.Click += new System.EventHandler(this.button_modificar_Click);
            // 
            // button_desbloquear
            // 
            this.button_desbloquear.AutoSize = true;
            this.button_desbloquear.Enabled = false;
            this.button_desbloquear.Location = new System.Drawing.Point(6, 117);
            this.button_desbloquear.Name = "button_desbloquear";
            this.button_desbloquear.Size = new System.Drawing.Size(96, 26);
            this.button_desbloquear.TabIndex = 1;
            this.button_desbloquear.Text = "Desbloquear";
            this.button_desbloquear.UseVisualStyleBackColor = true;
            this.button_desbloquear.Visible = false;
            this.button_desbloquear.Click += new System.EventHandler(this.button_desbloquear_Click);
            // 
            // button_crear
            // 
            this.button_crear.AutoSize = true;
            this.button_crear.Location = new System.Drawing.Point(6, 21);
            this.button_crear.Name = "button_crear";
            this.button_crear.Size = new System.Drawing.Size(96, 26);
            this.button_crear.TabIndex = 0;
            this.button_crear.Text = "Crear";
            this.button_crear.UseVisualStyleBackColor = true;
            this.button_crear.Click += new System.EventHandler(this.button_crear_Click);
            // 
            // radioButton_todos
            // 
            this.radioButton_todos.AutoSize = true;
            this.radioButton_todos.Checked = true;
            this.radioButton_todos.Location = new System.Drawing.Point(618, 5);
            this.radioButton_todos.Name = "radioButton_todos";
            this.radioButton_todos.Size = new System.Drawing.Size(68, 20);
            this.radioButton_todos.TabIndex = 3;
            this.radioButton_todos.TabStop = true;
            this.radioButton_todos.Text = "Todos";
            this.radioButton_todos.UseVisualStyleBackColor = true;
            this.radioButton_todos.CheckedChanged += new System.EventHandler(this.radioButton_todos_CheckedChanged);
            // 
            // radioButton_activos
            // 
            this.radioButton_activos.AutoSize = true;
            this.radioButton_activos.Location = new System.Drawing.Point(540, 5);
            this.radioButton_activos.Name = "radioButton_activos";
            this.radioButton_activos.Size = new System.Drawing.Size(72, 20);
            this.radioButton_activos.TabIndex = 4;
            this.radioButton_activos.Text = "Activos";
            this.radioButton_activos.UseVisualStyleBackColor = true;
            this.radioButton_activos.CheckedChanged += new System.EventHandler(this.radioButton_activos_CheckedChanged);
            // 
            // radioButton_bloqueados
            // 
            this.radioButton_bloqueados.AutoSize = true;
            this.radioButton_bloqueados.Location = new System.Drawing.Point(345, 5);
            this.radioButton_bloqueados.Name = "radioButton_bloqueados";
            this.radioButton_bloqueados.Size = new System.Drawing.Size(102, 20);
            this.radioButton_bloqueados.TabIndex = 5;
            this.radioButton_bloqueados.Text = "Bloqueados";
            this.radioButton_bloqueados.UseVisualStyleBackColor = true;
            this.radioButton_bloqueados.CheckedChanged += new System.EventHandler(this.radioButton_bloqueados_CheckedChanged);
            // 
            // radioButton_inactivos
            // 
            this.radioButton_inactivos.AutoSize = true;
            this.radioButton_inactivos.Location = new System.Drawing.Point(453, 5);
            this.radioButton_inactivos.Name = "radioButton_inactivos";
            this.radioButton_inactivos.Size = new System.Drawing.Size(81, 20);
            this.radioButton_inactivos.TabIndex = 6;
            this.radioButton_inactivos.Text = "Inactivos";
            this.radioButton_inactivos.UseVisualStyleBackColor = true;
            this.radioButton_inactivos.CheckedChanged += new System.EventHandler(this.radioButton_inactivos_CheckedChanged);
            // 
            // UI_Gestion_Usuarios_44MM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ControlBox = false;
            this.Controls.Add(this.radioButton_inactivos);
            this.Controls.Add(this.radioButton_bloqueados);
            this.Controls.Add(this.radioButton_activos);
            this.Controls.Add(this.radioButton_todos);
            this.Controls.Add(this.groupBox_controles);
            this.Controls.Add(this.label_lista);
            this.Controls.Add(this.dataGridView_lista);
            this.Name = "UI_Gestion_Usuarios_44MM";
            this.Text = "UI_Gestion_Usuarios";
            this.Load += new System.EventHandler(this.UI_Gestion_Usuarios_44MM_Load);
            this.Shown += new System.EventHandler(this.UI_Gestion_Usuarios_44MM_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_lista)).EndInit();
            this.groupBox_controles.ResumeLayout(false);
            this.groupBox_controles.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_lista;
        private System.Windows.Forms.Label label_lista;
        private System.Windows.Forms.GroupBox groupBox_controles;
        private System.Windows.Forms.Button button_crear;
        private System.Windows.Forms.Button button_activar_desactivar;
        private System.Windows.Forms.Button button_modificar;
        private System.Windows.Forms.Button button_desbloquear;
        private System.Windows.Forms.RadioButton radioButton_todos;
        private System.Windows.Forms.RadioButton radioButton_activos;
        private System.Windows.Forms.RadioButton radioButton_bloqueados;
        private System.Windows.Forms.Button button_actualizar;
        private System.Windows.Forms.RadioButton radioButton_inactivos;
    }
}