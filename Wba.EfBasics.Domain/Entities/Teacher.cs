using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Wba.EfBasics.Domain.Entities
{
    public class Teacher
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(150)]
        public string TeacherName { get; set; }
        [Required]
        public decimal YearlyWage { get; set; }
        public ContactInfo ContactInfo { get; set; }
        public ICollection<CoursesTeachers> Courses { get; set; }
    }
}
