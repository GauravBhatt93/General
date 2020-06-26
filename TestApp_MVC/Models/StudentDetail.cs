using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestApp_MVC.Models
{
    public class StudentData
    {
        public StudentData()
        {
            List<StudentData> students = new List<StudentData>();
        }

        public List<StudentData> students { get; set; }
        public int ID { get; set; }
        [Required]
        [RegularExpression("^[a-zA-Z ]*$")] 
        public string FirstName { get; set; }
        [Required]
        [RegularExpression("^[a-zA-Z ]*$")] 
        public string LastName { get; set; }
        [Required]
        [RegularExpression(@"^[\w-\._\+%]+@(?:[\w-]+\.)+[\w]{2,6}$", ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; }
        [Required]
        [RegularExpression("([0-9]+)")]
        [Range(100, 1500, ErrorMessage = "Please  Enter Value Between 100 to 1500 ")]
        public string PckMoney { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
        [Required]
        [RegularExpression("([0-9]+)" , ErrorMessage = "Field should contain only string")]
        public string Age { get; set; }
        [Required]
        [RegularExpression("^[a-zA-Z ]*$" , ErrorMessage = "Field should contain only string")]
        public string City { get; set; }
        [Required]
        [RegularExpression("^[a-zA-Z ]*$" , ErrorMessage = "Field should contain only string")]
        public string State { get; set; }
        [Required]
        [RegularExpression("([0-9]+)" , ErrorMessage = "Field should contain only string")]
        public string Zip { get; set; }
        [Required]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Field should contain only string")]
        public string Country { get; set; }



    }
}