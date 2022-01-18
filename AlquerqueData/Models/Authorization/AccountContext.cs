using Microsoft.EntityFrameworkCore;
using AlquerqueContract.Users;
using AlquerqueDataAccess;
using AlquerqueDataAccess.Entitys.Person;

namespace AlquerqueDataAccess.Models.Authorization
{
    public class AccountContext : DbContext
    { 
        public DbSet<Person> UserLoginModel { get; set; }
        public AccountContext()
        {
            Database.EnsureCreated();
        }
       
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(Config.ConnectionString);
        }
    }
}
