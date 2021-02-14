using System;
using System.ComponentModel.DataAnnotations;

namespace AdminPortal.Models
{
    public class FCATK
    {
        [Display(Name = "Referensi")]
        public string order_ref { get; set; }
        [Display(Name = "Barang")]
        public string item { get; set; }
        [Display(Name = "Masuk")]
        public DateTime tgl_masuk { get; set; }
        [Display(Name = "Stock awal")]
        public float stock_before { get; set; }
        [Display(Name = "Jumlah beli")]
        public float bought_amt { get; set; }
        [Display(Name = "Stock Setelah Beli")]
        public float stock_after { get; set; }
        [Display(Name = "Penanggung Jawab")]
        public string pj { get; set; }
        public string item_type { get; set; }
        
        
    }
}