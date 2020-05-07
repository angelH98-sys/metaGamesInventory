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
    public partial class RDCompras : Form
    {
        public RDCompras()
        {
            InitializeComponent();
        }

        private List<orders> compras; //sells asi decia antes
        private List<orders_product> orderProducts = new List<orders_product>();
        private List<tax> taxes = new List<tax>();

        private orders compraSelected; //sellSelected

        private void formatDGV()
        {
            dgvCompra.Columns[0].HeaderText = "Fecha";
            dgvCompra.Columns[1].HeaderText = "Monto sin impuestos";
            dgvCompra.Columns[2].HeaderText = "Impuestos";
            dgvCompra.Columns[3].HeaderText = "Total";
            dgvCompra.Columns[4].HeaderText = "Estado";
          //  dgvCompra.Columns[5].HeaderText = "Cliente";
            dgvCompra.Columns[6].HeaderText = "Empleado";
                                                           dgvCompra.Columns[5].Visible = false;
            dgvProducto.Columns[0].HeaderText = "Nombre";
            dgvProducto.Columns[1].HeaderText = "Cantidad";
            dgvProducto.Columns[2].HeaderText = "Precio";
            dgvProducto.Columns[3].HeaderText = "Promoción";
            dgvProducto.Columns[4].HeaderText = "Porcentaje";
            dgvProducto.Columns[5].HeaderText = "Descuento";
            dgvProducto.Columns[6].HeaderText = "Total";

            dgvImpuestos.Columns[0].HeaderText = "Nombre";
            dgvImpuestos.Columns[1].HeaderText = "Porcentaje";
        }

        private void refreshDGV()
        {
           dgvCompra.ColumnCount = 7;
            dgvProducto.ColumnCount = 7;
            dgvImpuestos.ColumnCount = 2;

            List<employee> e;
            List<discount> di;
            List<product> pr;
            using (metaGamesInventoryAlterEntities DB = new metaGamesInventoryAlterEntities())
            {
                e = DB.employee.ToList<employee>();
                di = DB.discount.ToList<discount>();
                pr = DB.product.ToList<product>();
            }

            dgvCompra.Rows.Clear();
            foreach (var s in compras)
            {
                dgvCompra.Rows.Add(s.order_date.ToString(),
                    s.amount_untaxed.ToString(),
                    s.amount_tax.ToString(),
                    s.amount_total.ToString(),
                    s.order_state,
                    s.third,
                    e.Where(d => d.id == s.id_employee).First().name);
            }

            dgvProducto.Rows.Clear();
            foreach (var p in orderProducts)
            {
                string discountName = "-";
                string discountPercentage = "-";
                string discountAmount = "-";
                if (p.id_discount != null)
                {
                    discountName = di.Where(d => d.id == p.id_discount).First().name;
                    discountPercentage = di.Where(d => d.id == p.id_discount).First().percentage.ToString();
                    discountAmount = p.amount_discount.ToString();
                }//aqui estaba el codigo sin boton eliminar

                //Copiar este codigo para borrar datos
               
                    dgvProducto.Rows.Add(pr.Where(d => d.id == p.id_product).First().name,

                    p.quantity.ToString(),
                    p.unit_price.ToString(),
                    discountName,
                    discountPercentage,
                    discountAmount,
                    p.subtotal.ToString());
                    
                
                //Copiar este codigo para borrar datos


            }

            dgvImpuestos.Rows.Clear();
            foreach (var t in taxes)
            {
                dgvImpuestos.Rows.Add(t.name, t.percentage.ToString());
            }
            formatDGV();
        }


        private void fillTextBox()
        {
            dtpfecha.Value = (DateTime)compraSelected.order_date;
           // txtcliente.Text = compraSelected.third;
            using (metaGamesInventoryAlterEntities DB = new metaGamesInventoryAlterEntities())
            {
                txtEmpleado.Text = DB.employee.ToList<employee>().Where(d => d.id == compraSelected.id_employee).First().name;
            }
            txttotalSinImpuesto.Text = "$" + compraSelected.amount_untaxed.ToString();
            txtImpuestos.Text = "$" + compraSelected.amount_tax.ToString();
            txtTotal.Text = "$" + compraSelected.amount_total.ToString();
        }

        private void RDCompras_Load(object sender, EventArgs e)
        {
            using (metaGamesInventoryAlterEntities DB = new metaGamesInventoryAlterEntities())
            {
                compras = DB.orders.ToList<orders>().Where(d => d.transaction_type == "Compra").ToList<orders>();
            }
            refreshDGV();
        }

        private void dgvCompra_CellClick(object sender, DataGridViewCellEventArgs e)     //Creo que aqui podria cargar la lsita de proveedor
        {
            try
            {
                compraSelected = compras.ElementAt<orders>(e.RowIndex);
                List<orders_tax> tax_order;
                List<tax> allTaxes;
                using (metaGamesInventoryAlterEntities DB = new metaGamesInventoryAlterEntities())
                {
                    orderProducts = DB.orders_product.ToList<orders_product>().Where(d => d.id_order == compraSelected.id).ToList<orders_product>();
                    tax_order = DB.orders_tax.ToList<orders_tax>().Where(d => d.id_order == compraSelected.id).ToList<orders_tax>();
                    allTaxes = DB.tax.ToList<tax>();
                }
                taxes = new List<tax>();
                foreach (var t in tax_order)
                {
                    foreach (var tt in allTaxes)
                    {
                        if (t.id_tax == tt.id)
                        {
                            taxes.Add(tt);
                        }
                    }
                }
                refreshDGV();
                fillTextBox();
                if (compraSelected.order_state == "Borrador")
                {
                    btn_modificar.Enabled = true;
                    botoneliminar.Enabled = true;
                    btn_Aprobar.Enabled = true;
                }
                else
                {
                    btn_modificar.Enabled = false;
                    btn_Aprobar.Enabled = false;
                    botoneliminar.Enabled = false;
                }
            }
            catch
            {
                return;
            }
        }

        private void btn_modificar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtEmpleado.Text))
            {

                MessageBox.Show("Debe Selecionar una Compra");

                return;
            }

            this.Close();
            CUComprascs form = new CUComprascs (compraSelected, orderProducts);
            form.MdiParent = metaGamesInventory.home.ActiveForm;
            form.Text = "Modificación de venta";
            form.Show();

            //---------PRUEBA ANTES DE ENTREGAR---------------------------------------------------------------------------------------------------------------------------------------------
            //refreshDGV();
            //fillTextBox();
            //---------------------------------------------------------------------------------
           
        }

        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            
        }

        private void restartControls()
        {
            btn_modificar.Enabled = false;
           // btn_Eliminar.Enabled = false;
            btn_Aprobar.Enabled = false;

            compraSelected = new orders();
           // txtcliente.Text = "";
            txtEmpleado.Text = "";
            txtImpuestos.Text = "";
            txtTotal.Text = "";
            txttotalSinImpuesto.Text = "";

            dtpfecha.Value = DateTime.Today;
        }

        private void btn_Aprobar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtEmpleado.Text))
            {

                MessageBox.Show("Debe Selecionar una Compra");

                return;
            }

            var msg = MessageBox.Show("¿Esta seguro de querer aprovar la compra seleccionada?", "¡Advertencia!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (msg == DialogResult.Yes)
            {
                List<product> inventory;
                using (metaGamesInventoryAlterEntities DB = new metaGamesInventoryAlterEntities())
                {
                    inventory = DB.product.ToList<product>();

                    product singleProduct;
                    foreach (var p in orderProducts)
                    {
                        singleProduct = inventory.Where(d => d.id == p.id_product).First();
                       
                            singleProduct.stock = singleProduct.stock + p.quantity;//aqui modifique para que sume en lugar de restar sume
                            DB.Entry(singleProduct).State = System.Data.Entity.EntityState.Modified;
                       
                    }
                   
                        compraSelected.order_state = "Efectuada";
                    DB.Entry(compraSelected).State = System.Data.Entity.EntityState.Modified;
                    DB.SaveChanges();
                    MessageBox.Show("Compra efectuada exitosamente", "¡Operación exitosa!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    restartControls();
                    refreshDGV();
                }
            }
        }

        private void btn_Nueva_Compra_Click(object sender, EventArgs e)
        {
            this.Close();
            CUComprascs form = new CUComprascs();
            form.MdiParent = metaGamesInventory.home.ActiveForm;
            form.Text = "Nueva Compra";
            form.Show();
        }

        private void botoneliminar_Click(object sender, EventArgs e)
        {
            var msg = MessageBox.Show("¿Esta seguro de querer eliminar el registro?", "¡Advertencia!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (msg == DialogResult.Yes)
            {
                using (metaGamesInventoryAlterEntities DB = new metaGamesInventoryAlterEntities())
                {
                    foreach (var p in orderProducts)
                    {
                        DB.Entry(p).State = System.Data.Entity.EntityState.Deleted;
                    }
                    List<orders_tax> ot = DB.orders_tax.ToList<orders_tax>().Where(d => d.id_order == compraSelected.id).ToList<orders_tax>();
                    foreach (var t in ot)
                    {
                        DB.Entry(t).State = System.Data.Entity.EntityState.Deleted;
                    }
                    DB.Entry(compraSelected).State = System.Data.Entity.EntityState.Deleted;//Removemos el registro seleccionado del contexto
                    DB.SaveChanges();//Persistimos los cambios en la base de datos
                    MessageBox.Show("Registro eliminado exitosamente", "Operación exitosa", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    restartControls();
                    compras = DB.orders.ToList<orders>().Where(d => d.transaction_type == "Compra").ToList<orders>();
                    refreshDGV();
                }
            }//Este boton se agrego como ultimo
        }
    }
}
