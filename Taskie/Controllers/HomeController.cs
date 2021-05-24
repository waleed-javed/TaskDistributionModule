using System;
using System.Web.Mvc;
using Taskie.Models;

namespace Taskie.Controllers
{
    public class HomeController : Controller
    {
        //Accessing DB for storing the Data
        EmployeeServices EmpServices = new EmployeeServices();

        /// <summary>
        /// This Action returns Landing page for the Employee
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Psot Action for Landing page
        /// </summary>
        /// <param name="employee"></param>
        /// <returns> Redirects to Next Page, if Successfull.</returns>
        [HttpPost]
        public ActionResult Index(Employee_table employee)
        {
            if (employee != null)
            {
                if (!EmpServices.checkUserNameAvailable(employee))
                {
                    //Randomizing the ID for simplicity purposes
                    //var rand = new Random();
                    //employee.ID = rand.Next(10).ToString();

                    //Adding values to DB Table
                    EmpServices.SaveEmployeeToDB(employee);
               
                return RedirectToAction("Index","Assignmnet");
                }
                return View();
            }
            return View();
        }


        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}