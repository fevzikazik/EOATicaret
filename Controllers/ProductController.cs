using EOATicaret.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EOATicaret.Controllers
{
    public class ProductController : Controller
    {
        db_EOAEntities1 db = new db_EOAEntities1();

        public ActionResult Detail(int id)
        {

            var product = db.tblUrunler.Where(pr => pr.urunID == id).FirstOrDefault();
            ViewBag.product = product;
            return View();
        }

        [HttpGet]
        public ActionResult Add()
        {
            if (Session["kull"] != null )
            {
                tblMusteri gelenK = (tblMusteri)Session["kull"];
                if(gelenK.tblRol.rolID == 2)
                {
                    return View();
                }
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult Add(FormCollection fc)
        {
            tblUrunler yeniUrun = new tblUrunler();
            yeniUrun.urunAdi = fc["urunAd"];

            using (var db = new db_EOAEntities1())
            {
                db.tblUrunler.Add(yeniUrun);
                db.SaveChanges();

            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Remove()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Remove(FormCollection fm)
        {
            List<tblUrunler> tblUrunlers = new List<tblUrunler>();
            tblUrunler DeletedUrun = new tblUrunler();

            int id = Convert.ToInt32(fm["urunId"]);

            //var deneme = Convert.ToInt32(fc["urunId"]);

            tblUrunlers = db.tblUrunler.ToList();

            DeletedUrun = tblUrunlers.First(p => p.urunID == id);

            db.tblUrunler.Remove(DeletedUrun);

            db.SaveChanges();

            return RedirectToAction("Index", "Home");
        }



    }
}