using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

using System.Windows.Forms;

namespace metaGamesInventory
{
    public partial class CUEmployees : Form
    {
        public CUEmployees()
        {
            InitializeComponent();
        }

        //Objeto que almacenará el objeto proveniente del formulario RDEmployee para la actualización de datos
        employee employeeToUpdate = null;
        bool closable = false;
        public CUEmployees(employee obj)//Sobrecarga del constructor del formulario, proveniente de RDEmployee
        {
            InitializeComponent();
            employeeToUpdate = obj;
            dataToTextbox();
            btnCancel.Visible = true;
        }

        static string GetMd5Hash(MD5 md5Hash, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        private void dataToTextbox()
        //Método encargado de inicializar los campos del formulario, tomando referencia del objeto a actualizar
        {
            txtName.Text = employeeToUpdate.name.ToString();
            txtUsername.Text = employeeToUpdate.login_user.ToString();
            txtPassword.Text = employeeToUpdate.login_pass.ToString();
            txtQuestion.Text = employeeToUpdate.emergency_question.ToString();
            txtAnswer.Text = employeeToUpdate.answer.ToString();
        }

        private void createEmployee()//Método encargado de crear nuevos registros en la tabla Employee
        {
            if (!checkEqualPasswords(txtPassword.Text, txtConfirmPassword.Text))
            {
                MessageBox.Show("Las contraseñas no coinciden");
            }
            else
            {
                employee obj = new employee();//Creación de objeto de la tabla: Employee
                MD5 md5Hash = MD5.Create();
                //Asignamos valores del formulario al objeto creado
                obj.name = txtName.Text;
                obj.login_user = txtUsername.Text;
                obj.login_pass = GetMd5Hash(md5Hash, txtPassword.Text);
                //obj.login_pass = txtPassword.Text;
                obj.emergency_question = txtQuestion.Text;
                obj.answer = txtAnswer.Text;
                obj.id_group = 1;

                //Usando objeto de referencia a las entidades de metaGamesInventoryAlterEntities
                using (metaGamesInventoryAlterEntities BD = new metaGamesInventoryAlterEntities())
                {
                    try
                    {
                        BD.employee.Add(obj);//Añadimos el objeto nuevo al contexto de la entidad Employee
                        BD.SaveChanges();//Guardamos los cambios hechos al contexto en la base de datos metaGamesInventory
                        MessageBox.Show("Empleado registrado exitosamente.", "Operación exitosa", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        RDEmployees form = new RDEmployees();
                        form.Show();
                        this.Close();
                    }
                    catch
                    {
                        string text = "Posibles incongruencias:" +
                            "\n1. Ya existe un usuario con el nombre de usuario: " + txtUsername.Text;
                        MessageBox.Show(text, "Operación fallida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void updateEmployee()
        {
            if (!checkEqualPasswords(txtPassword.Text, txtConfirmPassword.Text))
            {
                MessageBox.Show("Las contraseñas no coinciden");
                errorProvider1.SetError(txtConfirmPassword, "Las contraseñas no coinciden");
            }
            else
            {
                //Asignamos valores al registro a modificar
                employeeToUpdate.name = txtName.Text;
                employeeToUpdate.login_user = txtUsername.Text;
                employeeToUpdate.login_pass = txtPassword.Text;
                employeeToUpdate.emergency_question = txtQuestion.Text;
                employeeToUpdate.answer = txtAnswer.Text;

                using (metaGamesInventoryAlterEntities BD = new metaGamesInventoryAlterEntities())
                {
                    try
                    {
                        BD.Entry(employeeToUpdate).State = System.Data.Entity.EntityState.Modified;
                        BD.SaveChanges();
                        MessageBox.Show("Empleado actualizado exitosamente.", "Operación exitosa", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        RDEmployees form = new RDEmployees();
                        form.Show();
                        this.Close();
                    }
                    catch
                    {
                        string text = "Posibles incongruencias:" +
                            "\n1. Ya existe un empleado con el nombre de usuario: " + employeeToUpdate.login_user.ToString();
                        MessageBox.Show(text, "Operación fallida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private Boolean checkEqualPasswords(String password1, String password2)
        {
            if (string.IsNullOrWhiteSpace(txtPassword.Text))//Si no se ha ingresado información al campo indicado...
            {
                return false;
            }
            else
            {
                if (password1 == password2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
           
        }
        private void BtnSend_Click(object sender, EventArgs e)
        {
            if (employeeToUpdate == null)
            {
                createEmployee();
            }
            else
            {
                updateEmployee();
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            var ans = MessageBox.Show("¿Estas seguro de cancelar la modificación del empleado " + employeeToUpdate.name.ToString() + " ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (ans == DialogResult.Yes)
            {
                RDEmployees form = new RDEmployees();
                form.Show();
                this.Close();
            }
        }

        private void TxtName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))//Si no se ha ingresado información al campo indicado...
            {
                e.Cancel = true;//Cancelamos la ejecución de cualquier evento
                txtName.Focus();//Enfocamos el campo
                //Añadimos un mensaje descriptivo del error de validación
                errorProvider1.SetError(txtName, "Por favor, ingresa el nombre del empleado");
            }
            else
            {
                e.Cancel = false;//Continua la ejecución de los eventos
                errorProvider1.SetError(txtName, null);//Eliminamos cualquier mensaje de validación referido al campo en cuestión
            }
        }

        private void TxtUsername_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))//Si no se ha ingresado información al campo indicado...
            {
                e.Cancel = true;//Cancelamos la ejecución de cualquier evento
                txtUsername.Focus();//Enfocamos el campo
                //Añadimos un mensaje descriptivo del error de validación
                errorProvider1.SetError(txtUsername, "Por favor, ingresa el nombre de usuario");
            }
            else
            {
                e.Cancel = false;//Continua la ejecución de los eventos
                errorProvider1.SetError(txtUsername, null);//Eliminamos cualquier mensaje de validación referido al campo en cuestión
            }
        }

        private void TxtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPassword.Text))//Si no se ha ingresado información al campo indicado...
            {
                e.Cancel = true;//Cancelamos la ejecución de cualquier evento
                txtPassword.Focus();//Enfocamos el campo
                //Añadimos un mensaje descriptivo del error de validación
                errorProvider1.SetError(txtPassword, "Por favor, ingresa la contraseña");
            }
            else
            {
                e.Cancel = false;//Continua la ejecución de los eventos
                errorProvider1.SetError(txtPassword, null);//Eliminamos cualquier mensaje de validación referido al campo en cuestión
            }
        }

        private void TxtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtConfirmPassword.Text))//Si no se ha ingresado información al campo indicado...
            {
                e.Cancel = true;//Cancelamos la ejecución de cualquier evento
                txtConfirmPassword.Focus();//Enfocamos el campo
                //Añadimos un mensaje descriptivo del error de validación
                errorProvider1.SetError(txtConfirmPassword, "Por favor, confirme la contraseña");
            }
            else
            {

                e.Cancel = false;//Continua la ejecución de los eventos
                errorProvider1.SetError(txtConfirmPassword, null);//Eliminamos cualquier mensaje de validación referido al campo en cuestión
            }
        }

        private void TxtQuestion_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtQuestion.Text))//Si no se ha ingresado información al campo indicado...
            {
                e.Cancel = true;//Cancelamos la ejecución de cualquier evento
                txtQuestion.Focus();//Enfocamos el campo
                //Añadimos un mensaje descriptivo del error de validación
                errorProvider1.SetError(txtQuestion, "Por favor, ingresa la pregunta de seguridad");
            }
            else
            {
                e.Cancel = false;//Continua la ejecución de los eventos
                errorProvider1.SetError(txtQuestion, null);//Eliminamos cualquier mensaje de validación referido al campo en cuestión
            }
        }

        private void TxtAnswer_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAnswer.Text))//Si no se ha ingresado información al campo indicado...
            {
                e.Cancel = true;//Cancelamos la ejecución de cualquier evento
                txtAnswer.Focus();//Enfocamos el campo
                //Añadimos un mensaje descriptivo del error de validación
                errorProvider1.SetError(txtAnswer, "Por favor, ingresa la respuesta");
            }
            else
            {
                e.Cancel = false;//Continua la ejecución de los eventos
                errorProvider1.SetError(txtAnswer, null);//Eliminamos cualquier mensaje de validación referido al campo en cuestión
            }
        }

        private void CUEmployees_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void CUEmployees_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !checkBoxShowPassword.Checked;
            txtPassword.PasswordChar = checkBoxShowPassword.Checked ? '\0' : '*';

        }
    }
}
