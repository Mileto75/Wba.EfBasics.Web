using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Wba.EfBasics.Domain.Entities;
using Wba.EfBasics.Web.Data;
using Wba.EfBasics.Web.Models;

namespace Wba.EfBasics.Web.Controllers
{
    public class HomeController : Controller
    {
        //injecteer de databaseContext
        //declareer een private readonly DbContext
        private readonly SchoolDbContext _schoolDbContext;
        //injecteer de DbContext dmv Constructor
        public HomeController(SchoolDbContext schoolDbContext)
        {
            //injectie in controller
            _schoolDbContext = schoolDbContext;
        }
        public IActionResult Index()
        {
            //haal de cursus op met id 1
            var courseInDb = _schoolDbContext
                .Courses
                .SingleOrDefault(c => c.Id == 2);
            
            //haal alle cursussen op
            var courses = _schoolDbContext.Courses.ToList();
            foreach(var course in courses)
            {
                Console.WriteLine($"{course.Id}-{course.CourseName}");
            }
            //selectie op basis van voorwaarden
            //vb haal alle cursussen die beginnen met WB
            //linq Where
            var coursesWb = _schoolDbContext
                .Courses
                .Where(c => c.CourseName.Contains("WB"))
                .OrderBy(c => c.CourseName)
                .ToList();
            foreach(var courseWb in coursesWb)
            {
                Console.WriteLine($"{courseWb.Id}-{courseWb.CourseName}");
            }
            //selectie van veld(en)
            //bv enkel de courseName = enkel veld
            var courseOnlyTitle = _schoolDbContext
                .Courses
                .OrderBy(c => c.CourseName)
                .Select(c => c.CourseName)//vanaf hier = lijst van string
                .ToList();
            //select van 2(of meer) velden
            //gebruik anoniem object
            //vb Id en Coursename
            var coursesTitleId = _schoolDbContext
                .Courses
                .OrderBy(c => c.CourseName)
                .Select(c => new {c.CourseName,c.Id })
                .ToList();

            //ophalen gerelateerde data
            //gebruik de include method 
            //(rechtreeks gerelateerd)
            //ThenInclude (onrechtstreeks gerelateerd)
            //haal courses met hun teachers op
            var coursesTeachers = _schoolDbContext
                .Courses
                .Include(c => c.Teachers)//join CoursesTeachers
                .ThenInclude(ct => ct.Teacher)
                .OrderBy(c => c.CourseName)//join met Taachers
                .ToList();
            foreach(var coursesTeacher in coursesTeachers)
            {
                Console.WriteLine($"{coursesTeacher?.CourseName}");
                foreach(var teacher in coursesTeacher?.Teachers)
                {
                    Console.Write($"{teacher?.Teacher?.TeacherName} ");
                }
            }

            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
