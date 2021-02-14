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
        [Display(Name = "Uraian")]
        [Required(ErrorMessage = "Nama barang harus diisi")]
        public string item { get; set; }
        [Display(Name = "Stock")]
        [Required(ErrorMessage = "Jumlah stok awal harus diisi")]
        [DisplayFormat(DataFormatString = ("{0:0,0}"))]
        public float stock { get; set; }
        [Display(Name = "Jumlah Diubah")]
        public int amt_modified { get; set; }
        [Display(Name = "Terakhir Diubah")]
        public DateTime last_modified { get; set; }
        [Display(Name = "Diubah Oleh")]
        public string modified_by { get; set; }
        [Display(Name = "Merk")]
        [Required(ErrorMessage = "Nama merk harus diisi")]
        public string brand { get; set; }
        [Display(Name = "Harga Jual")]
        [DisplayFormat(DataFormatString = ("{0:0,0}"))]
        [Required(ErrorMessage ="Harga barang harus diisi")]
        public float price { get; set; }
        [Display(Name ="Stock Tambahan")]
        [Required(ErrorMessage = "Jumlah stock tambahan harus diisi")]
        public float stockAdded { get; set; }
        [Display(Name ="Stock Sebelum")]
        public float stock_before { get; set; }
        [Display(Name ="Pembeli")]
        [Required(ErrorMessage ="Nama pembeli harus diisi")]
        public string buyer { get; set; }
        [Display(Name ="Jumlah Bayar")]
        [Required(ErrorMessage ="Jumlah Bayar harus diisi")]
        public float amt_spent { get; set; }

    }
}