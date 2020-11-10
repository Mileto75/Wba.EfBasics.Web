using System;
using System.Collections.Generic;
using System.Text;

namespace Wba.EfBasics.Domain.Entities
{
    public class Student
    {
        public long Id { get; set; }
        public string StudentName { get; set; }
        public Course Course { get; set; }
    }
}
