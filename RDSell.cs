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
    public partial class RDSell : Form
    {
        public RDSell()
        {
            InitializeComponent();
        }

        private List<orders> sells;
        private List<orders_product> orderProducts = new List<orders_product>();
        private List<tax> taxes = new List<tax>();

        private orders sellSelected;

        private void formatDGV()
        {
            dgvSell.Columns[0].HeaderText = "Fecha";
            dgvSell.Columns[1].HeaderText = "Monto sin impuestos";
            dgvSell.Columns[2].HeaderText = "Impuestos";
            dgvSell.Columns[3].HeaderText = "Total";
            dgvSell.Columns[4].HeaderText = "Estado";
            dgvSell.Columns[5].HeaderText = "Cliente";
            dgvSell.Columns[6].HeaderText = "Empleado";

            dgvProduct.Columns[0].HeaderText = "Nombre";
            dgvProduct.Columns[1].HeaderText = "Cantidad";
            dgvProduct.Columns[2].HeaderText = "Precio";
            dgvProduct.Columns[3].HeaderText = "Promoción";
            dgvProduct.Columns[4].HeaderText = "Porcentaje";
            dgvProduct.Columns[5].HeaderText = "Descuento";
            dgvProduct.Columns[6].HeaderText = "Total";

            dgvTax.Columns[0].HeaderText = "Nombre";
            dgvTax.Columns[1].HeaderText = "Porcentaje";
        }

        private void refreshDGV()
        {
            dgvSell.ColumnCount = 7;
            dgvProduct.ColumnCount = 7;
            dgvTax.ColumnCount = 2;

            List<employee> e;
            List<discount> di;
            List<product> pr;
            using (metaGamesInventoryAlterEntities DB = new metaGamesInventoryAlterEntities())
            {
                e = DB.employee.ToList<employee>();
                di = DB.discount.ToList<discount>();
                pr = DB.product.ToList<product>();
            }

            dgvSell.Rows.Clear();
            foreach (var s in sells)
            {
                dgvSell.Rows.Add(s.order_date.ToString(),
                    s.amount_untaxed.ToString(),
                    s.amount_tax.ToString(),
                    s.amount_total.ToString(),
                    s.order_state,
                    s.third,
                    e.Where(d => d.id == s.id_employee).First().name);
            }

            dgvProduct.Rows.Clear();
            foreach(var p in orderProducts)
            {
                string discountName = "-";
                string discountPercentage = "-";
                string discountAmount = "-";
                if (p.id_discount != null)
                {
                    discountName = di.Where(d => d.id == p.id_discount).First().name;
                    discountPercentage = di.Where(d => d.id == p.id_discount).First().percentage.ToString();
                    discountAmount = p.amount_discount.ToString();
                }
                dgvProduct.Rows.Add(pr.Where(d=> d.id == p.id_product).First().name,
                    p.quantity.ToString(),
                    p.unit_price.ToString(),
                    discountName,
                    discountPercentage,
                    discountAmount,
                    p.subtotal.ToString());
            }

            dgvTax.Rows.Clear();
            foreach(var t in taxes)
            {
                dgvTax.Rows.Add(t.name, t.percentage.ToString());
            }
            formatDGV();
        }

        private void fillTextBox()
        {
            dtpDate.Value = (DateTime)sellSelected.order_date;
            txtCustomer.Text = sellSelected.third;
            using (metaGamesInventoryAlterEntities DB = new metaGamesInventoryAlterEntities())
            {
                txtEmployee.Text = DB.employee.ToList<employee>().Where(d => d.id == sellSelected.id_employee).First().name;
            }
            txtUntaxed.Text = "$" + sellSelected.amount_untaxed.ToString();
            txtTaxes.Text = "$" + sellSelected.amount_tax.ToString();
            txtTotal.Text = "$" + sellSelected.amount_total.ToString();
        }

        private void RDSell_Load(object sender, EventArgs e)
        {
            using (metaGamesInventoryAlterEntities DB = new metaGamesInventoryAlterEntities())
            {
                sells = DB.orders.ToList<orders>().Where(d => d.transaction_type == "Venta").ToList<orders>();
            }
            refreshDGV();
        }

        private void dgvSell_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                sellSelected = sells.ElementAt<orders>(e.RowIndex);
                List<orders_tax> tax_order;
                List<tax> allTaxes;
                using (metaGamesInventoryAlterEntities DB = new metaGamesInventoryAlterEntities())
                {
                    orderProducts = DB.orders_product.ToList<orders_product>().Where(d => d.id_order == sellSelected.id).ToList<orders_product>();
                    tax_order = DB.orders_tax.ToList<orders_tax>().Where(d => d.id_order == sellSelected.id).ToList<orders_tax>();
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
                if(sellSelected.order_state == "Borrador")
                {
                    btnModify.Enabled = true;
                    btnDelete.Enabled = true;
                    btnApprove.Enabled = true;
                }
            }
            catch
            {
                return;
            }
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            this.Close();
            CUSell form = new CUSell(sellSelected, orderProducts);
            form.MdiParent = metaGamesInventory.home.ActiveForm;
            form.Text = "Modificación de venta";
            form.Show();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var msg = MessageBox.Show("¿Esta seguro de querer eliminar el registro?", "¡Advertencia!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (msg == DialogResult.Yes)
            {
                using (metaGamesInventoryAlterEntities DB = new metaGamesInventoryAlterEntities())
                {
                    foreach(var p in orderProducts)
                    {
                        DB.Entry(p).State = System.Data.Entity.EntityState.Deleted;
                    }
                    List<orders_tax> ot = DB.orders_tax.ToList<orders_tax>().Where(d => d.id_order == sellSelected.id).ToList<orders_tax>();
                    foreach(var t in ot)
                    {
                        DB.Entry(t).State = System.Data.Entity.EntityState.Deleted;
                    }
                    DB.Entry(sellSelected).State = System.Data.Entity.EntityState.Deleted;//Removemos el registro seleccionado del contexto
                    DB.SaveChanges();//Persistimos los cambios en la base de datos
                    MessageBox.Show("Registro eliminado exitosamente", "Operación exitosa", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    restartControls();
                    sells = DB.orders.ToList<orders>().Where(d => d.transaction_type == "Venta").ToList<orders>();
                    refreshDGV();
                }
            }
        }

        private void restartControls()
        {
            btnModify.Enabled = false;
            btnDelete.Enabled = false;
            btnApprove.Enabled = false;

            sellSelected = new orders();
            txtCustomer.Text = "";
            txtEmployee.Text = "";
            txtTaxes.Text = "";
            txtTotal.Text = "";
            txtUntaxed.Text = "";

            dtpDate.Value = DateTime.Today;
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            var msg = MessageBox.Show("¿Esta seguro de querer aprovar la venta seleccionada?", "¡Advertencia!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
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
                        if (singleProduct.stock >= p.quantity)
                        {
                            singleProduct.stock = singleProduct.stock - p.quantity; 
                            DB.Entry(singleProduct).State = System.Data.Entity.EntityState.Modified;
                        }
                        else
                        {
                            MessageBox.Show("Existencias en almacen insuficientes para el producto:" + singleProduct.name, "¡Producto insuficiente!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            restartControls();
                            return;
                        }
                    }
                    sellSelected.order_state = "Efectuada";
                    DB.Entry(sellSelected).State = System.Data.Entity.EntityState.Modified;
                    DB.SaveChanges();
                    MessageBox.Show("Venta efectuada exitosamente", "¡Operación exitosa!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    restartControls();
                    refreshDGV();
                }
            }
        }

        private void btnNewSell_Click(object sender, EventArgs e)
        {
            this.Close();
            CUSell form = new CUSell();
            form.MdiParent = metaGamesInventory.home.ActiveForm;
            form.Text = "Nueva Venta";
            form.Show();
        }
    }
}
