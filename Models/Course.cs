//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StudentService.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web;

    public partial class Course
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Course()
        {
            this.Sections = new HashSet<Section>();
        }
     
        public string DepartmentCode { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "CourseCode required")]
        [MaxLength(7 ,ErrorMessage = "CourseCode ID MaxLength 7 characters")]
        public string CourseCode { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "CourseTitle required")]
        [MaxLength(20, ErrorMessage = "CourseTitle MaxLength 20 characters")]
        public string CourseTitle { get; set; }
        [StringLength(1, ErrorMessage = "CrediteHour must be 1 character")]
        public string CrediteHour { get; set; }
        public string Syllabus { get; set; }
        public HttpPostedFileBase file { get; set; }
        public virtual Department Department { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Section> Sections { get; set; }
    }
}
