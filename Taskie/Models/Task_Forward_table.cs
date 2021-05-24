namespace Taskie.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Task_Forward_table
    {
        [StringLength(10)]
        public string Task_Assignment_ID { get; set; }

        [StringLength(10)]
        public string Task_Assignment_Forwarded_To_Employee_ID { get; set; }

        [Required]
        [StringLength(10)]
        public string Task_Status { get; set; }

        [Key]
        [StringLength(10)]
        public string Task_Forward_ID { get; set; }

        public virtual Assigment_table Assigment_table { get; set; }

        public virtual Employee_table Employee_table { get; set; }
    }
}
