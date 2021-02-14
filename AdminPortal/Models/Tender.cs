using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdminPortal.Models
{
    public class Tender
    {
        [Display(Name = "Instansi")]
        [Required(ErrorMessage ="Nama instansi harus terisi")]
        public string instansi { get; set; }
        [Display(Name ="Alamat")]
        [Required(ErrorMessage ="Alamat instansi harus terisi")]
        public string alamat { get; set; }
        [Display(Name ="Nomor Kontak")]
        [RegularExpression(@"^[0-9]{10,12}$",ErrorMessage ="Masukkan 10-12 digit angka")]
        [Required(ErrorMessage ="Nomor kontak instansi harus terisi")]
        public string no_kontak { get; set; }
        [Display(Name ="E-mail")]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }

    }
}