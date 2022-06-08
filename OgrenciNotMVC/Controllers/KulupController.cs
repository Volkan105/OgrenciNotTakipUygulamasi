using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OgrenciNotMVC.Models.EntityFramework;

namespace OgrenciNotMVC.Controllers
{
    public class KulupController : Controller
    {
        // GET: Kulup
        MvcOkulDBEntities1 db = new MvcOkulDBEntities1();
        
        public ActionResult Index()
        {
            var kulupler = db.Kulupler.ToList();
            return View(kulupler);
        }

        [HttpGet]
        public ActionResult YeniKulup()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniKulup(Kulupler k)
        {
            db.Kulupler.Add(k);
            db.SaveChanges();
            return View();
        }

        public ActionResult Sil(int id)
        {
            var kulup = db.Kulupler.Find(id);
            db.Kulupler.Remove(kulup);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KulupGetir(int id)
        {
            var klp = db.Kulupler.Find(id);
            return View("KulupGetir",klp);
        }

        public ActionResult Guncelle(Kulupler k)
        {
            var klp = db.Kulupler.Find(k.KulupId);
            klp.KulupAd = k.KulupAd;
            db.SaveChanges();
            return RedirectToAction("Index", "Kulup");
        }
    }
}