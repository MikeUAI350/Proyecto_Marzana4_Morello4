namespace AMARENT
{
    partial class UI_Respaldo_44MM
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
            this.button_restore = new System.Windows.Forms.Button();
            this.button_direccion_restore = new System.Windows.Forms.Button();
            this.label_restore = new System.Windows.Forms.Label();
            this.textBox_restore = new System.Windows.Forms.TextBox();
            this.openFileDialog_restore = new System.Windows.Forms.OpenFileDialog();
            this.button_atras = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_restore
            // 
            this.button_restore.Location = new System.Drawing.Point(12, 56);
            this.button_restore.Name = "button_restore";
            this.button_restore.Size = new System.Drawing.Size(75, 23);
            this.button_restore.TabIndex = 11;
            this.button_restore.Text = "Restore";
            this.button_restore.UseVisualStyleBackColor = true;
            this.button_restore.Click += new System.EventHandler(this.button_restore_Click);
            // 
            // button_direccion_restore
            // 
            this.button_direccion_restore.AutoSize = true;
            this.button_direccion_restore.Location = new System.Drawing.Point(144, 28);
            this.button_direccion_restore.Name = "button_direccion_restore";
            this.button_direccion_restore.Size = new System.Drawing.Size(26, 26);
            this.button_direccion_restore.TabIndex = 10;
            this.button_direccion_restore.Text = "...";
            this.button_direccion_restore.UseVisualStyleBackColor = true;
            this.button_direccion_restore.Click += new System.EventHandler(this.button_direccion_restore_Click);
            // 
            // label_restore
            // 
            this.label_restore.AutoSize = true;
            this.label_restore.Location = new System.Drawing.Point(12, 9);
            this.label_restore.Name = "label_restore";
            this.label_restore.Size = new System.Drawing.Size(55, 16);
            this.label_restore.TabIndex = 9;
            this.label_restore.Text = "Restore";
            // 
            // textBox_restore
            // 
            this.textBox_restore.Location = new System.Drawing.Point(12, 28);
            this.textBox_restore.Name = "textBox_restore";
            this.textBox_restore.ReadOnly = true;
            this.textBox_restore.Size = new System.Drawing.Size(126, 22);
            this.textBox_restore.TabIndex = 8;
            // 
            // button_atras
            // 
            this.button_atras.Location = new System.Drawing.Point(95, 56);
            this.button_atras.Name = "button_atras";
            this.button_atras.Size = new System.Drawing.Size(75, 23);
            this.button_atras.TabIndex = 12;
            this.button_atras.Text = "Restore";
            this.button_atras.UseVisualStyleBackColor = true;
            this.button_atras.Click += new System.EventHandler(this.button_atras_Click);
            // 
            // UI_Respaldo_44MM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(182, 83);
            this.ControlBox = false;
            this.Controls.Add(this.button_atras);
            this.Controls.Add(this.button_restore);
            this.Controls.Add(this.button_direccion_restore);
            this.Controls.Add(this.label_restore);
            this.Controls.Add(this.textBox_restore);
            this.Name = "UI_Respaldo_44MM";
            this.Text = "UI_Respaldo_44MM";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_restore;
        private System.Windows.Forms.Button button_direccion_restore;
        private System.Windows.Forms.Label label_restore;
        private System.Windows.Forms.TextBox textBox_restore;
        private System.Windows.Forms.OpenFileDialog openFileDialog_restore;
        private System.Windows.Forms.Button button_atras;
    }
}