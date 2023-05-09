using First_Api.Models;
using Microsoft.EntityFrameworkCore;

namespace First_Api.Data
{
    public class MyDbContext: DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options)
           : base(options)
        {
        }

        public DbSet<UserModel> User { get; set; }

    }
}
