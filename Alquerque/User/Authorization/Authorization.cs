using AlquerqueContract.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlquerqueDataAccess.Models.Authorization;
using AlquerqueDataAccess.Entitys.Person;

namespace Alquerque.User.Authorization
{
    public class Authorization
    {
        public Person LogInAccount(LoginModel user)
        {
            if (!VerifyUserLogInfo(user))
            {
                throw new Exception("Not correctly parametr");
            }
            AuthorizationDb authorizationDb = new AuthorizationDb();
            if (!authorizationDb.LoginExist(user.Login))
            {
                throw new Exception("Account doesn`t exist");
            }
            if (authorizationDb.GetPassword(user.Login).Equals(PasswordHash.CryptMessage(user.Password, user.Login)))
            {
                return authorizationDb.GetUser(user.Login);
            }
            throw new Exception("Not correctly password");           
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
            Person us = new Person()
            {
                Login = user.Login,
                Password = user.Password,
                RoleId = 1
            };
            await authorizationDb.SaveNewUser(us);
        }
        public async Task DeleteUser(int id)
        {
            Person user;
            if (id<1)
            {
                throw new Exception("Not correctly parametr");
            }
            AuthorizationDb authorizationDb = new AuthorizationDb();
            try
            {
                 user = authorizationDb.GetUser(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            try
            {
                await authorizationDb.DeleteUser(user);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
