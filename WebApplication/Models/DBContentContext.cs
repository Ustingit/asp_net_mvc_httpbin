using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class DBContentContext : DbContext
    {
        private static DBContentContext _instance;

        public static DBContentContext Instance => _instance ?? (_instance = new DBContentContext());

        public DbSet<DBContent> DBContents { get; set; }
    }
}
