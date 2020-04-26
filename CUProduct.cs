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
    public partial class CUProduct : Form
    {
        public CUProduct()
        {
            InitializeComponent();
        }
        bool closable = false;
        home home = new home();//Referencia a MdiParent
        product productToUpdate;
        //Objeto que almacenará un producto a modificar, proveniente del formulario RDProduct
        public CUProduct(product obj)
            //Sobrecarga del constructor CUProduct.
            //Usado por el formulario de RDProduct para la actualización de los datos de algun producto
        {
            InitializeComponent();
            productToUpdate = obj;
            assigningData();
        }

        private void assigningData()
            /*Método encargado de la asignación de los datos de productToUpdate
             a los campos respectivos del formulario*/
        {
            txtName.Text = productToUpdate.name;
            nudPrice.Value = Decimal.Parse(productToUpdate.price.ToString());
            nudMinimum.Value = Decimal.Parse(productToUpdate.minimum_quantity.ToString());
            nudStock.Value = Decimal.Parse(productToUpdate.stock.ToString());
            txtDescription.Text = productToUpdate.product_description;
            btnCancel.Visible = true;
        }
        
        private void CUProduct_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (closable == false)
            {
                var ans = MessageBox.Show("Todos los cambios quedarán anulados si decides abandonar el formulario", "¿Seguro de salir del formulario?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (ans == DialogResult.Yes)
                {
                    if (productToUpdate != null)
                    {
                        RDProduct form = new RDProduct();
                        form.MdiParent = metaGamesInventory.home.ActiveForm;
                        form.Text = "Productos regitrados";
                        form.Show();
                    }
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        List<provider> providers;//Listado de proveedores para combobox cmbProvider
        List<product_category> categories;//Listado de categoria de productos para combobox cmbCategory

        private void CUProduct_Load(object sender, EventArgs e)
        {
            using (metaGamesInventoryAlterEntities BD = new metaGamesInventoryAlterEntities())
                //Creamos un nuevo contexto de la base de datos
            {
                providers = BD.provider.ToList<provider>();//Obtenemos los registros de la tabla Provider
                categories = BD.product_category.ToList<product_category>();//Obtenemos los registros de la tabla Product_category
            }
            foreach(var p in providers)
                //Agregamos los nombres de los proveedores de la base de datos al combobox
            {
                if (productToUpdate != null && p.id.Equals(productToUpdate.id_provider))
                    //Si acaso se esta ejecutando la actualización de datos de un producto,
                    //establecemos por defecto el valor de cmbProvider con el dato proveniente del producto en cuestión.
                {
                    cmbProvider.Text = p.name;
                }
                cmbProvider.Items.Add(p.name);
            }
            foreach(var c in categories)
                //Agregamos los nombres de las categorias de la base de datos al combobox
            {
                if (productToUpdate != null && c.id.Equals(productToUpdate.id_product_category))
                //Si acaso se esta ejecutando la actualización de datos de un producto,
                //establecemos por defecto el valor de cmbCategory con el dato proveniente del producto en cuestión.
                {
                    cmbCategory.Text = c.name;
                }
                cmbCategory.Items.Add(c.name);
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (controlValidator())
                //Si el formulario entero cumple las validaciones
            {
                if (productToUpdate == null)
                /*Si el objeto productToUpdate no cambia su estado inicial (null),
                 significa que no proviene del formulario RDProduct, por ende,
                 se ejecutara una inserción a la tabla Product*/
                {
                    createProduct();
                }
                else
                {
                    updateProduct();
                }
            }
        }

        private void updateProduct()
            //Método encargado de la actualización de datos dentro del contexto de la tabla Product y,
            //posteriormente, en la base de datos.
        {
            productToUpdate.name = txtName.Text;
            productToUpdate.price = Double.Parse(nudPrice.Value.ToString());
            productToUpdate.minimum_quantity = Int32.Parse(nudMinimum.Value.ToString());
            productToUpdate.stock = Int32.Parse(nudStock.Value.ToString());
            //Obtenemos el id, tanto del proveedor como de la categoria seleccionada,
            //gracias a una consulta a las listas correspondientes
            try
            {
                productToUpdate.id_provider = providers.Where(d => d.name == cmbProvider.Text).First().id;
            }
            catch
            /*Si acaso no encuentra el proveedor registrado, se procede a crear un nuevo registro dentro de la tabla Provider*/
            {
                using (metaGamesInventoryAlterEntities BD = new metaGamesInventoryAlterEntities())
                {
                    try
                    {
                        provider newProvider = new provider();
                        newProvider.name = cmbProvider.Text;
                        BD.provider.Add(newProvider);
                        BD.SaveChanges();
                    }
                    catch
                    {
                        MessageBox.Show("El proveedor ya existe", "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                }
            }

            try

            {
                productToUpdate.id_product_category = categories.Where(d => d.name == cmbCategory.Text).First().id;
            }
            catch
            /*Si acaso no encuentra el proveedor registrado, se procede a crear un nuevo registro dentro de la tabla product_category*/
            {
                using (metaGamesInventoryAlterEntities BD = new metaGamesInventoryAlterEntities())
                {
                    try
                    {
                        product_category newCategory = new product_category();
                        newCategory.name = cmbCategory.Text;
                        BD.product_category.Add(newCategory);
                        BD.SaveChanges();
                    }
                    catch
                    {
                        MessageBox.Show("La categoría ya existe", "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            productToUpdate.product_description = txtDescription.Text;

            using (metaGamesInventoryAlterEntities BD = new metaGamesInventoryAlterEntities())
                //Creamos un nuevo contexto de la base de datos
            {
                
                productToUpdate.id_provider = BD.provider.Where(d => d.name == cmbProvider.Text).First().id;
                productToUpdate.id_product_category = BD.product_category.Where(d => d.name == cmbCategory.Text).First().id;
                
                //Actualizamos el producto registrado dentro del contexto, por el objeto productToUpdate
                BD.Entry(productToUpdate).State = System.Data.Entity.EntityState.Modified;
                BD.SaveChanges();//Persistimos los datos actualizados dentro de la base de datos
                MessageBox.Show("Producto modificado exitosamente.", "Operación exitosa", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                closable = true;
                this.Close();
                RDProduct form = new RDProduct();
                form.MdiParent = metaGamesInventory.home.ActiveForm;
                form.Text = "Productos registrados";
                form.Show();
            }
        }

        private void createProduct()
            //Método encargado de la inserción de datos dentro del contexto de la tabla Product y,
            //posteriormente, en la base de datos.
        {
            product obj = new product();//Objeto que almacenará los datos obtenidos de los controles del formulario
            
            obj.name = txtName.Text;
            obj.price = Double.Parse(nudPrice.Value.ToString());
            obj.minimum_quantity = Int32.Parse(nudMinimum.Value.ToString());
            obj.stock = Int32.Parse(nudStock.Value.ToString());

            //Obtenemos el id, tanto del proveedor como de la categoria seleccionada,
            //gracias a una consulta a las listas correspondientes
            try

            {
                obj.id_provider = providers.Where(d => d.name == cmbProvider.Text).First().id;
            }
            catch
                /*Si acaso no encuentra el proveedor registrado, se procede a crear un nuevo registro dentro de la tabla Provider*/
            {
                using(metaGamesInventoryAlterEntities BD = new metaGamesInventoryAlterEntities())
                {
                    try
                    {
                        provider newProvider = new provider();
                        newProvider.name = cmbProvider.Text;
                        BD.provider.Add(newProvider);
                        BD.SaveChanges();
                    }
                    catch
                    {
                        MessageBox.Show("El proveedor ya existe", "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    
                }
            }

            try

            {
                obj.id_product_category = categories.Where(d => d.name == cmbCategory.Text).First().id;
            }
            catch
                /*Si acaso no encuentra el proveedor registrado, se procede a crear un nuevo registro dentro de la tabla product_category*/
            {
                using(metaGamesInventoryAlterEntities BD = new metaGamesInventoryAlterEntities())
                {
                    try
                    {
                        product_category newCategory = new product_category();
                        newCategory.name = cmbCategory.Text;
                        BD.product_category.Add(newCategory);
                        BD.SaveChanges();
                    }
                    catch
                    {
                        MessageBox.Show("La categoría ya existe", "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }

            obj.product_description = txtDescription.Text;

            using (metaGamesInventoryAlterEntities BD = new metaGamesInventoryAlterEntities())
            //Creamos un nuevo contexto de la base de datos
            {
                if(obj.id_provider == null)
                {
                    obj.id_provider = BD.provider.Where(d => d.name == cmbProvider.Text).First().id;
                }
                if(obj.id_product_category == null)
                {
                    obj.id_product_category = BD.product_category.Where(d => d.name == cmbCategory.Text).First().id;
                }
                BD.product.Add(obj);//Añadimos el objeto previamente establecido al contexto creado
                BD.SaveChanges();//Persistimos los datos del contexto, dentro de la base de datos
                MessageBox.Show("Producto registrado exitosamente.", "Operación exitosa", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                closable = true;
                this.Close();
                RDProduct form = new RDProduct();
                form.MdiParent = metaGamesInventory.home.ActiveForm;
                form.Text = "Productos registrados";
                form.Show();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
            //Método encargado del display de msgbox de confirmación
        {
            var ans = MessageBox.Show("¿Estas seguro de cancelar la modificación del producto " + productToUpdate.name.ToString() + " ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (ans == DialogResult.Yes)
            {
                closable = true;
                this.Close();
                RDProduct form = new RDProduct();
                form.MdiParent = metaGamesInventory.home.ActiveForm;
                form.Text = "Productos registrados";
                form.Show();
            }
        }

        
        private bool controlValidator()
            /*Método encargado de validar las entradas del formulario CUProduct*/
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))//Si no se ha ingresado información al campo indicado...
            {
                txtName.Focus();//Enfocamos el campo
                //Añadimos un mensaje descriptivo del error de validación
                errorProvider1.SetError(txtName, "Por favor, ingresa el nombre del producto");
                return false;
            }
            else
            {
                errorProvider1.SetError(txtName, null);
                //Eliminamos cualquier mensaje de validación referido al campo en cuestión
            }

            if (string.IsNullOrWhiteSpace(cmbProvider.Text))//Si no se ha ingresado información al campo indicado...
            {
                //Añadimos un mensaje descriptivo del error de validación
                errorProvider1.SetError(cmbProvider, "Por favor, ingresa el proveedor del producto");
                return false;
            }
            else
            {
                errorProvider1.SetError(cmbProvider, null);
                //Eliminamos cualquier mensaje de validación referido al campo en cuestión
            }

            if (string.IsNullOrWhiteSpace(cmbCategory.Text))//Si no se ha ingresado información al campo indicado...
            {
                //Añadimos un mensaje descriptivo del error de validación
                errorProvider1.SetError(cmbCategory, "Por favor, ingresa la categoría del producto");
                return false;
            }
            else
            {
                errorProvider1.SetError(cmbCategory, null);
                //Eliminamos cualquier mensaje de validación referido al campo en cuestión
            }
            
            return true;
        }

        private void btnProviderInfo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Si no existe el proveedor que necesitas," +
                "puedes dejar escrito su nombre y automaticamente se creara un registro con el nombre que le asignaste!" +
                "\n¡Ojo! Se creara el registro unicamente con su nombre. Si deseas editarlo más detalladamente, tendrás que" +
                "dirigirte al panel de Proveedores.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnCategoryinfo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Si no existe la categoría que necesitas," +
                "puedes dejar escrito su nombre y automaticamente se creara un registro con el nombre que le asignaste!",
                "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
