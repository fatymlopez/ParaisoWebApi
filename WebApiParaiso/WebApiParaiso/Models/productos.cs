namespace WebApiParaiso.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class productos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public productos()
        {
            menu = new HashSet<menu>();
        }

        public int id { get; set; }

        public int idcategoria { get; set; }

        [Required]
        [StringLength(75)]
        public string nomproducto { get; set; }

        public string descripcion { get; set; }

        [Column(TypeName = "money")]
        public decimal precio { get; set; }

        public int existencia { get; set; }

        public virtual categorias categorias { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<menu> menu { get; set; }
    }
}
