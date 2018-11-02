using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
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

        //List all product
        public IEnumerable<Product> ListAll()
        {
            return dbContext.Products.Where(x => x.Status == true).ToList();
        }


        public IEnumerable<Product> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<Product> model = dbContext.Products;
            if(!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString));
            }
            return model.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
        }

        //List top 4 newest product by date
        public List<Product> ListNewProducts(int top)
        {
            return dbContext.Products.OrderByDescending(x => x.CreatedDate).Take(top).ToList();
        }

        public int Insert(Product product)
        {
            dbContext.Products.Add(product);
            dbContext.SaveChanges();
            return product.ID;
        }

        //List discount product
        public List<Product> ListPromotionProducts(int top)
        {
            return dbContext.Products.Where(x => x.PromotionPrice != null).OrderByDescending(x => x.CreatedDate).Take(top).ToList();
        }

        //Get detail product
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
