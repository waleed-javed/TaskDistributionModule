using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Taskie.Models;

namespace Taskie.Controllers
{
    public class AssignmnetController : Controller
    {
        AssignmentService AssignService = new AssignmentService();

        // GET: Assignmnet
        [HttpGet]
        public ActionResult Index()
        {
            AssignmentListingModel assignmentListing = new AssignmentListingModel();
            assignmentListing.Assigments_List = AssignService.GetAllAssignmnets();

            return View("Index",assignmentListing);
        }

        [HttpPost]
        public ActionResult Index(Assigment_table assigment)
        {
            return RedirectToAction("CreateAssignment");
        }


        public ActionResult CreateAssignment()
        {
            Assigment_table model = new Assigment_table();
            //Return the task creation page
            return View();
        }

        [HttpPost]
        public ActionResult CreateAssignment(Assigment_table assignment)
        {
            if(!String.IsNullOrEmpty(assignment.Assignment_Title))
            {
                AssignService.CreateAssignment(assignment);
                return RedirectToAction("Index","Assignmnet");
            }

            return View();
        }
    }
}
