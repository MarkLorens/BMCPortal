using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdminPortal.Models
{
    public class Restock
    {
        [Display(Name ="Reference")]
        public string order_ref { get; set; }
        [Display(Name ="Date")]
        public DateTime date_bought { get; set; }
        [Display(Name ="Responsible")]
        public string buyer { get; set; }
        [Display(Name ="Bought Amount")]
        public float amt_bought { get; set; }
        [Display(Name ="Paid Amount")]
        [DisplayFormat(DataFormatString = ("{0:C}"))]
        public float amt_spent { get; set; }
        public int id { get; set; }
        [Display(Name ="Item")]
        public string item { get; set; }
        public string actualDate { get; set; }
    }
}