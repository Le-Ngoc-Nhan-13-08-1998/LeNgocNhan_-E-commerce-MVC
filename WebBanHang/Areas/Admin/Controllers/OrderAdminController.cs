using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHang.Context;

namespace WebBanHang.Areas.Admin.Controllers
{
    public class OrderAdminController : Controller
    {
        // GET: Admin/Order
        WebBanHangEntities ojbWebBanHangEntities = new WebBanHangEntities();
        // GET: Admin/Order
        public ActionResult Index(string currentFilter, string SearchString, int? page)
        {
            var lstOrder = new List<Order_2119110325>();
            if (SearchString != null)
            {
                page = 1;
            }
            else
            {
                SearchString = currentFilter;
            }
            if (!string.IsNullOrEmpty(SearchString))
            {
                //lấy tất cả các danh mucc theo từ khóa tìm kiếm
                lstOrder = ojbWebBanHangEntities.Order_2119110325.Where(n => n.Name.Contains(SearchString)).ToList();
            }
            else
            { //lấy tất cả các danh mục trong category
                lstOrder = ojbWebBanHangEntities.Order_2119110325.ToList();
            }
            ViewBag.CurrentFilter = SearchString;
            //Số lượng item của trang =6
            int pageSize = 6;
            //sắp xếp theo id sản phẩm, sp mới đưa lên đầu
            int pageNumber = (page ?? 1);
            lstOrder = lstOrder.OrderByDescending(n => n.Id).ToList();
            return View(lstOrder.ToPagedList(pageNumber, pageSize));
        }
        [HttpGet]
        public ActionResult Details(int Id)
        {
            var objOrder = ojbWebBanHangEntities.Order_2119110325.Where(n => n.Id == Id).FirstOrDefault();
            return View(objOrder);
        }
        [HttpGet]
        public ActionResult Delete(int Id)
        {
            var objOrder = ojbWebBanHangEntities.Order_2119110325.Where(n => n.Id == Id).FirstOrDefault();
            return View(objOrder);
        }
        [HttpPost]
        public ActionResult Delete(Order_2119110325 objCate, int Id)
        {
            objCate.Id = Id;
            var objcategory = ojbWebBanHangEntities.Order_2119110325.Where(n => n.Id == objCate.Id).FirstOrDefault();
            ojbWebBanHangEntities.Order_2119110325.Remove(objcategory);
            ojbWebBanHangEntities.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
