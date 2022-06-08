using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OgrenciNotMVC.Models.EntityFramework;

namespace OgrenciNotMVC.Controllers
{
    public class OgrenciController : Controller
    {
        // GET: Ogrenci
        MvcOkulDBEntities1 db = new MvcOkulDBEntities1();
        
        public ActionResult Index()
        {
            var ogrenciler = db.Ogrenciler.ToList();            
            return View(ogrenciler);
        }

        [HttpGet]
        public ActionResult YeniOgrenci()
        {
            List<SelectListItem> degerler = (from i in db.Kulupler.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KulupAd,
                                                 Value = i.KulupId.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View();
        }

        [HttpPost]
        public ActionResult YeniOgrenci(Ogrenciler o)
        {
            var klp = db.Kulupler.Where(m => m.KulupId == o.Kulupler.KulupId).FirstOrDefault();
            o.Kulupler = klp;
            db.Ogrenciler.Add(o);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Sil(int id)
        {
            var ogr = db.Ogrenciler.Find(id);
            db.Ogrenciler.Remove(ogr);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult OgrenciGetir(int id)
        {
            var ogr = db.Ogrenciler.Find(id);
            List<SelectListItem> degerler = (from i in db.Kulupler.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KulupAd,
                                                 Value = i.KulupId.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View("OgrenciGetir", ogr);
        }

        public ActionResult Guncelle(Ogrenciler o)
        {
            var ogr = db.Ogrenciler.Find(o.OgrenciId);
            ogr.OgrenciAd = o.OgrenciAd;
            ogr.OgrenciSoyad = o.OgrenciSoyad;
            ogr.OgrenciFotograf = o.OgrenciFotograf;
            ogr.OgreciCinsiyet = o.OgreciCinsiyet;
            ogr.OgrenciKulup = o.OgrenciKulup;
            db.SaveChanges();
            return RedirectToAction("Index", "Ogrenci");
        }
    }
}