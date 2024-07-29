using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AAJControl;
using Project1.Classes;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace Project1.Models
{
    public class Users
    {
        dbController s = new dbController();

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
        [Display(Name = "Network")]
        public string network { get; set; }
        [Display(Name = "Contact No.")]
        [Required]
        [DataType(DataType.PhoneNumber)]

        public System.DateTime dateCreated { get; set; }

        public System.DateTime lastLogin { get; set; }
        public int contact { get; set; }

        public void Register(Users obj)
        {
            s.InsertNormal("tbl_proj_user", p =>
            {
                p.Add("uname", obj.uname);
                p.Add("pword", obj.pword);
                p.Add("fname", obj.fname);
                p.Add("lname", obj.lname);
                p.Add("bday", obj.bday);
                p.Add("email", obj.email);
                p.Add("dateCreated", obj.dateCreated);
                p.Add("lastLogin", obj.lastLogin);
            });
        }

        public bool uLog(string uname, string pword)
        {
            
             Users usr = s.Query<Users>("SELECT uname, pword FROM tbl_proj_user WHERE uname = @uname AND pword = @pword", p => {
                 p.Add("@uname", uname);
                 p.Add("@pword", pword);
             }).SingleOrDefault();

            bool result = false;
            //functions
            if (usr != null)
            {
                result = true;
            }
            return result;

        }
        public Users Find(int ID)
        {
            return s.Query<Users>("SELECT * FROM tbl_proj_user WHERE ID = @ID", p => p.Add("@ID", ID)).SingleOrDefault();
        }






    }
}