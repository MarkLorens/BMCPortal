using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdminPortal.Models
{
    public class Stock
    {
        [Display(Name = "ID")]
        public int id { get; set; }
        [Display(Name = "Item")]
        [Required(ErrorMessage = "Nama barang harus diisi")]
        public string item { get; set; }
        [Display(Name = "Stock")]
        [Required(ErrorMessage = "Jumlah stok awal harus diisi")]
        public float stock { get; set; }
        [Display(Name = "Amount Changed")]
        public int amt_modified { get; set; }
        [Display(Name = "Last Modified")]
        public DateTime last_modified { get; set; }
        [Display(Name = "Modified By")]
        public string modified_by { get; set; }
        [Display(Name = "Brand")]
        [Required(ErrorMessage = "Nama merk harus diisi")]
        public string brand { get; set; }
        [Display(Name = "Price")]
        [Required(ErrorMessage ="Harga barang harus diisi")]
        [DisplayFormat(DataFormatString = ("{0:C}"))]
        public float price { get; set; }
        [Display(Name ="Bought Amount")]
        [Required(ErrorMessage = "Jumlah stock tambahan harus diisi")]
        public float stockAdded { get; set; }
        [Display(Name ="Stock Before")]
        public float stock_before { get; set; }
        [Display(Name ="Responsible")]
        [Required(ErrorMessage ="Nama pembeli harus diisi")]
        public string buyer { get; set; }
        [Display(Name ="Amount Paid")]
        [Required(ErrorMessage ="Jumlah Bayar harus diisi")]
        public float amt_spent { get; set; }

    }
}