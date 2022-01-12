using Microsoft.EntityFrameworkCore;
using AlquerqueContract.Users;
using AlquerqueDataAccess;
namespace AlquerqueDataAccess.Models.Authorization
{
    public class AccountContext : DbContext
    { 
        public DbSet<LoginModel> UserLoginModel { get; set; }
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
