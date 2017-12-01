using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FinanzasPersonales.Models
{
    public class FinanzasPersonalesViewModels
    {

    }

    public class TransaccionViewModel
    {
        public int? CategoriaID { get; set; }

        public int? CuentaBancoIDFuente { get; set; }

        public int? TarjetaCreditoIDFuente { get; set; }

        public int? CuentaPrestamoIDFuente { get; set; }

        public int? CuentaBancoIDObjetivo { get; set; }

        public int? TarjetaCreditoIDObjetivo { get; set; }

        public int? CuentaPrestamoIDObjetivo { get; set; }

        [StringLength(100)]
        public string No_Ref_Externo { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Fecha { get; set; }

        public bool? EFECTIVO { get; set; }

        [StringLength(900)]
        public string Adjunto { get; set; }

        public decimal? MontoIngreso { get; set; }

        public decimal? MontroEgreso { get; set; }
    }
}