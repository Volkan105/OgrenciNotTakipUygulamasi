using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OgrenciNotMVC.Models.EntityFramework;

namespace OgrenciNotMVC.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        MvcOkulDBEntities1 db = new MvcOkulDBEntities1();
        
        public ActionResult Index()
        {
            var dersler = db.Dersler.ToList();            
            return View(dersler);
        }
       
        [HttpGet]
        public ActionResult YeniDers()
        {
            return View();
        }
       
        [HttpPost]
        public ActionResult  YeniDers(Dersler p)
        {
            db.Dersler.Add(p);
            db.SaveChanges();
            return View();
        }

        public ActionResult Sil(int id)
        {
            var ders=db.Dersler.Find(id);
            db.Dersler.Remove(ders);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DersGetir(int id)
        {
            var drs = db.Dersler.Find(id);
            return View("DersGetir",drs);
        }

        public ActionResult Guncelle(Dersler p)
        {
            var drs = db.Dersler.Find(p.DersId);
            drs.DersAd = p.DersAd;
            db.SaveChanges();
            return View();
        }

    }
}