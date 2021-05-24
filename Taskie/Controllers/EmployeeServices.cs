using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Taskie.Models;

namespace Taskie.Controllers
{
    public class EmployeeServices
    {
        TaskieEntitiesModel dbContext = new TaskieEntitiesModel();

        //check availabale User Data
        public bool checkUserNameAvailable(Employee_table employee)
        {
            var response = dbContext.Employee_table.FirstOrDefault(res => res.Emp_Name == employee.Emp_Name || res.ID == employee.ID);
            if ( response != null)
            {
                return true;
            }
        return false;
        }

        // find User in Db by Username
        public string GetByUsername(string username)
        {
            if(!String.IsNullOrEmpty(username))
            {
                var response = dbContext.Employee_table.Find(username).ToString();
                if (!String.IsNullOrEmpty(response)){
                    return response;
                }
                return null;
            }
            return null;
        }

        //Return the complete table
        public List<Employee_table> GetAllEmployees()
        {

            return dbContext.Employee_table.Select(row => row).ToList();                
        }

        //save new users
        public void SaveEmployeeToDB(Employee_table employee)
        {
            if (employee != null)
            {
            dbContext.Employee_table.Add(employee);
            }
        }
    }



}