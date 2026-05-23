namespace AMARENT
{
    partial class UI_Login_44MM
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
            this.textBox_login = new System.Windows.Forms.TextBox();
            this.label_login = new System.Windows.Forms.Label();
            this.label_contra = new System.Windows.Forms.Label();
            this.textBox_contra = new System.Windows.Forms.TextBox();
            this.button_login = new System.Windows.Forms.Button();
            this.button_salir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox_login
            // 
            this.textBox_login.Location = new System.Drawing.Point(12, 28);
            this.textBox_login.Name = "textBox_login";
            this.textBox_login.Size = new System.Drawing.Size(100, 22);
            this.textBox_login.TabIndex = 0;
            // 
            // label_login
            // 
            this.label_login.AutoSize = true;
            this.label_login.Location = new System.Drawing.Point(12, 9);
            this.label_login.Name = "label_login";
            this.label_login.Size = new System.Drawing.Size(40, 16);
            this.label_login.TabIndex = 1;
            this.label_login.Text = "Login";
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
            this.textBox_contra.MouseEnter += new System.EventHandler(this.textBox_contra_MouseEnter);
            this.textBox_contra.MouseLeave += new System.EventHandler(this.textBox_contra_MouseLeave);
            // 
            // button_login
            // 
            this.button_login.Location = new System.Drawing.Point(12, 100);
            this.button_login.Name = "button_login";
            this.button_login.Size = new System.Drawing.Size(75, 23);
            this.button_login.TabIndex = 5;
            this.button_login.Text = "Iniciar";
            this.button_login.UseVisualStyleBackColor = true;
            this.button_login.Click += new System.EventHandler(this.button_login_Click);
            // 
            // button_salir
            // 
            this.button_salir.Location = new System.Drawing.Point(13, 129);
            this.button_salir.Name = "button_salir";
            this.button_salir.Size = new System.Drawing.Size(75, 23);
            this.button_salir.TabIndex = 7;
            this.button_salir.Text = "Salir";
            this.button_salir.UseVisualStyleBackColor = true;
            this.button_salir.Click += new System.EventHandler(this.button_salir_Click);
            // 
            // UI_Login_44MM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(148, 164);
            this.ControlBox = false;
            this.Controls.Add(this.button_salir);
            this.Controls.Add(this.button_login);
            this.Controls.Add(this.textBox_contra);
            this.Controls.Add(this.label_contra);
            this.Controls.Add(this.label_login);
            this.Controls.Add(this.textBox_login);
            this.Name = "UI_Login_44MM";
            this.Text = "UI_Login";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UI_Login_44MM_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_login;
        private System.Windows.Forms.Label label_login;
        private System.Windows.Forms.Label label_contra;
        private System.Windows.Forms.TextBox textBox_contra;
        private System.Windows.Forms.Button button_login;
        private System.Windows.Forms.Button button_salir;
    }
}