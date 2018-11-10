using Model.EF;
using PagedList;
using System;
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

        public IEnumerable<Product> ListAll()
        {
            return dbContext.Products.Where(x => x.Status == true).ToList();
        }

        /// <summary>
        /// List product by date
        /// </summary>
        /// <param name="top"></param>
        /// <returns></returns>
        public List<Product> ListNewProducts(int top)
        {
            return dbContext.Products.OrderByDescending(x => x.CreatedDate).Take(top).ToList();
        }

        public int Insert(Product product)
        {
            product.CreatedDate = DateTime.Now;
            dbContext.Products.Add(product);
            dbContext.SaveChanges();
            return product.ID;
        }

        //List discount product
        /// <summary>
        /// List product by branch
        /// </summary>
        /// <param name="branchID"></param>
        /// <returns></returns>
 
        public List<Product> ListByBranch(long branchID, ref int totalRecord, int pageIndex = 1, int pageSize = 2)
        {
            totalRecord = dbContext.Products.Where(x => x.BranchID == branchID).Count();
            var model = dbContext.Products.Where(x => x.BranchID == branchID).OrderByDescending(x => x.CreatedDate).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            return model;
        }

        public bool Update(Product product)
        {
            try
            {
                Product entity = dbContext.Products.Find(product.ID);
                entity.Name = product.Name;
                entity.Alias = product.Alias;
                entity.BranchID = product.BranchID;
                entity.Content = product.Content;
                entity.Description = product.Description;
                entity.Image = product.Image;
                entity.UpdatedDate = DateTime.Now;
                entity.MoreImages = product.MoreImages;
                entity.Quantity = product.Quantity;
                entity.Status = product.Status;
                entity.Price = product.Price;
                entity.PromotionPrice = product.PromotionPrice;
                entity.Warranty = product.Warranty;
                dbContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }

        /// <summary>
        /// List discount product
        /// </summary>
        /// <param name="top"></param>
        /// <returns></returns>
=======
>>>>>>> 22_10
        public List<Product> ListPromotionProducts(int top)
        {
            return dbContext.Products.Where(x => x.PromotionPrice != null)
                .OrderByDescending(x => x.CreatedDate)
                .Take(top)
                .ToList();
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
        public Product GetById(int id)
        {
            return dbContext.Products.Find(id);
        }

        public bool? ChangeStatus(int id)
        {
            var product = dbContext.Products.Find(id);
            product.Status = !product.Status;
            dbContext.SaveChanges();
            return product.Status;
        }

    }
}
