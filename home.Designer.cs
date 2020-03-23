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
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.providerMenu});
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
            // home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(848, 453);
            this.Controls.Add(this.menuStrip);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "home";
            this.Text = "Inventario de Meta Games";
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
    }
}



