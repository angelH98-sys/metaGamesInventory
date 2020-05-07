using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace metaGamesInventory
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
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


        private void Button1_Click(object sender, EventArgs e)
        {
            using (metaGamesInventoryAlterEntities BD = new metaGamesInventoryAlterEntities())
            {
                if (txtUsername.Text != string.Empty && txtPassword.Text != string.Empty)
                {
                    var userExist = BD.employee.FirstOrDefault(a => a.login_user.Equals(txtUsername.Text));
                if (userExist != null)//if exist then check password match or not?
                {
                        using (MD5 md5Hash = MD5.Create())
                        {
                            string hash = GetMd5Hash(md5Hash, txtPassword.Text);
                            if (hash.Equals(userExist.login_pass))
                             {
                             MessageBox.Show("Bienvenido: " + userExist.login_user, "Operación exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                             home home = new home();
                             home.Show();
                             this.Hide();
                            }
                            else
                            {
                              MessageBox.Show("Contraseña incorrecta", "Operación fallida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                             }
                        }

                }
                    else
                        MessageBox.Show("No existen registros con este nombre de usuario", "Operación fallida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("Llene los datos para continuar", "Operación fallida", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ResetPassword form = new ResetPassword();
            form.Show();
            this.Hide();
        }
    }
}
