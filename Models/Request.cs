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

    public partial class Request
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        [Required(AllowEmptyStrings = false, ErrorMessage = "RequestId required")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "does not match datatype")]
        public int RequestId { get; set; }
        public string CourseName { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
    
    
    }
}
