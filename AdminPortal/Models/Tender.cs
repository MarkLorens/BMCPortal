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
        [Display(Name = "Name")]
        [Required(ErrorMessage ="Nama instansi harus terisi")]
        public string instansi { get; set; }
        [Display(Name ="Address")]
        [Required(ErrorMessage ="Alamat instansi harus terisi")]
        public string alamat { get; set; }
        [Display(Name ="Contact Number")]
        [RegularExpression(@"^[0-9]{10,12}$",ErrorMessage ="Masukkan 10-12 digit angka")]
        [Required(ErrorMessage ="Nomor kontak instansi harus terisi")]
        public string no_kontak { get; set; }
        [Display(Name ="E-mail")]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }

    }
}