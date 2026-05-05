namespace AMARENT
{
    partial class UI_Cambiar_Clave_44MM
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
            this.textBox_contra = new System.Windows.Forms.TextBox();
            this.textBox_nueva_contra1 = new System.Windows.Forms.TextBox();
            this.textBox_nueva_contra2 = new System.Windows.Forms.TextBox();
            this.label_contra = new System.Windows.Forms.Label();
            this.label_nueva_contra1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button_confirmar = new System.Windows.Forms.Button();
            this.button_salir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox_contra
            // 
            this.textBox_contra.Location = new System.Drawing.Point(12, 28);
            this.textBox_contra.Name = "textBox_contra";
            this.textBox_contra.Size = new System.Drawing.Size(100, 22);
            this.textBox_contra.TabIndex = 0;
            // 
            // textBox_nueva_contra1
            // 
            this.textBox_nueva_contra1.Location = new System.Drawing.Point(12, 72);
            this.textBox_nueva_contra1.Name = "textBox_nueva_contra1";
            this.textBox_nueva_contra1.Size = new System.Drawing.Size(100, 22);
            this.textBox_nueva_contra1.TabIndex = 1;
            // 
            // textBox_nueva_contra2
            // 
            this.textBox_nueva_contra2.Location = new System.Drawing.Point(12, 116);
            this.textBox_nueva_contra2.Name = "textBox_nueva_contra2";
            this.textBox_nueva_contra2.Size = new System.Drawing.Size(100, 22);
            this.textBox_nueva_contra2.TabIndex = 2;
            // 
            // label_contra
            // 
            this.label_contra.AutoSize = true;
            this.label_contra.Location = new System.Drawing.Point(12, 9);
            this.label_contra.Name = "label_contra";
            this.label_contra.Size = new System.Drawing.Size(115, 16);
            this.label_contra.TabIndex = 3;
            this.label_contra.Text = "Contraseña actual";
            // 
            // label_nueva_contra1
            // 
            this.label_nueva_contra1.AutoSize = true;
            this.label_nueva_contra1.Location = new System.Drawing.Point(12, 53);
            this.label_nueva_contra1.Name = "label_nueva_contra1";
            this.label_nueva_contra1.Size = new System.Drawing.Size(117, 16);
            this.label_nueva_contra1.TabIndex = 4;
            this.label_nueva_contra1.Text = "Nueva contraseña";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(161, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Repetir nueva contraseña";
            // 
            // button_confirmar
            // 
            this.button_confirmar.Location = new System.Drawing.Point(12, 144);
            this.button_confirmar.Name = "button_confirmar";
            this.button_confirmar.Size = new System.Drawing.Size(75, 23);
            this.button_confirmar.TabIndex = 6;
            this.button_confirmar.Text = "Confirmar";
            this.button_confirmar.UseVisualStyleBackColor = true;
            this.button_confirmar.Click += new System.EventHandler(this.button_confirmar_Click);
            // 
            // button_salir
            // 
            this.button_salir.Location = new System.Drawing.Point(12, 415);
            this.button_salir.Name = "button_salir";
            this.button_salir.Size = new System.Drawing.Size(75, 23);
            this.button_salir.TabIndex = 7;
            this.button_salir.Text = "Salir";
            this.button_salir.UseVisualStyleBackColor = true;
            this.button_salir.Click += new System.EventHandler(this.button_salir_Click);
            // 
            // UI_Cambiar_Clave_44MM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ControlBox = false;
            this.Controls.Add(this.button_salir);
            this.Controls.Add(this.button_confirmar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label_nueva_contra1);
            this.Controls.Add(this.label_contra);
            this.Controls.Add(this.textBox_nueva_contra2);
            this.Controls.Add(this.textBox_nueva_contra1);
            this.Controls.Add(this.textBox_contra);
            this.Name = "UI_Cambiar_Clave_44MM";
            this.Text = "UI_Cambiar_Clave_44MM";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_contra;
        private System.Windows.Forms.TextBox textBox_nueva_contra1;
        private System.Windows.Forms.TextBox textBox_nueva_contra2;
        private System.Windows.Forms.Label label_contra;
        private System.Windows.Forms.Label label_nueva_contra1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button_confirmar;
        private System.Windows.Forms.Button button_salir;
    }
}