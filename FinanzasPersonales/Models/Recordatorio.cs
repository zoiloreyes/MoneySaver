namespace FinanzasPersonales.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Recordatorio")]
    public partial class Recordatorio
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Recordatorio()
        {
            PatronRecurrente = new HashSet<PatronRecurrente>();
        }

        public int RecordatorioID { get; set; }

        public int UsuarioID { get; set; }

        public int? TransaccionID { get; set; }

        [Required]
        [StringLength(500)]
        public string Descripcion { get; set; }

        [Column(TypeName = "date")]
        public DateTime? FechaInicio { get; set; }

        [Column(TypeName = "date")]
        public DateTime? FechaFin { get; set; }

        public bool EsRecurrente { get; set; }

        [Column(TypeName = "date")]
        public DateTime? FechaCreacion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PatronRecurrente> PatronRecurrente { get; set; }

        public virtual Transaccion Transaccion { get; set; }

        public virtual User User { get; set; }
    }
}
