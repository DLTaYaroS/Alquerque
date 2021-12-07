using AlquerqueContract.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlquerqueDataAccess.Models.Authorization;
namespace Alquerque.User.Authorization
{
    public class Authorization
    {
        public bool LogInAccount(LoginModel user)
        {
            if (!VerifyUserLogInfo(user))
            {
                throw new Exception("Not correctly parametr");
            }
            AuthorizationDb authorizationDb = new AuthorizationDb();
            if (!authorizationDb.LoginExist(user.Login))
            {
                return false;
            }
            if (authorizationDb.GetPassword(user.Login).Equals(PasswordHash.CryptMessage(user.Password, user.Login)))
            {
                return true;
            }
            return false;
        }
        private bool VerifyUserLogInfo(LoginModel user)
        {
            return true;
        }
        public async Task NewUser(LoginModel user)
        {
            if (!VerifyUserLogInfo(user))
            {
                throw new Exception("Not correctly parametr");
            }
            AuthorizationDb authorizationDb = new AuthorizationDb();
            if (authorizationDb.LoginExist(user.Login))
            {
                throw new Exception("Login already exist");
            }
            user.Password = PasswordHash.CryptMessage(user.Password, user.Login);
            await authorizationDb.SaveNewUser(user);
        }
    }
}
