﻿using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class BranchDao
    {
        private DidoStoreDbContext dbContext = null;

        public BranchDao()
        {
            this.dbContext = new DidoStoreDbContext();
        }

        public int Insert(Branch branch)
        {
            dbContext.Branches.Add(branch);
            dbContext.SaveChanges();
            return branch.ID;
        }

        public bool Update(Branch branch)
        {
            try
            {
                var entity = dbContext.Branches.Find(branch.ID);
                entity.Alias = branch.Alias;
                entity.BranchName = branch.BranchName;
                entity.Description = branch.Description;
                entity.Image = branch.Image;
                entity.Status = branch.Status;
                entity.UpdatedDate = branch.UpdatedDate;
                entity.DisplayOrder = branch.DisplayOrder;
                dbContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Branch GetByID(int id)
        {
            return dbContext.Branches.Find(id);
        }

        public List<Branch> ListAll()
        {
            return dbContext.Branches.Where(x => x.Status == true).ToList();
        }

        public IEnumerable<Branch> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<Branch> model = dbContext.Branches;
            if(!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.BranchName.Contains(searchString));
            }
            return model.OrderByDescending(x=>x.CreatedDate).ToPagedList(page, pageSize);
        }

        public bool Delete(int id)
        {
            try
            {
                var entity = dbContext.Branches.Find(id);
                dbContext.Branches.Remove(entity);
                dbContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool? ChangeStatus(int id)
        {
            var user = dbContext.Branches.Find(id);
            
            user.Status = !user.Status;
            dbContext.SaveChanges();
            return user.Status;
        }

    }
}
