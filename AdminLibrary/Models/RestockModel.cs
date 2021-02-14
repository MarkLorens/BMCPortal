using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminLibrary.Models
{
    public class RestockModel
    {
        public string order_ref { get; set; }
        public DateTime date_bought { get; set; }
        public string buyer { get; set; }
        public float amt_bought { get; set; }
        public float amt_spent { get; set; }
        public int id { get; set; }
        public string item { get; set; }
        public string actualDate { get; set; }
    }
}
