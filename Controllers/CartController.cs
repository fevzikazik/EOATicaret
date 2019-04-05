using EOATicaret.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace EOATicaret.Controllers
{
    public class CartController : Controller
    {

        db_EOAEntities1 db = new db_EOAEntities1();

        public ActionResult Index()
        {
            
            List<tblUrunler> cart = (List<tblUrunler>)Session["cart"];
            ViewBag.Cart = cart;
            return View();
        }

        [HttpPost]
        public ActionResult AddToCart(int id)
        {
            // int gelenID = Convert.ToInt32(Request.QueryString["s"]);
            //var productId = Convert.ToInt32(urun["urunIdsi"]);
          //  int id = Convert.ToInt32(sid);
          
                    tblUrunler addToCart = db.tblUrunler.First(p => p.urunID == id);

            if (addToCart.urunDetayStok > 0 )
            {
                if (Session["cart"] == null)
                {
                    List<tblUrunler> cart = new List<tblUrunler>();
                    cart.Add(addToCart);
                    Session["cart"] = cart;
                }
                else
                {
                    List<tblUrunler> cart = (List<tblUrunler>)Session["cart"];
                    cart.Add(addToCart);
                    Session["cart"] = cart;
                }
                return Json("başarılı");
            }

            return Json("stok kalmadı");
            //return new HttpStatusCodeResult(HttpStatusCode.OK);
            

        }

        [HttpPost]
        public ActionResult DeleteToCart(int id)
        {
            tblUrunler tmpUrun = ((List<tblUrunler>)Session["cart"]).Where(u => u.urunID == id).First();

            List<tblUrunler> cart = new List<tblUrunler>();
            cart = (List<tblUrunler>)Session["cart"];
            cart.Remove(tmpUrun);
            if (cart.Count==0)
                Session["cart"] = null;
            else
                Session["cart"] = cart;
            return RedirectToAction("Index", "Cart");
            //return new HttpStatusCodeResult(HttpStatusCode.OK);
        }

        [HttpGet]
        public ActionResult SepetiBosalt()
        {
            Session["cart"] = null;

            return RedirectToAction("Index", "Cart");
        }
    }
}