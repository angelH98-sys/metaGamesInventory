using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace metaGamesInventory
{
    public partial class home : Form
    {
        private int childFormNumber = 0;

        public home()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            CUProvider childForm = new CUProvider();
            childForm.MdiParent = this;
            childForm.Text = "Nuevo proveedor";
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RDCompany childForm = new RDCompany();
            childForm.MdiParent = this;
            childForm.Text = "Compañías registradas";
            childForm.Show();
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }
       

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void newCompanySubMenu_Click(object sender, EventArgs e)
        {
            CUCompany childForm = new CUCompany();
            childForm.MdiParent = this;
            childForm.Text = "Nueva compañía";
            childForm.Show();
        }

        private void ventasToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void nuevaCategoriaDeProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CUProductCategory childForm = new CUProductCategory();
            childForm.MdiParent = this;
            childForm.Text = "Nueva categoría de producto";
            childForm.Show();
        }

        private void categoriasDeProductoRegistradasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RDProductCategory childForm = new RDProductCategory();
            childForm.MdiParent = this;
            childForm.Text = "Categorias de productos registrados";
            childForm.Show();
        }

        private void nuevoProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CUProduct childForm = new CUProduct();
            childForm.MdiParent = this;
            childForm.Text = "Nuevo producto";
            childForm.Show();
        }

        private void productosRegistradosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RDProduct childForm = new RDProduct();
            childForm.MdiParent = this;
            childForm.Text = "Productos registrados";
            childForm.Show();
        }

        private void EmpleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void NuevoEmpleadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CUEmployees childForm = new CUEmployees();
            childForm.MdiParent = this;
            childForm.Text = "Nuevo empleado";
            childForm.Show();
        }

        private void EmpleadosRegistradosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RDEmployees childForm = new RDEmployees();
            childForm.MdiParent = this;
            childForm.Text = "Empleados registrados";
            childForm.Show();
        }

        private void nuevaVentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CUSell childForm = new CUSell();
            childForm.MdiParent = this;
            childForm.Text = "Nueva Venta";
            childForm.Show();
        }

        private void ventasRegistradasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RDSell childForm = new RDSell();
            childForm.MdiParent = this;
            childForm.Text = "Ventas registradas";
            childForm.Show();
        }
    }
}
