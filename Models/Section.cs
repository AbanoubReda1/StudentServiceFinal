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

    public partial class Section
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Section()
        {
            this.Materials = new HashSet<Material>();
            this.Tasks = new HashSet<Task>();
        }
    
        public string DepartmentCode { get; set; }
        public string CourseCode { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "SectionNumber required")]
        public int SectionNumber { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Semester required")]

        public string Semester { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Year required")]
        [StringLength(4, ErrorMessage = "Year must be 4 character")]
        [Range(2016, 2020, ErrorMessage = "You have reached your maximum limit of characters allowed (2016 to 2020)")]

        public string Year { get; set; }
        public int InstructorID { get; set; }
    
        public virtual Course Course { get; set; }
        public virtual Instructor Instructor { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Material> Materials { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Task> Tasks { get; set; }
    }
}
