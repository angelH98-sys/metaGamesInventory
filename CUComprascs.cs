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
    public partial class CUComprascs : Form
    {
        public CUComprascs()
        {
            InitializeComponent();
            loadTaxes();
            refreshDGV();
            loadDiscount();
            loadProvider();
        }

        public CUComprascs(orders oc, List<orders_product> opc)
        {
            orderToModify = oc;
            order = opc;
            InitializeComponent();
            loadTaxes();
            refreshDGV();
            loadDiscount();
            //txtcliente.Text = oc.third;
           
            dtpfecha.Value = (DateTime)oc.order_date;
            calculateTotal();
            loadProvider();
        }

        private void loadDiscount()
        {

            using (metaGamesInventoryAlterEntities DB = new metaGamesInventoryAlterEntities())
            {
                discounts = DB.discount.Where(d => d.start <= DateTime.Today.Date && d.ending >= DateTime.Today.Date).ToList<discount>();
            }
            foreach (var d in discounts)
            {
                cmbdescuento.Items.Add(d.name);
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

///----------------------------------------------
        private List<provider> providers;
        private provider providerSelected;
//--------------------------------------------------

        private void formatDGV()
        //Función encargada de establecer encabezados y ocultar columnas innecesarias de tablas del formulario
        {
            //Ocultamos los datos innecesarios
            dgvinventario.Columns[0].Visible = false;
            dgvinventario.Columns[3].Visible = false;
            dgvinventario.Columns[4].Visible = false;
            dgvinventario.Columns[6].Visible = false;
            dgvinventario.Columns[7].Visible = false;
            dgvinventario.Columns[8].Visible = false;
            dgvinventario.Columns[9].Visible = false;
            dgvinventario.Columns[10].Visible = false;

            //Renombreamos las columnas
            dgvinventario.Columns[1].HeaderText = "Nombre";
            dgvinventario.Columns[2].HeaderText = "Precio";
            dgvinventario.Columns[5].HeaderText = "Stock";

            dgvOrdenes.ColumnCount = 5;//Establecemos el número de columnas que contará la tabla de ordenes

            //Renombramos las columnas
            dgvOrdenes.Columns[0].HeaderText = "Producto";
            dgvOrdenes.Columns[1].HeaderText = "Precio";
            dgvOrdenes.Columns[2].HeaderText = "Cantidad";
            dgvOrdenes.Columns[3].HeaderText = "Descuento";
            dgvOrdenes.Columns[4].HeaderText = "Total";

            //Ocultamos los datos innecesarios
            dgvImpuestos.Columns[0].Visible = false;
            dgvImpuestos.Columns[3].Visible = false;
            dgvImpuestos.Columns[4].Visible = false;

            //Renombramos las columnas
            dgvImpuestos.Columns[1].HeaderText = "Nombre";
            dgvImpuestos.Columns[2].HeaderText = "Porcentaje";
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
                foreach (var o in ot)
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
                    cmbimpuestos.Items.Add(t.name);
                }
            }
        }

        private void dgvinventario_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = false;
        }

        private void dgvinventario_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Identificamos el producto seleccionado en el dgvInventory para su registro en la orden
            selected = new orders_product();
            try
            {
                product productSelected = inventory.ElementAt<product>(e.RowIndex);
                //Añadimos el valor del id del producto seleccionado
                selected.id_product = productSelected.id;

                //Seteamos el detalle del producto en los controles del formulario
                txtnompro.Text = productSelected.name;
                txtexistencia.Text = productSelected.stock.ToString();

                numprecuni.Value = (decimal)productSelected.price;
               // numcant.Maximum = (decimal)productSelected.stock;
                numcant.Value = 1;
                btn_Ordenar_Compra.Enabled = true;
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
            txtnompro.Text = "";
            txtexistencia.Text = "";
            numprecuni.Value = 0;
            numcant.Value = 1;
            cmbdescuento.Text = "";
            isModify = false;
            btn_Ordenar_Compra.Enabled = false;
            btnModificar.Enabled = false;
            btnEliminar.Enabled = false;

            //------aqui modifique--------------------------------------------------------------------------------------------------------------------------------------------------
            
        }

        private void btn_Ordenar_Compra_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtnompro.Text))
            {

                MessageBox.Show("Debe Selecionar un Producto");

                return;
            }
            if (!isModify)
            {
                selected.unit_price = (double)numprecuni.Value;
                selected.quantity = (int)numcant.Value;
                selected.amount_discount = 0;
                if (cmbdescuento.Text != "")
                {
                    selected.id_discount = discounts.ElementAt<discount>(cmbdescuento.SelectedIndex).id;
                    selected.amount_discount = (double)numcant.Value * (double)numprecuni.Value * discounts.ElementAt<discount>(cmbdescuento.SelectedIndex).percentage / 100;
                    selected.amount_discount = Math.Round((double)selected.amount_discount, 2);
                    
                }
                //aqui modifique en la noche
                
                //
                selected.subtotal = (double)(numcant.Value * numprecuni.Value) - selected.amount_discount; //aqui cambie signo tenia -
                order.Add(selected);//Añadimos los datos del producto a la lista de orden
            }
            else
            {
                order.Where(d => d.id_product == selected.id_product).First().quantity = (int)numcant.Value;
                order.Where(d => d.id_product == selected.id_product).First().unit_price = (double)numprecuni.Value;
                double amount = 0;
                if (cmbdescuento.Text != "")
                {
                    amount = (double)numcant.Value * (double)numprecuni.Value * discounts.ElementAt<discount>(cmbdescuento.SelectedIndex).percentage / 100;
                    order.Where(d => d.id_product == selected.id_product).First().id_discount = discounts.ElementAt<discount>(cmbdescuento.SelectedIndex).id;
                    order.Where(d => d.id_product == selected.id_product).First().amount_discount = amount;
                    order.Where(d => d.id_product == selected.id_product).First().amount_discount = Math.Round((double)amount, 2);
                }
                else
                {
                    order.Where(d => d.id_product == selected.id_product).First().id_discount = null;
                }
                order.Where(d => d.id_product == selected.id_product).First().subtotal = (double)(numprecuni.Value * numcant.Value) - amount; //aqui cambie signo esto sirve para no sume el descuento no tocar
            }
            refreshDGV();//Refrescamos los datos de las tablas
            restartControls();
            calculateTotal();
        }

        // verificar aqui lo de las ordenes
        private void refreshDGV()
        {
            dgvImpuestos.DataSource = null;
            dgvImpuestos.DataSource = taxesSelected;
            //prueba------------------------------------------------------------------------

            //Limpiamos los datos de las tablas
            dgvOrdenes.Rows.Clear();
            dgvinventario.DataSource = null;
            dgvinventario.Rows.Clear();

            List<product> productList;

            using (metaGamesInventoryAlterEntities DB = new metaGamesInventoryAlterEntities())
            {
                productList = DB.product.ToList<product>();
            }

            inventory = productList;
            dgvinventario.DataSource = inventory;

            if (orderToModify != null)
            {
                dgvOrdenes.ColumnCount = 5;
            }
            foreach (var o in order)
            {
                string name = productList.Where(d => d.id == o.id_product).First().name;
                dgvOrdenes.Rows.Add(name, o.unit_price.ToString(), o.quantity.ToString(), o.amount_discount.ToString(), o.subtotal.ToString());
                inventory.Remove(inventory.Where(d => d.id == o.id_product).First());
            }

            dgvinventario.DataSource = inventory;
            selected = new orders_product();
            formatDGV();
        }

        private void dgvOrdenes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                selected = order.ElementAt<orders_product>(e.RowIndex);
                //modificando para probar error

               
                

                //

                btnModificar.Enabled = true;
                btnEliminar.Enabled = true;
            }
            catch
            {
                MessageBox.Show("Debe seleccionar el registro de un producto de la tabla.", "¡ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                restartControls();
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            //------------------------
            if (string.IsNullOrEmpty(txttotalsinimp.Text))
            {

                MessageBox.Show("Debe Selecionar una Orden");

                return;
            }

            //------------------------
            
            product p;
            using (metaGamesInventoryAlterEntities DB = new metaGamesInventoryAlterEntities())
            {
                p = DB.product.Where(d => d.id == selected.id_product).First();
                
            }

            txtnompro.Text = p.name;
            txtexistencia.Text = p.stock.ToString();

            numprecuni.Value = (decimal)selected.unit_price;
            numcant.Maximum = (decimal)p.stock;
            numcant.Value = (decimal)selected.quantity;
            btn_Ordenar_Compra.Enabled = true;
            isModify = true;
            
            
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            //------------------------------
            if (string.IsNullOrEmpty(txttotalsinimp.Text))
            {

                MessageBox.Show("Debe Selecionar una Orden");

                return;
            }

            //------------------------------

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

            foreach (var o in order)
            {
                untaxed = untaxed + (double)o.subtotal;
            }

            foreach (var t in taxesSelected)
            {
                percentage += t.percentage;
            }

            taxes = Math.Round(untaxed * (percentage / 100), 2);
            total = untaxed + taxes;
            txttotalsinimp.Text = untaxed.ToString();
            txtimpuesto.Text = taxes.ToString();
            txttotal.Text = total.ToString();
            if (total > 0)
            {
                btnProcesarCompra.Enabled = true;
            }
        }

        private void cmbimpuestos_SelectedIndexChanged(object sender, EventArgs e)
        {
            tax selected = taxes.ElementAt(cmbimpuestos.SelectedIndex);
            cmbimpuestos.Items.RemoveAt(cmbimpuestos.SelectedIndex);
            taxes.Remove(selected);
            taxesSelected.Add(selected);
            refreshDGV();
            calculateTotal();
        }

        private void dgvImpuestos_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = false;
        }

        private void btnProcesarCompra_Click(object sender, EventArgs e)
        {
            ///////////////////////////////// prueba validacion orden
            if (string.IsNullOrEmpty(txttotalsinimp.Text))
            {

                MessageBox.Show("Debe Selecionar una Orden");

                return;
            }

            //////////////////////

            if (orderToModify != null)
                {
                    modifyOrder();
                }
                else
                {
                    createCompra();
                }

                this.Close();
                RDCompras form = new RDCompras();
                form.MdiParent = metaGamesInventory.home.ActiveForm;
                form.Text = "Compras Registradas";
                form.Show();
           

        }

        private void createCompra()
        {
            using (metaGamesInventoryAlterEntities DB = new metaGamesInventoryAlterEntities())
            {
                

                orders oc = new orders();
                oc.order_date = dtpfecha.Value;
               
                oc.amount_untaxed = double.Parse(txttotalsinimp.Text);
                oc.amount_tax = double.Parse(txtimpuesto.Text);
                oc.amount_total = double.Parse(txttotal.Text);
                oc.transaction_type = "Compra";
                oc.order_state = "Borrador";
               // oc.third = txtcliente.Text; //aqui se debe guardar el provedor
                //Reemplazar con el id del empleado logeado
                oc.id_employee = 7;
                

                //-----------------------
                
                //-----------------------

                DB.orders.Add(oc);
                DB.SaveChanges();

                oc = DB.orders.ToList<orders>().Last();

                foreach (var op in order)
                {
                    op.id_order = oc.id;
                    DB.orders_product.Add(op);
                }

                foreach (var t in taxesSelected)
                {
                    orders_tax g = new orders_tax();
                    g.id_order = oc.id;
                    g.id_tax = t.id;

                    DB.orders_tax.Add(g);
                }

                DB.SaveChanges();

                MessageBox.Show("Compra registrada exitoxamente en estado borrador.", "Compra registrada", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void modifyOrder()
        {
            using (metaGamesInventoryAlterEntities DB = new metaGamesInventoryAlterEntities())
            {
                orderToModify.order_date = dtpfecha.Value;
                orderToModify.amount_untaxed = double.Parse(txttotalsinimp.Text);
                orderToModify.amount_tax = double.Parse(txtimpuesto.Text);
                orderToModify.amount_total = double.Parse(txttotal.Text);
                orderToModify.transaction_type = "Compra";
                orderToModify.order_state = "Borrador";
              //  orderToModify.third = txtcliente.Text;
                //Reemplazar con el id del empleado logeado
                orderToModify.id_employee = 6;

                DB.Entry(orderToModify).State = System.Data.Entity.EntityState.Modified;
                DB.SaveChanges();

                List<orders_product> dborders = DB.orders_product.ToList<orders_product>().Where(d => d.id_order == orderToModify.id).ToList<orders_product>();
                List<orders_tax> orderTaxesRegisted = DB.orders_tax.ToList<orders_tax>().Where(d => d.id_order == orderToModify.id).ToList<orders_tax>();

                foreach (var h in dborders)
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
                    orders_tax g = new orders_tax(); //tenia g le vamos a poner t para probar
                    g.id_order = orderToModify.id;
                    g.id_tax = t.id;

                    DB.orders_tax.Add(g);
                }

                DB.SaveChanges();

                MessageBox.Show("Compra fue modificada exitoxamente.", "Compra modificada", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void loadProvider()
        {
            using (metaGamesInventoryAlterEntities DB = new metaGamesInventoryAlterEntities())

                providers = DB.provider.ToList<provider>();

           

        }

        private void txtbuscarproducto_KeyUp(object sender, KeyEventArgs e)
        {
            string search = txtbuscarproducto.Text.ToLower();
            for (int i = 0; i < dgvinventario.RowCount; i++)
            {
                if (!dgvinventario.Rows[i].Cells[1].Value.ToString().ToLower().Contains(search))
                {
                    CurrencyManager cm = (CurrencyManager)BindingContext[dgvinventario.DataSource];
                    cm.SuspendBinding();
                    dgvinventario.Rows[i].Visible = false;
                }
                else
                {
                    dgvinventario.Rows[i].Visible = true;
                }
            }
        }
    }
}
