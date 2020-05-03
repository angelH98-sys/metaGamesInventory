using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace metaGamesInventory
{
    public partial class PasswordResetConfirmation : Form
    {
        employee employeeToUpdate = null;
        public PasswordResetConfirmation()
        {
            InitializeComponent();
        }

        public PasswordResetConfirmation(employee obj)//Sobrecarga del constructor del formulario, proveniente de Password Reset
        {
            InitializeComponent();
            employeeToUpdate = obj;
        }

        private void ChbPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !chbPassword.Checked;
            txtPassword.PasswordChar = chbPassword.Checked ? '\0' : '*';
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

        private void BtnConfirmar_Click(object sender, EventArgs e)
        {
            if(txtPassword.Text != "" || txtConfirmPassword.Text != "")
            {
                if (txtPassword.Text == txtConfirmPassword.Text)
                {
                    MD5 md5Hash = MD5.Create();
                    employeeToUpdate.login_pass = GetMd5Hash(md5Hash, txtPassword.Text);
                    using (metaGamesInventoryAlterEntities BD = new metaGamesInventoryAlterEntities())
                    {
                        try
                        {
                            BD.Entry(employeeToUpdate).State = System.Data.Entity.EntityState.Modified;
                            BD.SaveChanges();
                            MessageBox.Show("Contraseña actualizada exitosamente.", "Operación exitosa", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            Login form = new Login();
                            form.Show();
                            this.Close();
                        }
                        catch (Exception error)
                        {
                            MessageBox.Show(error.Message, "Operación fallida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Las contraseñas no coinciden", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Debe llenar los campos para poder continuar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
