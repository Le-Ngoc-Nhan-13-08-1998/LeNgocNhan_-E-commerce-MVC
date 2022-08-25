
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using WebBanHang.Context;
using WebBanHang.Models;

namespace WebBanHang.Context.CategoryController
{
    public class CategoryController : Controller
    {
        // GET: Category
        WebBanHangEntities objWebBanHangEntities = new WebBanHangEntities();
        // GET: Category
       
        // GET: Category
        public ActionResult Index()
        {
            var lstCategory = objWebBanHangEntities.Category_2119110325.ToList();
            return View(lstCategory);
        }
        public ActionResult ProductCategory(int Id)
        {
            HomeModel objHomeModel = new HomeModel();
            objHomeModel.listCategory = objWebBanHangEntities.Category_2119110325.ToList();
            objHomeModel.listProduct = objWebBanHangEntities.Product_2119110325.Where(n => n.CategoryId == Id).ToList();
            return View(objHomeModel);
        }
    }
}

