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
                p.Add("network", getNetworktype(obj.contact));//get network
                p.Add("contact", obj.contact);
            });
        }

        public void Update(Contacts obj)//For Update
        {
            s.Update("tbl_proj_mobile", obj.ID, p =>
            {
                p.Add("cholder", obj.cholder);
                p.Add("network", getNetworktype(obj.contact));//get network
                p.Add("contact", obj.contact);
            });
        }

        public void Delete(Contacts obj)//For Delete
        {
            s.Query("DELETE FROM tbl_proj_mobile WHERE id = @id", p => p.Add("@ID", obj.ID)); 
        }
            
        

        private static string getNetworktype(string number)//For getting the Mobile Network via Mobile Prefix number
        {
            string result = null;
            var smart = new List<string> { "0928", "0951", "0998", "0999", "0939", "0919", "0920", "0921", "0918", "0947", "0949", "0908", "0929", "0961", "0945", "0953", "0954", "0955", "0956", "0965", "0966", "0967", "0975", "0980", "0994", "0817" };

            var globe = new List<string> { "0905", "0906", "0935", "0936", "0937", "0977", "0978", "0979", "0915", "0916", "0917", "0995", "0996", "0997", "0926", "0927", "0904" };

            var tnt = new List<string> { "0930", "0907", "0909", "0910", "0912", "0938", "0946", "0948", "0950" };

            var sun = new List<string> { "0931", "0932", "0933", "0934", "0973", "0974", "0940", "0941", "0942", "0943", "0944", "0922", "0923", "0924", "0925" };

            var dito = new List<string> { "0991", "0992", "0993", "0994", "0895", "0896", "0897", "0898" };

            var gomo = new List<string> { "0976", };

            var globePtpd = new List<string> { "09173", "09175", "09176", "09178", "09253", "09255", "09256", "09257", "09258" };

            var smartPtpd = new List<string> { "0813", };

            var networks = new Dictionary<string, List<string>> { { "Smart", smart }, { "Globe/TM", globe }, { "TNT", tnt }, { "Sun", sun }, { "Dito", dito }, { "Gomo", gomo }, { "Globe Postpaid", globePtpd }, { "Smart Postpaid", smartPtpd } };

            foreach (KeyValuePair<string, List<string>> d in networks)   
            {
                d.Value.ForEach(n =>
                {
                    if (number.Substring(0, 4) == n || number.Substring(0, 5) == n)
                    {
                        result = d.Key;
                        return;
                    }
                });
            }
            return result;
        }


    }
        

}

