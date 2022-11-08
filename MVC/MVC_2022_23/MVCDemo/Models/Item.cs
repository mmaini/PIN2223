using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCDemo.Models
{
    public class Item
    {
        //nije obavezno kad imenujemo property s ID, EF će to pretvoriti u Primary Key
        [Key] 
        public int Id { get; set; }
        //tko je posudio
        public string Borrower { get; set; }
        //kome je posuđeno
        public string Lender { get; set; }

        [DisplayName("Item name")]
        public string ItemName { get; set; }
    }
}
