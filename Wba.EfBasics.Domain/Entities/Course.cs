using System;
using System.Collections.Generic;
using System.Text;

namespace Wba.EfBasics.Domain.Entities
{
    public class Course
    {
        public long Id { get; set; }
        public string CourseName { get; set; }
        public int Duration { get; set; }
        public ICollection<CoursesTeachers> Teachers { get; set; }

        public ICollection<Student> Students { get; set; }
    }
}
