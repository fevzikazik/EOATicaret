using EOATicaret.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EOATicaret.Controllers
{
    public class HomeController : Controller
    {

        db_EOAEntities1 db = new db_EOAEntities1();


        public ActionResult Index()
        {
            var cat = db.tblKategori;
                return View(cat);
        }
        
    }
}