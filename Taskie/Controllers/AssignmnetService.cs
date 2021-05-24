using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Taskie.Models;

namespace Taskie.Controllers
{
    public class AssignmentService
    {
        TaskieEntitiesModel dbContext = new TaskieEntitiesModel();
        public void CreateAssignment(Assigment_table assigment)
        {
            if (assigment != null)
            {
                Random ra = new Random();

                assigment.Assignment_ID = ra.Next().ToString(); // random initialization for simplicity--auto later
 
                assigment.Employee_table.ID = dbContext.Employee_table.Find(assigment.Created_By_Employee_ID.ToLower()).ToString();

                //assigment.Created_By_Employee_ID.ToString();
                if (assigment.Assignment_Image == null)
                {
                    //place holding for null image for the time being
                    int filLength = 0;
                    byte[] byteImageArray;
                    byteImageArray = new byte[Convert.ToInt32(filLength)];
                    assigment.Assignment_Image = byteImageArray;
                }
                else
                {
                    var imageParts = assigment.Assignment_Image.ToString().Split(',').ToList<string>();
                    //Exclude the header from base64 by taking second element in List.
                    assigment.Assignment_Image = Convert.FromBase64String(imageParts[1]);
                }
                    dbContext.Assigment_table.Add(assigment);
                    dbContext.SaveChanges();
            }
        }
        
        public IEnumerable<Assigment_table> GetAllAssignmnets()
        {
            return dbContext.Assigment_table.ToList();
        }
    }

}