//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FinanzasPersonales
{
    using System;
    using System.Collections.Generic;
    
    public partial class Recordatorio
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Recordatorio()
        {
            this.PatronRecurrentes = new HashSet<PatronRecurrente>();
        }
    
        public int RecordatorioID { get; set; }
        public string UsuarioID { get; set; }
        public Nullable<int> TransaccionID { get; set; }
        public string Descripcion { get; set; }
        public Nullable<System.DateTime> FechaInicio { get; set; }
        public Nullable<System.DateTime> FechaFin { get; set; }
        public bool EsRecurrente { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
    
        public virtual AspNetUser AspNetUser { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PatronRecurrente> PatronRecurrentes { get; set; }
        public virtual Transaccion Transaccion { get; set; }
    }
}