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
                requestsDiagnosticDecorator.GetHttpbin200();
                
                requestsDiagnosticDecorator.GetHttpbinDelay();
            }
            stopWatch.Reset();
        }
    }
}