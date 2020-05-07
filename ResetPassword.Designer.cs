namespace metaGamesInventory
{
    partial class ResetPassword
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
            this.button1 = new System.Windows.Forms.Button();
            this.txtQuestion = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblQuestion = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblAnswer = new System.Windows.Forms.Label();
            this.txtAnswer = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.volverToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(38, 80);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(143, 38);
            this.button1.TabIndex = 12;
            this.button1.Text = "Solicitar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // txtQuestion
            // 
            this.txtQuestion.Location = new System.Drawing.Point(571, 32);
            this.txtQuestion.Name = "txtQuestion";
            this.txtQuestion.Size = new System.Drawing.Size(161, 20);
            this.txtQuestion.TabIndex = 10;
            this.txtQuestion.Visible = false;
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(194, 37);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(161, 20);
            this.txtUsername.TabIndex = 9;
            // 
            // lblQuestion
            // 
            this.lblQuestion.AutoSize = true;
            this.lblQuestion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuestion.Location = new System.Drawing.Point(408, 33);
            this.lblQuestion.Name = "lblQuestion";
            this.lblQuestion.Size = new System.Drawing.Size(145, 16);
            this.lblQuestion.TabIndex = 8;
            this.lblQuestion.Text = "Pregunta de seguridad";
            this.lblQuestion.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(29, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "Nombre de usuario";
            // 
            // lblAnswer
            // 
            this.lblAnswer.AutoSize = true;
            this.lblAnswer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAnswer.Location = new System.Drawing.Point(408, 80);
            this.lblAnswer.Name = "lblAnswer";
            this.lblAnswer.Size = new System.Drawing.Size(74, 16);
            this.lblAnswer.TabIndex = 13;
            this.lblAnswer.Text = "Respuesta";
            this.lblAnswer.Visible = false;
            // 
            // txtAnswer
            // 
            this.txtAnswer.Location = new System.Drawing.Point(571, 79);
            this.txtAnswer.Name = "txtAnswer";
            this.txtAnswer.Size = new System.Drawing.Size(161, 20);
            this.txtAnswer.TabIndex = 14;
            this.txtAnswer.Visible = false;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(410, 116);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(143, 38);
            this.button2.TabIndex = 15;
            this.button2.Text = "Enviar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.volverToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 16;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // volverToolStripMenuItem
            // 
            this.volverToolStripMenuItem.Name = "volverToolStripMenuItem";
            this.volverToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.volverToolStripMenuItem.Text = "Volver";
            this.volverToolStripMenuItem.Click += new System.EventHandler(this.VolverToolStripMenuItem_Click);
            // 
            // ResetPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 166);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.txtAnswer);
            this.Controls.Add(this.lblAnswer);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtQuestion);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.lblQuestion);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ResetPassword";
            this.Text = "ResetPassword";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtQuestion;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblQuestion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblAnswer;
        private System.Windows.Forms.TextBox txtAnswer;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem volverToolStripMenuItem;
    }
}