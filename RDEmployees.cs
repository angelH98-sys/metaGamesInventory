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
    public partial class RDEmployees : Form
    {
        public RDEmployees()
        {
            InitializeComponent();
        }

        List<employee> employees;
        private int[] columnsToHide = {3,7,8,9};
        employee selected;

        private void loadData()
        {
            using (metaGamesInventoryAlterEntities BD = new metaGamesInventoryAlterEntities())//Creamos un nuevo contexto de la base de datos
            {
                employees = BD.employee.ToList<employee>();//Asignamos los valores del contexto de la tabla Company al listado previamente declarado
            }
            dgvData.DataSource = employees;//Establecemos un nuevo origen de datos para el dgvData
            //Editando el texto de los encabezados de la tabla
            dgvData.Columns[1].HeaderText = "Nombre";
            dgvData.Columns[2].HeaderText = "Nombre de usuario";
            dgvData.Columns[3].HeaderText = "Contraseña";
            dgvData.Columns[4].HeaderText = "Pregunta de seguridad";
            dgvData.Columns[5].HeaderText = "Respuesta";
            dgvData.Columns[6].HeaderText = "Grupo";

            foreach (int column in columnsToHide)
                dgvData.Columns[column].Visible = false;
        }
        private void RDEmployees_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void DgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selected = employees.ElementAt<employee>(e.RowIndex);//Creamos un objeto con los datos de la celda seleccionada
            lstDetail.Items.Clear();
            //Mostramos los datos del objeto, añadiendolos en forma de items del lstDetail
            lstDetail.Items.Add("\nNombre: \n" + selected.name.ToString());
            lstDetail.Items.Add("\nNombre de usuario: \n" + selected.login_user.ToString());
            lstDetail.Items.Add("\nPregunta de seguridad: \n" + selected.emergency_question.ToString());
            lstDetail.Items.Add("\nRespuesta: \n" + selected.answer.ToString());
        }

        private void DgvData_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = false;
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            CUEmployees form = new CUEmployees(selected);
            form.Text = "Modificación de empleado";
            form.Show();
            this.Close();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
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

                    employees = BD.employee.ToList<employee>();//Asignamos los valores del contexto de la tabla Company al listado previamente declarado

                    dgvData.DataSource = employees;//Establecemos un nuevo origen de datos para el dgvData
                                                   //Editando el texto de los encabezados de la tabla
                    dgvData.Columns[1].HeaderText = "Nombre";
                    dgvData.Columns[2].HeaderText = "Nombre de usuario";
                    dgvData.Columns[3].HeaderText = "Pregunta de seguridad";
                    dgvData.Columns[4].HeaderText = "Respuesta";
                    dgvData.Columns[5].HeaderText = "Grupo";
                }
            }
        }

        private void BtnCreate_Click(object sender, EventArgs e)
        {
            CUEmployees form = new CUEmployees();
            form.Text = "Nuevo empleado";
            form.Show();
            this.Close();
        }

        private void filterData()
        {
            string value = txtSearch.Text;
            if (!value.Equals(""))
            {
                List<employee> tempEmployees = new List<employee>();
                foreach (employee f in employees)
                {
                    if (f.name.ToLower().Contains(value))
                    {
                        tempEmployees.Add(f);
                    }
                }
                dgvData.DataSource = tempEmployees;
                employees = tempEmployees;
            }
            else
            {
                loadData();
            }
        }

        private void TxtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                filterData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
