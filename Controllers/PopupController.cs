using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EOATicaret.Models;

namespace EOATicaret.Controllers
{
    public class PopupController : Controller
    {
        db_EOAEntities1 db = new db_EOAEntities1();
        // GET: Popup
        public ActionResult Index()
        {
            /*List<tblDuyuru> duyuru = db.tblDuyuru.ToList();
            return Json(duyuru, JsonRequestBehavior.AllowGet);*/
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult Degistir()
        {
            if (Session["kull"] != null && ((tblMusteri)Session["kull"]).rolId == 2)
            {
                return View();
            }
            return RedirectToAction("Index", "Home");
        }


        [HttpPost]
        public ActionResult Degistir(FormCollection fc, HttpPostedFileBase uploadFile)
        {

                tblDuyuru duyuru = new tblDuyuru();
            duyuru = db.tblDuyuru.First();

            duyuru.Baslik = fc["Baslik"];
            string dbKaydet = "Content/popup/popup.jpg";
            string path = Path.Combine(Server.MapPath("~/Content/popup/"), "popup.jpg");
            duyuru.img = dbKaydet;

            uploadFile.SaveAs(path);

            db.SaveChanges();

           

            return RedirectToAction("Index", "Home");
        }
    }
}