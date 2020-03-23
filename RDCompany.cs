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
    public partial class RDCompany : Form
    {
        public RDCompany()
        {
            InitializeComponent();
        }
        List<company> companies;//Variable que almacena la lista de elementos dentro de la tabla Company
        company selected;//Variable que almacena un objeto de tipo Company, de acuerdo al registro del dgvData que seleccione
        private void RDCompany_Load(object sender, EventArgs e)
        {
            using (metaGamesInventoryAlterEntities BD = new metaGamesInventoryAlterEntities())//Creamos un nuevo contexto de la base de datos
            {
                companies = BD.company.ToList<company>();//Asignamos los valores del contexto de la tabla Company al listado previamente declarado
            }
            dgvData.DataSource = companies;//Establecemos un nuevo origen de datos para el dgvData
            //Editando el texto de los encabezados de la tabla
            dgvData.Columns[1].HeaderText = "Nombre";
            dgvData.Columns[2].HeaderText = "Dirección";
            dgvData.Columns[3].HeaderText = "E-mail";
            dgvData.Columns[4].HeaderText = "Teléfono";
            dgvData.Columns[5].HeaderText = "Proveedor";
        }

        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            selected = companies.ElementAt<company>(e.RowIndex);//Creamos un objeto con los datos de la celda seleccionada
            lstDetail.Items.Clear();
            //Mostramos los datos del objeto, añadiendolos en forma de items del lstDetail
            lstDetail.Items.Add("\nNombre: \n" + selected.name.ToString());
            lstDetail.Items.Add("\nDirección: \n" + selected.company_address.ToString());
            lstDetail.Items.Add("\nE-mail: \n" + selected.email.ToString());
            lstDetail.Items.Add("\nTeléfono: \n" + selected.phone.ToString());
        }

        private void dgvData_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = false;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            CUCompany form = new CUCompany(selected);
            form.Text = "Modificación de compañía";
            form.Show();
            this.Close();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            CUCompany form = new CUCompany();
            form.Text = "Nueva compañía";
            form.Show();
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var msg = MessageBox.Show("¿Esta seguro de querer eliminar el registro?", "¡Advertencia!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if(msg == DialogResult.Yes)
            {
                using (metaGamesInventoryAlterEntities BD = new metaGamesInventoryAlterEntities())
                    //Creamos un nuevo contexto en la base de datos
                {
                    BD.Entry(selected).State = System.Data.Entity.EntityState.Deleted;//Removemos el registro seleccionado del contexto
                    BD.SaveChanges();//Persistimos los cambios en la base de datos
                    MessageBox.Show("Registro eliminado exitosamente", "Operación exitosa", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    lstDetail.Items.Clear();

                    companies = BD.company.ToList<company>();//Asignamos los valores del contexto de la tabla Company al listado previamente declarado
                    
                    dgvData.DataSource = companies;//Establecemos un nuevo origen de datos para el dgvData
                                                   //Editando el texto de los encabezados de la tabla
                    dgvData.Columns[1].HeaderText = "Nombre";
                    dgvData.Columns[2].HeaderText = "Dirección";
                    dgvData.Columns[3].HeaderText = "E-mail";
                    dgvData.Columns[4].HeaderText = "Teléfono";
                    dgvData.Columns[5].HeaderText = "Proveedor";
                }
            }
        }

        private void RDCompany_FormClosing(object sender, FormClosingEventArgs e)
        {
        }
    }
}
