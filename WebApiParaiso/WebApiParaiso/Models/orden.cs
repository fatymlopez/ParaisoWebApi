namespace WebApiParaiso.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("orden")]
    public partial class orden
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public orden()
        {
            ventash = new HashSet<ventash>();
        }

        public int id { get; set; }

        public int idubicacion { get; set; }

        public int idcliente { get; set; }

        public int idproducto { get; set; }

        public int cantidad { get; set; }

        [Column(TypeName = "money")]
        public decimal precio { get; set; }

        [Column(TypeName = "money")]
        public decimal total { get; set; }

        public TimeSpan hora { get; set; }

        public virtual cliente cliente { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ventash> ventash { get; set; }
    }
}
