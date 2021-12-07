using AlquerqueContract.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlquerqueDataAccess.Models.Authorization
{
    public class AuthorizationDb
    {
        private UsersLogContext db;
        public AuthorizationDb()
        {
            db = new UsersLogContext();
        }
        public async Task SaveNewUser(LoginModel user)
        {
            db.UserLoginModel.Add(user);
            await db.SaveChangesAsync();
        }
        public string GetPassword(string login)
        {
            var user= db.UserLoginModel.FirstOrDefault(u=>u.Login.Equals(login));
            return user.Password.ToString();
        }
        public bool LoginExist(string login)
        {
            var user = db.UserLoginModel.FirstOrDefault(u => u.Login.Equals(login));
            if (user == null)
                return false;
            return true;
        }
        public LoginModel GetUser(int id)
        {
            var user = db.UserLoginModel.First(u => u.Id.Equals(id));
            return user;
        }
        public LoginModel GetUser(string login)
        {
            var user = db.UserLoginModel.First(u => u.Login.Equals(login));
            return user;
        }
    }
}
