namespace FinanzasPersonales.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EstadoTarjetaCredito")]
    public partial class EstadoTarjetaCredito
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EstadoTarjetaCredito()
        {
            TarjetaCredito = new HashSet<TarjetaCredito>();
        }

        public int EstadoTarjetaCreditoID { get; set; }

        [Required]
        [StringLength(200)]
        public string Estado { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TarjetaCredito> TarjetaCredito { get; set; }
    }
}
