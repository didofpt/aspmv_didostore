using Models.Framework;
using System.Data.SqlClient;
using System.Linq;

namespace Models
{
    public class AccountModel
    {
        private DidoStoreDbContext _dbContext = null;

        public AccountModel()
        {
            _dbContext = new DidoStoreDbContext();
        }

        public bool Login(string username, string password)
        {

            object[] sqlParams =
            {
                new SqlParameter("Username", username),
                new SqlParameter("Password", password)
            };

            var res = _dbContext.Database.SqlQuery<bool>("usp_account_login @Username, @Password", sqlParams)
                .SingleOrDefault();
            return res;
        }

    }
}
