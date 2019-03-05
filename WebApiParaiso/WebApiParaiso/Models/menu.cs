namespace WebApiParaiso.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("menu")]
    public partial class menu
    {
        public int id { get; set; }

        public int idproducto { get; set; }

        public string descripcion { get; set; }

        [Column(TypeName = "money")]
        public decimal precio { get; set; }

        public virtual productos productos { get; set; }
    }
}
