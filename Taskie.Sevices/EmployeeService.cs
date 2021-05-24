using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taskie.Models;

namespace Taskie.Sevices
{
    public class EmployeeService
    {
        public void SaveEmployee(Employee_table employee)
        {
            using (TaskieEntitiesModel dbContext = new TaskieEntitiesModel())
            {
                //Adding values to DB Table
                dbContext.Employee_table.Add(employee);
                dbContext.SaveChanges();
            }
        }
    }
}
