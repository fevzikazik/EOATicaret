using EOATicaret.Models;
using System;
using System.Collections.Generic;
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
    }
}