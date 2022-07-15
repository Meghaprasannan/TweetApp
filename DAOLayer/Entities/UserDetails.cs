using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace test.DAOLayer.Entities
{
    public class UserDetails
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Full_Name { get; set; }
        

        [Required(ErrorMessage = "Please Enter Gender")]
        public  string Gender { get; set; }

        public DateTime DoB { get; set; }

        [Required(ErrorMessage = "Please enter Email Adress")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please set your password")]
        public string Password { get; set; }

        [Required(ErrorMessage ="Choose your security ques")]
        public string securityQuestion { get; set; }

        [Required(ErrorMessage ="Ans is required for security question")]
        public string Answer { get; set; }
    }
}
