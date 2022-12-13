using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entitiy;
using MvcCv.Repository;


namespace MvcCv.Controllers
{
    public class HobiController : Controller
    {
        GenericRepository<TblHobilerim> repo= new GenericRepository<TblHobilerim>();
        public ActionResult Index()
        {
            var hobiler = repo.List();
            return View(hobiler);
        }
        [HttpGet]
        public ActionResult HobiEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult HobiEkle(TblHobilerim t)
        {
            repo.TAdd(t);
            return RedirectToAction("Index");
        }
        public ActionResult HobiSil(int id)
        {
            var hobi = repo.Find(x => x.ID== id);
            repo.TDelete(hobi);
            return RedirectToAction("Index");  
        }
        [HttpGet]
        public ActionResult HobiDuzenle(int id)
        {
           var hobi = repo.Find(x => x.ID== id);
            return View(hobi);
        }
        [HttpPost]
        public ActionResult HobiDuzenle(TblHobilerim t)
        {
            var h = repo.Find(x=> x.ID== t.ID);
            h.Aciklama1 = t.Aciklama1;
            h.Aciklama2 = t.Aciklama2;
            repo.TUpdate(h);
            return RedirectToAction("Index");
        }


    }
}