using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using LAB3_LOBRICO_JB_31A3.Models;

namespace LAB3_LOBRICO_JB_31A3.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            string studentName = "JB SASPA LOBRICO";
            int score = 87;
            bool isPassed = (score >= 75);
            DateTime examDate = DateTime.Now;
            decimal tuitionFee = 15500.75m;

            ViewBag.StudentName = studentName;
            ViewBag.Score = score;
            ViewBag.IsPassed = isPassed;
            ViewBag.ExamDate = examDate;
            ViewBag.TuitionFee = tuitionFee;

            string grade;
            string message;
            if (score >= 90)
                grade = "A";
            else if (score >= 80)
                grade = "B";
            else if (score >= 75)
                grade = "C";
            else
                grade = "F";

            message = isPassed ? "Congratulations, you passed!" : "Better luck next time.";

            ViewBag.Grade = grade;
            ViewBag.Message = message;

            string[] courses = { "Web Systems", "OOP", "DBMS", "UI/UX", "Networking" };
            string courseList = string.Join(", ", courses);
            int courseCount = courses.Length;

            ViewBag.CourseList = courseList;
            ViewBag.CourseCount = courseCount;

            ViewBag.NetFee = ComputeNetFee(tuitionFee, 10);
            ViewBag.Today = DateTime.Now.ToString("MMMM dd, yyyy");

            var student = new Student
            {
                Name = "JB",
                Age = 21,
                Course = "Web Systems"
            };
            ViewBag.Student = student;

            var students = new List<Student>
            {
                new Student { Name = "Kathryn Bernardo", Age = 27, Course = "Web Systems" },
                new Student { Name = "Daniel Padilla", Age = 28, Course = "OOP" },
                new Student { Name = "Liza Soberano", Age = 26, Course = "DBMS" }
            };
            ViewBag.Students = students;

            return View();
        }

        private decimal ComputeNetFee(decimal tuition, decimal discountPercent)
        {
            return tuition - (tuition * discountPercent / 100);
        }

        public IActionResult AboutMe()
        {
            return View();
        }
    }
}
