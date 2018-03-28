using System;
using System.Diagnostics;
using WebApplication.Models.Requests;

namespace WebApplication.Models.Diagnostic
{
    public class RequestsDiagnosticDecorator : IRequestsDiagnosticDecorator
    {
        Stopwatch timer = new Stopwatch();
        DBContentContext db = new DBContentContext();

        public override void GetHttpbin200()
        {
            timer.Reset();
            timer.Start();
            base.GetHttpbin200();
            timer.Stop();

            TimeSpan timeTaken = timer.Elapsed;
            db.DBContents.Add(new DBContent { CommonResponseTime = timeTaken.TotalSeconds });
            db.SaveChanges();
        }

        public override void GetHttpbinDelay()
        {
            timer.Reset();
            timer.Start();
            base.GetHttpbinDelay();
            timer.Stop();

            TimeSpan timeTaken = timer.Elapsed;
            db.DBContents.Add(new DBContent { DelayedResponseTime = timeTaken.TotalSeconds });
            db.SaveChanges();
        }
    }

    public abstract class IRequestsDiagnosticDecorator : IRequester
    {
        protected IRequester component;

        public void SetComponent(IRequester component)
        {
            this.component = component;
        }

        public override void GetHttpbin200()
        {
            if (component != null)
            {
                component.GetHttpbin200();
            }
        }

        public override void GetHttpbinDelay()
        {
            if (component != null)
            {
                component.GetHttpbinDelay();
            }
        }
    }
}