using System;
using System.ComponentModel.DataAnnotations;

namespace AdminPortal.Models
{
    public class FCATK
    {
        [Display(Name = "Reference")]
        public string order_ref { get; set; }
        [Display(Name = "Items")]
        public string item { get; set; }
        [Display(Name = "Date")]
        public DateTime tgl_masuk { get; set; }
        [Display(Name = "Initial Stock")]
        public float stock_before { get; set; }
        [Display(Name = "Amount Bought")]
        public float bought_amt { get; set; }
        [Display(Name = "Stock After")]
        public float stock_after { get; set; }
        [Display(Name = "Responsible")]
        public string pj { get; set; }
        public string item_type { get; set; }
        
        
    }
}