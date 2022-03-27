using Microsoft.EntityFrameworkCore;
using WookieBooks.Models;

namespace WookieBooks.Repository
{
    public class WookieContext : DbContext
    {        
        public DbSet<Book> Books { get; set; }

        public WookieContext(DbContextOptions<WookieContext> contextOptions) : base(contextOptions)
        {
            
        }        
    }
}
