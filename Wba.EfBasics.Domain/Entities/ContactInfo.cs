using System;
using System.Collections.Generic;
using System.Text;

namespace Wba.EfBasics.Domain.Entities
{
    public class ContactInfo
    {
        public long Id { get; set; }//Id naam
        public string Address { get; set; }
        //navigation property naar Teacher
        public Teacher Teacher { get; set; }
        public int TeacherId { get; set; }
    }
}
