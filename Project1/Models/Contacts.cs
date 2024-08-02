using Project1.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project1.Models
{
    public class Contacts
    {
        dbController s = new dbController();

        public int ID { get; set; }
                
        [Display(Name = "Contact Holder")]
        public string cholder { get; set; }

        [Display(Name = "Network")]
        public string network { get; set; }

        [Display(Name = "Contact No.")]
        [Required]
        public string contact { get; set; }

        public List<Contacts> List()
        {
            return s.Query<Contacts>("SELECT * FROM tbl_proj_mobile");
        }

        public List<Contacts> List(string Search)//For Search
        {
            return s.Query<Contacts>("SELECT * FROM tbl_proj_mobile WHERE CONCAT(cholder,network) LIKE @search", p => p.Add("@search", $"%{ Search }%"));
        }

        public Contacts Find(int ID)
        {
            return s.Query<Contacts>("SELECT * FROM tbl_proj_mobile WHERE ID = @ID", p => p.Add("@ID", ID)).SingleOrDefault();
        }

        public void newCon(Contacts obj)//For Create new contact
        {
            s.InsertNormal("tbl_proj_mobile", p =>
            {
                p.Add("cholder", obj.cholder);
                p.Add("network", obj.network);
                p.Add("contact", obj.contact);
            });
        }

        public void Update(Contacts obj)//For Update
        {
            s.Update("tbl_proj_mobile", obj.ID, p =>
            {
                p.Add("cholder", obj.cholder);
                p.Add("network", obj.network);
                p.Add("contact", obj.contact);
            });
        }

        public void Delete(Contacts obj)//For Delete
        {
            s.Query("DELETE FROM tbl_proj_mobile WHERE id = @id", p => { p.Add("@ID", obj.ID); });
        }
             


    }

}