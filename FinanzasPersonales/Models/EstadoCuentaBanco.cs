namespace FinanzasPersonales.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EstadoCuentaBanco")]
    public partial class EstadoCuentaBanco
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EstadoCuentaBanco()
        {
            CuentaBanco = new HashSet<CuentaBanco>();
        }

        public int EstadoCuentaBancoID { get; set; }

        [Required]
        [StringLength(200)]
        public string Estado { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CuentaBanco> CuentaBanco { get; set; }
    }
}
