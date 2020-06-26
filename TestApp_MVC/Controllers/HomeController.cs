using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestApp_MVC.Models;
using TestApp_MVC.Repository.EmployeeRepository;
using static TestApp_MVC.Controllers.HomeController;

namespace TestApp_MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = ""; 
            StudentData newData = new StudentData();
            //To display data Count of Data should be more then 2 records ,kinldy check the query for more reference
            StudentRepository obj = new StudentRepository();
            newData.students = obj.StudentList();
            return View(newData);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        

        [HttpPost]
        public ActionResult Index(StudentData studentData)
        {
            StudentData newData = new StudentData();
            ViewBag.Message = "";
            if(ModelState.IsValid)
            {
                StudentRepository obj = new StudentRepository();
                int result=obj.saveData(studentData);
                if(result==0)
                {
                    ViewBag.Message = "Some Error Occured";
                }
                else
                {
                    ViewBag.Message = "Data Saved Successfully";
                }
                ModelState.Clear();
                newData.students = obj.StudentList();

                return View("Index", newData);
            } 
            return View("Index", studentData);
        }

      
    }

    
}