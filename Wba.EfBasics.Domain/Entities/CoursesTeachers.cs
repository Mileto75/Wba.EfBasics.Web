using System;
using System.Collections.Generic;
using System.Text;

namespace Wba.EfBasics.Domain.Entities
{
    public class CoursesTeachers
    {
        //navigation properties
        public Teacher Teacher { get; set; }
        public Course Course { get; set; }
        //foreign keys voor definiëren
        public int TeacherId { get; set; }
        public int CourseId { get; set; }
    }
}
