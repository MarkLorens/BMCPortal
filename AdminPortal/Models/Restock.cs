using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdminPortal.Models
{
    public class Restock
    {
        [Display(Name ="Referensi")]
        public string order_ref { get; set; }
        [Display(Name ="Tanggal Beli")]
        public DateTime date_bought { get; set; }
        [Display(Name ="Pembeli")]
        public string buyer { get; set; }
        [Display(Name ="Jumlah Beli")]
        [DisplayFormat(DataFormatString = ("{0:0,0}"))]
        public float amt_bought { get; set; }
        [Display(Name ="Jumlah Beli")]
        [DisplayFormat(DataFormatString = ("{0:0,0}"))]
        public float amt_spent { get; set; }
        public int id { get; set; }
        [Display(Name ="Uraian")]
        public string item { get; set; }
        public string actualDate { get; set; }
    }
}