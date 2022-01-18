using AlquerqueContract.Users;
using AlquerqueDataAccess.Entitys.Person;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlquerqueDataAccess.Models.Authorization
{
    public class AuthorizationDb
    {
        private AccountContext db;
        public AuthorizationDb()
        {
            db = new AccountContext();
        }
        public async Task SaveNewUser(Person user)
        {
            db.UserLoginModel.Add(user);
            await db.SaveChangesAsync();
        }
        public async Task DeleteUser(Person user)
        {
            db.UserLoginModel.Remove(user);
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
        public Person GetUser(int id)
        {
            var user = db.UserLoginModel.FirstOrDefault(u => u.Id.Equals(id));
            if (user == null)
            {
                throw new Exception("User doesn`t exist");
            }
            return user;
        }

        public IEnumerable<Person> GetUsers()
        {
            return db.UserLoginModel.ToList();
        }
        public Person GetUser(string login)
        {
            var user = db.UserLoginModel.First(u => u.Login.Equals(login));
            return user;
        }
    }
}
