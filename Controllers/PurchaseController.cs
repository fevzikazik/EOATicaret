using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EOATicaret.Models;

namespace EOATicaret.Controllers
{
    public class PurchaseController : Controller
    {
        // GET: Purchase
        [HttpGet]
        public ActionResult Index()
        {
            if (Session["kull"] != null)
            {
                tblMusteri gelenK = (tblMusteri)Session["kull"];
                if (gelenK.tblRol.rolID > 0)
                {
                    return View();
                }
            }

            return RedirectToAction("Index", "Login");
        }

        public ActionResult SiparisBitir()
        {
            if (Session["kull"] != null)
            {
                List<tblUrunler> sepetListesi = (List<tblUrunler>)Session["cart"];

                using (var db = new db_EOAEntities1())
                {
                    foreach (tblUrunler item in sepetListesi)
                    {

                        tblSiparis gelenSiparis = new tblSiparis()
                        {
                            musteriId = ((tblMusteri)Session["kull"]).musteriID,
                            siparisAdet = 1,
                            urunId = item.urunID,
                            siparisTarih = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"))
                        };

                        db.tblSiparis.Add(gelenSiparis);
                    }

                    foreach (tblUrunler item in sepetListesi)
                    {
                        tblUrunler tmpUrun = db.tblUrunler.Where(urun => urun.urunID == item.urunID).First();
                        tmpUrun.urunDetayStok--;
                    }
                    db.SaveChanges();
                }

                Session["cart"] = null;

                return RedirectToAction("Siparisler", "Profil");
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
