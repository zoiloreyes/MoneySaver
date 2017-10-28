//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FinanzasPersonales.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Recordatorio
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Recordatorio()
        {
            this.PatronRecurrente = new HashSet<PatronRecurrente>();
        }
    
        public int RecordatorioID { get; set; }
        public string UsuarioID { get; set; }
        public Nullable<int> TransaccionID { get; set; }
        public string Descripcion { get; set; }
        public Nullable<System.DateTime> FechaInicio { get; set; }
        public Nullable<System.DateTime> FechaFin { get; set; }
        public bool EsRecurrente { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
    
        public virtual AspNetUsers AspNetUsers { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PatronRecurrente> PatronRecurrente { get; set; }
        public virtual Transaccion Transaccion { get; set; }
    }
}
