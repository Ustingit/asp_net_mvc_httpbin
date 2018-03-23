using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class HttpbinResponsesDbInitializer : DropCreateDatabaseAlways<DBContentContext>
    {
        protected override void Seed(DBContentContext db)
        {
            base.Seed(db);
        }
    }
}