﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class DBContentContext : DbContext
    {
        public DbSet<DBContent> DBContents { get; set; }
    }
}