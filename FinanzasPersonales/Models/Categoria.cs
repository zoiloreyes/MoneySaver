//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FinanzasPersonales.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Categoria
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Categoria()
        {
            this.Categoria1 = new HashSet<Categoria>();
            this.PresupuestoCategoria = new HashSet<PresupuestoCategoria>();
        }
    
        public int CategoriaID { get; set; }
        public int EstadoCategoriaID { get; set; }
        public string UsuarioID { get; set; }
        public int TipoCategoriaID { get; set; }
        public Nullable<int> PadreCategoriaID { get; set; }
        public int MonedaID { get; set; }
        public string Comentario { get; set; }
        public string Nombre { get; set; }
    
        public virtual AspNetUsers AspNetUsers { get; set; }
        public virtual EstadoCategoria EstadoCategoria { get; set; }
        public virtual Moneda Moneda { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Categoria> Categoria1 { get; set; }
        public virtual Categoria Categoria2 { get; set; }
        public virtual TipoCategoria TipoCategoria { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PresupuestoCategoria> PresupuestoCategoria { get; set; }
    }
}
