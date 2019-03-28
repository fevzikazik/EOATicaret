using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EOATicaret.Models;

namespace EOATicaret.Models
{
    public class UrunlerViewModel
    {
        private List<tblUrunler> products;

        public UrunlerViewModel()
        {
            this.products = new List<tblUrunler>();
        }
        
        public List<tblUrunler> getAll()
        {
            return this.products;
        }
    }
}