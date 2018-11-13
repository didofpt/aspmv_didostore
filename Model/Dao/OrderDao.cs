using Model.EF;
using Model.ViewModel;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class OrderDao
    {
        private DidoStoreDbContext dbContext;
        public OrderDao()
        {
            dbContext = new DidoStoreDbContext();
        }

        public int Insert(Order order)
        {
            dbContext.Orders.Add(order);
            dbContext.SaveChanges();
            return order.ID;
        }

        public IEnumerable<Order> ListAll()
        {
            return dbContext.Orders.Where(x => x.Status == true).ToList();
        }

        public IEnumerable<Order> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<Order> model = dbContext.Orders;
            if(!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.ShipName.Contains(searchString));
            }
            return model.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
        }

        public bool? ChangeStatus(int id)
        {
            var order = dbContext.Orders.Find(id);
            order.Status = !order.Status;
            dbContext.SaveChanges();
            return order.Status;
        }

        //public OrderDetailViewModel ViewDetail(long id)
        //{
        //    var model = (from a in dbContext.OrderDetails
        //                 join b in dbContext.Products
        //                 on a.ProductID equals b.ID
        //                 where a.OrderID == id
        //                 select new
        //                 {
        //                     id = b.ID,
        //                     productName = b.Name,
        //                     quantity = a.Quantity,
        //                     price = b.Price,
        //                 }).AsEnumerable().Select(x => new OrderDetailViewModel()
        //                 {
        //                     id = x.id,
        //                     productName = x.productName,
        //                     quantity = x.quantity,
        //                     price = x.price,
        //                     total = x.quantity * x.price
        //                 });
        //    return (OrderDetailViewModel)model;
        //}
    }
}
