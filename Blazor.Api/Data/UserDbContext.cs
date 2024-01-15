using Blazor.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Blazor.Api.Data
{
    public class UserDBContext  : DbContext
    {
        public UserDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }
        public DbSet<User> Users { get; set; }
    }
}
