using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class DBContent
    {
        public int Id { get; set; }

        public double CommonResponseTime { get; set; }

        public double DelayedResponseTime { get; set; }
    }
}