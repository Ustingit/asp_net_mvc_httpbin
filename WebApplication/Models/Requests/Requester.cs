using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace WebApplication.Models.Requests
{
    public class Requester : IRequester
    {
        Random rnd = new Random();
        HttpWebRequest httpbin200Request = (HttpWebRequest)WebRequest.Create("http://httpbin.org/status/200");

        public override void GetHttpbin200()
        {
            HttpWebResponse response = (HttpWebResponse)httpbin200Request.GetResponse();
            response.Close();
        }

        public override void GetHttpbinDelay()
        {
            var delay = rnd.Next(0, 6).ToString();
            HttpWebRequest httpbinDelayRequest = (HttpWebRequest)WebRequest.Create($"http://httpbin.org/delay/{delay}");
            HttpWebResponse response = (HttpWebResponse)httpbinDelayRequest.GetResponse();
            response.Close();
        }
    }

    public abstract class IRequester
    {
        public abstract void GetHttpbin200();

        public abstract void GetHttpbinDelay();
    }
}