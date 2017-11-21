namespace FinanzasPersonales.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Categoria")]
    public partial class Categoria
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Categoria()
        {
            Categoria1 = new HashSet<Categoria>();
            PresupuestoCategoria = new HashSet<PresupuestoCategoria>();
        }

        public int CategoriaID { get; set; }

        public int EstadoCategoriaID { get; set; }

        public int UsuarioID { get; set; }

        public int TipoCategoriaID { get; set; }

        public int? PadreCategoriaID { get; set; }

        public int MonedaID { get; set; }

        [StringLength(800)]
        public string Comentario { get; set; }

        [StringLength(400)]
        public string Nombre { get; set; }

        public virtual EstadoCategoria EstadoCategoria { get; set; }

        public virtual Moneda Moneda { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Categoria> Categoria1 { get; set; }

        public virtual Categoria Categoria2 { get; set; }

        public ICollection<Transaccion> Transacciones { get; set; }

        public virtual TipoCategoria TipoCategoria { get; set; }

        public virtual User User { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PresupuestoCategoria> PresupuestoCategoria { get; set; }
    }
}
