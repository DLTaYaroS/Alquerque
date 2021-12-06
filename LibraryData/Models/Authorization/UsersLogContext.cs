using Microsoft.EntityFrameworkCore;
using MyLibraryContract.Users;
using MyLibraryDataAccess;
namespace MyLibraryDataAccess.Models.Authorization
{
    public class UsersLogContext : DbContext
    {
        public DbSet<UserAuthorization> UsersLog { get; set; }
        public UsersLogContext(DbContextOptions<UsersLogContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
       
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(Config.ConnectionString);
        }
    }
}
