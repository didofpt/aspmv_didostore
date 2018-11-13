using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class OrderDetailDao
    {
        private DidoStoreDbContext dbContext;
        public OrderDetailDao()
        {
            dbContext = new DidoStoreDbContext();
        }

        public bool Insert(OrderDetail orderDetail)
        {
            try
            {
                dbContext.OrderDetails.Add(orderDetail);
                dbContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }


        public IEnumerable<OrderDetail> ListAllPaging(int orderId, int page, int pageSize)
        {
            IQueryable<OrderDetail> model = dbContext.OrderDetails.Where(x => x.OrderID == orderId);
            return model.OrderByDescending(x => x.Quantity).ToPagedList(page, pageSize);
        }
    }
}
