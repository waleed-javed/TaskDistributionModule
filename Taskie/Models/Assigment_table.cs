namespace Taskie.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Assigment_table
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Assigment_table()
        {
            Assignment_Comment_table = new HashSet<Assignment_Comment_table>();
            Task_Forward_table = new HashSet<Task_Forward_table>();
        }

        [Key]
        [StringLength(10)]
        public string Assignment_ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Assignment_Title { get; set; }

        [Required]
        public string Assignment_Description { get; set; }

        [Column(TypeName = "image")]
        public byte[] Assignment_Image { get; set; }

        [Required]
        [StringLength(10)]
        public string Assignment_Priority { get; set; }

        [StringLength(10)]
        public string Created_By_Employee_ID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Assignment_Comment_table> Assignment_Comment_table { get; set; }

        public virtual Employee_table Employee_table { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Task_Forward_table> Task_Forward_table { get; set; }
    }
}
