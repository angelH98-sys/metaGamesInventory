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
    public partial class RDProduct : Form
    {
        public RDProduct()
        {
            InitializeComponent();
        }
        List<product> products;//Listado de la tabla product de la base de datos
        product selected;//Producto seleccionado del dgvData

        private void RDProduct_Load(object sender, EventArgs e)
            //Establecer los datos en la tabla dgvData
        {
            refreshDGV();
        }

        private void refreshDGV()
            //Método encargado de la actualización de los datos mostrados en dgvData
        {
            using (metaGamesInventoryAlterEntities BD = new metaGamesInventoryAlterEntities())
                //Establecemos un nuevo contexto de la base de datos
            {
                products = BD.product.ToList<product>();//Obtenemos los registros de la tabla Product
                dgvData.DataSource = products;//Establecemos el origen de datos con la lista de productos del contexto
                                              //Establecemos los encabezados del dgvData
                dgvData.Columns[1].HeaderText = "Nombre";
                dgvData.Columns[2].HeaderText = "Precio unitario";
                dgvData.Columns[3].HeaderText = "Descripción";
                dgvData.Columns[4].HeaderText = "Mínimo de existencias";
                dgvData.Columns[5].HeaderText = "Cantidad en almacenes";
                //Ocultamos los campos de llaves foraneas
                dgvData.Columns[6].Visible = false;
                dgvData.Columns[7].Visible = false;
                dgvData.Columns[8].Visible = false;
                dgvData.Columns[9].Visible = false;
                dgvData.Columns[10].Visible = false;
            }
            
        }

        private void dgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selected = products.ElementAt<product>(e.RowIndex);
            //Creamos un objeto con los datos de la celda seleccionada
            lstDetail.Items.Clear();
            lstDetail.Items.Add("Nombre:");
            lstDetail.Items.Add("   " + selected.name);
            lstDetail.Items.Add("------------------------------");
            lstDetail.Items.Add("Precio unitario:");
            lstDetail.Items.Add("   $" + selected.price.ToString());
            lstDetail.Items.Add("------------------------------");
            lstDetail.Items.Add("Mínimo de existencias:");
            lstDetail.Items.Add("   " + selected.minimum_quantity.ToString() + " unidad(es)");
            lstDetail.Items.Add("------------------------------");
            lstDetail.Items.Add("Cantidad en almacenes:");
            lstDetail.Items.Add("   " + selected.stock.ToString() + " unidad(es)");
            lstDetail.Items.Add("------------------------------");
            using (metaGamesInventoryAlterEntities BD = new metaGamesInventoryAlterEntities())
                //Creamos un nuevo contexto de la base de datos
            {
                lstDetail.Items.Add("Proveedor:");
                //Obtenemos el nombre del proveedor del producto
                string provider = BD.provider.Where(d => d.id == selected.id_provider).First().name;
                lstDetail.Items.Add("   " + provider);
                lstDetail.Items.Add("------------------------------");
                lstDetail.Items.Add("Categoría:");
                //Obtenemos el nombre de la categoría a la que pertenece el producto
                string category = BD.product_category.Where(d => d.id == selected.id_product_category).First().name;
                lstDetail.Items.Add("   " + category);
                lstDetail.Items.Add("------------------------------");
            }
            lstDetail.Items.Add("Descripción:");
            lstDetail.Items.Add("   " + selected.product_description);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if(selected != null)
                //Si acaso ha seleccionado un producto a actualizar
            {
                CUProduct form = new CUProduct(selected);
                form.Text = "Modificación de producto";
                form.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Debes seleccionar algún registro en la tabla de productos para poder modificar sus datos",
                    "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selected != null)
                //Si acaso ha seleccionado un producto a eliminar
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
                        lstDetail.Items.Clear();

                        products = BD.product.ToList<product>();//Asignamos los valores del contexto de la tabla Company al listado previamente declarado

                        refreshDGV();
                    }
                }
            }
            else
            {
                MessageBox.Show("Debes seleccionar algún registro en la tabla de productos para poder eliminar sus datos",
                    "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvData_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = false;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            CUProduct form = new CUProduct();
            form.Text = "Nuevo producto";
            form.Show();
            this.Close();
        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            string search = txtSearch.Text.ToLower();
            for(int i = 0; i < dgvData.RowCount; i++)
            {
                if (!dgvData.Rows[i].Cells[1].Value.ToString().ToLower().Contains(search))
                {
                    CurrencyManager cm = (CurrencyManager)BindingContext[dgvData.DataSource];
                    cm.SuspendBinding();
                    dgvData.Rows[i].Visible = false;
                }
                else
                {
                    dgvData.Rows[i].Visible = true;
                }
            }
        }
    }
}
