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
    
    public partial class employee
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public employee()
        {
            this.actions = new HashSet<actions>();
            this.orders = new HashSet<orders>();
        }
    
        public int id { get; set; }
        public string name { get; set; }
        public string login_user { get; set; }
        public string login_pass { get; set; }
        public string emergency_question { get; set; }
        public string answer { get; set; }
        public Nullable<int> id_group { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<actions> actions { get; set; }
        public virtual groups groups { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        override
        public string ToString()
        {
            return name;
        }
        public virtual ICollection<orders> orders { get; set; }
    }
}
