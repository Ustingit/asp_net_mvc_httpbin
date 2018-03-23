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
        int e = 0;
       
        public HomeModel()
        {
            requestsDiagnosticDecorator.SetComponent(requester);
        } 

        public int StartAppWorking(int duration)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            while (stopWatch.Elapsed < TimeSpan.FromSeconds(duration))
            {
                requestsDiagnosticDecorator.GetHttpbin200();
                
                requestsDiagnosticDecorator.GetHttpbinDelay();
            }
            stopWatch.Reset();
            return e;
        }
    }
}