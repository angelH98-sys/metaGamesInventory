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
    public partial class CUDescuentos : Form
    {
        public CUDescuentos()
        {
            InitializeComponent();
        }

        bool closable = false;
        home home = new home();

        discount descuentos;

        public CUDescuentos(discount obj)
        {
            InitializeComponent();
            descuentos = obj;
            assigningData();
        }

        private void assigningData()
        {
           // DateTime inicio = dtpinicio.Value;

            txtnombre.Text = descuentos.name;
            num.Value = descuentos.percentage;
           // dtpinicio.Value = descuentos.start;
            //dtpinicio.Value = descuentos.start;
           
             
        }

        private void dtpinicio_ValueChanged(object sender, EventArgs e)
        {
            DateTime inicio = dtpinicio.Value;
            

        }

        private void CreacionDescuento()
        {
            discount obj = new discount();
            obj.name = txtnombre.Text;
            obj.percentage = Int32.Parse(num.Value.ToString());
            obj.start = dtpinicio.Value;
            obj.ending = dtpfinal.Value;

            //Validacion Fecha 

            if (dtpinicio.Value.Date < dtpfinal.Value.Date)
            {
                //Lógica de guardado en base de datos
                using (metaGamesInventoryAlterEntities BD = new metaGamesInventoryAlterEntities())
                {
                    BD.discount.Add(obj);//Añadimos el objeto previamente establecido al contexto creado
                    BD.SaveChanges();//Persistimos los datos del contexto, dentro de la base de datos
                    MessageBox.Show("Descuento registrado exitosamente.", "Operación exitosa", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    closable = true;
                    this.Close();
                    RDDescuento form = new RDDescuento();
                    form.MdiParent = metaGamesInventory.home.ActiveForm;
                    form.Text = "Descuento registrados";
                    form.Show();
                }

            }
            else
            {
                MessageBox.Show("La fecha final no puede ser menos que la fecha de inicio");
            }
                //Mensaje de que no es posible guardar la info por la fecha

              
        }

        private void btn_Registrar_Descuento_Click(object sender, EventArgs e)
        {
            //Creacion de Descuento;
            if (Controlvali())
            //Si el formulario entero cumple las validaciones
            {
                if (descuentos == null)
                /*Si el objeto productToUpdate no cambia su estado inicial (null),
                 significa que no proviene del formulario RDProduct, por ende,
                 se ejecutara una inserción a la tabla Product*/
                {
                    CreacionDescuento();
                }
                else
                {
                    updateProduct();
                }
            }

        }

        private void updateProduct()
        {
            descuentos.name = txtnombre.Text;
            descuentos.percentage = Int32.Parse(num.Value.ToString());
            descuentos.start = dtpinicio.Value;
            descuentos.ending = dtpfinal.Value;



            using (metaGamesInventoryAlterEntities BD = new metaGamesInventoryAlterEntities())
            {
                BD.Entry(descuentos).State = System.Data.Entity.EntityState.Modified;
                BD.SaveChanges();//Persistimos los datos actualizados dentro de la base de datos
                MessageBox.Show("Descuento modificado exitosamente.", "Operación exitosa", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                closable = true;
                this.Close();
                RDDescuento form = new RDDescuento();
                form.MdiParent = metaGamesInventory.home.ActiveForm;
                form.Text = "Descuento Registrado";
                form.Show();
            }
        }

        private bool Controlvali()
        {
            if (string.IsNullOrWhiteSpace(txtnombre.Text))//Si no se ha ingresado información al campo indicado...
            {
                txtnombre.Focus();//Enfocamos el campo
                //Añadimos un mensaje descriptivo del error de validación
                errorProvider1.SetError(txtnombre, "Por favor, ingresa el nombre del Descuento");
                return false;
            }
            else
            {
                errorProvider1.SetError(txtnombre, null);
                //Eliminamos cualquier mensaje de validación referido al campo en cuestión
            }

            return true;
        }

        private void CUDescuentos_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (closable == false)
            {
                var ans = MessageBox.Show("Todos los cambios quedarán anulados si decides abandonar el formulario", "¿Seguro de salir del formulario?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (ans == DialogResult.Yes)
                {
                    if (descuentos != null)
                    {
                        RDDescuento form = new RDDescuento();
                        form.MdiParent = metaGamesInventory.home.ActiveForm;
                        form.Text = "Descuento regitrados";
                        form.Show();
                    }
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        private void txtnombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Space))
            {
                MessageBox.Show("Solo se permiten letras", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Handled = true;
                return;
            }
        }

        private void num_KeyPress(object sender, KeyPressEventArgs e)
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
