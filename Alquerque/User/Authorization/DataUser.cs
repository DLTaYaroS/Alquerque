using AlquerqueContract.Users;
using AlquerqueDataAccess.Models.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alquerque.User.Authorization
{
    public class DataUser
    {
        public  IEnumerable<LoginModel> GetAll(){
            AuthorizationDb db = new AuthorizationDb();
            return  db.GetUsers();
        }
        public LoginModel Get(int id)
        {
            return GetAll().First(u => u.Id == id);
        }
    }
}
