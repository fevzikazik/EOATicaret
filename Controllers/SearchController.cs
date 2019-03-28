using EOATicaret.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EOATicaret.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        [HttpGet]
        public ActionResult Index()
        {
            /*    //List<UrunlerViewModel> um = new List<UrunlerViewModel>();
                 string aranan = Request.QueryString["aranan"];

                 db_EOAEntities1 db = new db_EOAEntities1();
                 tblUrunler araSonuc = db.tblUrunler.ToList<tblUrunler>();
                 var bizimSonuc = araSonuc.Contains(aranan);
                 tblUrunler tblUrunler = (tblUrunler)araSonuc;


                 List<tblUrunler> urunListesi = new List<tblUrunler>();

                 foreach (tblUrunler urun in araSonuc)
                 {
                     if (urun.urunAdi.Contains(aranan))
                     {
                         urunListesi.Add(urun);
                     }

                 }
                // var araSonuc = db.tblUrunler;

                 return Json(urunListesi , JsonRequestBehavior.AllowGet);

          */
            string aranan = Request.QueryString["aranan"];
            if (aranan != null)
            {
                db_EOAEntities1 db = new db_EOAEntities1();
                List<tblUrunler> tblUrunlers = new List<tblUrunler>();
                // List<UrunlerViewModel> model = new List<UrunlerViewModel>();
                tblUrunlers = db.tblUrunler.Where(s => s.urunAdi.Contains(aranan)).ToList();

                ViewBag.Title = "Arama | " + aranan;
                return View(tblUrunlers);
            }

            return RedirectToAction("Index","Home");
           
        }
    }
}