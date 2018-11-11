using Dido_Store_2.Common;
using Dido_Store_2.Models;
using Model.Dao;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Dido_Store_2.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var productDao = new ProductDao();
            ViewBag.NewProducts = productDao.ListNewProducts(4);
            ViewBag.ListPromotionProducts = productDao.ListPromotionProducts(4);
            return View();
        }

        [ChildActionOnly]
        public PartialViewResult HeaderCart()
        {
            var cart = Session[CommonConstants.CART_SESSION];
            List<CartItem> list = new List<CartItem>();
            //Session.RemoveAll();
            if(cart != null)
            {
                list = cart as List<CartItem>;
            }
            return PartialView(list);
        }

    }
}