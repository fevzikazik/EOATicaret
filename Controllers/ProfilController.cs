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
    public class ProfilController : Controller
    {
        // GET: Profil
        public ActionResult Hesabim()
        {
            if (Session["kull"] != null)
            {
                tblMusteri gelenK = (tblMusteri)Session["kull"];
                return View();
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Siparisler()
        {
            if (Session["kull"] != null)
            {
                tblMusteri gelenK = (tblMusteri)Session["kull"];
                List<tblSiparis> Siparislerim = (List <tblSiparis>)gelenK.tblSiparis.ToList();
                ViewBag.Siparislerim = Siparislerim;

                return View();
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult Guncelle(FormCollection fc, HttpPostedFileBase uploadFile)
        {

            //bool isModified = false;

            if (Session["kull"] != null)
            {
                tblMusteri tempMus = new tblMusteri();
                using (var db = new db_EOAEntities1())
                {
                    string gelenKullAdi = fc["kullaniciAdi"];
                    tempMus = db.tblMusteri.Single(mus => mus.kullaniciAdi == gelenKullAdi);

                    tempMus.musteriAdi = fc["musteriAdi"];
                    tempMus.musteriSoyadi = fc["musteriSoyadi"];
                    tempMus.musteriTel = fc["musteriTel"];
                    tempMus.musteriAdres = fc["musteriAdres"];
                    tempMus.kullaniciAdi = fc["kullaniciAdi"];
                    tempMus.kullaniciSifre = fc["kullaniciSifre"];

                    
                    db.tblMusteri.Attach(tempMus);
                    db.Entry(tempMus).State = EntityState.Modified;
                    db.SaveChanges();
                    Session["kull"] = tempMus;
                    //isModified = true;
                }

            }
            return RedirectToAction("Hesabim");
        }

        public ActionResult Favorilerim()
        {
            if (Session["kull"] != null)
            {
                    return View();                
            }

            return View("Index", "Home");
        }

        [HttpGet]
        public ActionResult AddToFav(int id)
        {
            if (Session["kull"] != null)
            {
                using (var db = new db_EOAEntities1())
                {
                    tblFavori fav = new tblFavori();
                    fav.urunID = id;
                    fav.musteriID = Convert.ToInt32(((tblMusteri)Session["kull"]).musteriID);
                    db.tblFavori.Add(fav);
                    db.SaveChanges();
                }

                return View("Favorilerim");
            }
            return RedirectToAction("Index", "Login");
        }

        [HttpPost]
        public ActionResult DeleteToFav(int id)
        {
            if (Session["kull"] != null)
            {
                using (var db = new db_EOAEntities1())
                {
                    var sorguFav = (from fav in db.tblFavori
                                   where fav.favoriID == id
                                   select fav).First();

                    db.tblFavori.Remove(sorguFav);
                    db.SaveChanges();
                }

                return View("Favorilerim");
            }
            return RedirectToAction("Index", "Login");
        }
    }
}