using EOATicaret.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EOATicaret.Controllers
{
    public class AdminController : Controller
    {

        db_EOAEntities1 db = new db_EOAEntities1();

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Kategori()
        {
            if (Session["kull"] != null && ((tblMusteri)Session["kull"]).rolId == 2)
            {
                var cat = db.tblKategori;
                return View(cat);
            }
            return RedirectToAction("Index", "Home");
        }


        [HttpPost]
        public ActionResult KategoriSil(int id)
        {
            if (Session["kull"] != null && ((tblMusteri)Session["kull"]).rolId == 2)
            {
                using (var db = new db_EOAEntities1())
                {
                    var sorguCat = (from cat in db.tblKategori
                                    where cat.kategoriID == id
                                    select cat).First();

                    db.tblKategori.Remove(sorguCat);
                    db.SaveChanges();
                }

                return RedirectToAction("Kategori","Admin");
            }

            return RedirectToAction("Index", "Home");
        }

        public ActionResult KategoriEkle()
        {
            if (Session["kull"] != null && ((tblMusteri)Session["kull"]).rolId == 2)
            {
                return View();
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult KategoriEkle(FormCollection fc, HttpPostedFileBase uploadFile)
        {
            if (Session["kull"] != null && ((tblMusteri)Session["kull"]).rolId == 2)
            {

                tblKategori yeniKat = new tblKategori();
                yeniKat.kategoriAdi = fc["kategoriAd"];
                string path = Path.Combine(Server.MapPath("~/Content/kategori"), Path.GetFileName(uploadFile.FileName));
                string dbKaydet = "Content/kategori/" + uploadFile.FileName;
                yeniKat.kategoriResimLink = dbKaydet;

                uploadFile.SaveAs(path);

                db.tblKategori.Add(yeniKat);
                db.SaveChanges();

                return RedirectToAction("Kategori", "Admin");
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult KategoriDuzenle(int id)
        {
            if (Session["kull"] != null && ((tblMusteri)Session["kull"]).rolId == 2)
            {
                ViewBag.id = id;
                return View();
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult KategoriDuzenle(FormCollection fc, HttpPostedFileBase uploadFile)
        {

            if (Session["kull"] != null && ((tblMusteri)Session["kull"]).rolId == 2)
            {
                tblKategori tempKat = new tblKategori();
                using (var db = new db_EOAEntities1())
                {
                    string gelenKatAdi = fc["kategoriAd"];
                    long gelentId = Convert.ToInt64(fc["kategoriId"]);
                    tempKat = db.tblKategori.Single(cat => cat.kategoriID == gelentId);

                    tempKat.kategoriAdi = fc["kategoriAd"]; // TODO

                    if (uploadFile != null)
                    {
                        string path = Path.Combine(Server.MapPath("~/Content/kategori"), Path.GetFileName(uploadFile.FileName));
                        string dbKaydet = "Content/kategori/" + uploadFile.FileName;
                        tempKat.kategoriResimLink = dbKaydet;
                        uploadFile.SaveAs(path);
                    }


                    db.tblKategori.Attach(tempKat);
                    db.Entry(tempKat).State = EntityState.Modified;
                    db.SaveChanges();

                    return RedirectToAction("Kategori", "Admin");
                }
            }

            return RedirectToAction("Index", "Home");

        }

        public ActionResult Urun()
        {
            if (Session["kull"] != null && ((tblMusteri)Session["kull"]).rolId == 2)
            {
                var urun = db.tblUrunler;
                return View(urun);
            }
            return RedirectToAction("Index", "Home");
        }


        [HttpPost]
        public ActionResult UrunSil(int id)
        {
            if (Session["kull"] != null && ((tblMusteri)Session["kull"]).rolId == 2)
            {
                using (var db = new db_EOAEntities1())
                {
                    var sorguUrun = (from urun in db.tblUrunler
                                    where urun.urunID == id
                                    select urun).First();

                    db.tblUrunler.Remove(sorguUrun);
                    db.SaveChanges();
                }

                return RedirectToAction("Urun", "Admin");
            }

            return RedirectToAction("Index", "Home");
        }

        public ActionResult UrunEkle()
        {
            if (Session["kull"] != null && ((tblMusteri)Session["kull"]).rolId == 2)
            {
                return View();
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult UrunEkle(FormCollection fc, HttpPostedFileBase uploadFile)
        {
            if (Session["kull"] != null && ((tblMusteri)Session["kull"]).rolId == 2)
            {

                tblUrunler yeniUrun = new tblUrunler();
                yeniUrun.urunAdi = fc["urunAd"];
                yeniUrun.kategoriId = Convert.ToInt32(fc["kategoriId"]);
                yeniUrun.urunDetayStok = Convert.ToInt32(fc["urunDetayStok"]);
                yeniUrun.urunDetayFiyat = Convert.ToDecimal(fc["urunDetayFiyat"]);
                string path = Path.Combine(Server.MapPath("~/Content/resim"), Path.GetFileName(uploadFile.FileName));
                string dbKaydet = "Content/resim/" + uploadFile.FileName;
                yeniUrun.urunDetayResim = dbKaydet;
                uploadFile.SaveAs(path);
                var datenow = DateTime.Now.ToString("yyyy-MM-dd");
                yeniUrun.urunDetayTarih = Convert.ToDateTime(datenow);
                db.tblUrunler.Add(yeniUrun);
                db.SaveChanges();

                return RedirectToAction("Urun", "Admin");
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult UrunDuzenle(int id)
        {
            if (Session["kull"] != null && ((tblMusteri)Session["kull"]).rolId == 2)
            {
                ViewBag.id = id;
                return View();
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult UrunDuzenle(FormCollection fc, HttpPostedFileBase uploadFile)
        {

            if (Session["kull"] != null && ((tblMusteri)Session["kull"]).rolId == 2)
            {

                using (var db = new db_EOAEntities1())
                {
                    tblUrunler editUrun = new tblUrunler();

                    long gelentId = Convert.ToInt64(fc["urunID"]);
                    editUrun = db.tblUrunler.Single(urun => urun.urunID == gelentId);
                    editUrun.urunAdi = fc["urunAd"];
                    editUrun.urunDetayStok = Convert.ToInt32(fc["urunDetayStok"]);
                    editUrun.urunDetayFiyat = Convert.ToDecimal(fc["urunDetayFiyat"]);
                    if (uploadFile != null)
                    {
                        string path = Path.Combine(Server.MapPath("~/Content/resim"), Path.GetFileName(uploadFile.FileName));
                        string dbKaydet = "Content/resim/" + uploadFile.FileName;
                        editUrun.urunDetayResim = dbKaydet;
                        uploadFile.SaveAs(path);
                    }
                    

                    db.tblUrunler.Attach(editUrun);
                    db.Entry(editUrun).State = EntityState.Modified;
                    db.SaveChanges();

                    return RedirectToAction("Urun", "Admin");
                }
            }

            return RedirectToAction("Index", "Home");

        }
    }
}