namespace WebApiParaiso.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ubicacion")]
    public partial class ubicacion
    {
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string nomubicacion { get; set; }
    }
}
