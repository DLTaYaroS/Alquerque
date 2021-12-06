using MyLibraryContract.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibraryDataAccess.Models.Authorization
{
    class AuthorizationDb
    {
        private UsersLogContext db;

        public void SaveNewUser(UserAuthorization user)
        {
            db.UsersLog.Add(user);
            db.SaveChanges();
        }
        public string GetPassword(string login)
        {
            var user= db.UsersLog.FirstOrDefault(u=>u.Login.Equals(login));
            return user.Password.ToString();
        }
        public bool LoginExist(string login)
        {
            var user = db.UsersLog.First(u => u.Login.Equals(login));
            if (user == null)
                return false;
            return true;
        }
        public UserAuthorization GetUser(int id)
        {
            var user = db.UsersLog.First(u => u.Id.Equals(id));
            return user;
        }
        public UserAuthorization GetUser(string login)
        {
            var user = db.UsersLog.First(u => u.Login.Equals(login));
            return user;
        }
    }
}
