using Common;
using Dido_Store_2.Common;
using Dido_Store_2.Models;
using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Dido_Store_2.Controllers
{
    public class CartController : Controller
    {



        // GET: Cart
        public ActionResult Index()
        {
            var cart = Session[CommonConstants.CART_SESSION];
            var list = new List<CartItem>();
            //Session.RemoveAll();
            if(cart != null)
            {
                list = cart as List<CartItem>;
            }
            return View(list);
        }

        public ActionResult AddItem(int ProductID, int quantity)
        {
            var cart = Session[CommonConstants.CART_SESSION];

            if(cart != null)
            {
                var list = cart as List<CartItem>;
                if(list.Exists(p => p.Product.ID == ProductID))
                {
                    foreach(var item in list)
                    {
                        if(item.Product.ID == ProductID)
                        {
                            item.Quantity += quantity;
                        }
                    }
                }
                else
                {
                    var item = new CartItem();
                    var product = new ProductDao().GetById(ProductID);
                    item.Product = product;
                    item.Quantity = quantity;
                    list.Add(item);
                }
                Session[CommonConstants.CART_SESSION] = list;
            }
            else
            {
                var item = new CartItem();
                var product = new ProductDao().GetById(ProductID);
                item.Product = product;
                item.Quantity = quantity;
                var list = new List<CartItem>();
                list.Add(item);
                Session[CommonConstants.CART_SESSION] = list;
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult DeleteAll()
        {
            Session[CommonConstants.CART_SESSION] = null;
            return Json(new
            {
                status = true
            });
        }

        [HttpPost]
        public JsonResult Update(string cartModel)
        {
            var jsonCarts = new JavaScriptSerializer().Deserialize<List<CartItem>>(cartModel);
            var sessionCarts = (List<CartItem>)Session[CommonConstants.CART_SESSION];
            foreach(var item in sessionCarts)
            {
                var jsonItem = jsonCarts.SingleOrDefault(e => e.Product.ID == item.Product.ID);
                if(jsonItem != null)
                {
                    int availableQuantity = new ProductDao().GetQuantity(jsonItem.Product.ID);

                    if(availableQuantity < jsonItem.Quantity)
                    {
                        item.Quantity = availableQuantity;
                    }
                    else
                    {
                        item.Quantity = jsonItem.Quantity;
                    }
                }
            }
            Session[CommonConstants.CART_SESSION] = sessionCarts;
            return Json(new
            {
                status = true
            });
        }

        public JsonResult Delete(int id)
        {
            var sessionCarts = (List<CartItem>)Session[CommonConstants.CART_SESSION];
            sessionCarts.RemoveAll(e => e.Product.ID == id);
            Session[CommonConstants.CART_SESSION] = sessionCarts;
            if(sessionCarts.Count == 0)
            {
                return Json(new
                {
                    status = true,
                    empty = true
                });
            }
            return Json(new
            {
                status = true,
                empty = false
            });
        }

        [HttpGet]
        public ActionResult Payment()
        {
            var cart = Session[CommonConstants.CART_SESSION];
            var list = new List<CartItem>();
            //Session.RemoveAll();
            if(cart != null)
            {
                list = cart as List<CartItem>;
                ViewBag.cartList = list;
                return View();
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public ActionResult Payment(Order model)
        {
            if(ModelState.IsValid)
            {
                var order = new Order();
                order.CreatedDate = DateTime.Now;
                order.ShipAddress = model.ShipAddress;
                order.ShipEmail = model.ShipEmail;
                order.ShipMobile = model.ShipMobile;
                order.ShipName = model.ShipName;
                order.PaymentStatus = false;
                try
                {
                    var id = new OrderDao().Insert(order);
                    var orderDetailDao = new OrderDetailDao();
                    var cart = (List<CartItem>)Session[CommonConstants.CART_SESSION];
                    foreach(var item in cart)
                    {
                        var detail = new OrderDetail();
                        detail.OrderID = id;
                        detail.ProductID = item.Product.ID;
                        detail.Quantity = item.Quantity;
                        orderDetailDao.Insert(detail);
                        new ProductDao().UpdateQuantity(item.Product.ID, item.Quantity);
                    total += (item.Product.Price.GetValueOrDefault(0) * item.Quantity);

                    }
                }
                catch
                {
                    ModelState.AddModelError("", "Giao dịch không thành công");
                }

                       string content = System.IO.File.ReadAllText(Server.MapPath("~/assets/client/template/neworder.html"));

                content = content.Replace("{{CustomerName}}", shipName);
                content = content.Replace("{{Phone}}", shipMobile);
                content = content.Replace("{{Email}}", shipEmail);
                content = content.Replace("{{Address}}", shipAddress);
                content = content.Replace("{{Total}}", total.ToString("N0"));
                var toEmail = ConfigurationManager.AppSettings["ToEmailAddress"].ToString();

                new MailHelper().SendMail(shipEmail, "Đơn hàng mới từ DidoStore", content);
                new MailHelper().SendMail(toEmail, "Đơn hàng mới từ DidoStore", content);

                //Xóa session sau khi mua thành công
                Session[CommonConstants.CART_SESSION] = null;
                return Redirect("/hoan-thanh");
            }
            var carts = Session[CommonConstants.CART_SESSION];
            ViewBag.cartList = (List<CartItem>)carts;
            return View("Payment");

        }

        public ActionResult Success()
        {
            return View();
        }
    }
}