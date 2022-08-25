using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using WebBanHang.Context;

namespace WebBanHang.Areas.Admin.Controllers
{
    public class UserAdminController : Controller
    {
        // GET: Admin/User
        WebBanHangEntities ojbWebBanHangEntities = new WebBanHangEntities();
        // GET: Admin/User
        public ActionResult Index(string currentFilter, string SearchString, int? page)
        {
            var lstUser = new List<Users_2119110325>();
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
                lstUser = ojbWebBanHangEntities.Users_2119110325.Where(n => (n.FirstName).Contains(SearchString)).ToList();
            }
            else
            { //lấy tất cả các danh mục trong category
                lstUser = ojbWebBanHangEntities.Users_2119110325.ToList();
            }
            ViewBag.CurrentFilter = SearchString;
            //Số lượng item của trang =6
            int pageSize = 6;
            //sắp xếp theo id sản phẩm, sp mới đưa lên đầu
            int pageNumber = (page ?? 1);
            lstUser = lstUser.OrderByDescending(n => n.UserId).ToList();
            return View(lstUser.ToPagedList(pageNumber, pageSize));

        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            var ojbUser = ojbWebBanHangEntities.Users_2119110325.Where(n => n.UserId == id).FirstOrDefault();
            return View(ojbUser);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var ojbUser = ojbWebBanHangEntities.Users_2119110325.Where(n => n.UserId == id).FirstOrDefault();
            return View(ojbUser);
        }
        [HttpPost]
        public ActionResult Delete(Users_2119110325 objUser, int Id)
        {
            objUser.UserId = Id;
            var ojbUser = ojbWebBanHangEntities.Users_2119110325.Where(n => n.UserId == objUser.UserId).FirstOrDefault();
            ojbWebBanHangEntities.Users_2119110325.Remove(ojbUser);
            ojbWebBanHangEntities.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var ojbUser = ojbWebBanHangEntities.Users_2119110325.Where(n => n.UserId == id).FirstOrDefault();
            return View(ojbUser);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int Id, Users_2119110325 users)
        {
            users.UserId = Id;

            var check = ojbWebBanHangEntities.Users_2119110325.FirstOrDefault(s => s.UserId == Id);
            if (check != null)
            {
                users.Password = GetMD5(users.Password);
                ojbWebBanHangEntities.Configuration.ValidateOnSaveEnabled = false;
                ojbWebBanHangEntities.Entry(users.UserId).State = EntityState.Modified;
                ojbWebBanHangEntities.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.error = "Email already exists";
                return View();
            }


        }
        public static string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");

            }
            return byte2String;
        }

    }
}
