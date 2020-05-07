using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace metaGamesInventory
{
    public partial class CUCompany : Form
    {
        public CUCompany()
        {
            InitializeComponent();
        }
        

        //Objeto que almacenará el objeto proveniente del formulario RDCompany para la actualización de datos
        company companyToUpdate = null;
        public CUCompany(company obj)//Sobrecarga del constructor del formulario, proveniente de RDCompany
        {
            InitializeComponent();
            companyToUpdate = obj;
            dataToTextbox();
            btnCancel.Visible = true;
        }

        private void dataToTextbox()
            //Método encargado de inicializar los campos del formulario, tomando referencia del objeto a actualizar
        {
            txtName.Text = companyToUpdate.name.ToString();
            txtEmail.Text = companyToUpdate.email.ToString();
            txtPhone.Text = companyToUpdate.phone.ToString();
            txtAddress.Text = companyToUpdate.company_address.ToString();
        }


        private void btnSend_Click(object sender, EventArgs e)
        {
            
        }

        private void createCompany()//Método encargado de crear nuevos registros en la tabla Company
        {
            company obj = new company();//Creación de objeto de la tabla: Company

            //Asignamos valores del formulario al objeto creado
            obj.name = txtName.Text;
            obj.email = txtEmail.Text;
            obj.phone = txtPhone.Text;
            obj.company_address = txtAddress.Text;
            
            //Usando objeto de referencia a las entidades de metaGamesInventoryAlterEntities
            using (metaGamesInventoryAlterEntities BD = new metaGamesInventoryAlterEntities())
            {
                try
                {
                    BD.company.Add(obj);//Añadimos el objeto nuevo al contexto de la entidad Company
                    BD.SaveChanges();//Guardamos los cambios hechos al contexto en la base de datos metaGamesInventory
                    MessageBox.Show("Compañía registrada exitosamente.", "Operación exitosa", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    RDCompany form = new RDCompany();
                    form.Show();
                    this.Close();
                }
                catch
                {
                    string text = "Posibles incongruencias:" +
                        "\n1. Ya existe una compañía con el nombre: " + txtName.Text +
                        "\n2. Alguna otra compañía tiene registrado el teléfono: " + txtPhone.Text +
                        "\n3. Alguna otra compañía tiene registrado el E-mail: " + txtEmail.Text;
                    MessageBox.Show(text, "Operación fallida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void updateCompany()
        {

            //Asignamos valores al registro a modificar
            companyToUpdate.name = txtName.Text;
            companyToUpdate.email = txtEmail.Text;
            companyToUpdate.phone = txtPhone.Text;
            companyToUpdate.company_address = txtAddress.Text;

            using (metaGamesInventoryAlterEntities BD = new metaGamesInventoryAlterEntities())
            {
                try
                {
                    BD.Entry(companyToUpdate).State = System.Data.Entity.EntityState.Modified;
                    BD.SaveChanges();
                    MessageBox.Show("Compañía actualizada exitosamente.", "Operación exitosa", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    RDCompany form = new RDCompany();
                    form.Show();
                    this.Close();
                }
                catch
                {
                    string text = "Posibles incongruencias:" +
                        "\n1. Ya existe una compañía con el nombre: " + companyToUpdate.name.ToString() +
                        "\n2. Alguna otra compañía tiene registrado el teléfono: " + companyToUpdate.phone.ToString() +
                        "\n3. Alguna otra compañía tiene registrado el E-mail: " + companyToUpdate.email.ToString();
                    MessageBox.Show(text,"Operación fallida",MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))//Si no se ha ingresado información al campo indicado...
            {
                e.Cancel = true;//Cancelamos la ejecución de cualquier evento
                txtName.Focus();//Enfocamos el campo
                //Añadimos un mensaje descriptivo del error de validación
                errorProvider.SetError(txtName, "Por favor, ingresa el nombre de la compañía");
            }
            else
            {
                e.Cancel = false;//Continua la ejecución de los eventos
                errorProvider.SetError(txtName, null);//Eliminamos cualquier mensaje de validación referido al campo en cuestión
            }
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text))//Si no se ha ingresado información al campo indicado...
            {
                e.Cancel = true;//Cancelamos la ejecución de cualquier evento
                txtEmail.Focus();//Enfocamos el campo
                //Añadimos un mensaje descriptivo del error de validación
                errorProvider.SetError(txtEmail, "Por favor, ingresa el E-mail de la compañía");
            }
            else
            {
                e.Cancel = false;//Continua la ejecución de los eventos
                errorProvider.SetError(txtEmail, null);//Eliminamos cualquier mensaje de validación referido al campo en cuestión
            }
        }

        private void txtPhone_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPhone.Text))//Si no se ha ingresado información al campo indicado...
            {
                e.Cancel = true;//Cancelamos la ejecución de cualquier evento
                txtPhone.Focus();//Enfocamos el campo
                //Añadimos un mensaje descriptivo del error de validación
                errorProvider.SetError(txtPhone, "Por favor, ingresa el teléfono de la compañía");
            }
            else
            {
                e.Cancel = false;//Continua la ejecución de los eventos
                errorProvider.SetError(txtPhone, null);//Eliminamos cualquier mensaje de validación referido al campo en cuestión
            }
        }

        private void btnSend_Click_1(object sender, EventArgs e)
        {
            if (validateFields())
            {
                if (companyToUpdate == null)
                /*Si el objeto companyToUpdate no cambia su estado inicial (null),
                 significa que no proviene del formulario RDCompany, por ende,
                 se ejecutara una inserción a la tabla Company*/
                {
                    createCompany();
                }
                else
                {
                    updateCompany();
                }
            }
        }

        private void CUCompany_Load(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            var ans = MessageBox.Show("¿Estas seguro de cancelar la modificación de la compañía " + companyToUpdate.name.ToString() + " ?","", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if(ans == DialogResult.Yes)
            {
                RDCompany form = new RDCompany();
                form.Show();
                this.Close();
            }
        }

        private bool validateFields()
        {
            if(txtName.Text.Trim().Length == 0)
            {
                errorProvider.SetError(txtName, "Debe ingresar el nombre de la compañía.");
                return false;
            }
            else
            {
                errorProvider.SetError(txtName,null);
            }

            if (txtEmail.Text.Trim().Length == 0)
            {
                errorProvider.SetError(txtEmail, "Debe ingresar el email de contacto de la compañía.");
                return false;
            }
            else
            {
                errorProvider.SetError(txtEmail, null);
            }

            try
            {
                MailAddress m = new MailAddress(txtEmail.Text);
                errorProvider.SetError(txtEmail, null);
            }
            catch (FormatException)
            {
                errorProvider.SetError(txtEmail, "Formato de e-mail incorrecto.");
                return false;
            }

            if (txtPhone.Text.Trim().Length == 0)
            {
                errorProvider.SetError(txtPhone, "Debe ingresar el teléfono de contacto de la compañía.");
                return false;
            }
            else
            {
                errorProvider.SetError(txtPhone, null);
            }
            Regex rx = new Regex("^[0-9]{8}");
            if (!rx.IsMatch(txtPhone.Text))
            {
                errorProvider.SetError(txtPhone, "Formato de teléfono incorrecto. (Formáto requerido: 00000000)");
                return false;
            }
            else
            {
                errorProvider.SetError(txtPhone, null);
            }
            return true;
        }
    }
}
