using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
                .ToList();
            foreach(var courseWb in coursesWb)
            {
                Console.WriteLine($"{courseWb.Id}-{courseWb.CourseName}");
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
