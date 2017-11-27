namespace FinanzasPersonales.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CuentaBanco")]
    public partial class CuentaBanco
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CuentaBanco()
        {
            Transaccion = new HashSet<Transaccion>();
        }

        public int CuentaBancoID { get; set; }

        public int BancoID { get; set; }

        public int UsuarioID { get; set; }

        public int EstadoCuentaBancoID { get; set; }

        public int MonedaID { get; set; }

        [Required]
        [StringLength(120)]
        public string NombreCuentaBanco { get; set; }

        [Required]
        [StringLength(40)]
        public string NumeroCuenta { get; set; }

        [Required]
        [StringLength(80)]
        public string NombreTitular { get; set; }

        [Required]
        [StringLength(80)]
        public string ApellidoTitular { get; set; }

        [Column(TypeName = "date")]
        public DateTime FechaInicio { get; set; }

        public decimal BalanceInicial { get; set; }

        [StringLength(800)]
        public string Comentario { get; set; }

        public virtual Banco Banco { get; set; }

        public virtual EstadoCuentaBanco EstadoCuentaBanco { get; set; }

        public virtual Moneda Moneda { get; set; }

        public virtual User User { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Transaccion> Transaccion { get; set; }
    }
}
