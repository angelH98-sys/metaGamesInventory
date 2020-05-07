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
    public partial class RDImpuestos : Form
    {
        public RDImpuestos()
        {
            InitializeComponent();
        }

        List<tax> impuestos ;//Listado de la tabla tax de la base de datos
        tax selected;//tax seleccionado del dgvData

        private void RDImpuestos_Load(object sender, EventArgs e)
        {
            refresdgv();
        }

        private void refresdgv()
        {
            using (metaGamesInventoryAlterEntities BD = new metaGamesInventoryAlterEntities())
            //Establecemos un nuevo contexto de la base de datos
            {
                impuestos = BD.tax.ToList<tax>();//Obtenemos los registros de la tabla Product
                dgvdata.DataSource = impuestos;//Establecemos el origen de datos con la lista de productos del contexto
                                              //Establecemos los encabezados del dgvData
                dgvdata.Columns[1].HeaderText = "Nombre";
                dgvdata.Columns[2].HeaderText = "Porcentaje";
                dgvdata.Columns[0].Visible = false;
               //dgvdata.Columns[3].HeaderText = "Descripción";
               // dgvdata.Columns[4].HeaderText = "Mínimo de existencias";
               // dgvdata.Columns[5].HeaderText = "Cantidad en almacenes";
                //Ocultamos los campos de llaves foraneas
                dgvdata.Columns[3].Visible = false;
                dgvdata.Columns[4].Visible = false;
               // dgvdata.Columns[8].Visible = false;
               // dgvdata.Columns[9].Visible = false;
              //  dgvdata.Columns[10].Visible = false;
            }
        }

        private void dgvdata_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selected = impuestos.ElementAt<tax>(e.RowIndex);
            //Creamos un objeto con los datos de la celda seleccionada
            istDetail.Items.Clear();
            istDetail.Items.Add("Nombre:");
            istDetail.Items.Add("   " + selected.name);        
            istDetail.Items.Add("------------------------------");
            istDetail.Items.Add("Porcentaje:");
            istDetail.Items.Add("   " + selected.percentage.ToString() + " unidad(es)");
            istDetail.Items.Add("------------------------------");
            
        }

        private void button2_Click(object sender, EventArgs e)
        {//Boton actualizar

            if (selected != null)
            //Si acaso ha seleccionado un producto a actualizar
            {
                CUImpuestos form = new CUImpuestos(selected);
                form.Text = "Modificación de Impuesto";
                form.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Debes seleccionar algún registro en la tabla de Impuestos para poder modificar sus datos",
                    "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btneliminar_Click(object sender, EventArgs e)
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

                        impuestos = BD.tax.ToList<tax>();//Asignamos los valores del contexto de la tabla Company al listado previamente declarado

                        refresdgv();
                    }
                }
            }
            else
            {
                MessageBox.Show("Debes seleccionar algún registro en la tabla de productos para poder eliminar sus datos",
                    "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvdata_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = false;
        }

        //para crear nuevo
        private void btnnuevo_Click(object sender, EventArgs e)
        {
            CUImpuestos form = new CUImpuestos();
            form.Text = "Nuevo Impuestos";
            form.Show();
            this.Close();
        }

        //Para buscar

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
