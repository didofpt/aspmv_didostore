using Model.EF;
using System.Collections.Generic;
using System.Linq;

namespace Model.Dao
{
    public class ProductDao
    {
        DidoStoreDbContext dbContext;

        public ProductDao()
        {
            dbContext = new DidoStoreDbContext();
        }

        /// <summary>
        /// List all product
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Product> ListAll()
        {
            return dbContext.Products.Where(x => x.Status == true).ToList();
        }

<<<<<<< HEAD
        /// <summary>
        /// List product by date
        /// </summary>
        /// <param name="top"></param>
        /// <returns></returns>
=======
        //List top 4 newest product by date
>>>>>>> 2e15b885d8e129073a8b9ab1aae87339367d97aa
        public List<Product> ListNewProducts(int top)
        {
            return dbContext.Products.OrderByDescending(x => x.CreatedDate).Take(top).ToList();
        }

        /// <summary>
        /// List product by branch
        /// </summary>
        /// <param name="branchID"></param>
        /// <returns></returns>
        public List<Product> ListByBranch(long branchID, ref int totalRecord, int pageIndex = 1, int pageSize = 2)
        {
            totalRecord = dbContext.Products.Where(x => x.BranchID == branchID).Count();
            var model = dbContext.Products.Where(x => x.BranchID == branchID).OrderByDescending(x => x.CreatedDate).Skip((pageIndex -1) * pageSize).Take(pageSize).ToList();
            return model;
        }

        /// <summary>
        /// List discount product
        /// </summary>
        /// <param name="top"></param>
        /// <returns></returns>
        public List<Product> ListPromotionProducts(int top)
        {
            return dbContext.Products.Where(x => x.PromotionPrice != null).OrderByDescending(x => x.CreatedDate).Take(top).ToList();
        }

        /// <summary>
        /// List relate product
        /// </summary>
        /// <param name="productID"></param>
        /// <returns></returns>
        public List<Product> ListRelatedProducts(long productID)
        {
            var product = dbContext.Products.Find(productID);
            return dbContext.Products.Where(x => x.ID != productID && x.BranchID == product.BranchID).ToList();
        }

        /// <summary>
        /// Get detail product
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Product GetProduct(long id)
        {
            return dbContext.Products.Find(id);
        }

    }
}
