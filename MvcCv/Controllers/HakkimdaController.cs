using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entitiy;
using MvcCv.Repository;

namespace MvcCv.Controllers
{
    public class HakkimdaController : Controller
    {
        DbCvEntities db = new DbCvEntities();
        GenericRepository<TblHakkimda> repo = new GenericRepository<TblHakkimda>();
        [HttpGet]
        public ActionResult Index()
        {
            var hakkimda = repo.List();
            return View(hakkimda);
        }
        [HttpPost]
        public ActionResult Index(TblHakkimda h)
        {
            var t = repo.Find(x => x.ID == 1);
            t.Ad = h.Ad;
            t.Soyad = h.Soyad;
            t.Adres = h.Adres;
            t.Mail = h.Mail;
            t.Telefon = h.Telefon;
            t.Aciklama = h.Aciklama;
            t.Resim = h.Resim;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}