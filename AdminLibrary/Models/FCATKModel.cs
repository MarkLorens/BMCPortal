using System;

namespace AdminLibrary.Models
{
    public class FCATKModel
    {
        public string order_ref { get; set; }
        public string item { get; set; }
        public DateTime tgl_masuk { get; set; }
        public float stock_before { get; set; }
        public float bought_amt { get; set; }
        public float stock_after { get; set; }
        public string pj { get; set; }
        public string item_type { get; set; }
        
        
    }
}