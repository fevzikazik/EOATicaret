using EOATicaret.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EOATicaret.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {

            db_EOAEntities1 db = new db_EOAEntities1();
            List<tblUrunler> tblUrunlers = new List<tblUrunler>();
            tblKategori kategori = new tblKategori();

            if (Request.QueryString["kategoriID"]!=null)
            {
                int kategoriID = Convert.ToInt32(Request.QueryString["kategoriID"]);
                kategori = db.tblKategori.Where(p => p.kategoriID == kategoriID).First();
                tblUrunlers = db.tblUrunler.Where(urun => urun.tblKategori.kategoriID == kategoriID).ToList();
                ViewBag.Kategori = kategori.kategoriAdi;
                
            }
            else
            {
                ViewBag.Kategori = "TÜMÜ";
               tblUrunlers = db.tblUrunler.ToList();
            }
            

            return View(tblUrunlers);
        }
    }
}