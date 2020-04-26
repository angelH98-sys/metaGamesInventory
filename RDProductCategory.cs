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
    public partial class RDProductCategory : Form
    {
        public RDProductCategory()
        {
            InitializeComponent();
        }

        private void RDProductCategory_Load(object sender, EventArgs e)
        {
            refreshDGV();
        }
        List<product_category> categories;
        product_category selected;
        private void refreshDGV()
            //Método encargado de refrescar los datos del dgvData con los registros de la tabla product_category
        {
            using (metaGamesInventoryAlterEntities BD = new metaGamesInventoryAlterEntities())
                //Estableciendo el contexto de la base de datos
            {
                categories = BD.product_category.ToList<product_category>();
                //Asignamos los registros de la tabla a la lista categories
            }
            dgvData.DataSource = categories;//Establecemos el origen de datos del dgvData
            //Configuramos los encabezados del dgvData
            dgvData.Columns[1].HeaderText = "Nombre";
            dgvData.Columns[2].HeaderText = "Productos";
        }

        private void dgvData_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = false;
        }

        private void dgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selected = categories.ElementAt<product_category>(e.RowIndex);
            //Creamos un objeto con los datos de la celda seleccionada
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            CUProductCategory form = new CUProductCategory(selected);
            form.Text = "Modificación de categoría de producto";
            form.Show();
            this.Close();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            CUProductCategory form = new CUProductCategory();
            form.Text = "Nueva de categoría de producto";
            form.Show();
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var msg = MessageBox.Show("¿Esta seguro de querer eliminar el registro?", "¡Advertencia!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (msg == DialogResult.Yes)
            {
                using (metaGamesInventoryAlterEntities BD = new metaGamesInventoryAlterEntities())
                //Creamos un nuevo contexto en la base de datos
                {
                    BD.Entry(selected).State = System.Data.Entity.EntityState.Deleted;//Removemos el registro seleccionado del contexto
                    BD.SaveChanges();//Persistimos los cambios en la base de datos
                    MessageBox.Show("Registro eliminado exitosamente", "Operación exitosa", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    refreshDGV();
                }
            }
        }
    }
}
