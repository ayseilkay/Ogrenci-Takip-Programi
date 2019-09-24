using OgrenciTakipEt.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OgrenciTakipEt.Models
{
    public class MvcProjesiContext : DbContext
    {
        public MvcProjesiContext() : base("MvcProjesiContext")
        {

        }
        public DbSet<Bolumler> BolumListesi { get; set; }
        public DbSet<City> CityList { get; set; }
        public DbSet<Ogrenci> OgrenciListesi { get; set; }

    }
}