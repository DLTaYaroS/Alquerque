using Microsoft.EntityFrameworkCore;
using AlquerqueContract.Users;
using AlquerqueDataAccess;
namespace AlquerqueDataAccess.Models.Authorization
{
    public class UsersLogContext : DbContext
    {
        public DbSet<LoginModel> UsersLog { get; set; }
        public UsersLogContext()
        {
            Database.EnsureCreated();
        }
       
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(Config.ConnectionString);
        }
    }
}
