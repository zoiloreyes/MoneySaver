namespace FinanzasPersonales.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TipoRecurrencia")]
    public partial class TipoRecurrencia
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TipoRecurrencia()
        {
            PatronRecurrente = new HashSet<PatronRecurrente>();
        }

        public int TipoRecurrenciaID { get; set; }

        [Required]
        [StringLength(200)]
        public string Nombre { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PatronRecurrente> PatronRecurrente { get; set; }
    }
}
