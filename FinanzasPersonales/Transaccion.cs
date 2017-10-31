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
    
    public partial class Transaccion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Transaccion()
        {
            this.Recordatorios = new HashSet<Recordatorio>();
        }
    
        public int TransaccionID { get; set; }
        public string UsuarioID { get; set; }
        public Nullable<int> CuentaBancoID { get; set; }
        public Nullable<int> TarjetaCreditoID { get; set; }
        public Nullable<int> CuentaPrestamoID { get; set; }
        public Nullable<int> ContactoID { get; set; }
        public string No_Ref_Externo { get; set; }
        public Nullable<System.DateTime> Fecha { get; set; }
        public Nullable<bool> EFECTIVO { get; set; }
        public string Adjunto { get; set; }
        public Nullable<decimal> MontoIngreso { get; set; }
        public Nullable<decimal> MontroEgreso { get; set; }
    
        public virtual AspNetUser AspNetUser { get; set; }
        public virtual Contacto Contacto { get; set; }
        public virtual CuentaBanco CuentaBanco { get; set; }
        public virtual CuentaPrestamo CuentaPrestamo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Recordatorio> Recordatorios { get; set; }
        public virtual TarjetaCredito TarjetaCredito { get; set; }
    }
}