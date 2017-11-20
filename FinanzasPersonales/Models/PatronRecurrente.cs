namespace FinanzasPersonales.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PatronRecurrente")]
    public partial class PatronRecurrente
    {
        public int PatronRecurrenteID { get; set; }

        public int RecordatorioID { get; set; }

        public int TipoRecurrenciaID { get; set; }

        public int? NumeroSeparaciones { get; set; }

        public int? NumeroMaxOcurrencia { get; set; }

        public int? DiaDeSemana { get; set; }

        public int? SemanaDeMes { get; set; }

        public int? DiaDeMes { get; set; }

        public int? MesDeAno { get; set; }

        public virtual Recordatorio Recordatorio { get; set; }

        public virtual TipoRecurrencia TipoRecurrencia { get; set; }
    }
}
