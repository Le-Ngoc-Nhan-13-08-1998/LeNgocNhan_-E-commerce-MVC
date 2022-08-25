using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHang.Context;

namespace WebBanHang.Controllers
{
    public class PaymentController : Controller
    {
        // GET: Pay
        WebBanHangEntities ojbWebBanHang = new WebBanHangEntities();

        // GET: Payment
        public ActionResult Payment()
        {
            if (Session["idUser"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                var lstcart = (List<CartModel>)Session["Cart"];
                //gán dữ liệu
                Order_2119110325 objOrder = new Order_2119110325();
                objOrder.Name = "DonHang" + DateTime.Now.ToString("yyyyyMMdd");
                objOrder.UserId = int.Parse(Session["idUser"].ToString());
                objOrder.Price = int.Parse(Session["total"].ToString());
                objOrder.CreatedOnUtc = DateTime.Now;
                objOrder.Status = 1;
                ojbWebBanHang.Order_2119110325.Add(objOrder);
                ojbWebBanHang.SaveChanges();

                int intOrderID = objOrder.Id;
                List<OrderDetail_2119110325> lstOrderDetail = new List<OrderDetail_2119110325>();
                foreach (var item in lstcart)
                {

                    OrderDetail_2119110325 objDetail = new OrderDetail_2119110325();
                    objDetail.Quantity = item.Quantity;
                    objDetail.OrderId = intOrderID;
                    objDetail.ProductId = item.Product.Id;
                    lstOrderDetail.Add(objDetail);
                }
                ojbWebBanHang.OrderDetail_2119110325.AddRange(lstOrderDetail);
                ojbWebBanHang.SaveChanges();

            }
            return View();

        }
    }
}