//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace metaGamesInventory
{
    using System;
    using System.Collections.Generic;
    
    public partial class tax
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tax()
        {
            this.orders_tax = new HashSet<orders_tax>();
        }
    
        public int id { get; set; }
        public string name { get; set; }
        public int percentage { get; set; }
        public Nullable<bool> default_tax { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<orders_tax> orders_tax { get; set; }
    }
}
