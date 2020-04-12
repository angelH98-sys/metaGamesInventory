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
    public partial class ResetPassword : Form
    {
        public ResetPassword()
        {
            InitializeComponent();
        }
         employee userExists;
        private void Button1_Click(object sender, EventArgs e)
        {
            using (metaGamesInventoryAlterEntities BD = new metaGamesInventoryAlterEntities())
            {
                if (txtUsername.Text != string.Empty)
                {
                    userExists = BD.employee.FirstOrDefault(a => a.login_user.Equals(txtUsername.Text));
                    if (userExists != null)//if exist then check password match or not?
                    {
                        lblAnswer.Visible = true;
                        lblQuestion.Visible = true;
                        txtAnswer.Visible = true;
                        txtQuestion.Visible = true;
                        button2.Visible = true;
                        txtQuestion.Text = userExists.emergency_question;
 
                    }
                    else
                        MessageBox.Show("No existen registros con este nombre de usuario", "Operación fallida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("Llene los datos para continuar", "Operación fallida", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Boolean checkAnswer()
        {
            using (metaGamesInventoryAlterEntities BD = new metaGamesInventoryAlterEntities())
            {
               // var userExist = BD.employee.FirstOrDefault(a => a.login_user.Equals(txtUsername.Text));
                if (userExists != null)//if exist then check password match or not?
                {
                    if (userExists.answer.ToLower() == txtAnswer.Text.ToLower())
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            if (checkAnswer())
            {
                label2.Visible = true;
                txtPassword.Visible = true;
                txtPassword.Text = userExists.login_pass;
            }
            else
            {
                MessageBox.Show("Respuesta incorrecta", "Operación fallida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                label2.Visible = false;
                txtPassword.Visible = false;
            }
        }
    }
}
