using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace OgrenciTakipEt.Models
{
    public class Ogrenci
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "Adı Giriniz")]
        [StringLength(100)]
        public string Ad { get; set; }

        [Required(ErrorMessage = "Soyadını Giriniz")]
        [StringLength(100)]
        public string Soyad { get; set; }


        [StringLength(250)]
        public string Bolum { get; set; }

        [Required(ErrorMessage = "E-posta Girilmesi Zorunludur")]
        [RegularExpression(@"^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$", ErrorMessage = "Doğru E-posta Formatını Giriniz")]
        [StringLength(100)]
        public string Posta { get; set; }

        [Required(ErrorMessage = "Telefon Girilmesi Zorunludur")]
        [StringLength(100)]
        public string Tel { get; set; }

        [Required(ErrorMessage = "İşyeri Girilmesi Zorunludur")]
        [StringLength(100)]
        public string isyeri { get; set; }

        [StringLength(500)]
        public string Adres { get; set; }


        [StringLength(100)]
        public string Sehir { get; set; }

        [Required(ErrorMessage = "Resim Girilmesi Zorunludur")]
        [StringLength(250)]
        public string Resim { get; set; }



    }
}