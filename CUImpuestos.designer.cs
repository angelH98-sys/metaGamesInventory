namespace metaGamesInventory
{
    partial class CUImpuestos
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.txtnimpu = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnimpuesto = new System.Windows.Forms.Button();
            this.numimp = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.numimp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(27, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre:";
            // 
            // txtnimpu
            // 
            this.txtnimpu.Location = new System.Drawing.Point(138, 115);
            this.txtnimpu.Name = "txtnimpu";
            this.txtnimpu.Size = new System.Drawing.Size(148, 20);
            this.txtnimpu.TabIndex = 1;
            this.txtnimpu.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtnimpu_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(27, 174);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Porcentaje:";
            // 
            // btnimpuesto
            // 
            this.btnimpuesto.Location = new System.Drawing.Point(138, 230);
            this.btnimpuesto.Name = "btnimpuesto";
            this.btnimpuesto.Size = new System.Drawing.Size(148, 33);
            this.btnimpuesto.TabIndex = 4;
            this.btnimpuesto.Text = "Registrar";
            this.btnimpuesto.UseVisualStyleBackColor = true;
            this.btnimpuesto.Click += new System.EventHandler(this.btnimpuesto_Click);
            // 
            // numimp
            // 
            this.numimp.Location = new System.Drawing.Point(138, 174);
            this.numimp.Name = "numimp";
            this.numimp.Size = new System.Drawing.Size(148, 20);
            this.numimp.TabIndex = 5;
            this.numimp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numimp_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(26, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 25);
            this.label3.TabIndex = 6;
            this.label3.Text = "Impuestos";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // CUImpuestos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 301);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numimp);
            this.Controls.Add(this.btnimpuesto);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtnimpu);
            this.Controls.Add(this.label1);
            this.Name = "CUImpuestos";
            this.Text = "CUImpuestos";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CUImpuestos_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.numimp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtnimpu;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnimpuesto;
        private System.Windows.Forms.NumericUpDown numimp;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}