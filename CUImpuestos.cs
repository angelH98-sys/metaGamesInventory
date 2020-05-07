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
    public partial class CUImpuestos : Form
    {
        public CUImpuestos()
        {
            InitializeComponent();
        }
        bool closable = false;
        home home = new home();

        tax impuestos;

        public CUImpuestos(tax obj)
        {
            InitializeComponent();
            impuestos = obj;
            assigningData();
        }

        private void assigningData()
        {
            txtnimpu.Text = impuestos.name;
            numimp.Value = Int32.Parse(impuestos.percentage.ToString());
        }

        private void CreacionImpuesto()
        {
            tax obj = new tax();
            obj.name = txtnimpu.Text;
            obj.percentage = Int32.Parse(numimp.Value.ToString());
            //Int32.Parse(txtporcen.ToString());

            using (metaGamesInventoryAlterEntities BD = new metaGamesInventoryAlterEntities())
            {
                BD.tax.Add(obj);//Añadimos el objeto previamente establecido al contexto creado
                BD.SaveChanges();//Persistimos los datos del contexto, dentro de la base de datos
                MessageBox.Show("Impuesto registrado exitosamente.", "Operación exitosa", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                closable = true;
                this.Close();
                RDImpuestos form = new RDImpuestos();
                form.MdiParent = metaGamesInventory.home.ActiveForm;
                form.Text = "Impuesto registrados";
                form.Show();
            }
           
            
            
           
           
        }

        private void btnimpuesto_Click(object sender, EventArgs e)
        {
            //CreacionImpuesto();

            if (Controlvali())
            //Si el formulario entero cumple las validaciones
            {
                if (impuestos == null)
                /*Si el objeto productToUpdate no cambia su estado inicial (null),
                 significa que no proviene del formulario RDProduct, por ende,
                 se ejecutara una inserción a la tabla Product*/
                {
                    CreacionImpuesto();
                }
                else
                {
                    updateProduct();
                }
            }


        }

        private void updateProduct()
        {
            impuestos.name = txtnimpu.Text;
            impuestos.percentage = Int32.Parse(numimp.Value.ToString());

            using (metaGamesInventoryAlterEntities BD = new metaGamesInventoryAlterEntities())
            {
                BD.Entry(impuestos).State = System.Data.Entity.EntityState.Modified;
                BD.SaveChanges();//Persistimos los datos actualizados dentro de la base de datos
                MessageBox.Show("Producto modificado exitosamente.", "Operación exitosa", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                closable = true;
                this.Close();
                RDImpuestos form = new RDImpuestos();
                form.MdiParent = metaGamesInventory.home.ActiveForm;
                form.Text = "Impuesto Registrado";
                form.Show();
            }
        }


        private bool Controlvali()
        {
            if (string.IsNullOrWhiteSpace(txtnimpu.Text))//Si no se ha ingresado información al campo indicado...
            {
                txtnimpu.Focus();//Enfocamos el campo
                //Añadimos un mensaje descriptivo del error de validación
                errorProvider1.SetError(txtnimpu, "Por favor, ingresa el nombre del producto");
                return false;
            }
            else
            {
                errorProvider1.SetError(txtnimpu, null);
                //Eliminamos cualquier mensaje de validación referido al campo en cuestión
            }

            return true;
        }

        private void CUImpuestos_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (closable == false)
            {
                var ans = MessageBox.Show("Todos los cambios quedarán anulados si decides abandonar el formulario", "¿Seguro de salir del formulario?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (ans == DialogResult.Yes)
                {
                    if (impuestos != null)
                    {
                        RDImpuestos form = new RDImpuestos();
                        form.MdiParent = metaGamesInventory.home.ActiveForm;
                        form.Text = "impuestos regitrados";
                        form.Show();
                    }
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        private void txtnimpu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Space))
            {
                MessageBox.Show("Solo se permiten letras", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Handled = true;
                return;
            }
        }

        private void numimp_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Handled = true;
                return;
            }
        }
    }
}
