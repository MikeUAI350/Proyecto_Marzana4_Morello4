namespace AMARENT
{
    partial class UI_Gestion_Respaldo_44MM
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
            this.textBox_backup = new System.Windows.Forms.TextBox();
            this.label_backup = new System.Windows.Forms.Label();
            this.label_restore = new System.Windows.Forms.Label();
            this.textBox_restore = new System.Windows.Forms.TextBox();
            this.button_direccion_backup = new System.Windows.Forms.Button();
            this.button_direccion_restore = new System.Windows.Forms.Button();
            this.button_backup = new System.Windows.Forms.Button();
            this.button_restore = new System.Windows.Forms.Button();
            this.openFileDialog_restore = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog_backup = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // textBox_backup
            // 
            this.textBox_backup.Location = new System.Drawing.Point(12, 27);
            this.textBox_backup.Name = "textBox_backup";
            this.textBox_backup.ReadOnly = true;
            this.textBox_backup.Size = new System.Drawing.Size(100, 22);
            this.textBox_backup.TabIndex = 0;
            // 
            // label_backup
            // 
            this.label_backup.AutoSize = true;
            this.label_backup.Location = new System.Drawing.Point(9, 9);
            this.label_backup.Name = "label_backup";
            this.label_backup.Size = new System.Drawing.Size(56, 16);
            this.label_backup.TabIndex = 1;
            this.label_backup.Text = "BackUp";
            // 
            // label_restore
            // 
            this.label_restore.AutoSize = true;
            this.label_restore.Location = new System.Drawing.Point(12, 82);
            this.label_restore.Name = "label_restore";
            this.label_restore.Size = new System.Drawing.Size(55, 16);
            this.label_restore.TabIndex = 3;
            this.label_restore.Text = "Restore";
            // 
            // textBox_restore
            // 
            this.textBox_restore.Location = new System.Drawing.Point(12, 101);
            this.textBox_restore.Name = "textBox_restore";
            this.textBox_restore.ReadOnly = true;
            this.textBox_restore.Size = new System.Drawing.Size(100, 22);
            this.textBox_restore.TabIndex = 2;
            // 
            // button_direccion_backup
            // 
            this.button_direccion_backup.AutoSize = true;
            this.button_direccion_backup.Location = new System.Drawing.Point(118, 26);
            this.button_direccion_backup.Name = "button_direccion_backup";
            this.button_direccion_backup.Size = new System.Drawing.Size(26, 26);
            this.button_direccion_backup.TabIndex = 4;
            this.button_direccion_backup.Text = "...";
            this.button_direccion_backup.UseVisualStyleBackColor = true;
            this.button_direccion_backup.Click += new System.EventHandler(this.button_direccion_backup_Click);
            // 
            // button_direccion_restore
            // 
            this.button_direccion_restore.AutoSize = true;
            this.button_direccion_restore.Location = new System.Drawing.Point(118, 100);
            this.button_direccion_restore.Name = "button_direccion_restore";
            this.button_direccion_restore.Size = new System.Drawing.Size(26, 26);
            this.button_direccion_restore.TabIndex = 5;
            this.button_direccion_restore.Text = "...";
            this.button_direccion_restore.UseVisualStyleBackColor = true;
            this.button_direccion_restore.Click += new System.EventHandler(this.button_direccion_restore_Click);
            // 
            // button_backup
            // 
            this.button_backup.Location = new System.Drawing.Point(12, 56);
            this.button_backup.Name = "button_backup";
            this.button_backup.Size = new System.Drawing.Size(75, 23);
            this.button_backup.TabIndex = 6;
            this.button_backup.Text = "BackUp";
            this.button_backup.UseVisualStyleBackColor = true;
            this.button_backup.Click += new System.EventHandler(this.button_backup_Click);
            // 
            // button_restore
            // 
            this.button_restore.Location = new System.Drawing.Point(12, 129);
            this.button_restore.Name = "button_restore";
            this.button_restore.Size = new System.Drawing.Size(75, 23);
            this.button_restore.TabIndex = 7;
            this.button_restore.Text = "Restore";
            this.button_restore.UseVisualStyleBackColor = true;
            this.button_restore.Click += new System.EventHandler(this.button_restore_Click);
            // 
            // UI_Gestion_Respaldo_44MM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ControlBox = false;
            this.Controls.Add(this.button_restore);
            this.Controls.Add(this.button_backup);
            this.Controls.Add(this.button_direccion_restore);
            this.Controls.Add(this.button_direccion_backup);
            this.Controls.Add(this.label_restore);
            this.Controls.Add(this.textBox_restore);
            this.Controls.Add(this.label_backup);
            this.Controls.Add(this.textBox_backup);
            this.Name = "UI_Gestion_Respaldo_44MM";
            this.Text = "UI_Respaldo_44MM";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_backup;
        private System.Windows.Forms.Label label_backup;
        private System.Windows.Forms.Label label_restore;
        private System.Windows.Forms.TextBox textBox_restore;
        private System.Windows.Forms.Button button_direccion_backup;
        private System.Windows.Forms.Button button_direccion_restore;
        private System.Windows.Forms.Button button_backup;
        private System.Windows.Forms.Button button_restore;
        private System.Windows.Forms.OpenFileDialog openFileDialog_restore;
        private System.Windows.Forms.SaveFileDialog saveFileDialog_backup;
    }
}