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
        public int id { get; set; }

        public int idubicacion { get; set; }

        public int idcliente { get; set; }

        public int idproducto { get; set; }

        public int cantidad { get; set; }

        [Column(TypeName = "money")]
        public decimal precio { get; set; }
    }
}
