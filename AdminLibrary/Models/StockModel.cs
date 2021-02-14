using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminLibrary.Models
{
    public class StockModel
    {
        public int id { get; set; }
        public string item { get; set; }
        public float stock { get; set; }
        public int amt_modified { get; set; }
        public DateTime last_modified { get; set; }
        public string modified_by { get; set; }
        public string brand { get; set; }
        public float price { get; set; }
        public float stock_before { get; set; }

    }
}
