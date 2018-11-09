using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Model.Dao
{
    public class UserDao
    {
        DidoStoreDbContext dbContext = null;

        public UserDao()
        {
            dbContext = new DidoStoreDbContext();
        }

        public IEnumerable<User> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<User> model = dbContext.Users;
            if(!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Username.Contains(searchString) || x.Name.Contains(searchString));
            }
            return model.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
        }

        public int Insert(User entity)
        {
            dbContext.Users.Add(entity);
            dbContext.SaveChanges();
            return entity.ID;
        }

        public User GetById(int id)
        {
            return dbContext.Users.Find(id);
        }

        public bool Update(User entity)
        {
            try
            {
                var user = dbContext.Users.Find(entity.ID);
                user.Name = entity.Name;
                if(!string.IsNullOrEmpty(entity.Password))
                {
                    user.Password = entity.Password;
                }
                user.Address = entity.Address;
                user.Email = entity.Email;
                user.BirthDay = entity.BirthDay;
                user.Phone = entity.Phone;
                user.Gender = entity.Gender;
                user.UpdatedDate = DateTime.Now;
                dbContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }

        public User GetByUserName(string userName)
        {
            return dbContext.Users.SingleOrDefault(x => x.Username == userName);
        }

        public bool Login(string userName, string password)
        {
            var res = dbContext.Users.Count(i => i.Username == userName && i.Password == password);
            return res > 0;
        }

        public bool Delete(int id)
        {
            try
            {
                var user = dbContext.Users.Find(id);
                dbContext.Users.Remove(user);
                dbContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool CheckUserName(string username)
        {
            return dbContext.Users.Count(x => x.Username == username) > 0;
        }
        public bool CheckEmail(string email)
        {
            return dbContext.Users.Count(x => x.Email == email) > 0;
        }

    }
}
