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
            db.DBContents.Add(new DBContent { CommonResponseTime = 1, DelayedResponseTime = 3 });
            db.DBContents.Add(new DBContent { CommonResponseTime = 2, DelayedResponseTime = 3 });
            db.DBContents.Add(new DBContent { CommonResponseTime = 1, DelayedResponseTime = 3 });
            db.DBContents.Add(new DBContent { CommonResponseTime = 1, DelayedResponseTime = 3 });
            db.DBContents.Add(new DBContent { CommonResponseTime = 2, DelayedResponseTime = 4 });
            db.DBContents.Add(new DBContent { CommonResponseTime = 1, DelayedResponseTime = 3 });
            db.DBContents.Add(new DBContent { CommonResponseTime = 1, DelayedResponseTime = 3 });
            db.DBContents.Add(new DBContent { CommonResponseTime = 1, DelayedResponseTime = 6 });
            db.DBContents.Add(new DBContent { CommonResponseTime = 1, DelayedResponseTime = 3 });
            db.DBContents.Add(new DBContent { CommonResponseTime = 1, DelayedResponseTime = 3 });
            db.DBContents.Add(new DBContent { CommonResponseTime = 4, DelayedResponseTime = 7 });
            db.DBContents.Add(new DBContent { CommonResponseTime = 1, DelayedResponseTime = 3 });
            db.DBContents.Add(new DBContent { CommonResponseTime = 1, DelayedResponseTime = 3 });
            db.DBContents.Add(new DBContent { CommonResponseTime = 2, DelayedResponseTime = 3 });
            db.DBContents.Add(new DBContent { CommonResponseTime = 1, DelayedResponseTime = 3 });
            db.DBContents.Add(new DBContent { CommonResponseTime = 3, DelayedResponseTime = 5 });
            db.DBContents.Add(new DBContent { CommonResponseTime = 1, DelayedResponseTime = 3 });

            base.Seed(db);
        }
    }
}