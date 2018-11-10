using Model.EF;
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

    }
}
