using System;
using System.Collections.Generic;
using System.Text;

namespace Wba.EfBasics.Domain.Entities
{
    public class Teacher
    {
        public int Id { get; set; }
        public string TeacherName { get; set; }
        public decimal YearlyWage { get; set; }
        public ICollection<Course> Courses { get; set; }
    }
}
