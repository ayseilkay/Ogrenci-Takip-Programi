using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace OgrenciTakipEt.Models
{
    public class City
    {
        [Key]
        [StringLength(2)]
        public string code { get; set; }

        [StringLength(50)]
        public string name { get; set; }
    }
}