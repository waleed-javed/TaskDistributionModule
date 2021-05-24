namespace Taskie.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Assignment_Comment_table
    {
        [Key]
        [StringLength(10)]
        public string Comment_ID { get; set; }

        [StringLength(10)]
        public string Assignment_ID { get; set; }

        public string Comment { get; set; }

        [Column(TypeName = "image")]
        public byte[] Comment_Image { get; set; }

        public virtual Assigment_table Assigment_table { get; set; }
    }
}
