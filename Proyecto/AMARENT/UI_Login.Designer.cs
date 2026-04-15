namespace AMARENT
{
    partial class UI_Login
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
            this.textBox_correo = new System.Windows.Forms.TextBox();
            this.label_correo = new System.Windows.Forms.Label();
            this.label_contra = new System.Windows.Forms.Label();
            this.textBox_contra = new System.Windows.Forms.TextBox();
            this.checkBox_ms = new System.Windows.Forms.CheckBox();
            this.button_login = new System.Windows.Forms.Button();
            this.label_mensaje = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox_correo
            // 
            this.textBox_correo.Location = new System.Drawing.Point(12, 28);
            this.textBox_correo.Name = "textBox_correo";
            this.textBox_correo.Size = new System.Drawing.Size(100, 22);
            this.textBox_correo.TabIndex = 0;
            // 
            // label_correo
            // 
            this.label_correo.AutoSize = true;
            this.label_correo.Location = new System.Drawing.Point(12, 9);
            this.label_correo.Name = "label_correo";
            this.label_correo.Size = new System.Drawing.Size(48, 16);
            this.label_correo.TabIndex = 1;
            this.label_correo.Text = "Correo";
            // 
            // label_contra
            // 
            this.label_contra.AutoSize = true;
            this.label_contra.Location = new System.Drawing.Point(12, 53);
            this.label_contra.Name = "label_contra";
            this.label_contra.Size = new System.Drawing.Size(76, 16);
            this.label_contra.TabIndex = 2;
            this.label_contra.Text = "Contraseña";
            // 
            // textBox_contra
            // 
            this.textBox_contra.Location = new System.Drawing.Point(12, 72);
            this.textBox_contra.Name = "textBox_contra";
            this.textBox_contra.Size = new System.Drawing.Size(100, 22);
            this.textBox_contra.TabIndex = 3;
            this.textBox_contra.UseSystemPasswordChar = true;
            // 
            // checkBox_ms
            // 
            this.checkBox_ms.AutoSize = true;
            this.checkBox_ms.Location = new System.Drawing.Point(12, 100);
            this.checkBox_ms.Name = "checkBox_ms";
            this.checkBox_ms.Size = new System.Drawing.Size(130, 20);
            this.checkBox_ms.TabIndex = 4;
            this.checkBox_ms.Text = "Mantener Sesion";
            this.checkBox_ms.UseVisualStyleBackColor = true;
            // 
            // button_login
            // 
            this.button_login.Location = new System.Drawing.Point(12, 142);
            this.button_login.Name = "button_login";
            this.button_login.Size = new System.Drawing.Size(75, 23);
            this.button_login.TabIndex = 5;
            this.button_login.Text = "Iniciar";
            this.button_login.UseVisualStyleBackColor = true;
            this.button_login.Click += new System.EventHandler(this.button1_Click);
            // 
            // label_mensaje
            // 
            this.label_mensaje.AutoSize = true;
            this.label_mensaje.Location = new System.Drawing.Point(12, 123);
            this.label_mensaje.Name = "label_mensaje";
            this.label_mensaje.Size = new System.Drawing.Size(0, 16);
            this.label_mensaje.TabIndex = 6;
            // 
            // UI_Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label_mensaje);
            this.Controls.Add(this.button_login);
            this.Controls.Add(this.checkBox_ms);
            this.Controls.Add(this.textBox_contra);
            this.Controls.Add(this.label_contra);
            this.Controls.Add(this.label_correo);
            this.Controls.Add(this.textBox_correo);
            this.Name = "UI_Login";
            this.Text = "UI_Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_correo;
        private System.Windows.Forms.Label label_correo;
        private System.Windows.Forms.Label label_contra;
        private System.Windows.Forms.TextBox textBox_contra;
        private System.Windows.Forms.CheckBox checkBox_ms;
        private System.Windows.Forms.Button button_login;
        private System.Windows.Forms.Label label_mensaje;
    }
}