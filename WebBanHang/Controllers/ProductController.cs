
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHang.Context;

namespace WebBanHang.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        WebBanHangEntities objWebBanHangEntities = new WebBanHangEntities();

        public ActionResult Detail(int Id)
        {
            var objProduct = objWebBanHangEntities.Product_2119110325.Where(n => n.Id == Id).FirstOrDefault();
            return View(objProduct);
        }
    }
}