namespace FinanzasPersonales.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Contacto")]
    public partial class Contacto
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Contacto()
        {
            Transaccion = new HashSet<Transaccion>();
        }

        public int ContactoID { get; set; }

        public int UsuarioID { get; set; }

        [Required]
        [StringLength(300)]
        public string Nombre { get; set; }

        [StringLength(256)]
        public string Email { get; set; }

        [StringLength(500)]
        public string Direccion { get; set; }

        [StringLength(400)]
        public string Telefono { get; set; }

        public virtual User User { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Transaccion> Transaccion { get; set; }
    }
}
