using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using EOATicaret.Models;

namespace EOATicaret.Controllers
{
    public class SignupController : Controller
    {
        // GET: Signup
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(FormCollection mus)
        {
            tblMusteri Musteri = new tblMusteri();
            Musteri.musteriAdi = mus["musteriAdi"];
            Musteri.musteriSoyadi = mus["musteriSoyadi"];
            Musteri.kullaniciAdi = mus["kullaniciAdi"];
            Musteri.kullaniciSifre = mus["kullaniciSifre"];
            Musteri.rolId = 1;

            using (var db = new db_EOAEntities1())
            {
                db.tblMusteri.Add(Musteri);
                db.SaveChanges();

            }

            return RedirectToAction("Index","Home");
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon(); // it will clear the session at the end of request
            return RedirectToAction("Index", "Home");
        }

    }
}