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

        dbFutureSoftEntities1 db = new dbFutureSoftEntities1();


        public ActionResult Index()
        {
            var categories = db.tbl_Kategori;
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

            return View(categories);
        }
    }
}