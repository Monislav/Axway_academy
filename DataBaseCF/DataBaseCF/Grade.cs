using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseCF
{
    public enum Grades
    {
        Failed,
        Fine,
        Good,
        VeryGood,
        Excellent
    }
    public class Grade
    {
        public int GradeID { get; set; }
        public int StudentID { get; set; }
        public Grades ? Grades { get; set; }
        public int CoursesID { get; set; }

        public virtual Student Student { get; set; }
        public virtual Courses Courses { get; set; }
    }
}
