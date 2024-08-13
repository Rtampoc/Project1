using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AAJControl;
using Project1.Classes;
using System.ComponentModel.DataAnnotations;
using System.Data;
using Project1.Models;


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
       

        public List<Users> List()
        {
            return s.Query<Users>("SELECT * FROM tbl_proj_users");
        }

        public List<Users> List()
        {
            return s.Query<Users>("SELECT email FROM tbl_proj_users");
        }

        public List<Users> List(string Search)//For Search
        {
            return s.Query<Users>("SELECT * FROM tbl_proj_users WHERE CONCAT(fname,lname) LIKE @search", p => p.Add("@search", $"%{ Search }%"));
        }

        //public void Register(Users obj)//For Registration
        //{
        //    s.InsertNormal("tbl_proj_user", p =>
        //    {
        //        p.Add("uname", obj.uname);
        //        p.Add("pword", obj.pword);
        //        p.Add("fname", obj.fname);
        //        p.Add("lname", obj.lname);
        //        p.Add("bday", obj.bday);
        //        p.Add("email", obj.email);
        //        //p.Add("dateCreated", DateTime.Now);
        //    });

            

        //}
        public bool Register(Users obj)//For Registration
        {
            
            var emailExist = List().Exists(x => x.email == obj.email);//validation for existing emails
            bool res = false;
            if (!emailExist)
            {
                s.InsertNormal("tbl_proj_users", p =>
                {
                    p.Add("uname", obj.uname);
                    p.Add("pword", obj.pword);
                    p.Add("fname", obj.fname);
                    p.Add("lname", obj.lname);
                    p.Add("bday", obj.bday);
                    p.Add("email", obj.email);

                });
                res = true;
            }
            else
            {
                res = false;
            }
            return res;
        }


        public bool uLog(string uname, string pword)//For user login
        {
            Users usr = s.Query<Users>("SELECT uname, pword FROM tbl_proj_users WHERE uname = @uname AND pword = @pword", p =>
            {
                p.Add("@uname", uname);
                p.Add("@pword", pword);
            }).SingleOrDefault();

            bool result = false;
            //function
            if (usr != null)
            {
                result = true;
            }
            return result;

        }     

         
         
               

    }
}