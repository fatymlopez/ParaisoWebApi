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
        public int id { get; set; }

        public int idubicacion { get; set; }

        public int? idreservacion { get; set; }

        public DateTime fecha { get; set; }

        public int? estado { get; set; }

        public virtual reservacion reservacion { get; set; }

        public virtual ubicacion ubicacion { get; set; }
    }
}
