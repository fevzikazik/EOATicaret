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
    }
}