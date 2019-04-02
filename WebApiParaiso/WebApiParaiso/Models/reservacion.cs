namespace WebApiParaiso.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("reservacion")]
    public partial class reservacion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public reservacion()
        {
            detallereservacion = new HashSet<detallereservacion>();
            orden = new HashSet<orden>();
        }

        public int id { get; set; }

        public int idubicacion { get; set; }

        public int idcliente { get; set; }

        public int idproducto { get; set; }

        public int cantidad { get; set; }

        public decimal? total { get; set; }

        public virtual cliente cliente { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<detallereservacion> detallereservacion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<orden> orden { get; set; }
    }
}
