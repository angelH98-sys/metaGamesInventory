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
    public partial class RDDescuento : Form
    {
        public RDDescuento()
        {
            InitializeComponent();
        }

        List<discount> descuentos;//Listado de la tabla product de la base de datos
        discount selected;//Producto seleccionado del dgvData

        private void RDDescuento_Load(object sender, EventArgs e)
        {
            refresdgv();
        }

        private void refresdgv()
        {
            using (metaGamesInventoryAlterEntities BD = new metaGamesInventoryAlterEntities())
            //Establecemos un nuevo contexto de la base de datos
            {
                descuentos = BD.discount.ToList<discount>();//Obtenemos los registros de la tabla Product
                dgvdata.DataSource = descuentos;//Establecemos el origen de datos con la lista de productos del contexto
                                                //Establecemos los encabezados del dgvData
                dgvdata.Columns[0].Visible = false;
                dgvdata.Columns[1].HeaderText = "Nombre";
                dgvdata.Columns[2].HeaderText = "Porcentaje";
                //dgvdata.Columns[3].HeaderText = "Descripción";
                // dgvdata.Columns[4].HeaderText = "Mínimo de existencias";
                // dgvdata.Columns[5].HeaderText = "Cantidad en almacenes";
                //Ocultamos los campos de llaves foraneas
                dgvdata.Columns[3].HeaderText = "Fecha Inicio"; //Continene Inicio de fecha
                dgvdata.Columns[4].HeaderText = "Fecha Final"; //Contiene Final de fecha
                 dgvdata.Columns[5].Visible = false; //Contiene Order product
               
            }
        }

        private void dgvdata_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selected = descuentos.ElementAt<discount>(e.RowIndex);
            //Creamos un objeto con los datos de la celda seleccionada
            istDetail.Items.Clear();
            istDetail.Items.Add("Nombre:");
            istDetail.Items.Add("   " + selected.name);
            istDetail.Items.Add("------------------------------");
            istDetail.Items.Add("Porcentaje:");
            istDetail.Items.Add("   " + selected.percentage.ToString() + "%");
            istDetail.Items.Add("------------------------------");
            istDetail.Items.Add("Fecha Inicio:");
            istDetail.Items.Add("   " + selected.start);
            istDetail.Items.Add("------------------------------");
            istDetail.Items.Add("Fecha Final:");
            istDetail.Items.Add("   " + selected.ending);
        }

        //CTUALIZAR REGISTRO
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (selected != null)
            //Si acaso ha seleccionado un producto a actualizar
            {
                CUDescuentos form = new CUDescuentos(selected);
                form.Text = "Modificación de Descuento";
                form.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Debes seleccionar algún registro en la tabla de Descuentos para poder modificar sus datos",
                    "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //ELIMINAR REGISTRO

        private void btnEliminar_Click(object sender, EventArgs e)
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
                        istDetail.Items.Clear();

                        descuentos = BD.discount.ToList<discount>();//Asignamos los valores del contexto de la tabla Company al listado previamente declarado

                        refresdgv();
                    }
                }
            }
            else
            {
                MessageBox.Show("Debes seleccionar algún registro en la tabla de Descuentos para poder eliminar sus datos",
                    "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvdata_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = false;
        }

        private void btncrear_Click(object sender, EventArgs e)
        {
            CUDescuentos form = new CUDescuentos();
            form.Text = "Nuevo Descuento";
            form.Show();
            this.Close();
        }

        private void txtbuscar_KeyUp(object sender, KeyEventArgs e)
        {
            string search = txtbuscar.Text.ToLower();
            for (int i = 0; i < dgvdata.RowCount; i++)
            {
                if (!dgvdata.Rows[i].Cells[1].Value.ToString().ToLower().Contains(search))
                {
                    CurrencyManager cm = (CurrencyManager)BindingContext[dgvdata.DataSource];
                    cm.SuspendBinding();
                    dgvdata.Rows[i].Visible = false;
                }
                else
                {
                    dgvdata.Rows[i].Visible = true;
                }
            }
        }
    }
}
