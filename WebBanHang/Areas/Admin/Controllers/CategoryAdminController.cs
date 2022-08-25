using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHang.Context;

namespace WebBanHang.Areas.Admin.Controllers
{
    public class CategoryAdminController : Controller
    {
        // GET: Admin/CategoryAdmin
        WebBanHangEntities ojbWebBanHangEntities = new WebBanHangEntities();

        public ActionResult Index(string currentFilter, string SearchString, int? page)
        {
            var lstCategory = new List<Category_2119110325>();
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
                lstCategory = ojbWebBanHangEntities.Category_2119110325.Where(n => n.Name.Contains(SearchString)).ToList();
            }
            else
            { //lấy tất cả các danh mục trong category
                lstCategory = ojbWebBanHangEntities.Category_2119110325.ToList();
            }
            ViewBag.CurrentFilter = SearchString;
            //Số lượng item của trang =6
            int pageSize = 6;
            //sắp xếp theo id sản phẩm, sp mới đưa lên đầu
            int pageNumber = (page ?? 1);
            lstCategory = lstCategory.OrderByDescending(n => n.Id).ToList();
            return View(lstCategory.ToPagedList(pageNumber, pageSize));
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Create(Category_2119110325 category)
        {
            try
            {
                if (category.ImageUpload != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(category.ImageUpload.FileName);
                    string extention = Path.GetExtension(category.ImageUpload.FileName);
                    fileName = fileName + "_" + long.Parse(DateTime.Now.ToString("yyyyMMddhhmmss")) + extention;
                    category.Avatar = fileName;
                    category.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/images/items"), fileName));
                }
                ojbWebBanHangEntities.Category_2119110325.Add(category);
                ojbWebBanHangEntities.SaveChanges();
                return RedirectToAction("Index");

            }
            catch (Exception)
            {

                return RedirectToAction("Lỗi");
            }
        }

        [HttpGet]
        public ActionResult Details(int Id)
        {
            var objProduct = ojbWebBanHangEntities.Category_2119110325.Where(n => n.Id == Id).FirstOrDefault();
            return View(objProduct);
        }
        [HttpGet]
        public ActionResult Delete(int Id)
        {
            var objProduct = ojbWebBanHangEntities.Category_2119110325.Where(n => n.Id == Id).FirstOrDefault();
            return View(objProduct);
        }
        [HttpPost]
        public ActionResult Delete(Category_2119110325 objCate, int Id)
        {
            objCate.Id = Id;
            var objcategory = ojbWebBanHangEntities.Category_2119110325.Where(n => n.Id == objCate.Id).FirstOrDefault();
            ojbWebBanHangEntities.Category_2119110325.Remove(objcategory);
            ojbWebBanHangEntities.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int Id)
        {
            var objProduct = ojbWebBanHangEntities.Category_2119110325.Where(n => n.Id == Id).FirstOrDefault();
            return View(objProduct);
        }
        [HttpPost]
        public ActionResult Edit(Category_2119110325 category)
        {
            try
            {
                if (category.ImageUpload != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(category.ImageUpload.FileName);
                    string extension = Path.GetExtension(category.ImageUpload.FileName);
                    fileName = fileName + extension;
                    category.Avatar = fileName;
                    category.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/images/items"), fileName));
                }
                category.UpdatedOnUtc = DateTime.Now;
                ojbWebBanHangEntities.Entry(category).State = EntityState.Modified;
                ojbWebBanHangEntities.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return RedirectToAction("Error");
            }
        }
    }
}