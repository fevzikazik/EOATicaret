using EOATicaret.Models;
using System;
using System.Collections.Generic;
using System.IO;
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
        public ActionResult Add(FormCollection fc, HttpPostedFileBase uploadFile)
        {
            tblUrunler yeniUrun = new tblUrunler();
            yeniUrun.urunAdi = fc["urunAd"];
            yeniUrun.urunDetayStok = Convert.ToInt32(fc["urunDetayStok"]);
            yeniUrun.urunDetayFiyat = Convert.ToDecimal(fc["urunDetayFiyat"]);
            yeniUrun.kategoriId = Convert.ToInt32(fc["kategoriId"]);
            string path = Path.Combine(Server.MapPath("~/Content/resim"), Path.GetFileName(uploadFile.FileName));
            string dbKaydet = "Content/resim/" + uploadFile.FileName;
            yeniUrun.urunDetayResim = dbKaydet;
            uploadFile.SaveAs(path);

            using (var db = new db_EOAEntities1())
            {
                db.tblUrunler.Add(yeniUrun);
                db.SaveChanges();

            }

            return RedirectToAction("Index","Home");
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