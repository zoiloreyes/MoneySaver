namespace FinanzasPersonales.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CuentaPrestamo")]
    public partial class CuentaPrestamo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CuentaPrestamo()
        {
            Transaccion = new HashSet<Transaccion>();
        }
        [Required]
        [StringLength(120)]
        public string NombrePrestamo { get; set; }

        public int CuentaPrestamoID { get; set; }

        public int MonedaID { get; set; }

        public int UsuarioID { get; set; }

        public decimal? CapitalInicial { get; set; }

        public decimal TasaAnual { get; set; }

        public int? PagosPorAno { get; set; }

        [Column(TypeName = "date")]
        public DateTime? FechaInicio { get; set; }

        public int? NumeroPagos { get; set; }

        public virtual Moneda Moneda { get; set; }

        public virtual User User { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Transaccion> Transaccion { get; set; }
    }
}
