namespace metaGamesInventory
{
    partial class CUComprascs
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtbuscarproducto = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.btn_Ordenar_Compra = new System.Windows.Forms.Button();
            this.cmbdescuento = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.numcant = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.numprecuni = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.txtexistencia = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtnompro = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvinventario = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvImpuestos = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbimpuestos = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dtpfecha = new System.Windows.Forms.DateTimePicker();
            this.btnProcesarCompra = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txttotal = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtimpuesto = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txttotalsinimp = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.dgvOrdenes = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numcant)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numprecuni)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvinventario)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvImpuestos)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdenes)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtbuscarproducto);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.btn_Ordenar_Compra);
            this.groupBox1.Controls.Add(this.cmbdescuento);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.numcant);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.numprecuni);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtexistencia);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtnompro);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dgvinventario);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(600, 374);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "En Almacen";
            // 
            // txtbuscarproducto
            // 
            this.txtbuscarproducto.Location = new System.Drawing.Point(75, 28);
            this.txtbuscarproducto.Name = "txtbuscarproducto";
            this.txtbuscarproducto.Size = new System.Drawing.Size(280, 26);
            this.txtbuscarproducto.TabIndex = 13;
            this.txtbuscarproducto.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtbuscarproducto_KeyUp);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 31);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(67, 20);
            this.label13.TabIndex = 12;
            this.label13.Text = "Buscar :";
            // 
            // btn_Ordenar_Compra
            // 
            this.btn_Ordenar_Compra.Location = new System.Drawing.Point(365, 318);
            this.btn_Ordenar_Compra.Name = "btn_Ordenar_Compra";
            this.btn_Ordenar_Compra.Size = new System.Drawing.Size(229, 50);
            this.btn_Ordenar_Compra.TabIndex = 11;
            this.btn_Ordenar_Compra.Text = "Ordenar Compra";
            this.btn_Ordenar_Compra.UseVisualStyleBackColor = true;
            this.btn_Ordenar_Compra.Click += new System.EventHandler(this.btn_Ordenar_Compra_Click);
            // 
            // cmbdescuento
            // 
            this.cmbdescuento.FormattingEnabled = true;
            this.cmbdescuento.Location = new System.Drawing.Point(369, 273);
            this.cmbdescuento.Name = "cmbdescuento";
            this.cmbdescuento.Size = new System.Drawing.Size(222, 28);
            this.cmbdescuento.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(365, 241);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "Descuento:";
            // 
            // numcant
            // 
            this.numcant.Location = new System.Drawing.Point(518, 197);
            this.numcant.Name = "numcant";
            this.numcant.Size = new System.Drawing.Size(73, 26);
            this.numcant.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(365, 199);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(147, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Cantidad solicitada:";
            // 
            // numprecuni
            // 
            this.numprecuni.Location = new System.Drawing.Point(497, 151);
            this.numprecuni.Name = "numprecuni";
            this.numprecuni.Size = new System.Drawing.Size(94, 26);
            this.numprecuni.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(365, 153);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Precio Unitario: $";
            // 
            // txtexistencia
            // 
            this.txtexistencia.Location = new System.Drawing.Point(460, 105);
            this.txtexistencia.Name = "txtexistencia";
            this.txtexistencia.Size = new System.Drawing.Size(131, 26);
            this.txtexistencia.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(365, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Existencias:";
            // 
            // txtnompro
            // 
            this.txtnompro.Location = new System.Drawing.Point(365, 64);
            this.txtnompro.Name = "txtnompro";
            this.txtnompro.Size = new System.Drawing.Size(229, 26);
            this.txtnompro.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(361, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nombre del Producto:";
            // 
            // dgvinventario
            // 
            this.dgvinventario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvinventario.Location = new System.Drawing.Point(6, 64);
            this.dgvinventario.Name = "dgvinventario";
            this.dgvinventario.Size = new System.Drawing.Size(353, 304);
            this.dgvinventario.TabIndex = 0;
            this.dgvinventario.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvinventario_CellClick);
            this.dgvinventario.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvinventario_DataError);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvImpuestos);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.cmbimpuestos);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 386);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(308, 203);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Impuestos";
            // 
            // dgvImpuestos
            // 
            this.dgvImpuestos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvImpuestos.Location = new System.Drawing.Point(6, 96);
            this.dgvImpuestos.Name = "dgvImpuestos";
            this.dgvImpuestos.Size = new System.Drawing.Size(296, 101);
            this.dgvImpuestos.TabIndex = 3;
            this.dgvImpuestos.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvImpuestos_DataError);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 74);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 20);
            this.label7.TabIndex = 2;
            this.label7.Text = "Aplicados:";
            // 
            // cmbimpuestos
            // 
            this.cmbimpuestos.FormattingEnabled = true;
            this.cmbimpuestos.Location = new System.Drawing.Point(99, 35);
            this.cmbimpuestos.Name = "cmbimpuestos";
            this.cmbimpuestos.Size = new System.Drawing.Size(193, 28);
            this.cmbimpuestos.TabIndex = 1;
            this.cmbimpuestos.SelectedIndexChanged += new System.EventHandler(this.cmbimpuestos_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 38);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 20);
            this.label6.TabIndex = 0;
            this.label6.Text = "Disponible:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(332, 399);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(123, 20);
            this.label8.TabIndex = 2;
            this.label8.Text = "Fecha de venta:";
            // 
            // dtpfecha
            // 
            this.dtpfecha.Location = new System.Drawing.Point(335, 429);
            this.dtpfecha.Name = "dtpfecha";
            this.dtpfecha.Size = new System.Drawing.Size(277, 20);
            this.dtpfecha.TabIndex = 3;
            // 
            // btnProcesarCompra
            // 
            this.btnProcesarCompra.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProcesarCompra.Location = new System.Drawing.Point(336, 520);
            this.btnProcesarCompra.Name = "btnProcesarCompra";
            this.btnProcesarCompra.Size = new System.Drawing.Size(276, 63);
            this.btnProcesarCompra.TabIndex = 5;
            this.btnProcesarCompra.Text = "Procesar Compra";
            this.btnProcesarCompra.UseVisualStyleBackColor = true;
            this.btnProcesarCompra.Click += new System.EventHandler(this.btnProcesarCompra_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txttotal);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.txtimpuesto);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.txttotalsinimp);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.btnEliminar);
            this.groupBox3.Controls.Add(this.btnModificar);
            this.groupBox3.Controls.Add(this.dgvOrdenes);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(618, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(400, 583);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "En Orden";
            // 
            // txttotal
            // 
            this.txttotal.Location = new System.Drawing.Point(202, 517);
            this.txttotal.Name = "txttotal";
            this.txttotal.Size = new System.Drawing.Size(192, 26);
            this.txttotal.TabIndex = 8;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(135, 520);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(61, 20);
            this.label12.TabIndex = 7;
            this.label12.Text = "Total: $";
            // 
            // txtimpuesto
            // 
            this.txtimpuesto.Location = new System.Drawing.Point(202, 479);
            this.txtimpuesto.Name = "txtimpuesto";
            this.txtimpuesto.Size = new System.Drawing.Size(192, 26);
            this.txtimpuesto.TabIndex = 6;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(34, 479);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(101, 20);
            this.label11.TabIndex = 5;
            this.label11.Text = "Impuestos: $";
            // 
            // txttotalsinimp
            // 
            this.txttotalsinimp.Location = new System.Drawing.Point(202, 445);
            this.txttotalsinimp.Name = "txttotalsinimp";
            this.txttotalsinimp.Size = new System.Drawing.Size(192, 26);
            this.txttotalsinimp.TabIndex = 4;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(34, 448);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(162, 20);
            this.label10.TabIndex = 3;
            this.label10.Text = "Total sin impuestos: $";
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(210, 387);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(184, 50);
            this.btnEliminar.TabIndex = 2;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(6, 387);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(190, 50);
            this.btnModificar.TabIndex = 1;
            this.btnModificar.Text = "Editar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // dgvOrdenes
            // 
            this.dgvOrdenes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrdenes.Location = new System.Drawing.Point(6, 64);
            this.dgvOrdenes.Name = "dgvOrdenes";
            this.dgvOrdenes.Size = new System.Drawing.Size(388, 312);
            this.dgvOrdenes.TabIndex = 0;
            this.dgvOrdenes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrdenes_CellClick);
            // 
            // CUComprascs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1027, 611);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnProcesarCompra);
            this.Controls.Add(this.dtpfecha);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "CUComprascs";
            this.Text = "CUComprascs";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numcant)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numprecuni)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvinventario)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvImpuestos)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdenes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvinventario;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtnompro;
        private System.Windows.Forms.TextBox txtexistencia;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numprecuni;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numcant;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbdescuento;
        private System.Windows.Forms.Button btn_Ordenar_Compra;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbimpuestos;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dgvImpuestos;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtpfecha;
        private System.Windows.Forms.Button btnProcesarCompra;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgvOrdenes;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txttotalsinimp;
        private System.Windows.Forms.TextBox txtimpuesto;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txttotal;
        private System.Windows.Forms.TextBox txtbuscarproducto;
        private System.Windows.Forms.Label label13;
    }
}