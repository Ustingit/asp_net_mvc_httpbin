using System.Data.Entity;

namespace WebApplication.Models
{
    public class HttpbinResponsesDbInitializer : DropCreateDatabaseAlways<DBContentContext>
    {
        protected override void Seed(DBContentContext db)
        {
            db.DBContents.Add(new DBContent { CommonResponseTime = 0, DelayedResponseTime = 0 });
            base.Seed(db);
        }
    }
}