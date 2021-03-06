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

    public partial class Department
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Department()
        {
            this.Courses = new HashSet<Course>();
        }

        [Required(AllowEmptyStrings = false, ErrorMessage = "DepartmentCode required")]
        [DataType(DataType.Text, ErrorMessage = "does not match datatype)")]
       
        [StringLength(2, ErrorMessage = "DepartmentCode must be 2  characters")]
        public string DepartmentCode { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "DepartmentName required")]
        [DataType(DataType.Text, ErrorMessage = "does not match datatype)")]
        [StringLength(20, ErrorMessage = "DepartmentCode must be 20  characters")]
       
        public string DepartmentName { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Course> Courses { get; set; }
    }
}
