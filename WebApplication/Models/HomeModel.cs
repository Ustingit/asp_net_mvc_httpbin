using System;
using System.Diagnostics;
using WebApplication.Models.Requests;

namespace WebApplication.Models
{
    public class HomeModel
    {
        private static HomeModel _instance;

        public static HomeModel Instance => _instance ?? (_instance = new HomeModel());

        DBContentContext db = new DBContentContext();
        Requester requester = new Requester();
        Stopwatch timer = new Stopwatch();

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