using Model.EF;
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
    }
}
