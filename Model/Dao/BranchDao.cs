using Model.EF;
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
        public List<Branch> ListAll()
        {
            return dbContext.Branches.Where(x => x.Status == true).ToList();
        }

        public IEnumerable<Branch> ListAllPaging(int page, int pageSize)
        {
            return dbContext.Branches.OrderByDescending(x=>x.CreatedDate).ToPagedList(page, pageSize);
        }

    }
}
