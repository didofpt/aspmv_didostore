using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dido_Store_2.Areas.Admin.Controllers
{
    public class OrderDetailController : BaseController
    {
        // GET: Admin/OrderDetail
        public ActionResult Index(int id, int page = 1, int pageSize = 2)
        {
            var dao = new OrderDetailDao();
            IEnumerable<OrderDetail> model = dao.ListAllPaging(id, page, pageSize);
            ViewBag.total = model.Sum(x => x.Product.Price * x.Quantity);
            return View(model);
        }
    }
}