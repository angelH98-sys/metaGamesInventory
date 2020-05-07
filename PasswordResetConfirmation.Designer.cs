namespace metaGamesInventory
{
    partial class PasswordResetConfirmation
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();
            this.chbPassword = new System.Windows.Forms.CheckBox();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nueva contraseña:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(24, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Confirmar contraseña:";
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(183, 35);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(195, 22);
            this.txtPassword.TabIndex = 2;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConfirmPassword.Location = new System.Drawing.Point(183, 90);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.Size = new System.Drawing.Size(195, 22);
            this.txtConfirmPassword.TabIndex = 3;
            this.txtConfirmPassword.UseSystemPasswordChar = true;
            // 
            // chbPassword
            // 
            this.chbPassword.AutoSize = true;
            this.chbPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbPassword.Location = new System.Drawing.Point(409, 35);
            this.chbPassword.Name = "chbPassword";
            this.chbPassword.Size = new System.Drawing.Size(142, 20);
            this.chbPassword.TabIndex = 4;
            this.chbPassword.Text = "Mostrar contraseña";
            this.chbPassword.UseVisualStyleBackColor = true;
            this.chbPassword.CheckedChanged += new System.EventHandler(this.ChbPassword_CheckedChanged);
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Location = new System.Drawing.Point(466, 112);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(85, 23);
            this.btnConfirmar.TabIndex = 5;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.BtnConfirmar_Click);
            // 
            // PasswordResetConfirmation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(637, 147);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.chbPassword);
            this.Controls.Add(this.txtConfirmPassword);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "PasswordResetConfirmation";
            this.Text = "PasswordResetConfirmation";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.CheckBox chbPassword;
        private System.Windows.Forms.Button btnConfirmar;
    }
}