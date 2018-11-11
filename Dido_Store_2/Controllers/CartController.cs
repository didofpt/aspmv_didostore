<<<<<<< HEAD
﻿using Dido_Store_2.Models;
using Model.Dao;
=======
﻿using Dido_Store_2.Common;
using Dido_Store_2.Models;
using Model.Dao;
using Model.EF;
>>>>>>> 0bc525544065982ded84d265aa669143e56569eb
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
<<<<<<< HEAD
=======
using System.Web.Script.Serialization;
>>>>>>> 0bc525544065982ded84d265aa669143e56569eb

namespace Dido_Store_2.Controllers
{
    public class CartController : Controller
    {
<<<<<<< HEAD
        private const string CartSession = "CartSession";
        // GET: Cart
        public ActionResult Index()
        {
            var cart = Session[CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return View();
        }

        public ActionResult AddItem(long productID, int quantity)
        {
            var product = new ProductDao().GetByID(productID);
            var cart = Session[CartSession];
            if (cart != null)
            {
                var list = (List<CartItem>)cart;
                if (list.Exists(x => x.Product.ID == productID))
                {
                    foreach (var item in list)
                    {
                        if (item.Product.ID == productID)
=======



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
>>>>>>> 0bc525544065982ded84d265aa669143e56569eb
                        {
                            item.Quantity += quantity;
                        }
                    }
                }
                else
                {
<<<<<<< HEAD
                    //tạo mới
                    var item = new CartItem();
                    item.Product = product;
                    item.Quantity = quantity;

                    //Gán vào session
                    Session[CartSession] = list;
                }
            }
            else
            {
                //tạo mới
                var item = new CartItem();
=======
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
>>>>>>> 0bc525544065982ded84d265aa669143e56569eb
                item.Product = product;
                item.Quantity = quantity;
                var list = new List<CartItem>();
                list.Add(item);
<<<<<<< HEAD
                //Gán vào session
                Session[CartSession] = list;
            }
            return RedirectToAction("Index");
        }
=======
                Session[CommonConstants.CART_SESSION] = list;
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult DeleteAll()
        {
            Session[CommonConstants.CART_SESSION] = null;
            return Json(new {
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
                    item.Quantity = jsonItem.Quantity;
                }
            }
            Session[CommonConstants.CART_SESSION] = sessionCarts;
            return Json(new {
                status = true
            });
        }

        public JsonResult Delete(int id)
        {
            var sessionCarts = (List<CartItem>) Session[CommonConstants.CART_SESSION];
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
            return Json(new {
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
                return View(list);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public ActionResult Payment(string shipName, string shipMobile, string shipEmail, string shipAddress)
        {
            var order = new Order();
            order.CreatedDate = DateTime.Now;
            order.ShipAddress = shipAddress;
            order.ShipEmail = shipEmail;
            order.ShipMobile = shipMobile;
            order.ShipName = shipName;
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
                }
            }
            catch
            {
                return Redirect("/xem-gio-hang");
            }
            //Xóa session sau khi mua thành công
            Session[CommonConstants.CART_SESSION] = null;
            return Redirect("/hoan-thanh");
        }

        public ActionResult Success()
        {
            return View();
        }
>>>>>>> 0bc525544065982ded84d265aa669143e56569eb
    }
}