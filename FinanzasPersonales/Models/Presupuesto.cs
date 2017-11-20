namespace FinanzasPersonales.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Presupuesto")]
    public partial class Presupuesto
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Presupuesto()
        {
            PresupuestoCategoria = new HashSet<PresupuestoCategoria>();
        }

        public int PresupuestoID { get; set; }

        public int PeriodoTemporalID { get; set; }

        public int UsuarioID { get; set; }

        [Required]
        [StringLength(200)]
        public string Nombre { get; set; }

        public virtual PeriodoTemporal PeriodoTemporal { get; set; }

        public virtual User User { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PresupuestoCategoria> PresupuestoCategoria { get; set; }
    }
}
