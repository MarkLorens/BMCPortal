using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminLibrary.Models
{
    public class OrderModel
    {
        public string order_ref { get; set; }
        public string item { get; set; }
        public DateTime tgl_masuk { get; set; }
        public DateTime tgl_selesai { get; set; }
        public float dp { get; set; }
        public float sisa { get; set; }
        public float total { get; set; }
        public string pj { get; set; }
        public string instansi { get; set; }
        public int id { get; set; }
        public float bought_amt { get; set; }
        public string item_type { get; set; }
        public float stock_before { get; set; }
    }
}
