using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project1.Models
{
    public class UserAccounts
    {
        public int ID { get; set; }
        [Display(Name = "Username")]
        [Required]
        public string uname { get; set; }
        [Display(Name = "Password")]
        [Required]
        [DataType(DataType.Password)]
        public string pword { get; set; }
        [Display(Name = "First name")]
        [Required]
        public string fname { get; set; }
        [Display(Name = "Last name")]
        [Required]
        public string lname { get; set; }
        [Display(Name = "Date of Birth")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date)]
        public DateTime bday { get; set; }

        [Display(Name = "Email")]
        [Required]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }
        
    }
}