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
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Instructor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Instructor()
        {
            this.Sections = new HashSet<Section>();
        }
        [Required(AllowEmptyStrings = false, ErrorMessage = "InstructorID required")]


        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "does not match datatype")]

        public int InstructorID { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "InstructorName required")]
        [DataType(DataType.Text, ErrorMessage = "does not match datatype)")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "does not match datatype")]
        [MaxLength(20, ErrorMessage = "InstructorName MaxLength 20  characters")]
        public string InstructorName { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Section> Sections { get; set; }
    }
}
