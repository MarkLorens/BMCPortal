using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.Mvc;

namespace AdminPortal.Models
{
    public class Order
    {
        [Display(Name ="Referensi")]
        public string order_ref { get; set; }
        [Display(Name ="Uraian")]
        [Required]
        public string item { get; set; }
        [Display(Name ="Masuk")]
        public DateTime tgl_masuk { get; set; }
        [Display(Name ="Selesai")]
        public DateTime tgl_selesai { get; set; }
        [Display(Name ="DP")]
        [DisplayFormat(DataFormatString = ("{0:C}"))]
        [Required(ErrorMessage ="DP harus terisi. jika DP tidak ada, masukkan 0")]
        public float dp { get; set; }
        [Display(Name ="Sisa")]
        [DisplayFormat(DataFormatString = ("{0:C}"))]
        public float sisa { get; set; }
        [Display(Name ="Total")]
        [DisplayFormat(DataFormatString = ("{0:C}"))]
        public float total { get; set; }
        [Display(Name ="PJ")]
        [Required(ErrorMessage ="Penanggung jawab harus terisi.")]
        public string pj { get; set; }
        [Display(Name ="Instansi")]
        [Required]
        public string instansi { get; set; }
        public int id { get; set; }
        [Display(Name ="Jumlah beli")]
        [Required(ErrorMessage ="Jumlah harus diisi")]
        public float bought_amt { get; set; }
        [Display(Name = "Menggunakan")]
        public string item_type { get; set; }
        public float stock_before { get; set; }
    }
}