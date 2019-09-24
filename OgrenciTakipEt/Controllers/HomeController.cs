using OgrenciTakipEt.Models;
using System.IO;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Net;
using System.Threading.Tasks;

namespace OgrenciTakipEt.Controllers
{
    public class HomeController : Controller
    {
        private SqlConnection baglanti = new SqlConnection();


        private MvcProjesiContext Context = new MvcProjesiContext();
        [HttpGet]
        //public ActionResult Index()
        //{
        //    return View();
        //}
        public ViewResult Index()
        {
            baglanti.ConnectionString = "Data Source =DESKTOP-O1AM6QO\\SQLEXPRESS;Initial Catalog = Ogrencidb;Integrated Security=True";
            //baglanti.ConnectionString = "Data Source =localhost;Initial Catalog = OgrenciDb;Integrated Security=True";


            SqlCommand komut = new SqlCommand("Select * from Bolumlers", baglanti);
            DataTable tablo = new DataTable();
            SqlDataAdapter Adoptor = new SqlDataAdapter(komut);
            Adoptor.Fill(tablo);
            int i = Convert.ToInt32(tablo.Rows.Count);

            List<Bolumler> BolumListesi = new List<Bolumler>();
            Bolumler s = new Bolumler();
            for (int j = 0; j < i; j++)
            {
                s = new Bolumler();
                s.id = Convert.ToInt32(tablo.Rows[j][0]);
                s.Bolum = Convert.ToString(tablo.Rows[j][1]);
                BolumListesi.Add(s);
            }
            ViewBag.BolumListesi = new SelectList(BolumListesi, "Bolum", "Bolum");


            komut = new SqlCommand("Select * from Cities", baglanti);
            tablo = new DataTable();
            Adoptor = new SqlDataAdapter(komut);
            Adoptor.Fill(tablo);
            i = Convert.ToInt32(tablo.Rows.Count);

            List<City> CityList = new List<City>();
            City c = new City();
            for (int j = 0; j < i; j++)
            {
                c = new City();
                c.code = Convert.ToString(tablo.Rows[j][0]);
                c.name = Convert.ToString(tablo.Rows[j][1]);
                CityList.Add(c);
            }
            ViewBag.CityList = new SelectList(CityList, "name", "name");


            return View();
        }
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Contact(EmailFormModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var body = "<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>";
        //        var message = new MailMessage();
        //        message.To.Add(new MailAddress("elfslncbn@gmail.com"));  // replace with valid value 
        //        message.From = new MailAddress("aayseilkayr@gmail.com");  // replace with valid value
        //        message.Subject = "Your email subject";
        //        message.Body = string.Format(body, model.FromName, model.FromEmail, model.Message);
        //        message.IsBodyHtml = true;

        //        using (var smtp = new SmtpClient())
        //        {
        //            var credential = new NetworkCredential
        //            {
        //                UserName = "aayseilkay@gmail.com",  // replace with valid value
        //                Password = "8835"  // replace with valid value
        //            };
        //            smtp.Credentials = credential;
        //            smtp.Host = "smtp-mail.gmail.com";
        //            smtp.Port = 587;
        //            smtp.EnableSsl = true;
        //            await smtp.SendMailAsync(message);
        //            return RedirectToAction("Sent");
        //        }
        //    }
        //    return View(model);
        //}

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Index(Ogrenci OgrenciModel, HttpPostedFileBase Dosyaicerigi)
        {
            if (Dosyaicerigi == null)
            {

                ViewBag.Message = "Öğrenci resmini boş bırakmayınız";

                //return RedirectToAction("Index");
                //return Redirect("http://gedikbey.ogu.edu.tr/Ogrenci/Home/IndesxUnutma");
                return View("IndexUnutma");


            }

            // if(Dosyaicerigi.ContentLength>0)
            //   {
            var DosyaAdi = Guid.NewGuid().ToString() + "_" + Path.GetFileName(Dosyaicerigi.FileName);
            string FilePath = Path.Combine(Server.MapPath("~/Resimler"), DosyaAdi);
            OgrenciModel.Resim = DosyaAdi;
            Dosyaicerigi.SaveAs(FilePath);
            // }
            Context.OgrenciListesi.Add(OgrenciModel);
            Context.SaveChanges();


            MailAddress Alici = new MailAddress(OgrenciModel.Posta);
            MailAddress Gonderen = new MailAddress("web@ogu.edu.tr");
            MailMessage eposta = new MailMessage(Gonderen, Alici);
            eposta.To.Add("gedikbey1@gmail.com");
            eposta.Subject = "öğrenci Takip Et Programı E-posta Gönderme";
            eposta.IsBodyHtml = true;
            eposta.Body = "Bildiriniz elimize ulaşmış olup, gereği için işlemler başlatılmıştır. İlgi ve önerileriniz için teşekkür eder, iyi çalışmalar dileriz<br/><br> Adı: " + OgrenciModel.Ad +
            "<br/><br/> Soyadı: " + OgrenciModel.Soyad +
            "<br/><br/> Bölüm: " + OgrenciModel.Bolum +
            "<br/><br/> E-posta: " + OgrenciModel.Posta +
            "<br/><br/> Telefon: " + OgrenciModel.Tel +
            "<br/><br/> İşyeri: " + OgrenciModel.isyeri +
            "<br/><br/> Adres: " + OgrenciModel.Adres +
            "<br/><br/> Şehir: " + OgrenciModel.Sehir;


            System.Net.NetworkCredential sifre = new System.Net.NetworkCredential("web@ogu.edu.tr", "abcdefg");
            SmtpClient istemci = new SmtpClient();
            istemci.Host = "mail.ogu.edu.tr";
            istemci.Credentials = sifre;
            istemci.DeliveryMethod = SmtpDeliveryMethod.Network;
            istemci.Send(eposta);

            return View("AnaSayfaTesekkur", OgrenciModel);


        }
        public ActionResult IndexBolum()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ViewResult IndexBolum(Bolumler BolumlerModel)
        {
            Context.BolumListesi.Add(BolumlerModel);
            Context.SaveChanges();
            return View("Tesekkur", BolumlerModel);
        }
    }
}