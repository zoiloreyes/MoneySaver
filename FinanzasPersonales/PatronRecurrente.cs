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
    
    public partial class PatronRecurrente
    {
        public int PatronRecurrenteID { get; set; }
        public int RecordatorioID { get; set; }
        public int TipoRecurrenciaID { get; set; }
        public Nullable<int> NumeroSeparaciones { get; set; }
        public Nullable<int> NumeroMaxOcurrencia { get; set; }
        public Nullable<int> DiaDeSemana { get; set; }
        public Nullable<int> SemanaDeMes { get; set; }
        public Nullable<int> DiaDeMes { get; set; }
        public Nullable<int> MesDeAno { get; set; }
    
        public virtual Recordatorio Recordatorio { get; set; }
        public virtual TipoRecurrencia TipoRecurrencia { get; set; }
    }
}
