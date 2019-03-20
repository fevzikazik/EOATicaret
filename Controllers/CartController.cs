using EOATicaret.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EOATicaret.Controllers
{
    public class CartController : Controller
    {

        dbFutureSoftEntities1 db = new dbFutureSoftEntities1();

        public ActionResult Index()
        {
            var urun = db.tbl_Urun;
            /*
            sqlConnection.Open();
            SqlCommand komut = new SqlCommand();
            komut.Connection = sqlConnection;
            komut.CommandText = "SELECT * FROM tbl_Urun";
            komut.ExecuteNonQuery();
            komut.Dispose();
            SqlDataAdapter adapter = new SqlDataAdapter(komut);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "tbl_Urun");

            List<string> lst = ds.Tables[0].ToList<string>();

            ViewBag.MyList = myList;
            */

            return View(urun);

        }
    }
}