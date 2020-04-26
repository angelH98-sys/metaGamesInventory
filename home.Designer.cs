namespace metaGamesInventory
{
    partial class home
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(home));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.providerMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.newProviderSubMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.registedProvidersSubMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.newCompanySubMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.registedCompaniesSubMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.productosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevoProductoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productosRegistradosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.nuevaCategoriaDeProductoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.categoriasDeProductoRegistradasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ventasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevaVentaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ventasRegistradasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comprasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevaCompraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comprasRegistradasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.promocionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevaPromociónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.promocionesRegistradasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.impuestosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevoImpuestoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.impuestosRegistradosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.empleadosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevoEmpleadoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.empleadosRegistradosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.providerMenu,
            this.productosToolStripMenuItem,
            this.ventasToolStripMenuItem,
            this.comprasToolStripMenuItem,
            this.promocionesToolStripMenuItem,
            this.impuestosToolStripMenuItem,
            this.empleadosToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(848, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "MenuStrip";
            // 
            // providerMenu
            // 
            this.providerMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newProviderSubMenu,
            this.registedProvidersSubMenu,
            this.toolStripSeparator3,
            this.newCompanySubMenu,
            this.registedCompaniesSubMenu});
            this.providerMenu.ImageTransparentColor = System.Drawing.SystemColors.ActiveBorder;
            this.providerMenu.Name = "providerMenu";
            this.providerMenu.Size = new System.Drawing.Size(84, 20);
            this.providerMenu.Text = "&Proveedores";
            // 
            // newProviderSubMenu
            // 
            this.newProviderSubMenu.Image = ((System.Drawing.Image)(resources.GetObject("newProviderSubMenu.Image")));
            this.newProviderSubMenu.ImageTransparentColor = System.Drawing.Color.Black;
            this.newProviderSubMenu.Name = "newProviderSubMenu";
            this.newProviderSubMenu.Size = new System.Drawing.Size(243, 22);
            this.newProviderSubMenu.Text = "&Nuevo proveedor";
            this.newProviderSubMenu.Click += new System.EventHandler(this.ShowNewForm);
            // 
            // registedProvidersSubMenu
            // 
            this.registedProvidersSubMenu.Image = ((System.Drawing.Image)(resources.GetObject("registedProvidersSubMenu.Image")));
            this.registedProvidersSubMenu.ImageTransparentColor = System.Drawing.Color.Black;
            this.registedProvidersSubMenu.Name = "registedProvidersSubMenu";
            this.registedProvidersSubMenu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.registedProvidersSubMenu.Size = new System.Drawing.Size(243, 22);
            this.registedProvidersSubMenu.Text = "&Proveedores registrados";
            this.registedProvidersSubMenu.Click += new System.EventHandler(this.OpenFile);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(240, 6);
            // 
            // newCompanySubMenu
            // 
            this.newCompanySubMenu.Image = ((System.Drawing.Image)(resources.GetObject("newCompanySubMenu.Image")));
            this.newCompanySubMenu.ImageTransparentColor = System.Drawing.Color.Black;
            this.newCompanySubMenu.Name = "newCompanySubMenu";
            this.newCompanySubMenu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.newCompanySubMenu.Size = new System.Drawing.Size(243, 22);
            this.newCompanySubMenu.Text = "&Nueva Compañia";
            this.newCompanySubMenu.Click += new System.EventHandler(this.newCompanySubMenu_Click);
            // 
            // registedCompaniesSubMenu
            // 
            this.registedCompaniesSubMenu.Name = "registedCompaniesSubMenu";
            this.registedCompaniesSubMenu.Size = new System.Drawing.Size(243, 22);
            this.registedCompaniesSubMenu.Text = "Compañias registradas";
            this.registedCompaniesSubMenu.Click += new System.EventHandler(this.SaveAsToolStripMenuItem_Click);
            // 
            // productosToolStripMenuItem
            // 
            this.productosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoProductoToolStripMenuItem,
            this.productosRegistradosToolStripMenuItem,
            this.toolStripSeparator1,
            this.nuevaCategoriaDeProductoToolStripMenuItem,
            this.categoriasDeProductoRegistradasToolStripMenuItem});
            this.productosToolStripMenuItem.Name = "productosToolStripMenuItem";
            this.productosToolStripMenuItem.Size = new System.Drawing.Size(73, 20);
            this.productosToolStripMenuItem.Text = "&Productos";
            // 
            // nuevoProductoToolStripMenuItem
            // 
            this.nuevoProductoToolStripMenuItem.Name = "nuevoProductoToolStripMenuItem";
            this.nuevoProductoToolStripMenuItem.Size = new System.Drawing.Size(258, 22);
            this.nuevoProductoToolStripMenuItem.Text = "&Nuevo producto";
            this.nuevoProductoToolStripMenuItem.Click += new System.EventHandler(this.nuevoProductoToolStripMenuItem_Click);
            // 
            // productosRegistradosToolStripMenuItem
            // 
            this.productosRegistradosToolStripMenuItem.Name = "productosRegistradosToolStripMenuItem";
            this.productosRegistradosToolStripMenuItem.Size = new System.Drawing.Size(258, 22);
            this.productosRegistradosToolStripMenuItem.Text = "Productos registrados";
            this.productosRegistradosToolStripMenuItem.Click += new System.EventHandler(this.productosRegistradosToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(255, 6);
            // 
            // nuevaCategoriaDeProductoToolStripMenuItem
            // 
            this.nuevaCategoriaDeProductoToolStripMenuItem.Name = "nuevaCategoriaDeProductoToolStripMenuItem";
            this.nuevaCategoriaDeProductoToolStripMenuItem.Size = new System.Drawing.Size(258, 22);
            this.nuevaCategoriaDeProductoToolStripMenuItem.Text = "&Nueva categoria de producto";
            this.nuevaCategoriaDeProductoToolStripMenuItem.Click += new System.EventHandler(this.nuevaCategoriaDeProductoToolStripMenuItem_Click);
            // 
            // categoriasDeProductoRegistradasToolStripMenuItem
            // 
            this.categoriasDeProductoRegistradasToolStripMenuItem.Name = "categoriasDeProductoRegistradasToolStripMenuItem";
            this.categoriasDeProductoRegistradasToolStripMenuItem.Size = new System.Drawing.Size(258, 22);
            this.categoriasDeProductoRegistradasToolStripMenuItem.Text = "&Categorias de producto registradas";
            this.categoriasDeProductoRegistradasToolStripMenuItem.Click += new System.EventHandler(this.categoriasDeProductoRegistradasToolStripMenuItem_Click);
            // 
            // ventasToolStripMenuItem
            // 
            this.ventasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevaVentaToolStripMenuItem,
            this.ventasRegistradasToolStripMenuItem});
            this.ventasToolStripMenuItem.Name = "ventasToolStripMenuItem";
            this.ventasToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.ventasToolStripMenuItem.Text = "Ventas";
            this.ventasToolStripMenuItem.Click += new System.EventHandler(this.ventasToolStripMenuItem_Click);
            // 
            // nuevaVentaToolStripMenuItem
            // 
            this.nuevaVentaToolStripMenuItem.Name = "nuevaVentaToolStripMenuItem";
            this.nuevaVentaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.nuevaVentaToolStripMenuItem.Text = "&Nueva venta";
            this.nuevaVentaToolStripMenuItem.Click += new System.EventHandler(this.nuevaVentaToolStripMenuItem_Click);
            // 
            // ventasRegistradasToolStripMenuItem
            // 
            this.ventasRegistradasToolStripMenuItem.Name = "ventasRegistradasToolStripMenuItem";
            this.ventasRegistradasToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.ventasRegistradasToolStripMenuItem.Text = "&Ventas registradas";
            // 
            // comprasToolStripMenuItem
            // 
            this.comprasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevaCompraToolStripMenuItem,
            this.comprasRegistradasToolStripMenuItem});
            this.comprasToolStripMenuItem.Name = "comprasToolStripMenuItem";
            this.comprasToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.comprasToolStripMenuItem.Text = "Compras";
            // 
            // nuevaCompraToolStripMenuItem
            // 
            this.nuevaCompraToolStripMenuItem.Name = "nuevaCompraToolStripMenuItem";
            this.nuevaCompraToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.nuevaCompraToolStripMenuItem.Text = "&Nueva compra";
            // 
            // comprasRegistradasToolStripMenuItem
            // 
            this.comprasRegistradasToolStripMenuItem.Name = "comprasRegistradasToolStripMenuItem";
            this.comprasRegistradasToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.comprasRegistradasToolStripMenuItem.Text = "&Compras registradas";
            // 
            // promocionesToolStripMenuItem
            // 
            this.promocionesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevaPromociónToolStripMenuItem,
            this.promocionesRegistradasToolStripMenuItem});
            this.promocionesToolStripMenuItem.Name = "promocionesToolStripMenuItem";
            this.promocionesToolStripMenuItem.Size = new System.Drawing.Size(89, 20);
            this.promocionesToolStripMenuItem.Text = "&Promociones";
            // 
            // nuevaPromociónToolStripMenuItem
            // 
            this.nuevaPromociónToolStripMenuItem.Name = "nuevaPromociónToolStripMenuItem";
            this.nuevaPromociónToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.nuevaPromociónToolStripMenuItem.Text = "&Nueva promoción";
            // 
            // promocionesRegistradasToolStripMenuItem
            // 
            this.promocionesRegistradasToolStripMenuItem.Name = "promocionesRegistradasToolStripMenuItem";
            this.promocionesRegistradasToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.promocionesRegistradasToolStripMenuItem.Text = "&Promociones registradas ";
            // 
            // impuestosToolStripMenuItem
            // 
            this.impuestosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoImpuestoToolStripMenuItem,
            this.impuestosRegistradosToolStripMenuItem});
            this.impuestosToolStripMenuItem.Name = "impuestosToolStripMenuItem";
            this.impuestosToolStripMenuItem.Size = new System.Drawing.Size(74, 20);
            this.impuestosToolStripMenuItem.Text = "&Impuestos";
            // 
            // nuevoImpuestoToolStripMenuItem
            // 
            this.nuevoImpuestoToolStripMenuItem.Name = "nuevoImpuestoToolStripMenuItem";
            this.nuevoImpuestoToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.nuevoImpuestoToolStripMenuItem.Text = "&Nuevo impuesto";
            // 
            // impuestosRegistradosToolStripMenuItem
            // 
            this.impuestosRegistradosToolStripMenuItem.Name = "impuestosRegistradosToolStripMenuItem";
            this.impuestosRegistradosToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.impuestosRegistradosToolStripMenuItem.Text = "&Impuestos registrados";
            // 
            // empleadosToolStripMenuItem
            // 
            this.empleadosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoEmpleadoToolStripMenuItem,
            this.empleadosRegistradosToolStripMenuItem});
            this.empleadosToolStripMenuItem.Name = "empleadosToolStripMenuItem";
            this.empleadosToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.empleadosToolStripMenuItem.Text = "&Empleados";
            this.empleadosToolStripMenuItem.Click += new System.EventHandler(this.EmpleadosToolStripMenuItem_Click);
            // 
            // nuevoEmpleadoToolStripMenuItem
            // 
            this.nuevoEmpleadoToolStripMenuItem.Name = "nuevoEmpleadoToolStripMenuItem";
            this.nuevoEmpleadoToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.nuevoEmpleadoToolStripMenuItem.Text = "&Nuevo empleado";
            this.nuevoEmpleadoToolStripMenuItem.Click += new System.EventHandler(this.NuevoEmpleadoToolStripMenuItem_Click);
            // 
            // empleadosRegistradosToolStripMenuItem
            // 
            this.empleadosRegistradosToolStripMenuItem.Name = "empleadosRegistradosToolStripMenuItem";
            this.empleadosRegistradosToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.empleadosRegistradosToolStripMenuItem.Text = "&Empleados registrados";
            this.empleadosRegistradosToolStripMenuItem.Click += new System.EventHandler(this.EmpleadosRegistradosToolStripMenuItem_Click);
            // 
            // home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(848, 453);
            this.Controls.Add(this.menuStrip);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "home";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inventario de Meta Games";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem providerMenu;
        private System.Windows.Forms.ToolStripMenuItem newProviderSubMenu;
        private System.Windows.Forms.ToolStripMenuItem registedProvidersSubMenu;
        private System.Windows.Forms.ToolStripMenuItem newCompanySubMenu;
        private System.Windows.Forms.ToolStripMenuItem registedCompaniesSubMenu;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStripMenuItem productosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevoProductoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productosRegistradosToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem nuevaCategoriaDeProductoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem categoriasDeProductoRegistradasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ventasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevaVentaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ventasRegistradasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem comprasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevaCompraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem comprasRegistradasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem promocionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevaPromociónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem promocionesRegistradasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem impuestosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevoImpuestoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem impuestosRegistradosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem empleadosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevoEmpleadoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem empleadosRegistradosToolStripMenuItem;
    }
}



