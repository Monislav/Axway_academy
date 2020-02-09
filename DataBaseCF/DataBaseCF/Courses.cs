using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseCF
{
    public class Courses
    {

        public int Id { get; set; }
        public int CoursesID { get; set; }
        public string Name { get; set; }
        public int Credits { get; set; }

        public virtual Student Student { get; set; }
    }
}
