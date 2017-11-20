namespace FinanzasPersonales.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EstadoTarjetaDebito")]
    public partial class EstadoTarjetaDebito
    {
        public int EstadoTarjetaDebitoID { get; set; }

        [Required]
        [StringLength(200)]
        public string Estado { get; set; }
    }
}
