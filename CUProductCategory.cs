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
    public partial class CUProductCategory : Form
    {
        public CUProductCategory()
        {
            InitializeComponent();
        }

        product_category categoryToUpdate;
        public CUProductCategory(product_category obj)
        {
            InitializeComponent();
            categoryToUpdate = obj;
            txtName.Text = obj.name;
            btnCancel.Visible = true;
        }

        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                e.Cancel = true;//Cancelamos la ejecución de cualquier evento
                txtName.Focus();//Enfocamos el campo
                //Añadimos un mensaje descriptivo del error de validación
                errorProvider1.SetError(txtName, "Por favor, ingresa el nombre de la categoría");
            }
            else
            {
                e.Cancel = false;//Continua la ejecución de los eventos
                errorProvider1.SetError(txtName, null);//Eliminamos cualquier mensaje de validación referido al campo en cuestión
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(categoryToUpdate == null)
            {
                createCategory();
            }
            else
            {
                updateCategory();
            }
        }

        private void createCategory()
        {
            product_category obj = new product_category();

            obj.name = txtName.Text;

            using (metaGamesInventoryAlterEntities BD = new metaGamesInventoryAlterEntities())
            {
                try
                {
                    BD.product_category.Add(obj);//Añadimos el objeto nuevo al contexto de la entidad Company
                    BD.SaveChanges();//Guardamos los cambios hechos al contexto en la base de datos metaGamesInventory
                    MessageBox.Show("Categoría registrada exitosamente.", "Operación exitosa", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    RDProductCategory form = new RDProductCategory();
                    form.Show();
                    this.Close();
                }
                catch
                {
                    string text = "Posibles incongruencias:" +
                        "\n1. Ya existe una categoría con el nombre: " + txtName.Text;
                    MessageBox.Show(text, "Operación fallida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void updateCategory()
        {
            categoryToUpdate.name = txtName.Text;

            using(metaGamesInventoryAlterEntities BD = new metaGamesInventoryAlterEntities())
            {
                try
                {
                    BD.Entry(categoryToUpdate).State = System.Data.Entity.EntityState.Modified;
                    BD.SaveChanges();
                    MessageBox.Show("Categoría actualizada exitosamente.", "Operación exitosa", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    RDProductCategory form = new RDProductCategory();
                    form.Show();
                    this.Close();
                }
                catch
                {
                    string text = "Posibles incongruencias:" +
                        "\n1. Ya existe una categoría con el nombre: " + categoryToUpdate.name.ToString();
                    MessageBox.Show(text, "Operación fallida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void CUProductCategory_Load(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            var ans = MessageBox.Show("¿Estas seguro de cancelar la modificación de la categoría " + categoryToUpdate.name.ToString() + " ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (ans == DialogResult.Yes)
            {
                RDProductCategory form = new RDProductCategory();
                form.Show();
                this.Close();
            }
        }
    }
}
