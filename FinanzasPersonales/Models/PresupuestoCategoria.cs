namespace FinanzasPersonales.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PresupuestoCategoria")]
    public partial class PresupuestoCategoria
    {
        public int PresupuestoCategoriaID { get; set; }

        public int CategoriaID { get; set; }

        public int PresupuestoID { get; set; }

        public decimal? Monto { get; set; }

        public virtual Categoria Categoria { get; set; }

        public virtual Presupuesto Presupuesto { get; set; }
    }
}
