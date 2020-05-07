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
    public partial class CUSell : Form
    {
        public CUSell()
        {
            InitializeComponent();
            loadTaxes();
            refreshDGV();
            loadDiscount();
        }

        public CUSell(orders o, List<orders_product> op)
        {
            orderToModify = o;
            order = op;
            InitializeComponent();
            loadTaxes();
            refreshDGV();
            loadDiscount();
            txtCustomer.Text = o.third;
            dtpSellDate.Value = (DateTime)o.order_date;
            calculateTotal();
        }

        private void loadDiscount()
        {
            using (metaGamesInventoryAlterEntities DB = new metaGamesInventoryAlterEntities())
            {
                discounts = DB.discount.Where(d=> d.start <= DateTime.Today.Date && d.ending >= DateTime.Today.Date).ToList<discount>();
            }
            foreach(var d in discounts)
            {
                cmbDiscount.Items.Add(d.name);
            }

        }

        private orders orderToModify;
        private List<product> inventory;//Listado de productos registrados en base de datos
        private List<orders_product> order = new List<orders_product>();//Listado de productos a vender
        private List<tax> taxes;
        private List<tax> taxesSelected = new List<tax>();
        private List<discount> discounts;
        private tax taxSelected;
        private orders_product selected;//Producto seleccionado para su edición de orden
        private bool isModify = false;//Indicativo si la operación es una adición o una modificación de un articulo especifico en la orden

        private void formatDGV()
            //Función encargada de establecer encabezados y ocultar columnas innecesarias de tablas del formulario
        {
            //Ocultamos los datos innecesarios
            dgvInventory.Columns[0].Visible = false;
            dgvInventory.Columns[3].Visible = false;
            dgvInventory.Columns[4].Visible = false;
            dgvInventory.Columns[6].Visible = false;
            dgvInventory.Columns[7].Visible = false;
            dgvInventory.Columns[8].Visible = false;
            dgvInventory.Columns[9].Visible = false;
            dgvInventory.Columns[10].Visible = false;

            //Renombreamos las columnas
            dgvInventory.Columns[1].HeaderText = "Nombre";
            dgvInventory.Columns[2].HeaderText = "Precio";
            dgvInventory.Columns[5].HeaderText = "Stock";

            dgvOrder.ColumnCount = 5;//Establecemos el número de columnas que contará la tabla de ordenes

            //Renombramos las columnas
            dgvOrder.Columns[0].HeaderText = "Producto";
            dgvOrder.Columns[1].HeaderText = "Precio";
            dgvOrder.Columns[2].HeaderText = "Cantidad";
            dgvOrder.Columns[3].HeaderText = "Descuento";
            dgvOrder.Columns[4].HeaderText = "Total";
            
            //Ocultamos los datos innecesarios
            dgvTax.Columns[0].Visible = false;
            dgvTax.Columns[3].Visible = false;
            dgvTax.Columns[4].Visible = false;

            //Renombramos las columnas
            dgvTax.Columns[1].HeaderText = "Nombre";
            dgvTax.Columns[2].HeaderText = "Porcentaje";
        }

        private void loadTaxes()
        {
            using (metaGamesInventoryAlterEntities DB = new metaGamesInventoryAlterEntities())
            {
                taxes = DB.tax.ToList<tax>();
            }

            if (orderToModify != null)
            {
                List<orders_tax> ot;
                using (metaGamesInventoryAlterEntities DB = new metaGamesInventoryAlterEntities())
                {
                    ot = DB.orders_tax.ToList<orders_tax>().Where(d => d.id_order == orderToModify.id).ToList<orders_tax>();
                }
                foreach(var o in ot)
                {
                    tax t = taxes.Where(d => d.id == o.id_tax).First();
                    taxes.Remove(t);
                    taxesSelected.Add(t);
                }
            }
            else
            {
                foreach (var t in taxes)
                {
                    cmbTax.Items.Add(t.name);
                }
            }
        }

        private void dgvInventory_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = false;
        }

        private void dgvInventory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Identificamos el producto seleccionado en el dgvInventory para su registro en la orden
            selected = new orders_product();
            isModify = false;
            try
            {
                product productSelected = inventory.ElementAt<product>(e.RowIndex);
                //Añadimos el valor del id del producto seleccionado
                selected.id_product = productSelected.id;

                //Seteamos el detalle del producto en los controles del formulario
                txtName.Text = productSelected.name;
                txtStock.Text = productSelected.stock.ToString();

                nudPrice.Value = (decimal)productSelected.price;
                nudQuantity.Maximum = (decimal)productSelected.stock;
                nudQuantity.Value = 1;
                btnToOrder.Enabled = true;
            }
            catch
            {
                MessageBox.Show("Debe seleccionar el registro de un producto de la tabla.", "¡ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                restartControls();
            }
        }

        private void restartControls()
        {
            selected = new orders_product();
            txtName.Text = "";
            txtStock.Text = "";
            nudPrice.Value = 0;
            nudQuantity.Value = 1;
            cmbDiscount.Text = "";
            isModify = false;
            btnToOrder.Enabled = false;
            btnModify.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void btnToOrder_Click(object sender, EventArgs e)
        {
            if (!isModify)
            {
                selected.unit_price = (double)nudPrice.Value;
                selected.quantity = (int)nudQuantity.Value;
                selected.amount_discount = 0;
                if(cmbDiscount.Text != "")
                {
                    selected.id_discount = discounts.ElementAt<discount>(cmbDiscount.SelectedIndex).id;
                    selected.amount_discount = (double)nudQuantity.Value * (double)nudPrice.Value * discounts.ElementAt<discount>(cmbDiscount.SelectedIndex).percentage / 100;
                    selected.amount_discount = Math.Round((double)selected.amount_discount, 2);
                }
                selected.subtotal = (double)(nudQuantity.Value * nudPrice.Value) - selected.amount_discount;
                order.Add(selected);//Añadimos los datos del producto a la lista de orden
            }
            else
            {
                order.Where(d => d.id_product == selected.id_product).First().quantity = (int)nudQuantity.Value;
                order.Where(d => d.id_product == selected.id_product).First().unit_price = (double)nudPrice.Value;
                double amount = 0;
                if (cmbDiscount.Text != "")
                {
                    amount = (double)nudQuantity.Value * (double)nudPrice.Value * discounts.ElementAt<discount>(cmbDiscount.SelectedIndex).percentage / 100;
                    order.Where(d => d.id_product == selected.id_product).First().id_discount = discounts.ElementAt<discount>(cmbDiscount.SelectedIndex).id;
                    order.Where(d => d.id_product == selected.id_product).First().amount_discount = amount;
                    order.Where(d => d.id_product == selected.id_product).First().amount_discount = Math.Round((double)amount, 2);
                }
                else
                {
                    order.Where(d => d.id_product == selected.id_product).First().id_discount = null;
                }
                order.Where(d => d.id_product == selected.id_product).First().subtotal = (double)(nudPrice.Value * nudQuantity.Value) - amount;
            }
            refreshDGV();//Refrescamos los datos de las tablas
            restartControls();
            calculateTotal();
        }

        
        private void refreshDGV()
            //Establece los valores de los dgv segun las listas inventory, order y tax
        {
            dgvTax.DataSource = null;
            dgvTax.DataSource = taxesSelected;

            //Limpiamos los datos de las tablas
            dgvOrder.Rows.Clear();
            dgvInventory.DataSource = null;
            dgvInventory.Rows.Clear();

            List<product> productList;

            using (metaGamesInventoryAlterEntities DB = new metaGamesInventoryAlterEntities())
            {
                productList = DB.product.ToList<product>();
            }
            
            inventory = productList;
            dgvInventory.DataSource = inventory;

            if(orderToModify != null)
            {
                dgvOrder.ColumnCount = 5;
            }
            foreach (var o in order)
            {
                string name = productList.Where(d => d.id == o.id_product).First().name;
                dgvOrder.Rows.Add(name, o.unit_price.ToString(), o.quantity.ToString(), o.amount_discount.ToString(), o.subtotal.ToString());
                inventory.Remove(inventory.Where(d => d.id == o.id_product).First());
            }

            dgvInventory.DataSource = inventory;
            selected = new orders_product();
            formatDGV();
        }

        private void dgvOrder_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                selected = order.ElementAt<orders_product>(e.RowIndex);
                
                btnModify.Enabled = true;
                btnDelete.Enabled = true;
            }
            catch
            {
                MessageBox.Show("Debe seleccionar el registro de un producto de la tabla.", "¡ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                restartControls();
            }
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            product p;
            using (metaGamesInventoryAlterEntities DB = new metaGamesInventoryAlterEntities())
            {
                p = DB.product.Where(d => d.id == selected.id_product).First();
            }

            txtName.Text = p.name;
            txtStock.Text = p.stock.ToString();

            nudPrice.Value = (decimal)selected.unit_price;
            nudQuantity.Maximum = (decimal)p.stock;
            nudQuantity.Value = (decimal)selected.quantity;
            btnToOrder.Enabled = true;
            isModify = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var msg = MessageBox.Show("¿Esta seguro de querer eliminar el producto de la orden?", "¡Advertencia!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (msg == DialogResult.Yes)
            {
                order.Remove(selected);
                refreshDGV();//Refrescamos los datos de las tablas
                restartControls();
                calculateTotal();
            }
        }

        private void calculateTotal()
        {
            double untaxed = 0;
            double taxes = 0;
            double total = 0;
            double percentage = 0;

            foreach(var o in order)
            {
                untaxed = untaxed + (double)o.subtotal;
            }
            
            foreach(var t in taxesSelected)
            {
                percentage += t.percentage;
            }
            
            taxes = Math.Round(untaxed * (percentage / 100),2);
            total = untaxed + taxes;
            txtUntaxed.Text = untaxed.ToString();
            txtTaxes.Text = taxes.ToString();
            txtTotal.Text = total.ToString();
            if(total > 0)
            {
                btnSend.Enabled = true;
            }
        }

        private void cmbTax_SelectedIndexChanged(object sender, EventArgs e)
        {
            tax selected = taxes.ElementAt(cmbTax.SelectedIndex);
            cmbTax.Items.RemoveAt(cmbTax.SelectedIndex);
            taxes.Remove(selected);
            taxesSelected.Add(selected);
            refreshDGV();
            calculateTotal();
        }

        private void dgvTax_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = false;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if(orderToModify != null)
            {
                modifyOrder();
            }
            else
            {
                createSell();
            }

            this.Close();
            RDSell form = new RDSell();
            form.MdiParent = metaGamesInventory.home.ActiveForm;
            form.Text = "Ventas registradas";
            form.Show();
        }

        private void createSell()
        {
            using (metaGamesInventoryAlterEntities DB = new metaGamesInventoryAlterEntities())
            {
                orders o = new orders();
                o.order_date = dtpSellDate.Value;
                o.amount_untaxed = double.Parse(txtUntaxed.Text);
                o.amount_tax = double.Parse(txtTaxes.Text);
                o.amount_total = double.Parse(txtTotal.Text);
                o.transaction_type = "Venta";
                o.order_state = "Borrador";
                o.third = txtCustomer.Text;
                //Reemplazar con el id del empleado logeado
                o.id_employee = 6;

                DB.orders.Add(o);
                DB.SaveChanges();

                o = DB.orders.ToList<orders>().Last();

                foreach(var op in order)
                {
                    op.id_order = o.id;
                    DB.orders_product.Add(op);
                }

                foreach(var t in taxesSelected)
                {
                    orders_tax g = new orders_tax();
                    g.id_order = o.id;
                    g.id_tax = t.id;

                    DB.orders_tax.Add(g);
                }

                DB.SaveChanges();

                MessageBox.Show("Venta registrada exitoxamente en estado borrador.", "Venta registrada", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void modifyOrder()
        {
            using (metaGamesInventoryAlterEntities DB = new metaGamesInventoryAlterEntities())
            {
                orderToModify.order_date = dtpSellDate.Value;
                orderToModify.amount_untaxed = double.Parse(txtUntaxed.Text);
                orderToModify.amount_tax = double.Parse(txtTaxes.Text);
                orderToModify.amount_total = double.Parse(txtTotal.Text);
                orderToModify.transaction_type = "Venta";
                orderToModify.order_state = "Borrador";
                orderToModify.third = txtCustomer.Text;
                //Reemplazar con el id del empleado logeado
                orderToModify.id_employee = 6;

                DB.Entry(orderToModify).State = System.Data.Entity.EntityState.Modified;
                DB.SaveChanges();

                List<orders_product> dborders = DB.orders_product.ToList<orders_product>().Where(d => d.id_order == orderToModify.id).ToList<orders_product>();
                List<orders_tax> orderTaxesRegisted = DB.orders_tax.ToList<orders_tax>().Where(d => d.id_order == orderToModify.id).ToList<orders_tax>();

                foreach(var h in dborders)
                {
                    DB.Entry(h).State = System.Data.Entity.EntityState.Deleted;
                }
                foreach (var h in orderTaxesRegisted)
                {
                    DB.Entry(h).State = System.Data.Entity.EntityState.Deleted;
                }
                DB.SaveChanges();

                foreach (var op in order)
                {
                    op.id_order = orderToModify.id;
                    DB.orders_product.Add(op);
                }

                foreach (var t in taxesSelected)
                {
                    orders_tax g = new orders_tax();
                    g.id_order = orderToModify.id;
                    g.id_tax = t.id;

                    DB.orders_tax.Add(g);
                }

                DB.SaveChanges();

                MessageBox.Show("Venta fue modificada exitoxamente.", "Venta modificada", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            string search = txtSearch.Text.ToLower();
            for (int i = 0; i < dgvInventory.RowCount; i++)
            {
                if(dgvInventory.Rows[i].Cells[1].Value != null)
                {
                    if (!dgvInventory.Rows[i].Cells[1].Value.ToString().ToLower().Contains(search))
                    {
                        CurrencyManager cm = (CurrencyManager)BindingContext[dgvInventory.DataSource];
                        cm.SuspendBinding();
                        dgvInventory.Rows[i].Visible = false;
                    }
                    else
                    {
                        dgvInventory.Rows[i].Visible = true;
                    }
                }
            }
        }
    }
}
