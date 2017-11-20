namespace FinanzasPersonales.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Transaccion")]
    public partial class Transaccion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Transaccion()
        {
            Recordatorio = new HashSet<Recordatorio>();
        }

        public int TransaccionID { get; set; }

        public int UsuarioID { get; set; }

        public int? CuentaBancoID { get; set; }

        public int? TarjetaCreditoID { get; set; }

        public int? CuentaPrestamoID { get; set; }

        public int? ContactoID { get; set; }

        [StringLength(100)]
        public string No_Ref_Externo { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Fecha { get; set; }

        public bool? EFECTIVO { get; set; }

        [StringLength(900)]
        public string Adjunto { get; set; }

        public decimal? MontoIngreso { get; set; }

        public decimal? MontroEgreso { get; set; }

        public virtual Contacto Contacto { get; set; }

        public virtual CuentaBanco CuentaBanco { get; set; }

        public virtual CuentaPrestamo CuentaPrestamo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Recordatorio> Recordatorio { get; set; }

        public virtual TarjetaCredito TarjetaCredito { get; set; }

        public virtual User User { get; set; }
    }
}
