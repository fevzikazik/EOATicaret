using EOATicaret.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace EOATicaret.Controllers
{
    public class LoginController : Controller
    {

        [HttpGet]
        public ActionResult Index()
        {
            if (Session["kull"] == null)
            {
                return View();
            }
            return RedirectToAction("Hesabim", "Profil");
        }


        // GET: Login
        [HttpPost]
        public ActionResult Kontrol(tblMusteri m)
        {
            db_EOAEntities1 db = new db_EOAEntities1();
            var _kull = db.tblMusteri.Where(s => s.kullaniciAdi == m.kullaniciAdi);
            if (_kull.Any())
            {
                if (_kull.Where(s => s.kullaniciSifre == m.kullaniciSifre).Any())
                {
                    //Session["kull"] = ((tblMusteri)_kull);
                    Session["kull"] = _kull.SingleOrDefault();

                    return RedirectToAction("Index","Home");
                }
                else
                {
                    //ViewBag.Mesaj = Json("Hata");
                    //return Json(new { status = true, message = "Invalid Password!" });
                    return RedirectToAction("Index", "Login");
                }
            }
            else
            {
                // return Json(new { status = false, message = "Invalid Email!" });
                return RedirectToAction("Index", "Login");
            }
        }
    }
}