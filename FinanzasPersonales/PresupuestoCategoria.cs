//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FinanzasPersonales
{
    using System;
    using System.Collections.Generic;
    
    public partial class PresupuestoCategoria
    {
        public int PresupuestoCategoriaID { get; set; }
        public int CategoriaID { get; set; }
        public int PresupuestoID { get; set; }
        public Nullable<decimal> Monto { get; set; }
    
        public virtual Categoria Categoria { get; set; }
        public virtual Presupuesto Presupuesto { get; set; }
    }
}
