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
    public partial class CUProvider : Form
    {
        public CUProvider()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnSend_Click(object sender, EventArgs e)
        {

        }

        List<company> companies;
        private void CUProvider_Load(object sender, EventArgs e)
        {
            using (metaGamesInventoryAlterEntities BD = new metaGamesInventoryAlterEntities())
                //Creamos el contexto de la base de datos
            {
                companies = BD.company.ToList<company>();
                foreach (var company in companies)
                    //Recorremos cada registro de la tabla company para alimentar el combobox de selección indicado
                {
                    cmbCompany.Items.Add(company.name.ToString());
                }
            }
        }

        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
                //Si no se ingreso información en el campo indicado
            {
                e.Cancel = true;//Cancelamos la ejecución de cualquier evento
                txtName.Focus();//Enfocamos el campo
                //Añadimos un mensaje descriptivo del error de validación
                errorProvider1.SetError(txtName, "Por favor, ingresa el nombre del proveedor");
            }
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            
        }

        private void txtPhone_Validating(object sender, CancelEventArgs e)
        {
            
        }

        private void txtEmail_Validating_1(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            //Si no se ingreso información en el campo indicado
            {
                e.Cancel = true;//Cancelamos la ejecución de cualquier evento
                txtEmail.Focus();//Enfocamos el campo
                //Añadimos un mensaje descriptivo del error de validación
                errorProvider1.SetError(txtEmail, "Por favor, ingresa el e-mail del proveedor");
            }
        }

        private void txtPhone_Validating_1(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPhone.Text))
            //Si no se ingreso información en el campo indicado
            {
                e.Cancel = true;//Cancelamos la ejecución de cualquier evento
                txtPhone.Focus();//Enfocamos el campo
                //Añadimos un mensaje descriptivo del error de validación
                errorProvider1.SetError(txtPhone, "Por favor, ingresa el teléfono del proveedor");
            }
        }

        private void txtMobile_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMobile.Text))
            //Si no se ingreso información en el campo indicado
            {
                e.Cancel = true;//Cancelamos la ejecución de cualquier evento
                txtMobile.Focus();//Enfocamos el campo
                //Añadimos un mensaje descriptivo del error de validación
                errorProvider1.SetError(txtMobile, "Por favor, ingresa el celular del proveedor");
            }
        }

        private void btnSend_Click_1(object sender, EventArgs e)
        {
            createProvider();
        }

        private void createProvider()
        {
            provider obj = new provider();

            obj.name = txtName.Text;
            obj.id_company = companies.Where(d => d.name == cmbCompany.Text).First().id;
            obj.email = txtEmail.Text;
            obj.phone = txtPhone.Text;
            obj.mobile = txtMobile.Text;
            obj.payment_term = cmbPaymentTerms.Text;

            using (metaGamesInventoryAlterEntities BD = new metaGamesInventoryAlterEntities())
            {
                try
                {
                    BD.provider.Add(obj);
                    BD.SaveChanges();
                    MessageBox.Show("Proveedor registrado exitosamente.", "Operación exitosa", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    
                    this.Close();
                }
                catch
                {
                    string text = "Posibles incongruencias:" +
                        "\n2. Algun otro proveedor tiene registrado el teléfono: " + txtPhone.Text +
                        "\n2. Algun otro proveedor tiene registrado el celular: " + txtMobile.Text +
                        "\n3. Alguna otra compañía tiene registrado el E-mail: " + txtEmail.Text;
                    MessageBox.Show(text, "Operación fallida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
