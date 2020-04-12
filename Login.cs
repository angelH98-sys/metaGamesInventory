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

        private void Button1_Click(object sender, EventArgs e)
        {
            using (metaGamesInventoryAlterEntities BD = new metaGamesInventoryAlterEntities())
            {
                if (txtUsername.Text != string.Empty && txtPassword.Text != string.Empty)
                {
                    var userExist = BD.employee.FirstOrDefault(a => a.login_user.Equals(txtUsername.Text));
                if (userExist != null)//if exist then check password match or not?
                {
                        if (userExist.login_pass.Equals(txtPassword.Text))
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
            form.ShowDialog();
        }
    }
}
