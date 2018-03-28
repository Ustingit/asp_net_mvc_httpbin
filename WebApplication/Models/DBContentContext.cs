using System.Data.Entity;

namespace WebApplication.Models
{
    public class DBContentContext : DbContext
    {
        public DbSet<DBContent> DBContents { get; set; }
    }
}
