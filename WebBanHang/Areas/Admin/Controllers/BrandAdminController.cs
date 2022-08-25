
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
    public class BrandAdminController : Controller
    {
        // GET: Admin/Brand
        WebBanHangEntities ojbWebBanHangEntities = new WebBanHangEntities();

        // GET: Admin/Brand
        public ActionResult Index(string currentFilter, string SearchString, int? page)
        {
            var lstBrand = ojbWebBanHangEntities.Brand_2119110325.ToList();

            //Số lượng item của trang =6
            int pageSize = 6;
            //sắp xếp theo id sản phẩm, sp mới đưa lên đầu
            int pageNumber = (page ?? 1);
            lstBrand = lstBrand.OrderByDescending(n => n.Id).ToList();
            return View(lstBrand.ToPagedList(pageNumber, pageSize));
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Error()
        {
            return View();
        }
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Create(Brand_2119110325 brand)
        {
            try
            {
                if (brand.ImageUpload != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(brand.ImageUpload.FileName);
                    string extention = Path.GetExtension(brand.ImageUpload.FileName);
                    fileName = fileName + "_" + long.Parse(DateTime.Now.ToString("yyyyMMddhhmmss")) + extention;
                    brand.Avatar = fileName;
                    brand.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/images/items"), fileName));
                }
                ojbWebBanHangEntities.Brand_2119110325.Add(brand);
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
            var objProduct = ojbWebBanHangEntities.Brand_2119110325.Where(n => n.Id == Id).FirstOrDefault();
            return View(objProduct);
        }
        [HttpGet]
        public ActionResult Delete(int Id)
        {
            var objProduct = ojbWebBanHangEntities.Brand_2119110325.Where(n => n.Id == Id).FirstOrDefault();
            return View(objProduct);
        }
        [HttpPost]
        public ActionResult Delete(Brand_2119110325 objBrand, int Id)
        {
            objBrand.Id = Id;
            var objcategory = ojbWebBanHangEntities.Brand_2119110325.Where(n => n.Id == objBrand.Id).FirstOrDefault();
            ojbWebBanHangEntities.Brand_2119110325.Remove(objcategory);
            ojbWebBanHangEntities.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int Id)
        {
            var objProduct = ojbWebBanHangEntities.Brand_2119110325.Where(n => n.Id == Id).FirstOrDefault();
            //Session["anhgoc"] = objProduct.Avatar.ToString();
            return View(objProduct);
        }
        [HttpPost]
        public ActionResult Edit(Brand_2119110325 brand)
        {
            try
            {
                if (brand.ImageUpload != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(brand.ImageUpload.FileName);
                    string extension = Path.GetExtension(brand.ImageUpload.FileName);
                    fileName = fileName + extension;
                    brand.Avatar = fileName;
                    brand.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/images/items"), fileName));
                }
                //else
                //{
                //    brand.Avatar = Session["anhgoc"].ToString();
                //}
                brand.UpdateUtc = DateTime.Now;
                ojbWebBanHangEntities.Entry(brand).State = EntityState.Modified;
                ojbWebBanHangEntities.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return RedirectToAction("Nhập thiếu thông tin");
            }

        }
    }
}