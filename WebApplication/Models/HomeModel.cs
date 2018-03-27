using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using WebApplication.Models.Diagnostic;
using WebApplication.Models.Requests;

namespace WebApplication.Models
{
    public class HomeModel
    {
        private static HomeModel _instance;

        public static HomeModel Instance => _instance ?? (_instance = new HomeModel());

        DBContentContext db = DBContentContext.Instance;
        Requester requester = new Requester();
        Stopwatch timer = new Stopwatch();
        RequestsDiagnosticDecorator requestsDiagnosticDecorator = new RequestsDiagnosticDecorator();
       
        public HomeModel()
        {
            requestsDiagnosticDecorator.SetComponent(requester);
        } 

        public void StartAppWorking(int duration)
        {
            db.DBContents.RemoveRange(db.DBContents);
            db.SaveChanges();

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            while (stopWatch.Elapsed < TimeSpan.FromSeconds(duration))
            {
                timer.Reset();
                timer.Start();
                requester.GetHttpbin200();
                timer.Stop();
                var timeTaken200 = timer.Elapsed.TotalSeconds;

                timer.Reset();
                timer.Start();
                requester.GetHttpbinDelay();
                timer.Stop();
                var timeTakenDelay = timer.Elapsed.TotalSeconds;

                db.DBContents.Add(new DBContent { CommonResponseTime = timeTaken200, DelayedResponseTime = timeTakenDelay });
                db.SaveChanges();
            }
            stopWatch.Reset();
        }
    }
}