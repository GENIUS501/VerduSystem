//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AccesoDatos
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tab_Roles
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tab_Roles()
        {
            this.Tab_Permisos = new HashSet<Tab_Permisos>();
            this.Tab_Usuarios = new HashSet<Tab_Usuarios>();
        }
    
        public int Id_Rol { get; set; }
        public string Nombre_Rol { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tab_Permisos> Tab_Permisos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tab_Usuarios> Tab_Usuarios { get; set; }
    }
}
