using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OgrenciNotMVC.Models.EntityFramework;
using OgrenciNotMVC.Models;

namespace OgrenciNotMVC.Controllers
{
    public class NotController : Controller
    {
        // GET: Not
        MvcOkulDBEntities1 db = new MvcOkulDBEntities1();
        

        public ActionResult Index()
        {
            var notlar = db.Notlar.ToList();            
            return View(notlar);
        }

        [HttpGet]
        public ActionResult YeniSinav()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniSinav(Notlar tbn)
        {
            db.Notlar.Add(tbn);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult NotGetir(int id)
        {
            var notlar = db.Notlar.Find(id);
            return View("NotGetir", notlar);

        }

        [HttpPost]
       public ActionResult NotGetir(Class1 mdl,Notlar p,int sinav1=0,int sinav2=0,int sinav3=0,int proje=0)
        {
            if(mdl.Islem == "Hesapla")
            {
                int ortalama = (sinav1 + sinav2 + sinav3 + proje) / 4;
                ViewBag.ort = ortalama;
            }

            if(mdl.Islem == "NotGuncelle")
            {
                var snv = db.Notlar.Find(p.NotId);
                snv.Sinav1 = p.Sinav1;
                snv.Sinav2 = p.Sinav2;
                snv.Sinav3 = p.Sinav3;
                snv.Proje = p.Proje;
                snv.Ortalama = p.Ortalama;
                db.SaveChanges();
                return RedirectToAction("Index", "Notlar");
            }
            return View();
        }

        
    }
}