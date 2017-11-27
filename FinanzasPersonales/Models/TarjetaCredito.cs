namespace FinanzasPersonales.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TarjetaCredito")]
    public partial class TarjetaCredito
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TarjetaCredito()
        {
            Transaccion = new HashSet<Transaccion>();
        }

        public int TarjetaCreditoID { get; set; }

        public int UsuarioID { get; set; }

        public int BancoID { get; set; }

        public int EstadoTarjetaCreditoID { get; set; }

        public int MonedaID { get; set; }

        [Required]
        [StringLength(120)]
        public string NombreTarjetaCredito { get; set; }

        [Required]
        [StringLength(40)]
        public string NumeroTarjeta { get; set; }

        [Required]
        [StringLength(80)]
        public string NombreTitular { get; set; }

        [Required]
        [StringLength(80)]
        public string ApellidoTitular { get; set; }

        [Column(TypeName = "date")]
        public DateTime FechaInicio { get; set; }

        [Column(TypeName = "date")]
        public DateTime FechaExpiracion { get; set; }

        //public int MarcaID { get; set; }

        [Required]
        [StringLength(3)]
        public string CVC { get; set; }

        public decimal TasaEfectivaAnual { get; set; }

        public decimal DeudaInicial { get; set; }

        public decimal LimiteCredito { get; set; }

        [StringLength(800)]
        public string Comentario { get; set; }

        public virtual Banco Banco { get; set; }

        public virtual EstadoTarjetaCredito EstadoTarjetaCredito { get; set; }

        //public virtual Marca Marca { get; set; }

        public virtual Moneda Moneda { get; set; }

        public virtual User User { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Transaccion> Transaccion { get; set; }
    }
}
