using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Taskie.Models
{
    public class AssignmentModel
    {
        public string Assignment_ID { get; set; }
        public string Assignment_Title { get; set; }
        public string Assignment_Description { get; set; }
        public byte[] Assignment_Image { get; set; }
        public string Assignment_Priority { get; set; }
        public string Created_By_Employee_ID { get; set; }
    }
   
    
    public class AssignmentListingModel
    {
        public IEnumerable<Assigment_table> Assigments_List { get; set; }
    }
}