namespace FinanzasPersonales.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Banco")]
    public partial class Banco
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Banco()
        {
            CuentaBanco = new HashSet<CuentaBanco>();
            TarjetaCredito = new HashSet<TarjetaCredito>();
        }

        public int BancoID { get; set; }

        [Required]
        [StringLength(200)]
        public string NombreBanco { get; set; }

        [Required]
        [StringLength(30)]
        public string Pais { get; set; }

        [Required]
        public int UsuarioID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CuentaBanco> CuentaBanco { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TarjetaCredito> TarjetaCredito { get; set; }
    }
}
