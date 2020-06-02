using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace StudentService.Models
{
    [MetadataType(typeof(StudentMetadata))]
    public partial class Student
    {
        public string ConfiremPassword { get; set; }
    }
    public class StudentMetadata

    {
        [Display(Name = "Student ID")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Student ID required")]
        [DataType(DataType.Text)]
        public string StudentID { get; set; }

        [Display(Name ="First Name")]
        [Required(AllowEmptyStrings =false,ErrorMessage = "First Name required")]
        [DataType(DataType.Text)]
        public string StudentName { get; set; }

       
        [Display(Name = "PhoneNumber")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "PhoneNumber required")]
        [DataType(DataType.PhoneNumber)]
        public string Mobile { get; set; }
        [Display(Name = "E-Mail Address")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "E-Mail Address required")]
        [DataType(DataType.EmailAddress)]
        public string StudentEmail { get; set; }

        [Display(Name = "Level")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Department required")]
    
        public string Level { get; set; }

        [Display(Name = "DateOfBirth")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "DateOFBirth required")]
        [DataType(DataType.Date)]
        public string DateOfBirth { get; set; }


        [Display(Name = "Password ")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Password required")]
        [DataType(DataType.Password)]
        [MinLength(8,ErrorMessage ="Password 8 or more characters")]
        public string Password { get; set; }


        [Display(Name = "Confirm Password ")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Confirm Password required")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password not match ")]
        public string ConfiremPassword { get; set; }
    }
 
}