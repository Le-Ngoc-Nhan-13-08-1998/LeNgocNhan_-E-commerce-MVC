using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using WebBanHang.Context;

namespace WebBanHang.Controllers
{
    public class HomeController : Controller
    {
        WebBanHangEntities objWebBanHangEntities = new WebBanHangEntities();
    public ActionResult Index()
    {
        HomeModel objHomeModel = new HomeModel();
        objHomeModel.listCategory = objWebBanHangEntities.Category_2119110325.ToList();
        objHomeModel.listProduct = objWebBanHangEntities.Product_2119110325.ToList();
        return View(objHomeModel);
    }

    public ActionResult About()
    {
        ViewBag.Message = "Your application description page.";

        return View();
    }

    public ActionResult Contact()
    {
        ViewBag.Message = "Your contact page.";

        return View();
    }
    [HttpGet]
    public ActionResult Register()
    {
        return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Register(Users_2119110325 _user)
    {
        if (ModelState.IsValid)
        {
            var check = objWebBanHangEntities.Users_2119110325.FirstOrDefault(s => s.Email == _user.Email);
            if (check == null)
            {
                _user.Password = GetMD5(_user.Password);
                objWebBanHangEntities.Configuration.ValidateOnSaveEnabled = false;
                objWebBanHangEntities.Users_2119110325.Add(_user);
                objWebBanHangEntities.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.error = "Email already exists";
                return View();
            }
        }
        return View();

    }
    [HttpGet]
    public ActionResult Login()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Login(string email, string password)
    {
        if (ModelState.IsValid)
        {
            var f_password = GetMD5(password);
            var data = objWebBanHangEntities.Users_2119110325.Where(s => s.Email.Equals(email) && s.Password.Equals(f_password)).ToList();
            if (data.Count() > 0)
            {
                //add session
                Session["FullName"] = data.FirstOrDefault().FirstName + " " + data.FirstOrDefault().LastName;
                Session["Email"] = data.FirstOrDefault().Email;
                Session["idUser"] = data.FirstOrDefault().UserId;
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.error = "Login failed";
                return RedirectToAction("Login");
            }
        }
        return View();
    }
    public ActionResult Logout()
    {
        Session.Clear();//remove session
        return RedirectToAction("Login");
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