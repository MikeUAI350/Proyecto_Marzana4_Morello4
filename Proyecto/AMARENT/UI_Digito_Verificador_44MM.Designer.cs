namespace Digito_Verificador_IS
{
    partial class UI_Digito_Verificador_44MM
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.button_salir = new System.Windows.Forms.Button();
            this.button_recalcular = new System.Windows.Forms.Button();
            this.button_restock = new System.Windows.Forms.Button();
            this.button_mostrar_errores = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_salir
            // 
            this.button_salir.AutoSize = true;
            this.button_salir.Location = new System.Drawing.Point(12, 115);
            this.button_salir.Name = "button_salir";
            this.button_salir.Size = new System.Drawing.Size(158, 26);
            this.button_salir.TabIndex = 0;
            this.button_salir.Text = "Salir";
            this.button_salir.UseVisualStyleBackColor = true;
            this.button_salir.Click += new System.EventHandler(this.button_salir_Click);
            // 
            // button_recalcular
            // 
            this.button_recalcular.AutoSize = true;
            this.button_recalcular.Location = new System.Drawing.Point(12, 83);
            this.button_recalcular.Name = "button_recalcular";
            this.button_recalcular.Size = new System.Drawing.Size(158, 26);
            this.button_recalcular.TabIndex = 1;
            this.button_recalcular.Text = "Recalcular";
            this.button_recalcular.UseVisualStyleBackColor = true;
            this.button_recalcular.Click += new System.EventHandler(this.button_recalcular_Click);
            // 
            // button_restock
            // 
            this.button_restock.AutoSize = true;
            this.button_restock.Location = new System.Drawing.Point(12, 51);
            this.button_restock.Name = "button_restock";
            this.button_restock.Size = new System.Drawing.Size(158, 26);
            this.button_restock.TabIndex = 2;
            this.button_restock.Text = "Restock";
            this.button_restock.UseVisualStyleBackColor = true;
            this.button_restock.Click += new System.EventHandler(this.button_restock_Click);
            // 
            // button_mostrar_errores
            // 
            this.button_mostrar_errores.AutoSize = true;
            this.button_mostrar_errores.Location = new System.Drawing.Point(12, 19);
            this.button_mostrar_errores.Name = "button_mostrar_errores";
            this.button_mostrar_errores.Size = new System.Drawing.Size(158, 26);
            this.button_mostrar_errores.TabIndex = 3;
            this.button_mostrar_errores.Text = "Mostrar Errores";
            this.button_mostrar_errores.UseVisualStyleBackColor = true;
            this.button_mostrar_errores.Click += new System.EventHandler(this.button_mostrar_errores_Click);
            // 
            // UI_Digito_Verificador_44MM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(182, 153);
            this.ControlBox = false;
            this.Controls.Add(this.button_mostrar_errores);
            this.Controls.Add(this.button_restock);
            this.Controls.Add(this.button_recalcular);
            this.Controls.Add(this.button_salir);
            this.Name = "UI_Digito_Verificador_44MM";
            this.Text = "Inconsistencia en la Base de Datos";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_salir;
        private System.Windows.Forms.Button button_recalcular;
        private System.Windows.Forms.Button button_restock;
        private System.Windows.Forms.Button button_mostrar_errores;
    }
}

