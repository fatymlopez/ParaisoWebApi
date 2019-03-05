namespace WebApiParaiso.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ventash")]
    public partial class ventash
    {
        public int id { get; set; }

        public int idorden { get; set; }

        public int idubicacion { get; set; }

        public int idcliente { get; set; }

        public int idproducto { get; set; }

        public int cantidad { get; set; }

        [Column(TypeName = "money")]
        public decimal precio { get; set; }

        [Column(TypeName = "money")]
        public decimal total { get; set; }

        public TimeSpan hora { get; set; }

        public DateTime fecha { get; set; }

        public virtual orden orden { get; set; }
    }
}
