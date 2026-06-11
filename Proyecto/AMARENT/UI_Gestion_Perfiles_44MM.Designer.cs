namespace AMARENT
{
    partial class UI_Gestion_Perfiles_44MM
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
            this.dataGridView_composicion = new System.Windows.Forms.DataGridView();
            this.dataGridView_lista = new System.Windows.Forms.DataGridView();
            this.button_quitar = new System.Windows.Forms.Button();
            this.button_crear = new System.Windows.Forms.Button();
            this.button_agregar = new System.Windows.Forms.Button();
            this.button_actualizar = new System.Windows.Forms.Button();
            this.radioButton_perfil = new System.Windows.Forms.RadioButton();
            this.radioButton_familia = new System.Windows.Forms.RadioButton();
            this.textBox_codigo = new System.Windows.Forms.TextBox();
            this.label_composicion = new System.Windows.Forms.Label();
            this.label_lista = new System.Windows.Forms.Label();
            this.button_limpiar = new System.Windows.Forms.Button();
            this.treeView_arbol = new System.Windows.Forms.TreeView();
            this.textBox_nombre = new System.Windows.Forms.TextBox();
            this.label_codigo = new System.Windows.Forms.Label();
            this.label_nombre = new System.Windows.Forms.Label();
            this.button_eliminar = new System.Windows.Forms.Button();
            this.button_modificar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_composicion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_lista)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_composicion
            // 
            this.dataGridView_composicion.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_composicion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_composicion.Location = new System.Drawing.Point(12, 28);
            this.dataGridView_composicion.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView_composicion.Name = "dataGridView_composicion";
            this.dataGridView_composicion.ReadOnly = true;
            this.dataGridView_composicion.RowHeadersVisible = false;
            this.dataGridView_composicion.RowHeadersWidth = 51;
            this.dataGridView_composicion.RowTemplate.Height = 24;
            this.dataGridView_composicion.Size = new System.Drawing.Size(240, 410);
            this.dataGridView_composicion.TabIndex = 0;
            this.dataGridView_composicion.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_composicion_CellClick);
            // 
            // dataGridView_lista
            // 
            this.dataGridView_lista.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_lista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_lista.Location = new System.Drawing.Point(548, 28);
            this.dataGridView_lista.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView_lista.Name = "dataGridView_lista";
            this.dataGridView_lista.ReadOnly = true;
            this.dataGridView_lista.RowHeadersVisible = false;
            this.dataGridView_lista.RowHeadersWidth = 51;
            this.dataGridView_lista.RowTemplate.Height = 24;
            this.dataGridView_lista.Size = new System.Drawing.Size(240, 410);
            this.dataGridView_lista.TabIndex = 1;
            this.dataGridView_lista.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_lista_CellClick);
            // 
            // button_quitar
            // 
            this.button_quitar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_quitar.AutoSize = true;
            this.button_quitar.Location = new System.Drawing.Point(259, 378);
            this.button_quitar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_quitar.Name = "button_quitar";
            this.button_quitar.Size = new System.Drawing.Size(75, 28);
            this.button_quitar.TabIndex = 2;
            this.button_quitar.Text = "Quitar";
            this.button_quitar.UseVisualStyleBackColor = true;
            this.button_quitar.Click += new System.EventHandler(this.button_quitar_Click);
            // 
            // button_crear
            // 
            this.button_crear.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button_crear.AutoSize = true;
            this.button_crear.Location = new System.Drawing.Point(365, 348);
            this.button_crear.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_crear.Name = "button_crear";
            this.button_crear.Size = new System.Drawing.Size(75, 28);
            this.button_crear.TabIndex = 3;
            this.button_crear.Text = "Crear";
            this.button_crear.UseVisualStyleBackColor = true;
            this.button_crear.Click += new System.EventHandler(this.button_crear_Click);
            // 
            // button_agregar
            // 
            this.button_agregar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_agregar.AutoSize = true;
            this.button_agregar.Location = new System.Drawing.Point(467, 378);
            this.button_agregar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_agregar.Name = "button_agregar";
            this.button_agregar.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.button_agregar.Size = new System.Drawing.Size(75, 28);
            this.button_agregar.TabIndex = 4;
            this.button_agregar.Text = "Agregar";
            this.button_agregar.UseVisualStyleBackColor = true;
            this.button_agregar.Click += new System.EventHandler(this.button_agregar_Click);
            // 
            // button_actualizar
            // 
            this.button_actualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_actualizar.AutoSize = true;
            this.button_actualizar.Location = new System.Drawing.Point(457, 410);
            this.button_actualizar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_actualizar.Name = "button_actualizar";
            this.button_actualizar.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.button_actualizar.Size = new System.Drawing.Size(84, 28);
            this.button_actualizar.TabIndex = 5;
            this.button_actualizar.Text = "Actualizar";
            this.button_actualizar.UseVisualStyleBackColor = true;
            this.button_actualizar.Click += new System.EventHandler(this.button_actualizar_Click);
            // 
            // radioButton_perfil
            // 
            this.radioButton_perfil.AutoSize = true;
            this.radioButton_perfil.Checked = true;
            this.radioButton_perfil.Location = new System.Drawing.Point(259, 28);
            this.radioButton_perfil.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioButton_perfil.Name = "radioButton_perfil";
            this.radioButton_perfil.Size = new System.Drawing.Size(94, 20);
            this.radioButton_perfil.TabIndex = 6;
            this.radioButton_perfil.TabStop = true;
            this.radioButton_perfil.Text = "Crear Perfil";
            this.radioButton_perfil.UseVisualStyleBackColor = true;
            // 
            // radioButton_familia
            // 
            this.radioButton_familia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radioButton_familia.AutoSize = true;
            this.radioButton_familia.Location = new System.Drawing.Point(434, 28);
            this.radioButton_familia.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioButton_familia.Name = "radioButton_familia";
            this.radioButton_familia.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.radioButton_familia.Size = new System.Drawing.Size(108, 20);
            this.radioButton_familia.TabIndex = 7;
            this.radioButton_familia.Text = "Crear Familia";
            this.radioButton_familia.UseVisualStyleBackColor = true;
            // 
            // textBox_codigo
            // 
            this.textBox_codigo.Location = new System.Drawing.Point(259, 352);
            this.textBox_codigo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_codigo.Name = "textBox_codigo";
            this.textBox_codigo.Size = new System.Drawing.Size(100, 22);
            this.textBox_codigo.TabIndex = 8;
            // 
            // label_composicion
            // 
            this.label_composicion.AutoSize = true;
            this.label_composicion.Location = new System.Drawing.Point(12, 9);
            this.label_composicion.Name = "label_composicion";
            this.label_composicion.Size = new System.Drawing.Size(184, 16);
            this.label_composicion.TabIndex = 9;
            this.label_composicion.Text = "Familas y Permisos a Otorgar";
            // 
            // label_lista
            // 
            this.label_lista.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_lista.AutoSize = true;
            this.label_lista.Location = new System.Drawing.Point(585, 9);
            this.label_lista.Name = "label_lista";
            this.label_lista.Size = new System.Drawing.Size(203, 16);
            this.label_lista.TabIndex = 10;
            this.label_lista.Text = "Familias y Permisos Disponibles";
            this.label_lista.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // button_limpiar
            // 
            this.button_limpiar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_limpiar.AutoSize = true;
            this.button_limpiar.Location = new System.Drawing.Point(259, 410);
            this.button_limpiar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_limpiar.Name = "button_limpiar";
            this.button_limpiar.Size = new System.Drawing.Size(75, 28);
            this.button_limpiar.TabIndex = 11;
            this.button_limpiar.Text = "Limpiar";
            this.button_limpiar.UseVisualStyleBackColor = true;
            this.button_limpiar.Click += new System.EventHandler(this.button_limpiar_Click);
            // 
            // treeView_arbol
            // 
            this.treeView_arbol.Location = new System.Drawing.Point(259, 54);
            this.treeView_arbol.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.treeView_arbol.Name = "treeView_arbol";
            this.treeView_arbol.Size = new System.Drawing.Size(284, 276);
            this.treeView_arbol.TabIndex = 12;
            this.treeView_arbol.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_arbol_AfterSelect);
            // 
            // textBox_nombre
            // 
            this.textBox_nombre.Location = new System.Drawing.Point(443, 352);
            this.textBox_nombre.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_nombre.Name = "textBox_nombre";
            this.textBox_nombre.Size = new System.Drawing.Size(100, 22);
            this.textBox_nombre.TabIndex = 13;
            // 
            // label_codigo
            // 
            this.label_codigo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label_codigo.AutoSize = true;
            this.label_codigo.Location = new System.Drawing.Point(259, 334);
            this.label_codigo.Name = "label_codigo";
            this.label_codigo.Size = new System.Drawing.Size(51, 16);
            this.label_codigo.TabIndex = 14;
            this.label_codigo.Text = "Codigo";
            // 
            // label_nombre
            // 
            this.label_nombre.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label_nombre.AutoSize = true;
            this.label_nombre.Location = new System.Drawing.Point(485, 334);
            this.label_nombre.Name = "label_nombre";
            this.label_nombre.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label_nombre.Size = new System.Drawing.Size(56, 16);
            this.label_nombre.TabIndex = 15;
            this.label_nombre.Text = "Nombre";
            // 
            // button_eliminar
            // 
            this.button_eliminar.Location = new System.Drawing.Point(363, 415);
            this.button_eliminar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_eliminar.Name = "button_eliminar";
            this.button_eliminar.Size = new System.Drawing.Size(75, 23);
            this.button_eliminar.TabIndex = 16;
            this.button_eliminar.Text = "Eliminar";
            this.button_eliminar.UseVisualStyleBackColor = true;
            this.button_eliminar.Click += new System.EventHandler(this.button_eliminar_Click);
            // 
            // button_modificar
            // 
            this.button_modificar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button_modificar.AutoSize = true;
            this.button_modificar.Location = new System.Drawing.Point(361, 382);
            this.button_modificar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_modificar.Name = "button_modificar";
            this.button_modificar.Size = new System.Drawing.Size(80, 28);
            this.button_modificar.TabIndex = 17;
            this.button_modificar.Text = "Modificar";
            this.button_modificar.UseVisualStyleBackColor = true;
            this.button_modificar.Click += new System.EventHandler(this.button_modificar_Click);
            // 
            // UI_Gestion_Perfiles_44MM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ControlBox = false;
            this.Controls.Add(this.button_modificar);
            this.Controls.Add(this.button_eliminar);
            this.Controls.Add(this.label_nombre);
            this.Controls.Add(this.label_codigo);
            this.Controls.Add(this.textBox_nombre);
            this.Controls.Add(this.treeView_arbol);
            this.Controls.Add(this.button_limpiar);
            this.Controls.Add(this.label_lista);
            this.Controls.Add(this.label_composicion);
            this.Controls.Add(this.textBox_codigo);
            this.Controls.Add(this.radioButton_familia);
            this.Controls.Add(this.radioButton_perfil);
            this.Controls.Add(this.button_actualizar);
            this.Controls.Add(this.button_agregar);
            this.Controls.Add(this.button_crear);
            this.Controls.Add(this.button_quitar);
            this.Controls.Add(this.dataGridView_lista);
            this.Controls.Add(this.dataGridView_composicion);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "UI_Gestion_Perfiles_44MM";
            this.Text = "UI_Gestion_Perfiles_44MM";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_composicion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_lista)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_composicion;
        private System.Windows.Forms.DataGridView dataGridView_lista;
        private System.Windows.Forms.Button button_quitar;
        private System.Windows.Forms.Button button_crear;
        private System.Windows.Forms.Button button_agregar;
        private System.Windows.Forms.Button button_actualizar;
        private System.Windows.Forms.RadioButton radioButton_perfil;
        private System.Windows.Forms.RadioButton radioButton_familia;
        private System.Windows.Forms.TextBox textBox_codigo;
        private System.Windows.Forms.Label label_composicion;
        private System.Windows.Forms.Label label_lista;
        private System.Windows.Forms.Button button_limpiar;
        private System.Windows.Forms.TreeView treeView_arbol;
        private System.Windows.Forms.TextBox textBox_nombre;
        private System.Windows.Forms.Label label_codigo;
        private System.Windows.Forms.Label label_nombre;
        private System.Windows.Forms.Button button_eliminar;
        private System.Windows.Forms.Button button_modificar;
    }
}