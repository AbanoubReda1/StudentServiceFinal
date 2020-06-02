using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentService.Models
{
    public class filtr
    {
        public string DepartmentCode { get; set; }
        public string CourseCode { get; set; }
        public ICollection<Section> SectionDetails { get; set; }
        public ICollection<Instructor> InstructorDetails { get; set; }
        public ICollection<Material> MaterialDetails { get; set; }
        public ICollection<Task> TaskDetails { get; set; }
        public ICollection<Type> TypeDetails { get; set; }
    }
}