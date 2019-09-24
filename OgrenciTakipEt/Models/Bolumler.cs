using OgrenciTakipEt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace OgrenciTakipEt.Models
{
    public class Bolumler
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "Bölüm Adını Giriniz")]
        [StringLength(200)]
        public string Bolum { get; set; }
    }
}